using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class ItemPickerForm : Form
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        public long? SelectedItemId { get; private set; }
        public string SelectedItemName { get; private set; } = string.Empty;

        public ItemPickerForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        private void ItemPickerForm_Load(object sender, EventArgs e)
        {
            LoadItems();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            searchTextBox.KeyDown += SearchTextBox_KeyDown;
            searchButton.Click += SearchButton_Click;
            selectButton.Click += SelectButton_Click;
            cancelButton.Click += CancelButton_Click;
            itemsDataGridView.DoubleClick += ItemsDataGridView_DoubleClick;
        }

        private void LoadItems(string searchTerm = "")
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
    quantity_on_hand,
    expiration_date
FROM inventory_items
WHERE is_active = 1";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " AND (generic_name LIKE @search OR brand_name LIKE @search OR category LIKE @search)";
                }

                query += " ORDER BY generic_name, brand_name LIMIT 100;";

                using var command = new MySqlCommand(query, connection);
                
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    command.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                }

                using var adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Create columns FIRST
                SetupDataGridViewColumns();

                // Then bind
                itemsDataGridView.DataSource = null;
                itemsDataGridView.AutoGenerateColumns = false;
                itemsDataGridView.DataSource = table;
                // Configure columns
                SetupDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewColumns()
        {
            if (itemsDataGridView.Columns.Count > 0)
                return;

            itemsDataGridView.AutoGenerateColumns = false;
            itemsDataGridView.Columns.Clear();

            // Hidden ID column
            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "item_id",
                DataPropertyName = "item_id",
                Visible = false
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "generic_name",
                HeaderText = "Generic Name",
                DataPropertyName = "generic_name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "brand_name",
                HeaderText = "Brand Name",
                DataPropertyName = "brand_name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 20
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "category",
                HeaderText = "Category",
                DataPropertyName = "category",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "strength",
                HeaderText = "Strength",
                DataPropertyName = "strength",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "unit",
                HeaderText = "Unit",
                DataPropertyName = "unit",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "quantity_on_hand",
                HeaderText = "On Hand",
                DataPropertyName = "quantity_on_hand",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10,
                DefaultCellStyle = { Format = "N2" }
            });

            itemsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "expiration_date",
                HeaderText = "Exp Date",
                DataPropertyName = "expiration_date",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10,
                DefaultCellStyle = { Format = "MM/dd/yyyy" }
            });

            itemsDataGridView.ReadOnly = true;
            itemsDataGridView.AllowUserToAddRows = false;
            itemsDataGridView.AllowUserToDeleteRows = false;
            itemsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            itemsDataGridView.MultiSelect = false;
            itemsDataGridView.RowHeadersVisible = false;
        }

        private void SearchTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadItems(searchTextBox.Text.Trim());
            }
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            LoadItems(searchTextBox.Text.Trim());
        }

        private void SelectButton_Click(object? sender, EventArgs e)
        {
            SelectCurrentItem();
        }

        private void ItemsDataGridView_DoubleClick(object? sender, EventArgs e)
        {
            SelectCurrentItem();
        }

        private void SelectCurrentItem()
        {
            if (itemsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = itemsDataGridView.SelectedRows[0];
            SelectedItemId = Convert.ToInt64(selectedRow.Cells["item_id"].Value);
            
            var genericName = selectedRow.Cells["generic_name"].Value?.ToString() ?? "";
            var brandName = selectedRow.Cells["brand_name"].Value?.ToString() ?? "";
            SelectedItemName = string.IsNullOrWhiteSpace(brandName) 
                ? genericName 
                : $"{genericName} - {brandName}";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            SelectedItemId = null;
            SelectedItemName = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
