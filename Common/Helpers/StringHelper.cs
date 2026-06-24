using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ABMS_2026.Common.Helpers
{
    public static class StringHelper
    {
        public static string GenerateRegistrationNumber()
        {
            var year = DateTime.Now.Year.ToString();
            var random = new Random();
            var sequence = random.Next(10000, 99999).ToString();
            return $"{year}-{sequence}";
        }

        public static string GenerateCaseNumber()
        {
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString("D2");
            var random = new Random();
            var sequence = random.Next(1000, 9999).ToString();
            return $"ABC-{year}{month}-{sequence}";
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Basic validation for phone numbers (adjust based on local requirements)
            return Regex.IsMatch(phoneNumber, @"^[\d\s\-\+\(\)]+$");
        }

        public static string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return phoneNumber;

            var digits = Regex.Replace(phoneNumber, @"[^\d]", "");
            
            if (digits.Length == 11 && digits.StartsWith("0"))
            {
                return $"{digits.Substring(0, 4)}-{digits.Substring(4, 3)}-{digits.Substring(7, 4)}";
            }

            return phoneNumber;
        }
    }
}