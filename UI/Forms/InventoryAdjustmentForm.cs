using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Shared.Components;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class InventoryAdjustmentForm : Form, IModuleUpsertForm
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private ModuleRecordContext? _context;
        private long? _transactionId;
        private long? _selectedItemId;
        private string _selectedItemName = string.Empty;

        public InventoryAdjustmentForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        public InventoryAdjustmentForm(long transactionId) : this()
        {
            _transactionId = transactionId;
        }

        private void InventoryAdjustmentForm_Load(object sender, EventArgs e)
        {
            InitializeTransactionTypes();
            WireUpEvents();

            // Set default values
            dateTimePickerTransactionDate.Value = DateTime.Now;
        }

        public void LoadModuleRecord(ModuleRecordContext context)
        {
            _context = context;
            _transactionId = context.PrimaryKeyValue as long?;

            if (_transactionId.HasValue)
            {
                LoadTransactionData(_transactionId.Value);
                this.Text = "Edit Inventory Transaction";
            }
            else
            {
                this.Text = "New Inventory Transaction";
                // Set default values
                dateTimePickerTransactionDate.Value = DateTime.Now;
            }
        }

        private void InitializeTransactionTypes()
        {
            comboBoxTransactionType.Items.Clear();
            comboBoxTransactionType.Items.AddRange(new object[] { "IN", "ADJUSTMENT" });
            comboBoxTransactionType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void WireUpEvents()
        {
            selectItemButton.Click += SelectItemButton_Click;
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, args) => Close();
            comboBoxTransactionType.SelectedIndexChanged += ComboBoxTransactionType_SelectedIndexChanged;
        }

        private void SelectItemButton_Click(object? sender, EventArgs e)
        {
            using (var itemPicker = new ItemPickerForm())
            {
                itemPicker.StartPosition = FormStartPosition.CenterParent;
                
                if (itemPicker.ShowDialog(this) == DialogResult.OK)
                {
                    _selectedItemId = itemPicker.SelectedItemId;
                    _selectedItemName = itemPicker.SelectedItemName;
                    
                    textBoxSelectedItem.Text = _selectedItemName;
                    LoadCurrentStock();
                }
            }
        }

        private void LoadCurrentStock()
        {
            if (!_selectedItemId.HasValue) return;

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = "SELECT quantity_on_hand FROM inventory_items WHERE item_id = @item_id";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@item_id", _selectedItemId.Value);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    textBoxCurrentStock.Text = result.ToString();
                }
                else
                {
                    textBoxCurrentStock.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading current stock: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxTransactionType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateFormForTransactionType();
        }

        private void UpdateFormForTransactionType()
        {
            string transactionType = comboBoxTransactionType.SelectedItem?.ToString() ?? "IN";

            switch (transactionType)
            {
                case "IN":
                    this.Text = "Stock In";
                    numericUpDownQuantity.ForeColor = System.Drawing.Color.Green;
                    break;
                case "ADJUSTMENT":
                    this.Text = "Inventory Adjustment";
                    numericUpDownQuantity.ForeColor = System.Drawing.Color.Blue;
                    break;
            }
        }

        private void LoadTransactionData(long transactionId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT
    transaction_id,
    item_id,
    transaction_type,
    quantity,
    remarks,
    reference_no,
    transaction_date
FROM inventory_transactions
WHERE transaction_id = @transaction_id;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@transaction_id", transactionId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    _selectedItemId = reader["item_id"] as long?;
                    comboBoxTransactionType.SelectedItem = reader["transaction_type"]?.ToString() ?? "ADJUSTMENT";

                    if (reader["quantity"] != null && reader["quantity"] != DBNull.Value)
                    {
                        numericUpDownQuantity.Value = Convert.ToDecimal(reader["quantity"]);
                    }

                    textBoxRemarks.Text = reader["remarks"]?.ToString() ?? string.Empty;
                    textBoxReferenceNo.Text = reader["reference_no"]?.ToString() ?? string.Empty;

                    if (reader["transaction_date"] != null && reader["transaction_date"] != DBNull.Value)
                    {
                        dateTimePickerTransactionDate.Value = Convert.ToDateTime(reader["transaction_date"]);
                    }

                    // Load item name
                    if (_selectedItemId.HasValue)
                    {
                        LoadItemName(_selectedItemId.Value);
                        LoadCurrentStock();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transaction data: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemName(long itemId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT generic_name, brand_name 
FROM inventory_items 
WHERE item_id = @item_id;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@item_id", itemId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var genericName = reader["generic_name"]?.ToString() ?? "";
                    var brandName = reader["brand_name"]?.ToString() ?? "";
                    _selectedItemName = string.IsNullOrWhiteSpace(brandName) 
                        ? genericName 
                        : $"{genericName} - {brandName}";
                    textBoxSelectedItem.Text = _selectedItemName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item name: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (!_selectedItemId.HasValue)
            {
                MessageBox.Show("Please select an inventory item.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                selectItemButton.Focus();
                return false;
            }

            if (numericUpDownQuantity.Value == 0)
            {
                MessageBox.Show("Quantity cannot be zero.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownQuantity.Focus();
                return false;
            }

            return true;
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                using var transaction = connection.BeginTransaction();

                try
                {
                    long itemId = _selectedItemId.Value;
                    decimal quantity = numericUpDownQuantity.Value;
                    string transactionType = comboBoxTransactionType.SelectedItem?.ToString() ?? "IN";

                    // Calculate the actual quantity adjustment based on transaction type
                    decimal quantityAdjustment = transactionType switch
                    {
                        "IN" => quantity,
                        "ADJUSTMENT" => quantity, // Can be positive or negative
                        _ => quantity
                    };

                    string sql;

                    if (_transactionId.HasValue)
                    {
                        // For existing transactions, we need to reverse the old quantity first
                        // then apply the new quantity adjustment
                        string oldTransactionType = GetOldTransactionType(connection, transaction, _transactionId.Value);
                        decimal oldQuantity = GetOldQuantity(connection, transaction, _transactionId.Value);

                        // Calculate old adjustment
                        decimal oldAdjustment = oldTransactionType switch
                        {
                            "IN" => oldQuantity,
                            "ADJUSTMENT" => oldQuantity,
                            _ => oldQuantity
                        };

                        // Reverse old quantity
                        UpdateInventoryQuantity(connection, transaction, itemId, -oldAdjustment);

                        // Update transaction
                        sql = @"
UPDATE inventory_transactions SET
    item_id = @item_id,
    transaction_type = @transaction_type,
    quantity = @quantity,
    remarks = @remarks,
    reference_no = @reference_no,
    transaction_date = @transaction_date
WHERE transaction_id = @transaction_id;";

                        using var cmd = new MySqlCommand(sql, connection, transaction);
                        cmd.Parameters.AddWithValue("@item_id", itemId);
                        cmd.Parameters.AddWithValue("@transaction_type", transactionType);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@remarks", string.IsNullOrWhiteSpace(textBoxRemarks.Text.Trim()) ? (object)DBNull.Value : textBoxRemarks.Text.Trim());
                        cmd.Parameters.AddWithValue("@reference_no", string.IsNullOrWhiteSpace(textBoxReferenceNo.Text.Trim()) ? (object)DBNull.Value : textBoxReferenceNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@transaction_date", dateTimePickerTransactionDate.Value);
                        cmd.Parameters.AddWithValue("@transaction_id", _transactionId.Value);
                        cmd.ExecuteNonQuery();

                        // Apply new quantity
                        UpdateInventoryQuantity(connection, transaction, itemId, quantityAdjustment);
                    }
                    else
                    {
                        // Insert new transaction
                        sql = @"
INSERT INTO inventory_transactions (
    item_id, transaction_type, quantity, remarks, reference_no, transaction_date
) VALUES (
    @item_id, @transaction_type, @quantity, @remarks, @reference_no, @transaction_date
);

SELECT LAST_INSERT_ID();";

                        using var cmd = new MySqlCommand(sql, connection, transaction);
                        cmd.Parameters.AddWithValue("@item_id", itemId);
                        cmd.Parameters.AddWithValue("@transaction_type", transactionType);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@remarks", string.IsNullOrWhiteSpace(textBoxRemarks.Text.Trim()) ? (object)DBNull.Value : textBoxRemarks.Text.Trim());
                        cmd.Parameters.AddWithValue("@reference_no", string.IsNullOrWhiteSpace(textBoxReferenceNo.Text.Trim()) ? (object)DBNull.Value : textBoxReferenceNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@transaction_date", dateTimePickerTransactionDate.Value);

                        _transactionId = Convert.ToInt64(cmd.ExecuteScalar());

                        // Update inventory quantity
                        UpdateInventoryQuantity(connection, transaction, itemId, quantityAdjustment);
                    }

                    transaction.Commit();

                    MessageBox.Show("Inventory transaction saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving inventory transaction: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetOldTransactionType(MySqlConnection connection, MySqlTransaction transaction, long transactionId)
        {
            string sql = "SELECT transaction_type FROM inventory_transactions WHERE transaction_id = @transaction_id";
            using var cmd = new MySqlCommand(sql, connection, transaction);
            cmd.Parameters.AddWithValue("@transaction_id", transactionId);
            object result = cmd.ExecuteScalar();
            return result?.ToString() ?? "ADJUSTMENT";
        }

        private decimal GetOldQuantity(MySqlConnection connection, MySqlTransaction transaction, long transactionId)
        {
            string sql = "SELECT quantity FROM inventory_transactions WHERE transaction_id = @transaction_id";
            using var cmd = new MySqlCommand(sql, connection, transaction);
            cmd.Parameters.AddWithValue("@transaction_id", transactionId);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private void UpdateInventoryQuantity(MySqlConnection connection, MySqlTransaction transaction, long itemId, decimal adjustment)
        {
            string sql = @"
UPDATE inventory_items 
SET quantity_on_hand = quantity_on_hand + @adjustment
WHERE item_id = @item_id;";

            using var cmd = new MySqlCommand(sql, connection, transaction);
            cmd.Parameters.AddWithValue("@adjustment", adjustment);
            cmd.Parameters.AddWithValue("@item_id", itemId);
            cmd.ExecuteNonQuery();
        }
    }
}
