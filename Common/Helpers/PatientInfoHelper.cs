using System;
using MySql.Data.MySqlClient;
using ABMS_2026.Data.MySql;

namespace ABMS_2026.Common.Helpers
{
    internal static class PatientInfoHelper
    {
        public class PatientInfo
        {
            public int PatientId { get; set; }

            public string RegistrationNo { get; set; }

            public string LastName { get; set; }

            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public DateTime? BirthDate { get; set; }

            public int? Age { get; set; }

            public string Sex { get; set; }

            public string CivilStatus { get; set; }

            public string Address { get; set; }

            public string ContactNo { get; set; }

            public decimal? Weight { get; set; }

            public DateTime? CreatedAt { get; set; }

            /// <summary>
            /// Patient image stored as LONGBLOB.
            /// </summary>
            public byte[] Image { get; set; }

            public string FullName
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(MiddleName))
                        return $"{LastName}, {FirstName}";

                    return $"{LastName}, {FirstName} {MiddleName}";
                }
            }
        }

        public static PatientInfo GetPatient(int patientId)
        {
            const string query = @"
SELECT
    patient_id,
    registration_no,
    last_name,
    first_name,
    middle_name,
    birth_date,
    age,
    sex,
    civil_status,
    address,
    contact_no,
    weight,
    created_at,
    image
FROM patients
WHERE patient_id = @patient_id
LIMIT 1;";

            using var connection = new MySqlConnectionHelper().GetConnection();

            connection.Open();

            using var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@patient_id", patientId);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new PatientInfo
            {
                PatientId = Convert.ToInt32(reader["patient_id"]),
                RegistrationNo = reader["registration_no"]?.ToString(),
                LastName = reader["last_name"]?.ToString(),
                FirstName = reader["first_name"]?.ToString(),
                MiddleName = reader["middle_name"]?.ToString(),

                BirthDate = reader["birth_date"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["birth_date"]),

                Age = reader["age"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(reader["age"]),

                Sex = reader["sex"]?.ToString(),

                CivilStatus = reader["civil_status"]?.ToString(),

                Address = reader["address"]?.ToString(),

                ContactNo = reader["contact_no"]?.ToString(),

                Weight = reader["weight"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(reader["weight"]),

                CreatedAt = reader["created_at"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["created_at"]),

                Image = reader["image"] == DBNull.Value
                    ? null
                    : (byte[])reader["image"]
            };
        }
    }
}