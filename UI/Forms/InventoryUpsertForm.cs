using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Shared.Components;
using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class InventoryUpsertForm : Form, IModuleUpsertForm
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private ModuleRecordContext? _context;
        private long? _itemId;

        public InventoryUpsertForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        public InventoryUpsertForm(long itemId) : this()
        {
            _itemId = itemId;
        }

        private void InventoryUpsertForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxOptions();

            // Wire up save button
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, args) => Close();
        }

        public void LoadModuleRecord(ModuleRecordContext context)
        {
            _context = context;
            _itemId = context.PrimaryKeyValue as long?;

            if (_itemId.HasValue)
            {
                LoadInventoryItemData(_itemId.Value);
                this.Text = "Edit Inventory Item";
            }
            else
            {
                this.Text = "Add New Inventory Item";
                // Set default values
                checkBoxIsActive.Checked = true;
                numericUpDownReorderLevel.Value = 0;
            }
        }

        private void LoadComboBoxOptions()
        {
            // Load dropdown options from existing data
            CollectionHelper.LoadComboBoxDistinct(comboBoxCategory, "inventory_items", "category");
            CollectionHelper.LoadComboBoxDistinct(comboBoxDosageForm, "inventory_items", "dosage_form");
            CollectionHelper.LoadComboBoxDistinct(comboBoxUnit, "inventory_items", "unit");
        }

        private void LoadInventoryItemData(long itemId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT 
    item_id,
    generic_name,
    brand_name,
    category,
    strength,
    dosage_form,
    unit,
    reorder_level,
    expiration_date,
    is_active
FROM inventory_items
WHERE item_id = @item_id;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@item_id", itemId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    textBoxGenericName.Text = reader["generic_name"]?.ToString() ?? string.Empty;
                    textBoxBrandName.Text = reader["brand_name"]?.ToString() ?? string.Empty;
                    comboBoxCategory.Text = reader["category"]?.ToString() ?? string.Empty;
                    textBoxStrength.Text = reader["strength"]?.ToString() ?? string.Empty;
                    comboBoxDosageForm.Text = reader["dosage_form"]?.ToString() ?? string.Empty;
                    comboBoxUnit.Text = reader["unit"]?.ToString() ?? string.Empty;
                    
                    if (reader["reorder_level"] != null && reader["reorder_level"] != DBNull.Value)
                    {
                        numericUpDownReorderLevel.Value = Convert.ToDecimal(reader["reorder_level"]);
                    }

                    if (reader["expiration_date"] != null && reader["expiration_date"] != DBNull.Value)
                    {
                        dateTimePickerExpirationDate.Value = Convert.ToDateTime(reader["expiration_date"]);
                    }
                    else
                    {
                        dateTimePickerExpirationDate.Value = DateTime.Today.AddYears(1); // Default to 1 year from now
                    }

                    checkBoxIsActive.Checked = Convert.ToBoolean(reader["is_active"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory item: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxGenericName.Text))
            {
                MessageBox.Show("Generic name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxGenericName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxCategory.Text))
            {
                MessageBox.Show("Category is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxUnit.Text))
            {
                MessageBox.Show("Unit is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxUnit.Focus();
                return false;
            }

            if (numericUpDownReorderLevel.Value < 0)
            {
                MessageBox.Show("Reorder level cannot be negative.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownReorderLevel.Focus();
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

                string sql;

                if (_itemId.HasValue)
                {
                    // Update existing record
                    sql = @"
UPDATE inventory_items SET
    generic_name = @generic_name,
    brand_name = @brand_name,
    category = @category,
    strength = @strength,
    dosage_form = @dosage_form,
    unit = @unit,
    reorder_level = @reorder_level,
    expiration_date = @expiration_date,
    is_active = @is_active
WHERE item_id = @item_id;";
                }
                else
                {
                    // Insert new record
                    sql = @"
INSERT INTO inventory_items (
    generic_name, brand_name, category, strength, dosage_form, unit,
    reorder_level, expiration_date, is_active
) VALUES (
    @generic_name, @brand_name, @category, @strength, @dosage_form, @unit,
    @reorder_level, @expiration_date, @is_active
);

SELECT LAST_INSERT_ID();";
                }

                using var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@generic_name", textBoxGenericName.Text.Trim());
                cmd.Parameters.AddWithValue("@brand_name", string.IsNullOrWhiteSpace(textBoxBrandName.Text.Trim()) ? (object)DBNull.Value : textBoxBrandName.Text.Trim());
                cmd.Parameters.AddWithValue("@category", comboBoxCategory.Text.Trim());
                cmd.Parameters.AddWithValue("@strength", string.IsNullOrWhiteSpace(textBoxStrength.Text.Trim()) ? (object)DBNull.Value : textBoxStrength.Text.Trim());
                cmd.Parameters.AddWithValue("@dosage_form", string.IsNullOrWhiteSpace(comboBoxDosageForm.Text.Trim()) ? (object)DBNull.Value : comboBoxDosageForm.Text.Trim());
                cmd.Parameters.AddWithValue("@unit", comboBoxUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@reorder_level", numericUpDownReorderLevel.Value);
                
                if (dateTimePickerExpirationDate.Value == DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@expiration_date", (object)DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiration_date", dateTimePickerExpirationDate.Value);
                }
                
                cmd.Parameters.AddWithValue("@is_active", checkBoxIsActive.Checked);

                if (_itemId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@item_id", _itemId.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inventory item updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _itemId = Convert.ToInt64(cmd.ExecuteScalar());
                    MessageBox.Show("Inventory item added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving inventory item: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
