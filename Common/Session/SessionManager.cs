namespace ABMS_2026.Common.Session
{
    public static class SessionManager
    {
        public static int UserId { get; set; }

        public static string Username { get; set; } =
            string.Empty;

        public static string FullName { get; set; } =
            string.Empty;

        public static bool IsLoggedIn =>
            UserId > 0;

        public static void Clear()
        {
            UserId = 0;
            Username = string.Empty;
            FullName = string.Empty;
        }
    }
}