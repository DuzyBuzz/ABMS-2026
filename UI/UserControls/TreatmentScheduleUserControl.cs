using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class TreatmentScheduleUserControl : UserControl
    {
        private readonly MySqlConnectionHelper _connectionHelper;

        private DateTime _currentMonth;
        private DateTime _selectedDate;
        private int _biteCaseId;

        private readonly List<TreatmentScheduleData> _schedules = new();
        private Dictionary<DateTime, List<TreatmentScheduleData>> _schedulesByDate = new();
        private readonly List<CalendarCell> _cells = new();

        private static readonly Color HeaderBlue = Color.FromArgb(22, 54, 105);
        private static readonly Color HeaderLight = Color.FromArgb(240, 248, 255);
        private static readonly Color TodayColor = Color.FromArgb(255, 255, 224);
        private static readonly Color SelectedColor = Color.FromArgb(22, 54, 105);
        private static readonly Color OtherMonthColor = Color.FromArgb(245, 245, 245);

        public TreatmentScheduleUserControl()
        {
            InitializeComponent();

            _connectionHelper = new MySqlConnectionHelper();
            _currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _selectedDate = DateTime.Today;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            InitializeCalendarGrid();
        }

        public TreatmentScheduleUserControl(int biteCaseId) : this()
        {
            _biteCaseId = biteCaseId;
            LoadSchedulesForBiteCase(biteCaseId);
        }

        public void SetBiteCaseId(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            LoadSchedulesForBiteCase(biteCaseId);
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
            {
                calendarLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7f));
            }

            calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            for (int i = 0; i < 6; i++)
            {
                calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6f));
            }

            string[] weekdays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            for (int i = 0; i < 7; i++)
            {
                var label = new Label
                {
                    Text = weekdays[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = HeaderBlue,
                    BackColor = HeaderLight,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                };

                calendarLayoutPanel.Controls.Add(label, i, 0);
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
            RenderCalendar();
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
                Padding = new Padding(2, 1, 2, 0),
                BackColor = Color.Transparent
            };

            var detailsLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 7F, FontStyle.Regular),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(2, 0, 2, 2),
                BackColor = Color.Transparent
            };

            panel.Controls.Add(detailsLabel);
            panel.Controls.Add(dayLabel);

            var cell = new CalendarCell
            {
                Panel = panel,
                DayLabel = dayLabel,
                DetailsLabel = detailsLabel,
                Date = DateTime.MinValue
            };

            panel.Tag = cell;
            dayLabel.Tag = cell;
            detailsLabel.Tag = cell;

            panel.Click += CalendarCell_Click;
            dayLabel.Click += CalendarCell_Click;
            detailsLabel.Click += CalendarCell_Click;

            panel.MouseEnter += CalendarCell_MouseEnter;
            panel.MouseLeave += CalendarCell_MouseLeave;
            dayLabel.MouseEnter += CalendarCell_MouseEnter;
            dayLabel.MouseLeave += CalendarCell_MouseLeave;
            detailsLabel.MouseEnter += CalendarCell_MouseEnter;
            detailsLabel.MouseLeave += CalendarCell_MouseLeave;

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
                cell.DetailsLabel.Text = string.Empty;
                cell.DayLabel.ForeColor = Color.Black;
                cell.DetailsLabel.ForeColor = Color.Black;

                ApplyCellStyle(cell, currentDay);

                if (_schedulesByDate.TryGetValue(currentDay.Date, out var daySchedules) && daySchedules.Count > 0)
                {
                    cell.DetailsLabel.Text = BuildCellSummary(daySchedules);

                    if (currentDay.Date == _selectedDate.Date)
                    {
                        cell.DetailsLabel.ForeColor = Color.White;
                    }
                }

                if (currentDay.Date == _selectedDate.Date)
                {
                    cell.DayLabel.ForeColor = Color.White;
                    cell.DetailsLabel.ForeColor = Color.White;
                }
            }
        }

        private void ApplyCellStyle(CalendarCell cell, DateTime date)
        {
            if (date.Date == _selectedDate.Date)
            {
                cell.Panel.BackColor = SelectedColor;
                cell.DayLabel.ForeColor = Color.White;
                cell.DetailsLabel.ForeColor = Color.White;
            }
            else if (date.Date == DateTime.Today)
            {
                cell.Panel.BackColor = TodayColor;
                cell.DayLabel.ForeColor = Color.Black;
                cell.DetailsLabel.ForeColor = Color.Black;
            }
            else if (date.Month != _currentMonth.Month)
            {
                cell.Panel.BackColor = OtherMonthColor;
                cell.DayLabel.ForeColor = Color.Gray;
                cell.DetailsLabel.ForeColor = Color.DimGray;
            }
            else
            {
                cell.Panel.BackColor = Color.White;
                cell.DayLabel.ForeColor = Color.Black;
                cell.DetailsLabel.ForeColor = Color.Black;
            }
        }

        private string BuildCellSummary(List<TreatmentScheduleData> schedules)
        {
            var lines = new List<string>();

            foreach (var schedule in schedules.Take(2))
            {
                string text = schedule.DisplayItemName;

                if (!string.IsNullOrWhiteSpace(schedule.Route))
                    text += $" ({schedule.Route})";

                lines.Add(text);
            }

            if (schedules.Count > 2)
            {
                lines.Add($"+{schedules.Count - 2} more");
            }

            return string.Join(Environment.NewLine, lines);
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
            {
                cell.Panel.BackColor = Color.FromArgb(240, 248, 255);
            }
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
            if (!_schedulesByDate.TryGetValue(date.Date, out var daySchedules) || daySchedules.Count == 0)
            {
                MessageBox.Show(
                    $"No treatment schedules for {date:MMMM dd, yyyy}",
                    "Treatment Schedules",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Schedules for {date:MMMM dd, yyyy}");
            sb.AppendLine();

            foreach (var s in daySchedules)
            {
                sb.AppendLine($"Day: {s.ScheduleDay}");
                sb.AppendLine($"Biologic: {s.BiologicType}");
                sb.AppendLine($"Item: {s.DisplayItemName}");
                sb.AppendLine($"Route: {s.Route}");
                sb.AppendLine($"Status: {s.Status}");

                if (s.ScheduledDate != DateTime.MinValue)
                    sb.AppendLine($"Scheduled: {s.ScheduledDate:yyyy-MM-dd}");

                if (s.AdministeredDate.HasValue)
                    sb.AppendLine($"Administered: {s.AdministeredDate:yyyy-MM-dd}");

                if (!string.IsNullOrWhiteSpace(s.AdministeredBy))
                    sb.AppendLine($"Administered By: {s.AdministeredBy}");

                if (!string.IsNullOrWhiteSpace(s.Remarks))
                    sb.AppendLine($"Remarks: {s.Remarks}");

                sb.AppendLine(new string('-', 40));
            }

            MessageBox.Show(
                sb.ToString(),
                "Treatment Schedules",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(-1);
            RenderCalendar();
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(1);
            RenderCalendar();
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            _currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _selectedDate = DateTime.Today;
            RenderCalendar();
        }

        public void LoadSchedulesForBiteCase(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            _schedules.Clear();
            _schedulesByDate.Clear();

            if (_biteCaseId <= 0)
            {
                RenderCalendar();
                return;
            }

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                const string sql = @"
SELECT
    treatment_schedule_id,
    bite_case_id,
    schedule_day,
    scheduled_date,
    administered_date,
    biologic_type,
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
    route,
    created_at
FROM v_treatment_schedule
WHERE bite_case_id = @bite_case_id
ORDER BY
    FIELD(schedule_day, 'Day 0', 'Day 3', 'Day 7', 'Day 14', 'Day 28', 'Booster'),
    scheduled_date;";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var schedule = new TreatmentScheduleData
                    {
                        TreatmentScheduleId = reader["treatment_schedule_id"] != DBNull.Value
                            ? Convert.ToInt32(reader["treatment_schedule_id"])
                            : 0,

                        BiteCaseId = reader["bite_case_id"] != DBNull.Value
                            ? Convert.ToInt32(reader["bite_case_id"])
                            : 0,

                        ScheduleDay = reader["schedule_day"]?.ToString() ?? string.Empty,

                        ScheduledDate = reader["scheduled_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["scheduled_date"])
                            : DateTime.MinValue,

                        AdministeredDate = reader["administered_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["administered_date"])
                            : (DateTime?)null,

                        BiologicType = reader["biologic_type"]?.ToString() ?? string.Empty,

                        ItemId = reader["item_id"] != DBNull.Value
                            ? Convert.ToInt64(reader["item_id"])
                            : (long?)null,

                        GenericName = reader["generic_name"]?.ToString() ?? string.Empty,
                        BrandName = reader["brand_name"]?.ToString() ?? string.Empty,
                        ItemName = reader["item_name"]?.ToString() ?? string.Empty,
                        Category = reader["category"]?.ToString() ?? string.Empty,
                        Strength = reader["strength"]?.ToString() ?? string.Empty,
                        DosageForm = reader["dosage_form"]?.ToString() ?? string.Empty,
                        Unit = reader["unit"]?.ToString() ?? string.Empty,

                        QuantityUsed = reader["quantity_used"] != DBNull.Value
                            ? Convert.ToDecimal(reader["quantity_used"])
                            : (decimal?)null,

                        Status = reader["status"]?.ToString() ?? string.Empty,
                        AdministeredBy = reader["administered_by"]?.ToString() ?? string.Empty,
                        Remarks = reader["remarks"]?.ToString() ?? string.Empty,
                        Route = reader["route"]?.ToString() ?? string.Empty
                    };

                    _schedules.Add(schedule);
                }

                _schedulesByDate = _schedules
                    .Where(s => s.ScheduledDate != DateTime.MinValue)
                    .GroupBy(s => s.ScheduledDate.Date)
                    .ToDictionary(g => g.Key, g => g.ToList());

                RenderCalendar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading treatment schedules: {ex.Message}",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private sealed class CalendarCell
        {
            public Panel Panel { get; set; } = null!;
            public Label DayLabel { get; set; } = null!;
            public Label DetailsLabel { get; set; } = null!;
            public DateTime Date { get; set; }
        }

        private sealed class TreatmentScheduleData
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

            public string DisplayItemName
            {
                get
                {
                    if (!string.IsNullOrWhiteSpace(BrandName) && !string.IsNullOrWhiteSpace(GenericName))
                        return $"{BrandName} ({GenericName})";

                    if (!string.IsNullOrWhiteSpace(BrandName))
                        return BrandName;

                    if (!string.IsNullOrWhiteSpace(GenericName))
                        return GenericName;

                    if (!string.IsNullOrWhiteSpace(ItemName))
                        return ItemName;

                    return !string.IsNullOrWhiteSpace(BiologicType) ? BiologicType : "N/A";
                }
            }
        }
    }
}