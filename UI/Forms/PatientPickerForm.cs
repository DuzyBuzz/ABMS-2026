using ABMS_2026.Common.Helpers;
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

        private DataTable _patientTable =
            new DataTable();

        public int SelectedPatientId
        {
            get;
            private set;
        }

        public string SelectedPatientName
        {
            get;
            private set;
        } = string.Empty;

        public PatientPickerForm()
        {
            InitializeComponent();

            _connectionHelper =
                new MySqlConnectionHelper();

            HookEvents();
        }

        private void HookEvents()
        {
            Load += PatientPickerForm_Load;

            refreshButton.Click +=
                RefreshButton_Click;

            searchTextBox.TextChanged +=
                SearchTextBox_TextChanged;

            selectButton.Click +=
                SelectButton_Click;

            cancelButton.Click +=
                CancelButton_Click;

            patientDataGridView.CellDoubleClick +=
                PatientDataGridView_CellDoubleClick;
        }

        private void PatientPickerForm_Load(
            object sender,
            EventArgs e)
        {
            LoadPatients();
            LoadSearchSuggestions();
        }

        private void RefreshButton_Click(
            object sender,
            EventArgs e)
        {
            LoadPatients();
        }

        private void SearchTextBox_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplySearch();
        }

        private void SelectButton_Click(
            object sender,
            EventArgs e)
        {
            SelectCurrentPatient();
        }

        private void CancelButton_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private void PatientDataGridView_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            SelectCurrentPatient();
        }

        private void LoadPatients()
        {
            try
            {
                using (var connection =
                    _connectionHelper.GetConnection())
                {
                    connection.Open();

                    const string sql = @"
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
FROM v_patients
ORDER BY patient_id DESC
LIMIT 20;";

                    using (var adapter =
                        new MySqlDataAdapter(
                            sql,
                            connection))
                    {
                        _patientTable =
                            new DataTable();

                        adapter.Fill(
                            _patientTable);
                    }
                }

                patientDataGridView.DataSource =
                    _patientTable;

                FormatGrid();

                totalLabel.Text =
                    $"{_patientTable.Rows.Count:N0} Patients";

                ApplySearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Patients",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplySearch()
        {
            if (_patientTable == null)
            {
                return;
            }

            string search =
                searchTextBox.Text.Trim()
                .Replace("'", "''");

            DataView view =
                _patientTable.DefaultView;

            if (string.IsNullOrWhiteSpace(search))
            {
                view.RowFilter =
                    string.Empty;
            }
            else
            {
                view.RowFilter =
                    $"Convert(registration_no,'System.String') LIKE '%{search}%' " +
                    $"OR Convert(last_name,'System.String') LIKE '%{search}%' " +
                    $"OR Convert(first_name,'System.String') LIKE '%{search}%' " +
                    $"OR Convert(middle_name,'System.String') LIKE '%{search}%' " +
                    $"OR Convert(contact_no,'System.String') LIKE '%{search}%'";
            }

            totalLabel.Text =
                $"{view.Count:N0} Patients";
        }

        private void FormatGrid()
        {
            if (patientDataGridView.Columns.Count == 0)
            {
                return;
            }

            patientDataGridView.Columns["patient_id"]
                .Visible = false;

            patientDataGridView.Columns["registration_no"]
                .HeaderText = "Registration No";

            patientDataGridView.Columns["last_name"]
                .HeaderText = "Last Name";

            patientDataGridView.Columns["first_name"]
                .HeaderText = "First Name";

            patientDataGridView.Columns["middle_name"]
                .HeaderText = "Middle Name";

            patientDataGridView.Columns["birth_date"]
                .HeaderText = "Birth Date";

            patientDataGridView.Columns["age"]
                .HeaderText = "Age";

            patientDataGridView.Columns["sex"]
                .HeaderText = "Sex";

            patientDataGridView.Columns["civil_status"]
                .HeaderText = "Civil Status";

            patientDataGridView.Columns["address"]
                .HeaderText = "Address";

            patientDataGridView.Columns["contact_no"]
                .HeaderText = "Contact No";

            // Apply header styling
            patientDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(22, 54, 105);
            patientDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            patientDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(patientDataGridView.Font, System.Drawing.FontStyle.Bold);
            patientDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Auto-format columns
            AutoFormatColumns();
        }

        private void AutoFormatColumns()
        {
            if (_patientTable == null) return;

            foreach (DataGridViewColumn column in patientDataGridView.Columns)
            {
                if (column.Name == "patient_id")
                    continue;

                if (!_patientTable.Columns.Contains(column.Name))
                    continue;

                DataColumn dataColumn = _patientTable.Columns[column.Name];

                // Format date columns
                if (dataColumn.DataType == typeof(DateTime) || dataColumn.DataType == typeof(DateTime?))
                {
                    column.DefaultCellStyle.Format = "yyyy-MM-dd";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                // Format numeric columns
                else if (dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(int?))
                {
                    column.DefaultCellStyle.Format = "N0";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                // Text columns - left align
                else
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void SelectCurrentPatient()
        {
            if (patientDataGridView.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a patient.",
                    "Patient",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            SelectedPatientId =
                Convert.ToInt32(
                    patientDataGridView
                    .CurrentRow
                    .Cells["patient_id"]
                    .Value);

            string lastName = patientDataGridView.CurrentRow.Cells["last_name"].Value?.ToString() ?? string.Empty;
            string firstName = patientDataGridView.CurrentRow.Cells["first_name"].Value?.ToString() ?? string.Empty;
            string middleName = patientDataGridView.CurrentRow.Cells["middle_name"].Value?.ToString() ?? string.Empty;

            SelectedPatientName = $"{lastName}, {firstName} {middleName}".Trim();

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void LoadSearchSuggestions()
        {
            try
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                // Load suggestions from all searchable columns
                string[] columns = { "registration_no", "last_name", "first_name", "middle_name", "contact_no" };

                foreach (string column in columns)
                {
                    string query = $@"
SELECT DISTINCT {column}
FROM v_patients
WHERE {column} IS NOT NULL
AND {column} <> ''
ORDER BY {column}
LIMIT 100;";

                    using var command = new MySqlCommand(query, connection);
                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string value = reader[column].ToString();
                        if (!string.IsNullOrWhiteSpace(value) && !collection.Contains(value))
                        {
                            collection.Add(value);
                        }
                    }
                }

                searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                searchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                searchTextBox.AutoCompleteCustomSource = collection;
            }
            catch (Exception ex)
            {
                // Silently fail - suggestions are optional
                System.Diagnostics.Debug.WriteLine($"Failed to load search suggestions: {ex.Message}");
            }
        }
    }
}