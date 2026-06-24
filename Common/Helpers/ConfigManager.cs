using System;
using System.IO;
using System.Text.Json;
using MySql.Data.MySqlClient;

namespace ABMS_2026.Common.Helpers
{
    public static class ConfigManager
    {
        private static readonly string ConfigPath =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "database.config.json");

        public static string GetConnectionString()
        {
            if (!File.Exists(ConfigPath))
            {
                return string.Empty;
            }

            string json = File.ReadAllText(ConfigPath);

            var config =
                JsonSerializer.Deserialize<DatabaseConfig>(json);

            return config?.ConnectionString ?? string.Empty;
        }

        public static void SaveConnectionString(string connectionString)
        {
            var config = new DatabaseConfig
            {
                ConnectionString = connectionString
            };

            string json = JsonSerializer.Serialize(
                config,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(ConfigPath, json);
        }

        public static bool TestConnection(string connectionString)
        {
            try
            {
                using var connection =
                    new MySqlConnection(connectionString);

                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
    }
}