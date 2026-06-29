using ABMS_2026.Common.Helpers;
using ABMS_2026.Common.Session;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class BillingPaymentsUserControl : UserControl
    {
        private int? _billingId;
        private int _biteCaseId;
        private bool _isLoading;
        private readonly MySqlConnectionHelper _connectionHelper;

        public event Action<int>? BillingSaved;

        public BillingPaymentsUserControl()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();

            WireUpEvents();
            LoadComboBoxOptions();
        }

        public BillingPaymentsUserControl(int biteCaseId, int? billingId = null) : this()
        {
            _biteCaseId = biteCaseId;
            _billingId = billingId;
        }

        private void WireUpEvents()
        {
            Load += BillingPaymentsUserControl_Load;
            buttonAddItem.Click += ButtonAddItem_Click;
            buttonRemoveItem.Click += ButtonRemoveItem_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonPrint.Click += ButtonPrint_Click;
            textBoxDiscount.TextChanged += TextBoxDiscount_TextChanged;
            textBoxAmountPaid.TextChanged += TextBoxAmountPaid_TextChanged;
        }

        private void LoadComboBoxOptions()
        {
            comboBoxPaymentMethod.Items.Clear();
            comboBoxPaymentMethod.Items.AddRange(new object[] { "", "Cash", "Credit Card", "Debit Card", "Bank Transfer", "Insurance" });

            comboBoxPaymentStatus.Items.Clear();
            comboBoxPaymentStatus.Items.AddRange(new object[] { "Unpaid", "Partial", "Paid" });
        }

        private void BillingPaymentsUserControl_Load(object? sender, EventArgs e)
        {
            try
            {
                _isLoading = true;

                dateTimePickerBillingDate.Value = DateTime.Now;

                if (_billingId.HasValue)
                {
                    LoadBillingData(_billingId.Value);
                }
                else
                {
                    GenerateBillingNo();
                    LoadItemsFromTreatmentSchedule();
                }

                CalculateTotals();
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void GenerateBillingNo()
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT COALESCE(MAX(CAST(SUBSTRING(billing_no, 5) AS UNSIGNED)), 0) + 1
FROM billing
WHERE billing_no LIKE 'BILL-%';";

                using var command = new MySqlCommand(query, connection);
                object result = command.ExecuteScalar();
                int nextNumber = result != null ? Convert.ToInt32(result) : 1;

                textBoxBillingNo.Text = $"BILL-{nextNumber:D6}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating billing number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemsFromTreatmentSchedule()
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT ts.treatment_schedule_id, ts.schedule_day, ts.biologic_type, ts.quantity_used,
       ii.item_id, ii.generic_name, ii.brand_name, ii.unit_price
FROM treatment_schedule ts
LEFT JOIN inventory_items ii ON ts.item_id = ii.item_id
WHERE ts.bite_case_id = @biteCaseId
ORDER BY ts.scheduled_date;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@biteCaseId", _biteCaseId);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string biologicType = reader["biologic_type"].ToString() ?? "Unknown";
                    string scheduleDay = reader["schedule_day"].ToString() ?? "Unknown";
                    decimal quantityUsed = reader["quantity_used"] != DBNull.Value ? Convert.ToDecimal(reader["quantity_used"]) : 1m;
                    
                    string itemName = reader["generic_name"].ToString() ?? biologicType;
                    string brandName = reader["brand_name"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(brandName))
                    {
                        itemName = $"{itemName} ({brandName})";
                    }

                    decimal unitPrice = reader["unit_price"] != DBNull.Value ? Convert.ToDecimal(reader["unit_price"]) : 500m;

                    string description = $"{itemName} - {scheduleDay}";
                    int quantity = Convert.ToInt32(quantityUsed);
                    decimal lineTotal = quantity * unitPrice;

                    dataGridViewBillingItems.Rows.Add(description, quantity, unitPrice.ToString("F2"), lineTotal.ToString("F2"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items from treatment schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillingData(int billingId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string billingQuery = @"
SELECT billing_id, billing_no, billing_date, subtotal, discount, total,
       amount_paid, balance, payment_method, payment_status, remarks
FROM billing
WHERE billing_id = @billingId;";

                using var billingCommand = new MySqlCommand(billingQuery, connection);
                billingCommand.Parameters.AddWithValue("@billingId", billingId);

                using var billingReader = billingCommand.ExecuteReader();
                if (billingReader.Read())
                {
                    textBoxBillingNo.Text = billingReader["billing_no"].ToString() ?? string.Empty;
                    dateTimePickerBillingDate.Value = Convert.ToDateTime(billingReader["billing_date"]);
                    textBoxSubtotal.Text = Convert.ToDecimal(billingReader["subtotal"]).ToString("F2");
                    textBoxDiscount.Text = Convert.ToDecimal(billingReader["discount"]).ToString("F2");
                    textBoxTotal.Text = Convert.ToDecimal(billingReader["total"]).ToString("F2");
                    textBoxAmountPaid.Text = Convert.ToDecimal(billingReader["amount_paid"]).ToString("F2");
                    textBoxBalance.Text = Convert.ToDecimal(billingReader["balance"]).ToString("F2");
                    comboBoxPaymentMethod.Text = billingReader["payment_method"].ToString() ?? string.Empty;
                    comboBoxPaymentStatus.Text = billingReader["payment_status"].ToString() ?? string.Empty;
                    richTextBoxRemarks.Text = billingReader["remarks"].ToString() ?? string.Empty;
                }

                billingReader.Close();

                string itemsQuery = @"
SELECT description, quantity, unit_price, line_total
FROM billing_items
WHERE billing_id = @billingId
ORDER BY billing_item_id;";

                using var itemsCommand = new MySqlCommand(itemsQuery, connection);
                itemsCommand.Parameters.AddWithValue("@billingId", billingId);

                using var itemsReader = itemsCommand.ExecuteReader();
                dataGridViewBillingItems.Rows.Clear();

                while (itemsReader.Read())
                {
                    dataGridViewBillingItems.Rows.Add(
                        itemsReader["description"].ToString(),
                        itemsReader["quantity"].ToString(),
                        Convert.ToDecimal(itemsReader["unit_price"]).ToString("F2"),
                        Convert.ToDecimal(itemsReader["line_total"]).ToString("F2")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAddItem_Click(object? sender, EventArgs e)
        {
            using var form = new ItemPickerForm();
            if (form.ShowDialog() == DialogResult.OK && form.SelectedItemId.HasValue)
            {
                decimal unitPrice = GetItemPrice(form.SelectedItemId.Value);
                string description = form.SelectedItemName;
                int quantity = 1;
                decimal lineTotal = quantity * unitPrice;

                dataGridViewBillingItems.Rows.Add(description, quantity, unitPrice.ToString("F2"), lineTotal.ToString("F2"));
                CalculateTotals();
            }
        }

        private decimal GetItemPrice(long itemId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT COALESCE(unit_price, 0) AS unit_price 
FROM inventory_items 
WHERE item_id = @itemId;";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemId", itemId);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                return 0m;
            }
            catch
            {
                return 0m;
            }
        }

        private void ButtonRemoveItem_Click(object? sender, EventArgs e)
        {
            if (dataGridViewBillingItems.SelectedRows.Count > 0)
            {
                dataGridViewBillingItems.Rows.RemoveAt(dataGridViewBillingItems.SelectedRows[0].Index);
                CalculateTotals();
            }
        }

        private void CalculateTotals()
        {
            if (_isLoading) return;

            decimal subtotal = 0m;
            foreach (DataGridViewRow row in dataGridViewBillingItems.Rows)
            {
                if (row.Cells[itemLineTotalColumn.Index].Value != null)
                {
                    string? value = row.Cells[itemLineTotalColumn.Index].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(value) && decimal.TryParse(value, out decimal lineTotal))
                    {
                        subtotal += lineTotal;
                    }
                }
            }

            decimal discount = 0m;
            if (decimal.TryParse(textBoxDiscount.Text, out decimal discountValue))
            {
                discount = discountValue;
            }

            decimal total = subtotal - discount;
            decimal amountPaid = 0m;
            if (decimal.TryParse(textBoxAmountPaid.Text, out decimal amountPaidValue))
            {
                amountPaid = amountPaidValue;
            }

            decimal balance = total - amountPaid;

            textBoxSubtotal.Text = subtotal.ToString("F2");
            textBoxTotal.Text = total.ToString("F2");
            textBoxBalance.Text = balance.ToString("F2");

            if (balance <= 0)
            {
                comboBoxPaymentStatus.Text = "Paid";
            }
            else if (amountPaid > 0)
            {
                comboBoxPaymentStatus.Text = "Partial";
            }
            else
            {
                comboBoxPaymentStatus.Text = "Unpaid";
            }
        }

        private void TextBoxDiscount_TextChanged(object? sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void TextBoxAmountPaid_TextChanged(object? sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBillingItems.Rows.Count == 0)
                {
                    MessageBox.Show("Please add at least one billing item.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var connection = _connectionHelper.GetConnection();
                connection.Open();
                using var transaction = connection.BeginTransaction();

                try
                {
                    decimal subtotal = decimal.Parse(textBoxSubtotal.Text);
                    decimal discount = decimal.Parse(textBoxDiscount.Text);
                    decimal total = decimal.Parse(textBoxTotal.Text);
                    decimal amountPaid = decimal.Parse(textBoxAmountPaid.Text);
                    decimal balance = decimal.Parse(textBoxBalance.Text);

                    if (_billingId.HasValue)
                    {
                        string updateBillingQuery = @"
UPDATE billing
SET billing_date = @billingDate,
    subtotal = @subtotal,
    discount = @discount,
    total = @total,
    amount_paid = @amountPaid,
    balance = @balance,
    payment_method = @paymentMethod,
    payment_status = @paymentStatus,
    remarks = @remarks,
    updated_at = @updatedAt,
    updated_by = @updatedBy
WHERE billing_id = @billingId;";

                        using var updateCommand = new MySqlCommand(updateBillingQuery, connection, transaction);
                        updateCommand.Parameters.AddWithValue("@billingDate", dateTimePickerBillingDate.Value);
                        updateCommand.Parameters.AddWithValue("@subtotal", subtotal);
                        updateCommand.Parameters.AddWithValue("@discount", discount);
                        updateCommand.Parameters.AddWithValue("@total", total);
                        updateCommand.Parameters.AddWithValue("@amountPaid", amountPaid);
                        updateCommand.Parameters.AddWithValue("@balance", balance);
                        updateCommand.Parameters.AddWithValue("@paymentMethod", comboBoxPaymentMethod.Text);
                        updateCommand.Parameters.AddWithValue("@paymentStatus", comboBoxPaymentStatus.Text);
                        updateCommand.Parameters.AddWithValue("@remarks", richTextBoxRemarks.Text);
                        updateCommand.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                        updateCommand.Parameters.AddWithValue("@updatedBy", SessionManager.Username ?? "System");
                        updateCommand.Parameters.AddWithValue("@billingId", _billingId.Value);

                        updateCommand.ExecuteNonQuery();

                        string deleteItemsQuery = "DELETE FROM billing_items WHERE billing_id = @billingId;";
                        using var deleteCommand = new MySqlCommand(deleteItemsQuery, connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@billingId", _billingId.Value);
                        deleteCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertBillingQuery = @"
INSERT INTO billing (bite_case_id, billing_no, billing_date, subtotal, discount, total,
                     amount_paid, balance, payment_method, payment_status, remarks,
                     created_at, created_by)
VALUES (@biteCaseId, @billingNo, @billingDate, @subtotal, @discount, @total,
        @amountPaid, @balance, @paymentMethod, @paymentStatus, @remarks,
        @createdAt, @createdBy);
SELECT LAST_INSERT_ID();";

                        using var insertCommand = new MySqlCommand(insertBillingQuery, connection, transaction);
                        insertCommand.Parameters.AddWithValue("@biteCaseId", _biteCaseId);
                        insertCommand.Parameters.AddWithValue("@billingNo", textBoxBillingNo.Text);
                        insertCommand.Parameters.AddWithValue("@billingDate", dateTimePickerBillingDate.Value);
                        insertCommand.Parameters.AddWithValue("@subtotal", subtotal);
                        insertCommand.Parameters.AddWithValue("@discount", discount);
                        insertCommand.Parameters.AddWithValue("@total", total);
                        insertCommand.Parameters.AddWithValue("@amountPaid", amountPaid);
                        insertCommand.Parameters.AddWithValue("@balance", balance);
                        insertCommand.Parameters.AddWithValue("@paymentMethod", comboBoxPaymentMethod.Text);
                        insertCommand.Parameters.AddWithValue("@paymentStatus", comboBoxPaymentStatus.Text);
                        insertCommand.Parameters.AddWithValue("@remarks", richTextBoxRemarks.Text);
                        insertCommand.Parameters.AddWithValue("@createdAt", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@createdBy", SessionManager.Username ?? "System");

                        _billingId = Convert.ToInt32(insertCommand.ExecuteScalar());
                    }

                    string itemQuery = @"
INSERT INTO billing_items (billing_id, item_type, description, quantity, unit_price, line_total)
VALUES (@billingId, @itemType, @description, @quantity, @unitPrice, @lineTotal);";

                    foreach (DataGridViewRow row in dataGridViewBillingItems.Rows)
                    {
                        string description = row.Cells[itemDescriptionColumn.Index].Value?.ToString() ?? string.Empty;
                        int quantity = Convert.ToInt32(row.Cells[itemQuantityColumn.Index].Value);
                        decimal unitPrice = decimal.Parse(row.Cells[itemUnitPriceColumn.Index].Value?.ToString() ?? "0");
                        decimal lineTotal = decimal.Parse(row.Cells[itemLineTotalColumn.Index].Value?.ToString() ?? "0");

                        using var itemCommand = new MySqlCommand(itemQuery, connection, transaction);
                        itemCommand.Parameters.AddWithValue("@billingId", _billingId.Value);
                        itemCommand.Parameters.AddWithValue("@itemType", "Service");
                        itemCommand.Parameters.AddWithValue("@description", description);
                        itemCommand.Parameters.AddWithValue("@quantity", quantity);
                        itemCommand.Parameters.AddWithValue("@unitPrice", unitPrice);
                        itemCommand.Parameters.AddWithValue("@lineTotal", lineTotal);

                        itemCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Billing saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BillingSaved?.Invoke(_billingId.Value);
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving billing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonPrint_Click(object? sender, EventArgs e)
        {
            if (!_billingId.HasValue)
            {
                MessageBox.Show("Please save the billing first before printing.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Print functionality will be implemented with ReceiptPrintHelper.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
