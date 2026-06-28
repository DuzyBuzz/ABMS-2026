using ABMS_2026.Data.MySql;
using ABMS_2026.UI.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class TreatmentScheduleDayForm : Form
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private List<TreatmentScheduleData> _schedules;
        private DateTime _selectedDate;

        public TreatmentScheduleDayForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
            _schedules = new List<TreatmentScheduleData>();
            _selectedDate = DateTime.Now;
        }

        public void SetSchedules(List<TreatmentScheduleData> schedules)
        {
            _schedules = schedules;
            if (schedules.Count > 0)
            {
                _selectedDate = schedules[0].ScheduledDate;
            }
            LoadSchedulesToGrid();
        }

        private void TreatmentScheduleDayForm_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            LoadSchedulesToGrid();
        }

        private void InitializeGrid()
        {
            schedulesDataGridView.AutoGenerateColumns = false;
            schedulesDataGridView.AllowUserToAddRows = false;
            schedulesDataGridView.ReadOnly = true;
            schedulesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            schedulesDataGridView.MultiSelect = false;

            // Define columns
            schedulesDataGridView.Columns.Clear();

            schedulesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BiologicType",
                HeaderText = "Biologic Type",
                DataPropertyName = "BiologicType",
                Width = 150
            });

            schedulesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ScheduledDate",
                HeaderText = "Scheduled Date",
                DataPropertyName = "ScheduledDate",
                Width = 120
            });

            schedulesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            schedulesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Remarks",
                HeaderText = "Remarks",
                DataPropertyName = "Remarks",
                Width = 200
            });

            // Style the grid
            schedulesDataGridView.BackgroundColor = Color.White;
            schedulesDataGridView.BorderStyle = BorderStyle.FixedSingle;
            schedulesDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            schedulesDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(22, 54, 105);
            schedulesDataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadSchedulesToGrid()
        {
            schedulesDataGridView.DataSource = null;
            schedulesDataGridView.DataSource = _schedules;

            // Update title
            dateLabel.Text = $"Schedules for {_selectedDate:yyyy-MM-dd}";
            countLabel.Text = $"Total: {_schedules.Count}";
        }

        private void schedulesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Handle any cell click by showing schedule details
            var schedule = _schedules[e.RowIndex];
            ShowAppointmentDetails(schedule);
        }

        private void ShowAppointmentDetails(TreatmentScheduleData schedule)
        {
            string details = $"Date: {schedule.ScheduledDate:MMMM dd, yyyy h:mm tt}\n" +
                             $"Biologic: {schedule.BiologicType}\n" +
                             $"Status: {schedule.Status}\n" +
                             $"Remarks: {schedule.Remarks ?? "N/A"}";

            MessageBox.Show(details, "Schedule Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public class TreatmentScheduleData
        {
            public int TreatmentScheduleId { get; set; }
            public DateTime ScheduledDate { get; set; }
            public DateTime? AdministeredDate { get; set; }
            public string BiologicType { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public string? Remarks { get; set; }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}