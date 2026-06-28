using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class TreatmentForm : Form
    {
        private readonly int _biteCaseId;
        private readonly int? _treatmentScheduleId;
        private readonly MySqlConnectionHelper _connectionHelper;
        private long? _selectedItemId;
        private string _selectedItemName = string.Empty;

        public TreatmentForm(int biteCaseId, int? treatmentScheduleId = null)
        {
            _biteCaseId = biteCaseId;
            _treatmentScheduleId = treatmentScheduleId;
            _connectionHelper = new MySqlConnectionHelper();

            InitializeComponent();
        }

        private void TreatmentForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxOptions();
            formTitleLabel.Text = _treatmentScheduleId.HasValue ? "EDIT TREATMENT" : "ADD TREATMENT";

            if (_treatmentScheduleId.HasValue)
            {
                LoadTreatmentScheduleData(_treatmentScheduleId.Value);
            }
            else
            {
                // Set default values for new records
                scheduledDateDateTimePicker.Value = DateTime.Today;
                administeredDateDateTimePicker.Checked = false;
                statusComboBox.SelectedIndex = 0; // Default to Scheduled
                quantityUsedNumericUpDown.Value = 1;
            }
        }

        private void LoadComboBoxOptions()
        {
            // Load schedule day options
            scheduleDayComboBox.Items.AddRange(new object[]
            {
                "Day 0",
                "Day 3",
                "Day 7",
                "Day 14",
                "Day 28",
                "Booster"
            });

            // Load biologic type options
            biologicTypeComboBox.Items.AddRange(new object[]
            {
                "Rabies Vaccine",
                "ERIG",
                "HRIG",
                "Tetanus Toxoid",
                "Td",
                "ATS"
            });

            // Load route options
            routeComboBox.Items.AddRange(new object[]
            {
                "Intradermal",
                "Intramuscular"
            });

            // Load status options
            statusComboBox.Items.AddRange(new object[]
            {
                "Scheduled",
                "Completed",
                "Missed",
                "Cancelled"
            });
            CollectionHelper.LoadTextBoxSuggestions(
            administeredByTextBox,
            "treatment_schedule",
            "administered_by");
        }

        private void LoadTreatmentScheduleData(int treatmentScheduleId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT
    treatment_schedule_id,
    bite_case_id,
    schedule_day,
    scheduled_date,
    administered_date,
    biologic_type,
    route,
    item_id,
    quantity_used,
    status,
    administered_by,
    remarks
FROM treatment_schedule
WHERE treatment_schedule_id = @treatment_schedule_id
LIMIT 1;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@treatment_schedule_id", treatmentScheduleId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Load fields
                    scheduleDayComboBox.Text = reader["schedule_day"]?.ToString() ?? string.Empty;
                    scheduledDateDateTimePicker.Value = reader["scheduled_date"] != DBNull.Value
                        ? Convert.ToDateTime(reader["scheduled_date"])
                        : DateTime.Today;

                    if (reader["administered_date"] != DBNull.Value)
                    {
                        administeredDateDateTimePicker.Checked = true;
                        administeredDateDateTimePicker.Value = Convert.ToDateTime(reader["administered_date"]);
                    }
                    else
                    {
                        administeredDateDateTimePicker.Checked = false;
                    }

                    biologicTypeComboBox.Text = reader["biologic_type"]?.ToString() ?? string.Empty;
                    routeComboBox.Text = reader["route"]?.ToString() ?? string.Empty;
                    _selectedItemId = reader["item_id"] != DBNull.Value
                        ? Convert.ToInt64(reader["item_id"])
                        : null;

                    if (_selectedItemId.HasValue)
                    {
                        // Load item name from inventory
                        LoadItemName(_selectedItemId.Value);
                    }

                    quantityUsedNumericUpDown.Value = reader["quantity_used"] != DBNull.Value
                        ? Convert.ToDecimal(reader["quantity_used"])
                        : 1;

                    statusComboBox.Text = reader["status"]?.ToString() ?? "Scheduled";
                    administeredByTextBox.Text = reader["administered_by"]?.ToString() ?? string.Empty;
                    remarksTextBox.Text = reader["remarks"]?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading treatment schedule: {ex.Message}", "Load Error",
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
SELECT 
    generic_name,
    brand_name
FROM inventory_items
WHERE item_id = @item_id
LIMIT 1;";

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
                    selectedItemLabel.Text = _selectedItemName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemPickerButton_Click(object sender, EventArgs e)
        {
            using var itemPicker = new ItemPickerForm();
            if (itemPicker.ShowDialog(this) == DialogResult.OK)
            {
                _selectedItemId = itemPicker.SelectedItemId;
                _selectedItemName = itemPicker.SelectedItemName;
                selectedItemLabel.Text = _selectedItemName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
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
                    // Check if this is a new administration (administered date supplied)
                    bool isNewAdministration = false;
                    if (_selectedItemId.HasValue && administeredDateDateTimePicker.Checked)
                    {
                        if (!_treatmentScheduleId.HasValue)
                        {
                            // New record with administered date
                            isNewAdministration = true;
                        }
                        else
                        {
                            // Check if it was previously administered
                            isNewAdministration = !WasPreviouslyAdministered(connection, transaction, _treatmentScheduleId.Value);
                        }
                    }

                    int treatmentScheduleId = _treatmentScheduleId.HasValue
                        ? UpdateTreatmentSchedule(connection, transaction, _treatmentScheduleId.Value)
                        : InsertTreatmentSchedule(connection, transaction);

                    // Create inventory transaction if item is administered (administered date supplied)
                    if (isNewAdministration)
                    {
                        CreateInventoryTransaction(connection, transaction, treatmentScheduleId);
                    }

                    transaction.Commit();

                    MessageBox.Show("Treatment schedule saved successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving treatment schedule: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int InsertTreatmentSchedule(MySqlConnection connection, MySqlTransaction transaction)
        {
            string sql = @"
INSERT INTO treatment_schedule
(
    bite_case_id,
    schedule_day,
    scheduled_date,
    administered_date,
    biologic_type,
    route,
    item_id,
    quantity_used,
    status,
    administered_by,
    remarks
)
VALUES
(
    @bite_case_id,
    @schedule_day,
    @scheduled_date,
    @administered_date,
    @biologic_type,
    @route,
    @item_id,
    @quantity_used,
    @status,
    @administered_by,
    @remarks
);
SELECT LAST_INSERT_ID();";

            using var command = new MySqlCommand(sql, connection, transaction);
            AddParameters(command);

            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        private int UpdateTreatmentSchedule(MySqlConnection connection, MySqlTransaction transaction, int treatmentScheduleId)
        {
            string sql = @"
UPDATE treatment_schedule
SET
    schedule_day = @schedule_day,
    scheduled_date = @scheduled_date,
    administered_date = @administered_date,
    biologic_type = @biologic_type,
    route = @route,
    item_id = @item_id,
    quantity_used = @quantity_used,
    status = @status,
    administered_by = @administered_by,
    remarks = @remarks
WHERE treatment_schedule_id = @treatment_schedule_id;";

            using var command = new MySqlCommand(sql, connection, transaction);
            AddParameters(command);
            command.Parameters.AddWithValue("@treatment_schedule_id", treatmentScheduleId);

            command.ExecuteNonQuery();
            return treatmentScheduleId;
        }

        private void AddParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);
            command.Parameters.AddWithValue("@schedule_day", scheduleDayComboBox.Text);
            command.Parameters.AddWithValue("@scheduled_date", scheduledDateDateTimePicker.Value.ToString("yyyy-MM-dd"));

            if (administeredDateDateTimePicker.Checked)
            {
                command.Parameters.AddWithValue("@administered_date", administeredDateDateTimePicker.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                command.Parameters.AddWithValue("@administered_date", DBNull.Value);
            }

            command.Parameters.AddWithValue("@biologic_type", biologicTypeComboBox.Text);
            command.Parameters.AddWithValue("@route", routeComboBox.Text);
            command.Parameters.AddWithValue("@item_id", _selectedItemId.HasValue ? _selectedItemId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@quantity_used", quantityUsedNumericUpDown.Value);
            command.Parameters.AddWithValue("@status", statusComboBox.Text);
            command.Parameters.AddWithValue("@administered_by", administeredByTextBox.Text.Trim());
            command.Parameters.AddWithValue("@remarks", remarksTextBox.Text.Trim());
        }

        private void CreateInventoryTransaction(MySqlConnection connection, MySqlTransaction transaction, int treatmentScheduleId)
        {
            // Get expiration date from inventory item
            DateTime? expirationDate = GetItemExpirationDate(connection, transaction, _selectedItemId.Value);

            string sql = @"
INSERT INTO inventory_transactions
(
    item_id,
    transaction_type,
    quantity,
    remarks,
    reference_no,
    treatment_schedule_id,
    expiration_date
)
VALUES
(
    @item_id,
    'OUT',
    @quantity,
    @remarks,
    @reference_no,
    @treatment_schedule_id,
    @expiration_date
);";

            using var command = new MySqlCommand(sql, connection, transaction);
            command.Parameters.AddWithValue("@item_id", _selectedItemId.Value);
            command.Parameters.AddWithValue("@quantity", quantityUsedNumericUpDown.Value);
            command.Parameters.AddWithValue("@remarks", $"Treatment for bite case {_biteCaseId} - {_selectedItemName}");
            command.Parameters.AddWithValue("@reference_no", $"TS-{treatmentScheduleId}");
            command.Parameters.AddWithValue("@treatment_schedule_id", treatmentScheduleId);
            command.Parameters.AddWithValue("@expiration_date", expirationDate.HasValue ? (object)expirationDate.Value : DBNull.Value);

            command.ExecuteNonQuery();

            // Update inventory stock on hand (decrease for OUT transaction)
            UpdateInventoryQuantity(connection, transaction, _selectedItemId.Value, -quantityUsedNumericUpDown.Value);
        }

        private void UpdateInventoryQuantity(MySqlConnection connection, MySqlTransaction transaction, long itemId, decimal adjustment)
        {
            string sql = @"
UPDATE inventory_items
SET quantity_on_hand = quantity_on_hand + @adjustment
WHERE item_id = @item_id;";

            using var command = new MySqlCommand(sql, connection, transaction);
            command.Parameters.AddWithValue("@adjustment", adjustment);
            command.Parameters.AddWithValue("@item_id", itemId);
            command.ExecuteNonQuery();
        }

        private DateTime? GetItemExpirationDate(MySqlConnection connection, MySqlTransaction transaction, long itemId)
        {
            string sql = "SELECT expiration_date FROM inventory_items WHERE item_id = @item_id";
            using var command = new MySqlCommand(sql, connection, transaction);
            command.Parameters.AddWithValue("@item_id", itemId);

            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToDateTime(result);
            }

            return null;
        }

        private bool WasPreviouslyAdministered(MySqlConnection connection, MySqlTransaction transaction, int treatmentScheduleId)
        {
            string sql = @"
SELECT administered_date
FROM treatment_schedule
WHERE treatment_schedule_id = @treatment_schedule_id
LIMIT 1;";

            using var command = new MySqlCommand(sql, connection, transaction);
            command.Parameters.AddWithValue("@treatment_schedule_id", treatmentScheduleId);

            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return true; // Has an administered date
            }

            return false;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(scheduleDayComboBox.Text))
            {
                MessageBox.Show("Please select a schedule day.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                scheduleDayComboBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(biologicTypeComboBox.Text))
            {
                MessageBox.Show("Please select a biologic type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                biologicTypeComboBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(routeComboBox.Text))
            {
                MessageBox.Show("Please select a route.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                routeComboBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(statusComboBox.Text))
            {
                MessageBox.Show("Please select a status.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusComboBox.Focus();
                return false;
            }

            // Require item selection when administered date is supplied (to record inventory transaction)
            if (administeredDateDateTimePicker.Checked && !_selectedItemId.HasValue)
            {
                MessageBox.Show("Please select an item when specifying an administered date.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                itemPickerButton.Focus();
                return false;
            }

            return true;
        }
    }
}
