using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class TreatmentUserControl : UserControl
    {
        private const string ActionEditColumnName = "__action_edit";
        private const string ActionDeleteColumnName = "__action_delete";

        private readonly MySqlConnectionHelper _connectionHelper;
        private int _biteCaseId;
        private int _totalRecords;

        public TreatmentUserControl()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();

            WireUpEvents();
            ApplyDefaultVisualState();
        }

        public TreatmentUserControl(int biteCaseId) : this()
        {
            _biteCaseId = biteCaseId;
            LoadTreatmentSchedules();
        }

        public void SetBiteCaseId(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            LoadTreatmentSchedules();
        }

        private void WireUpEvents()
        {
            moduleSearchButton.Click += ModuleSearchButton_Click;
            moduleRefreshButton.Click += ModuleRefreshButton_Click;
            moduleAddButton.Click += ModuleAddButton_Click;
            moduleSearchTextBox.KeyDown += ModuleSearchTextBox_KeyDown;
            moduleDataGridView.CellContentClick += ModuleDataGridView_CellContentClick;
        }

        private void ApplyDefaultVisualState()
        {
            summaryLabel.Text = string.Empty;
        }

        private void LoadTreatmentSchedules(string searchTerm = "")
        {
            if (_biteCaseId <= 0)
            {
                moduleDataGridView.DataSource = null;
                summaryLabel.Text = "No bite case selected";
                return;
            }

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT
    treatment_schedule_id,
    schedule_day,
    scheduled_date,
    administered_date,
    biologic_type,
    route,
    item_id,
    generic_name,
    brand_name,
    item_name,
    category,
    strength,
    dosage_form,
    unit,
    quantity_used,
    status,
    administered_by,
    remarks,
    created_at
FROM v_treatment_schedule
WHERE bite_case_id = @bite_case_id";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " AND (schedule_day LIKE @search OR biologic_type LIKE @search OR status LIKE @search OR administered_by LIKE @search)";
                }

                query += " ORDER BY scheduled_date, schedule_day;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    command.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                }

                using var adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                _totalRecords = table.Rows.Count;

                moduleDataGridView.DataSource = null;
                moduleDataGridView.AutoGenerateColumns = false;
                moduleDataGridView.DataSource = table;

                SetupDataGridViewColumns();
                ApplyGridSettings();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading treatment schedules: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewColumns()
        {
            moduleDataGridView.Columns.Clear();

            // Add columns manually for better control
            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "treatment_schedule_id",
                HeaderText = "ID",
                DataPropertyName = "treatment_schedule_id",
                Visible = false
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "schedule_day",
                HeaderText = "Schedule Day",
                DataPropertyName = "schedule_day",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "scheduled_date",
                HeaderText = "Scheduled Date",
                DataPropertyName = "scheduled_date",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "administered_date",
                HeaderText = "Administered Date",
                DataPropertyName = "administered_date",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "biologic_type",
                HeaderText = "Biologic Type",
                DataPropertyName = "biologic_type",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "route",
                HeaderText = "Route",
                DataPropertyName = "route",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "item_name",
                HeaderText = "Item",
                DataPropertyName = "item_name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 18
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "quantity_used",
                HeaderText = "Quantity",
                DataPropertyName = "quantity_used",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "status",
                HeaderText = "Status",
                DataPropertyName = "status",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10
            });

            moduleDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "administered_by",
                HeaderText = "Administered By",
                DataPropertyName = "administered_by",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            // Add action columns
            var editColumn = new DataGridViewButtonColumn
            {
                Name = ActionEditColumnName,
                HeaderText = string.Empty,
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Flat
            };

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = ActionDeleteColumnName,
                HeaderText = string.Empty,
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Flat
            };

            moduleDataGridView.Columns.Add(editColumn);
            moduleDataGridView.Columns.Add(deleteColumn);
        }

        private void ApplyGridSettings()
        {
            moduleDataGridView.ReadOnly = true;
            moduleDataGridView.AllowUserToAddRows = false;
            moduleDataGridView.AllowUserToDeleteRows = false;
            moduleDataGridView.AllowUserToResizeRows = false;
            moduleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            moduleDataGridView.MultiSelect = false;
            moduleDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            moduleDataGridView.RowHeadersVisible = false;
            moduleDataGridView.EnableHeadersVisualStyles = false;

            // Apply header styling
            moduleDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 54, 105);
            moduleDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            moduleDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(moduleDataGridView.Font, FontStyle.Bold);
            moduleDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Format date columns
            foreach (DataGridViewColumn column in moduleDataGridView.Columns)
            {
                if (column.Name == "scheduled_date" || column.Name == "administered_date" || column.Name == "created_at")
                {
                    column.DefaultCellStyle.Format = "yyyy-MM-dd";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (column.Name == "quantity_used")
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void UpdateSummary()
        {
            summaryLabel.Text = $"Showing {_totalRecords:N0} treatment schedule(s)";
        }

        private void ModuleSearchButton_Click(object sender, EventArgs e)
        {
            LoadTreatmentSchedules(moduleSearchTextBox.Text.Trim());
        }

        private void ModuleRefreshButton_Click(object sender, EventArgs e)
        {
            moduleSearchTextBox.Clear();
            LoadTreatmentSchedules();
        }

        private void ModuleAddButton_Click(object sender, EventArgs e)
        {
            if (_biteCaseId <= 0)
            {
                MessageBox.Show("Please save the bite case first before adding treatment schedules.", "No Bite Case",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTreatmentForm(isEditMode: false, treatmentScheduleId: null);
        }

        private void ModuleSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadTreatmentSchedules(moduleSearchTextBox.Text.Trim());
            }
        }

        private void ModuleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (moduleDataGridView.Columns[e.ColumnIndex].Name == ActionEditColumnName)
            {
                var selectedRow = moduleDataGridView.Rows[e.RowIndex];
                int treatmentScheduleId = Convert.ToInt32(selectedRow.Cells["treatment_schedule_id"].Value);
                OpenTreatmentForm(isEditMode: true, treatmentScheduleId: treatmentScheduleId);
            }
            else if (moduleDataGridView.Columns[e.ColumnIndex].Name == ActionDeleteColumnName)
            {
                var selectedRow = moduleDataGridView.Rows[e.RowIndex];
                int treatmentScheduleId = Convert.ToInt32(selectedRow.Cells["treatment_schedule_id"].Value);
                DeleteTreatmentSchedule(treatmentScheduleId);
            }
        }

        private void OpenTreatmentForm(bool isEditMode, int? treatmentScheduleId)
        {
            using var form = new TreatmentForm(_biteCaseId, treatmentScheduleId);
            form.StartPosition = FormStartPosition.CenterParent;
            
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadTreatmentSchedules();
            }
        }

        private void DeleteTreatmentSchedule(int treatmentScheduleId)
        {
            DialogResult confirm = MessageBox.Show(
                "Delete this treatment schedule? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string sql = @"
DELETE FROM treatment_schedule
WHERE treatment_schedule_id = @treatment_schedule_id
LIMIT 1;";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@treatment_schedule_id", treatmentScheduleId);

                int affected = command.ExecuteNonQuery();

                if (affected > 0)
                {
                    MessageBox.Show("Treatment schedule deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTreatmentSchedules();
                }
                else
                {
                    MessageBox.Show("Treatment schedule not found or could not be deleted.", "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting treatment schedule: {ex.Message}", "Delete Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
