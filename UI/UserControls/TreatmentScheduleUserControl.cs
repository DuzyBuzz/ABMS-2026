using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class TreatmentScheduleUserControl : UserControl
    {
        private readonly MySqlConnectionHelper _connectionHelper = new();

        private DateTime _currentMonth = new(DateTime.Today.Year, DateTime.Today.Month, 1);
        private DateTime _selectedDate = DateTime.Today;

        private readonly List<TreatmentScheduleData> _monthSchedules = new();
        private readonly List<CalendarCell> _cells = new();

        private static readonly Color HeaderBlue = Color.FromArgb(22, 54, 105);
        private static readonly Color HeaderLight = Color.FromArgb(240, 248, 255);
        private static readonly Color TodayColor = Color.FromArgb(255, 255, 224);
        private static readonly Color SelectedColor = Color.FromArgb(22, 54, 105);
        private static readonly Color OtherMonthColor = Color.FromArgb(245, 245, 245);

        public TreatmentScheduleUserControl()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            InitializeCalendarGrid();
            LoadSchedulesForMonth(_currentMonth);
        }

        private void InitializeCalendarGrid()
        {
            _cells.Clear();

            calendarLayoutPanel.SuspendLayout();
            calendarLayoutPanel.Controls.Clear();
            calendarLayoutPanel.ColumnStyles.Clear();
            calendarLayoutPanel.RowStyles.Clear();

            calendarLayoutPanel.ColumnCount = 7;
            calendarLayoutPanel.RowCount = 7;

            for (int i = 0; i < 7; i++)
                calendarLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7f));

            calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            for (int i = 0; i < 6; i++)
                calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6f));

            string[] weekdays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            for (int i = 0; i < 7; i++)
            {
                calendarLayoutPanel.Controls.Add(new Label
                {
                    Text = weekdays[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = HeaderBlue,
                    BackColor = HeaderLight,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                }, i, 0);
            }

            for (int week = 0; week < 6; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    var cell = CreateCalendarCell();
                    _cells.Add(cell);
                    calendarLayoutPanel.Controls.Add(cell.Panel, day, week + 1);
                }
            }

            calendarLayoutPanel.ResumeLayout(true);
        }

        private CalendarCell CreateCalendarCell()
        {
            var panel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Cursor = Cursors.Hand
            };

            var dayLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 18,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(2, 1, 2, 0)
            };

            var countLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(2, 0, 2, 2)
            };

            panel.Controls.Add(countLabel);
            panel.Controls.Add(dayLabel);

            var cell = new CalendarCell
            {
                Panel = panel,
                DayLabel = dayLabel,
                CountLabel = countLabel,
                Date = DateTime.MinValue
            };

            panel.Tag = cell;
            dayLabel.Tag = cell;
            countLabel.Tag = cell;

            panel.Click += CalendarCell_Click;
            dayLabel.Click += CalendarCell_Click;
            countLabel.Click += CalendarCell_Click;

            panel.MouseEnter += CalendarCell_MouseEnter;
            panel.MouseLeave += CalendarCell_MouseLeave;
            dayLabel.MouseEnter += CalendarCell_MouseEnter;
            dayLabel.MouseLeave += CalendarCell_MouseLeave;
            countLabel.MouseEnter += CalendarCell_MouseEnter;
            countLabel.MouseLeave += CalendarCell_MouseLeave;

            return cell;
        }

        private void RenderCalendar()
        {
            if (_cells.Count != 42)
            {
                InitializeCalendarGrid();
                return;
            }

            DateTime firstOfMonth = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            int firstDayOfWeek = (int)firstOfMonth.DayOfWeek;
            DateTime firstDayToDisplay = firstOfMonth.AddDays(-firstDayOfWeek);

            monthYearLabel.Text = _currentMonth.ToString("MMMM yyyy");

            for (int i = 0; i < _cells.Count; i++)
            {
                DateTime currentDay = firstDayToDisplay.AddDays(i);
                CalendarCell cell = _cells[i];

                cell.Date = currentDay;
                cell.DayLabel.Text = currentDay.Day.ToString();
                cell.CountLabel.Text = string.Empty;

                ApplyCellStyle(cell, currentDay);

                int count = _monthSchedules.Count(x => x.ScheduledDate.Date == currentDay.Date);
                if (count > 0)
                {
                    cell.CountLabel.Text = count == 1 ? "1 schedule" : $"{count} schedules";
                    cell.CountLabel.ForeColor = currentDay.Date == _selectedDate.Date ? Color.White : Color.Black;
                }

                if (currentDay.Date == _selectedDate.Date)
                {
                    cell.DayLabel.ForeColor = Color.White;
                    cell.CountLabel.ForeColor = Color.White;
                }
            }
        }

        private void ApplyCellStyle(CalendarCell cell, DateTime date)
        {
            if (date.Date == _selectedDate.Date)
            {
                cell.Panel.BackColor = SelectedColor;
                cell.DayLabel.ForeColor = Color.White;
                cell.CountLabel.ForeColor = Color.White;
            }
            else if (date.Date == DateTime.Today)
            {
                cell.Panel.BackColor = TodayColor;
                cell.DayLabel.ForeColor = Color.Black;
                cell.CountLabel.ForeColor = Color.Black;
            }
            else if (date.Month != _currentMonth.Month)
            {
                cell.Panel.BackColor = OtherMonthColor;
                cell.DayLabel.ForeColor = Color.Gray;
                cell.CountLabel.ForeColor = Color.DimGray;
            }
            else
            {
                cell.Panel.BackColor = Color.White;
                cell.DayLabel.ForeColor = Color.Black;
                cell.CountLabel.ForeColor = Color.Black;
            }
        }

        private void CalendarCell_Click(object? sender, EventArgs e)
        {
            CalendarCell? cell = GetCellFromSender(sender);
            if (cell == null || cell.Date == DateTime.MinValue)
                return;

            _selectedDate = cell.Date;
            RenderCalendar();
            ShowDayDetails(cell.Date);
        }

        private void CalendarCell_MouseEnter(object? sender, EventArgs e)
        {
            CalendarCell? cell = GetCellFromSender(sender);
            if (cell == null)
                return;

            if (cell.Date.Date != _selectedDate.Date)
                cell.Panel.BackColor = Color.FromArgb(240, 248, 255);
        }

        private void CalendarCell_MouseLeave(object? sender, EventArgs e)
        {
            CalendarCell? cell = GetCellFromSender(sender);
            if (cell == null)
                return;

            ApplyCellStyle(cell, cell.Date);
        }

        private static CalendarCell? GetCellFromSender(object? sender)
        {
            if (sender is Control control && control.Tag is CalendarCell cell)
                return cell;

            return null;
        }

        private void ShowDayDetails(DateTime date)
        {
            var daySchedules = _monthSchedules
                .Where(x => x.ScheduledDate.Date == date.Date)
                .OrderBy(x => x.ScheduledDate)
                .ThenBy(x => x.TreatmentScheduleId)
                .ToList();

            if (daySchedules.Count == 0)
            {
                MessageBox.Show(
                    $"No treatment schedules for {date:MMMM dd, yyyy}",
                    "Treatment Schedules",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var form = new TreatmentDayDetailsForm(date, daySchedules);
            form.ShowDialog(this);
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(-1);
            LoadSchedulesForMonth(_currentMonth);
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(1);
            LoadSchedulesForMonth(_currentMonth);
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            _currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _selectedDate = DateTime.Today;
            LoadSchedulesForMonth(_currentMonth);
        }

        private void LoadSchedulesForMonth(DateTime month)
        {
            _monthSchedules.Clear();

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();
                DateTime startDate = new DateTime(month.Year, month.Month, 1).AddMonths(-1);
                DateTime endDate = new DateTime(month.Year, month.Month, 1).AddMonths(2);

                const string sql = @"
SELECT
    ts.treatment_schedule_id,
    ts.bite_case_id,
    ts.schedule_day,
    ts.scheduled_date,
    ts.administered_date,
    ts.biologic_type,
    ts.item_id,
    ts.generic_name,
    ts.brand_name,
    ts.item_name,
    ts.category,
    ts.strength,
    ts.dosage_form,
    ts.unit,
    ts.quantity_used,
    ts.status,
    ts.administered_by,
    ts.remarks,
    ts.route,
    ts.created_at,
    bc.registration_no,
    bc.patient_name
FROM v_treatment_schedule ts
LEFT JOIN v_bite_cases bc
    ON bc.bite_case_id = ts.bite_case_id
WHERE ts.scheduled_date >= @startDate
  AND ts.scheduled_date < @endDate
ORDER BY ts.scheduled_date, ts.treatment_schedule_id;";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _monthSchedules.Add(new TreatmentScheduleData
                    {
                        TreatmentScheduleId = reader["treatment_schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["treatment_schedule_id"]) : 0,
                        BiteCaseId = reader["bite_case_id"] != DBNull.Value ? Convert.ToInt32(reader["bite_case_id"]) : 0,
                        ScheduleDay = reader["schedule_day"]?.ToString() ?? string.Empty,
                        ScheduledDate = reader["scheduled_date"] != DBNull.Value ? Convert.ToDateTime(reader["scheduled_date"]) : DateTime.MinValue,
                        AdministeredDate = reader["administered_date"] != DBNull.Value ? Convert.ToDateTime(reader["administered_date"]) : (DateTime?)null,
                        BiologicType = reader["biologic_type"]?.ToString() ?? string.Empty,
                        ItemId = reader["item_id"] != DBNull.Value ? Convert.ToInt64(reader["item_id"]) : (long?)null,
                        GenericName = reader["generic_name"]?.ToString() ?? string.Empty,
                        BrandName = reader["brand_name"]?.ToString() ?? string.Empty,
                        ItemName = reader["item_name"]?.ToString() ?? string.Empty,
                        Category = reader["category"]?.ToString() ?? string.Empty,
                        Strength = reader["strength"]?.ToString() ?? string.Empty,
                        DosageForm = reader["dosage_form"]?.ToString() ?? string.Empty,
                        Unit = reader["unit"]?.ToString() ?? string.Empty,
                        QuantityUsed = reader["quantity_used"] != DBNull.Value ? Convert.ToDecimal(reader["quantity_used"]) : (decimal?)null,
                        Status = reader["status"]?.ToString() ?? string.Empty,
                        AdministeredBy = reader["administered_by"]?.ToString() ?? string.Empty,
                        Remarks = reader["remarks"]?.ToString() ?? string.Empty,
                        Route = reader["route"]?.ToString() ?? string.Empty,
                        RegistrationNo = reader["registration_no"]?.ToString() ?? string.Empty,
                        PatientName = reader["patient_name"]?.ToString() ?? string.Empty
                    });
                }

                RenderCalendar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedules: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void LoadSchedulesForBiteCase(int biteCaseId)
        {

        }
        private sealed class CalendarCell
        {
            public Panel Panel { get; set; } = null!;
            public Label DayLabel { get; set; } = null!;
            public Label CountLabel { get; set; } = null!;
            public DateTime Date { get; set; }
        }
    }

    public sealed class TreatmentScheduleData
    {
        public int TreatmentScheduleId { get; set; }
        public int BiteCaseId { get; set; }
        public string ScheduleDay { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public DateTime? AdministeredDate { get; set; }
        public string BiologicType { get; set; } = string.Empty;
        public long? ItemId { get; set; }
        public string GenericName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Strength { get; set; } = string.Empty;
        public string DosageForm { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal? QuantityUsed { get; set; }
        public string Status { get; set; } = string.Empty;
        public string AdministeredBy { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string RegistrationNo { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
    }

    public sealed class TreatmentDayDetailsForm : Form
    {
        public TreatmentDayDetailsForm(DateTime date, List<TreatmentScheduleData> schedules)
        {
            Text = $"Schedules for {date:MMMM dd, yyyy}";
            Width = 1150;
            Height = 500;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(22, 54, 105)
            };

            var titleLabel = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0),
                Text = $"{date:MMMM dd, yyyy}  ({schedules.Count} schedule(s))"
            };

            var closeButton = new Button
            {
                Text = "Close",
                Width = 90,
                Height = 28,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(Width - 130, 11),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            closeButton.Click += (_, __) => Close();

            topPanel.Controls.Add(closeButton);
            topPanel.Controls.Add(titleLabel);

            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false
            };

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 54, 105);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Reg. No", DataPropertyName = nameof(TreatmentScheduleData.RegistrationNo), FillWeight = 12 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Patient", DataPropertyName = nameof(TreatmentScheduleData.PatientName), FillWeight = 16 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Day", DataPropertyName = nameof(TreatmentScheduleData.ScheduleDay), FillWeight = 10 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Scheduled Date", DataPropertyName = nameof(TreatmentScheduleData.ScheduledDate), FillWeight = 12, DefaultCellStyle = { Format = "yyyy-MM-dd" } });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Biologic", DataPropertyName = nameof(TreatmentScheduleData.BiologicType), FillWeight = 12 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Item", DataPropertyName = nameof(TreatmentScheduleData.ItemName), FillWeight = 16 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Brand", DataPropertyName = nameof(TreatmentScheduleData.BrandName), FillWeight = 12 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Route", DataPropertyName = nameof(TreatmentScheduleData.Route), FillWeight = 10 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Qty", DataPropertyName = nameof(TreatmentScheduleData.QuantityUsed), FillWeight = 8, DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = nameof(TreatmentScheduleData.Status), FillWeight = 10 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Administered By", DataPropertyName = nameof(TreatmentScheduleData.AdministeredBy), FillWeight = 12 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Remarks", DataPropertyName = nameof(TreatmentScheduleData.Remarks), FillWeight = 16 });

            grid.DataSource = schedules;

            var bottomPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.White
            };

            var closeBottom = new Button
            {
                Text = "Close",
                Width = 100,
                Height = 30,
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Location = new Point(Width - 140, 10),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            closeBottom.Click += (_, __) => Close();

            bottomPanel.Controls.Add(closeBottom);

            Controls.Add(grid);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
        }
    }
}