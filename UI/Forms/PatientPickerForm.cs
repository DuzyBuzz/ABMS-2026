using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class PatientPickerForm : Form
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        public int? SelectedPatientId { get; private set; }
        public string SelectedPatientName { get; private set; } = string.Empty;

        public PatientPickerForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        private void PatientPickerForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            searchTextBox.KeyDown += SearchTextBox_KeyDown;
            searchButton.Click += SearchButton_Click;
            selectButton.Click += SelectButton_Click;
            cancelButton.Click += CancelButton_Click;
            patientsDataGridView.DoubleClick += PatientsDataGridView_DoubleClick;
        }

        private void LoadPatients(string searchTerm = "")
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT 
    patient_id,
    registration_no,
    last_name,
    first_name,
    middle_name,
    birth_date,
    age,
    sex,
    civil_status,
    address,
    contact_no
FROM patients
WHERE is_active = 1";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " AND (last_name LIKE @search OR first_name LIKE @search OR middle_name LIKE @search OR registration_no LIKE @search)";
                }

                query += " ORDER BY last_name, first_name LIMIT 100;";

                using var command = new MySqlCommand(query, connection);
                
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    command.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                }

                using var adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                patientsDataGridView.DataSource = null;
                patientsDataGridView.AutoGenerateColumns = false;
                patientsDataGridView.DataSource = table;

                SetupDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewColumns()
        {
            patientsDataGridView.Columns.Clear();

            // Add columns manually for better control
            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "patient_id",
                HeaderText = "ID",
                DataPropertyName = "patient_id",
                Visible = false
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "registration_no",
                HeaderText = "Reg No",
                DataPropertyName = "registration_no",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "last_name",
                HeaderText = "Last Name",
                DataPropertyName = "last_name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "first_name",
                HeaderText = "First Name",
                DataPropertyName = "first_name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "middle_name",
                HeaderText = "Middle Name",
                DataPropertyName = "middle_name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "age",
                HeaderText = "Age",
                DataPropertyName = "age",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "sex",
                HeaderText = "Sex",
                DataPropertyName = "sex",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            patientsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "address",
                HeaderText = "Address",
                DataPropertyName = "address",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });

            // Apply styling
            patientsDataGridView.ReadOnly = true;
            patientsDataGridView.AllowUserToAddRows = false;
            patientsDataGridView.AllowUserToDeleteRows = false;
            patientsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            patientsDataGridView.MultiSelect = false;
            patientsDataGridView.RowHeadersVisible = false;
        }

        private void SearchTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadPatients(searchTextBox.Text.Trim());
            }
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            LoadPatients(searchTextBox.Text.Trim());
        }

        private void SelectButton_Click(object? sender, EventArgs e)
        {
            SelectCurrentPatient();
        }

        private void PatientsDataGridView_DoubleClick(object? sender, EventArgs e)
        {
            SelectCurrentPatient();
        }

        private void SelectCurrentPatient()
        {
            if (patientsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = patientsDataGridView.SelectedRows[0];
            SelectedPatientId = Convert.ToInt32(selectedRow.Cells["patient_id"].Value);
            
            var lastName = selectedRow.Cells["last_name"].Value?.ToString() ?? "";
            var firstName = selectedRow.Cells["first_name"].Value?.ToString() ?? "";
            var middleName = selectedRow.Cells["middle_name"].Value?.ToString() ?? "";
            
            SelectedPatientName = $"{lastName}, {firstName} {middleName}".Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            SelectedPatientId = null;
            SelectedPatientName = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
