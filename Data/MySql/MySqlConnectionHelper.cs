using MySql.Data.MySqlClient;
using ABMS_2026.Common.Helpers;

namespace ABMS_2026.Data.MySql
{
    public class MySqlConnectionHelper
    {
        private readonly string? _connectionString;

        public MySqlConnectionHelper()
        {
        }

        public MySqlConnectionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            string connectionString =
                string.IsNullOrWhiteSpace(_connectionString)
                ? ConfigManager.GetConnectionString()
                : _connectionString;

            return new MySqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using var connection = GetConnection();

                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}