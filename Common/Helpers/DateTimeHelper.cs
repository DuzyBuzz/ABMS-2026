using System;

namespace ABMS_2026.Common.Helpers
{
    public static class DateTimeHelper
    {
        public static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            
            if (today.DayOfYear < birthDate.DayOfYear)
            {
                age--;
            }
            
            return age;
        }

        public static DateTime GetVaccinationDate(DateTime baseDate, int dayOffset)
        {
            return baseDate.AddDays(dayOffset);
        }

        public static bool IsOverdue(DateTime scheduledDate, DateTime actualDate)
        {
            return actualDate > scheduledDate;
        }

        public static int GetDaysOverdue(DateTime scheduledDate, DateTime actualDate)
        {
            if (actualDate <= scheduledDate)
                return 0;
            
            return (int)(actualDate - scheduledDate).TotalDays;
        }

        public static bool IsVaccinationDueToday(DateTime scheduledDate)
        {
            return scheduledDate.Date == DateTime.Today;
        }

        public static bool IsVaccinationUpcoming(DateTime scheduledDate)
        {
            return scheduledDate.Date > DateTime.Today;
        }

        public static string GetDateRangeDisplay(DateTime startDate, DateTime endDate)
        {
            if (startDate == endDate)
                return startDate.ToString("MMM dd, yyyy");
            
            return $"{startDate.ToString("MMM dd, yyyy")} - {endDate.ToString("MMM dd, yyyy")}";
        }

        public static DateTime GetDefaultStartOfMonth()
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        }

        public static DateTime GetDefaultEndOfMonth()
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        }
    }
}