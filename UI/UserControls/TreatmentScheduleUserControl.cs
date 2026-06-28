using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class TreatmentScheduleUserControl : UserControl
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private DateTime _currentMonth;
        private DateTime _selectedDate;
        private int _biteCaseId;
        private List<TreatmentScheduleData> _schedules = new List<TreatmentScheduleData>();

        public TreatmentScheduleUserControl()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
            _currentMonth = DateTime.Now;
            _selectedDate = DateTime.Now;
            InitializeCalendarGrid();
        }

        private void InitializeCalendarGrid()
        {
            // Clear existing day cells if any
            calendarLayoutPanel.Controls.Clear();
            calendarLayoutPanel.ColumnStyles.Clear();
            calendarLayoutPanel.RowStyles.Clear();

            // Create 7 columns for days of the week
            for (int i = 0; i < 7; i++)
            {
                calendarLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            }

            // Create rows for weekday headers + 6 weeks
            calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Weekday headers
            for (int i = 0; i < 6; i++)
            {
                calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6f));
            }

            // Add weekday header labels
            string[] weekdays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < 7; i++)
            {
                var label = new Label
                {
                    Text = weekdays[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(22, 54, 105),
                    BackColor = Color.FromArgb(240, 248, 255),
                    Dock = DockStyle.Fill
                };
                calendarLayoutPanel.Controls.Add(label, i, 0);
            }

            // Create day cells for the calendar
            for (int week = 0; week < 6; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    var dayPanel = new Panel
                    {
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new { week, day }
                    };

                    var dayLabel = new Label
                    {
                        Name = "dayLabel",
                        TextAlign = ContentAlignment.TopLeft,
                        Font = new Font("Segoe UI", 8F),
                        Padding = new Padding(2),
                        Location = new Point(2, 2),
                        AutoSize = true
                    };

                    var schedulesLabel = new Label
                    {
                        Name = "schedulesLabel",
                        TextAlign = ContentAlignment.TopLeft,
                        Font = new Font("Segoe UI", 7F),
                        Location = new Point(2, 18),
                        AutoSize = true,
                        MaximumSize = new Size(80, 100)
                    };

                    dayPanel.Controls.Add(dayLabel);
                    dayPanel.Controls.Add(schedulesLabel);
                    dayPanel.Click += DayPanel_Click;
                    dayPanel.MouseEnter += DayPanel_MouseEnter;
                    dayPanel.MouseLeave += DayPanel_MouseLeave;

                    calendarLayoutPanel.Controls.Add(dayPanel, day, week + 1);
                }
            }

            LoadCalendarData();
        }

        private void LoadCalendarData()
        {
            // Calculate first day of month and first day to display
            DateTime firstOfMonth = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            int firstDayOfWeek = (int)firstOfMonth.DayOfWeek;
            DateTime firstDayToDisplay = firstOfMonth.AddDays(-firstDayOfWeek);

            // Update month/year label
            monthYearLabel.Text = _currentMonth.ToString("MMMM yyyy");

            // Clear existing day cell contents
            for (int week = 0; week < 6; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    var control = calendarLayoutPanel.GetControlFromPosition(day, week + 1);
                    if (control is Panel dayPanel)
                    {
                        var dayLabel = dayPanel.Controls.Find("dayLabel", false).FirstOrDefault() as Label;
                        var schedulesLabel = dayPanel.Controls.Find("schedulesLabel", false).FirstOrDefault() as Label;

                        if (dayLabel != null) dayLabel.Text = "";
                        if (schedulesLabel != null) schedulesLabel.Text = "";
                        dayPanel.BackColor = Color.White;
                    }
                }
            }

            // Fill in the days
            DateTime currentDay = firstDayToDisplay;
            for (int week = 0; week < 6; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    var control = calendarLayoutPanel.GetControlFromPosition(day, week + 1);
                    if (control is Panel dayPanel)
                    {
                        var dayLabel = dayPanel.Controls.Find("dayLabel", false).FirstOrDefault() as Label;
                        var schedulesLabel = dayPanel.Controls.Find("schedulesLabel", false).FirstOrDefault() as Label;

                        if (dayLabel != null)
                        {
                            dayLabel.Text = currentDay.Day.ToString();
                            dayLabel.Tag = currentDay; // Store the date in the tag
                        }

                        // Highlight today
                        if (currentDay.Date == DateTime.Now.Date)
                        {
                            dayPanel.BackColor = Color.FromArgb(255, 255, 224);
                        }

                        // Highlight selected date
                        if (currentDay.Date == _selectedDate.Date)
                        {
                            dayPanel.BackColor = Color.FromArgb(22, 54, 105);
                            if (dayLabel != null) dayLabel.ForeColor = Color.White;
                        }
                        else if (currentDay.Month != _currentMonth.Month)
                        {
                            // Other month days
                            dayPanel.BackColor = Color.FromArgb(245, 245, 245);
                            if (dayLabel != null) dayLabel.ForeColor = Color.Gray;
                        }

                        // Load schedules for this day
                        if (schedulesLabel != null)
                        {
                            var daySchedules = _schedules.Where(s => s.ScheduledDate.Date == currentDay.Date).ToList();
                            if (daySchedules.Count > 0)
                            {
                                schedulesLabel.Text = string.Join("\n", daySchedules.Select(s => $"{s.BiologicType}"));
                            }
                        }

                        currentDay = currentDay.AddDays(1);
                    }
                }
            }
        }

        private void DayPanel_Click(object? sender, EventArgs e)
        {
            if (sender is Panel dayPanel)
            {
                var dayLabel = dayPanel.Controls.Find("dayLabel", false).FirstOrDefault() as Label;
                if (dayLabel?.Tag is DateTime clickedDate)
                {
                    _selectedDate = clickedDate;
                    LoadCalendarData();
                    ShowDayDetails(clickedDate);
                }
            }
        }

        private void DayPanel_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Panel dayPanel)
            {
                if (dayPanel.BackColor != Color.FromArgb(22, 54, 105))
                {
                    dayPanel.BackColor = Color.FromArgb(240, 248, 255);
                }
            }
        }

        private void DayPanel_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Panel dayPanel)
            {
                var dayLabel = dayPanel.Controls.Find("dayLabel", false).FirstOrDefault() as Label;
                if (dayLabel?.Tag is DateTime date)
                {
                    if (date.Date == DateTime.Now.Date)
                    {
                        dayPanel.BackColor = Color.FromArgb(255, 255, 224);
                    }
                    else if (date.Date == _selectedDate.Date)
                    {
                        dayPanel.BackColor = Color.FromArgb(22, 54, 105);
                    }
                    else if (date.Month != _currentMonth.Month)
                    {
                        dayPanel.BackColor = Color.FromArgb(245, 245, 245);
                    }
                    else
                    {
                        dayPanel.BackColor = Color.White;
                    }
                }
            }
        }

        private void ShowDayDetails(DateTime date)
        {
            var daySchedules = _schedules.Where(s => s.ScheduledDate.Date == date.Date).ToList();
            
            if (daySchedules.Count > 0)
            {
                string details = $"Schedules for {date:MMMM dd, yyyy}:\n\n";
                details += string.Join("\n\n", daySchedules.Select(s => 
                    $"Biologic: {s.BiologicType}\n" +
                    $"Status: {s.Status}\n" +
                    $"Time: {s.ScheduledDate:h:mm tt}\n" +
                    $"Remarks: {s.Remarks ?? "N/A"}"));
                
                MessageBox.Show(details, "Treatment Schedules",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No treatment schedules for {date:MMMM dd, yyyy}", "Treatment Schedules",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(-1);
            LoadCalendarData();
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(1);
            LoadCalendarData();
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            _currentMonth = DateTime.Now;
            _selectedDate = DateTime.Now;
            LoadCalendarData();
        }

        public void LoadSchedulesForBiteCase(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            _schedules.Clear();

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT 
    ts.treatment_schedule_id,
    ts.scheduled_date,
    ts.administered_date,
    ts.biologic_type,
    ts.status,
    ts.remarks
FROM treatment_schedule ts
WHERE ts.bite_case_id = @bite_case_id
ORDER BY ts.scheduled_date;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@bite_case_id", biteCaseId);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _schedules.Add(new TreatmentScheduleData
                    {
                        TreatmentScheduleId = Convert.ToInt32(reader["treatment_schedule_id"]),
                        ScheduledDate = Convert.ToDateTime(reader["scheduled_date"]),
                        AdministeredDate = reader["administered_date"] != DBNull.Value ? Convert.ToDateTime(reader["administered_date"]) : null,
                        BiologicType = reader["biologic_type"]?.ToString() ?? "N/A",
                        Status = reader["status"]?.ToString() ?? "Scheduled",
                        Remarks = reader["remarks"]?.ToString()
                    });
                }

                LoadCalendarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading treatment schedules: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class TreatmentScheduleData
        {
            public int TreatmentScheduleId { get; set; }
            public DateTime ScheduledDate { get; set; }
            public DateTime? AdministeredDate { get; set; }
            public string BiologicType { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public string? Remarks { get; set; }
        }
    }
}