using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class BiteCaseViewForm : Form
    {
        private int _biteCaseId;

        public BiteCaseViewForm()
        {
            InitializeComponent();
        }

        public void LoadBiteCase(MySqlDataReader reader)
        {
            try
            {
                // Basic information
                _biteCaseId = Convert.ToInt32(reader["bite_case_id"]);
                int patientId = Convert.ToInt32(reader["patient_id"]);
                string registrationNo = reader["registration_no"]?.ToString() ?? "N/A";
                string patientName = $"{reader["last_name"]}, {reader["first_name"]}";
                if (reader["middle_name"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["middle_name"].ToString()))
                {
                    patientName += $" {reader["middle_name"]?.ToString()?.Substring(0, 1)}.";
                }

                biteCaseIdLabel.Text = $"Bite Case ID: {_biteCaseId}";
                patientIdLabel.Text = $"Patient ID: {patientId}";
                registrationNoLabel.Text = $"Registration No: {registrationNo}";
                patientNameLabel.Text = $"Patient Name: {patientName}";

                // Exposure details
                if (reader["exposure_date"] != DBNull.Value)
                {
                    DateTime exposureDate = Convert.ToDateTime(reader["exposure_date"]);
                    exposureDateLabel.Text = $"Exposure Date: {exposureDate:yyyy-MM-dd}";
                }
                else
                {
                    exposureDateLabel.Text = "Exposure Date: N/A";
                }

                incidentPlaceLabel.Text = $"Incident Place: {reader["incident_place"]?.ToString() ?? "N/A"}";
                animalTypeLabel.Text = $"Animal Type: {reader["animal_type"]?.ToString() ?? "N/A"}";
                animalClassificationLabel.Text = $"Animal Classification: {reader["animal_classification"]?.ToString() ?? "N/A"}";
                animalStatusLabel.Text = $"Animal Status: {reader["animal_status"]?.ToString() ?? "N/A"}";

                // Wound details
                isWoundWashedLabel.Text = $"Wound Washed: {(reader["is_wound_washed"] != DBNull.Value && Convert.ToBoolean(reader["is_wound_washed"]) ? "Yes" : "No")}";
                woundTypeLabel.Text = $"Wound Type: {reader["wound_type"]?.ToString() ?? "N/A"}";
                woundCountLabel.Text = $"Wound Count: {reader["wound_count"]?.ToString() ?? "N/A"}";
                woundClassificationLabel.Text = $"Wound Classification: {reader["wound_classification"]?.ToString() ?? "N/A"}";
                biteLocationsLabel.Text = $"Bite Locations: {reader["bite_locations"]?.ToString() ?? "N/A"}";

                // Additional patient info
                if (reader["birth_date"] != DBNull.Value)
                {
                    DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                    birthDateLabel.Text = $"Birth Date: {birthDate:yyyy-MM-dd}";
                }
                else
                {
                    birthDateLabel.Text = "Birth Date: N/A";
                }

                ageLabel.Text = $"Age: {reader["age"]?.ToString() ?? "N/A"}";
                sexLabel.Text = $"Sex: {reader["sex"]?.ToString() ?? "N/A"}";
                civilStatusLabel.Text = $"Civil Status: {reader["civil_status"]?.ToString() ?? "N/A"}";
                addressLabel.Text = $"Address: {reader["address"]?.ToString() ?? "N/A"}";
                contactLabel.Text = $"Contact: {reader["contact_no"]?.ToString() ?? "N/A"}";
                weightLabel.Text = $"Weight: {reader["weight"]?.ToString() ?? "N/A"}";

                // Load bite chart if available
                LoadBiteChart(reader["bite_chart_path"]?.ToString());

                // Load treatment schedules
                treatmentScheduleUserControl.LoadSchedulesForBiteCase(_biteCaseId);

                this.Text = $"Bite Case Details - {patientName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bite case data: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadBiteCaseById(int biteCaseId)
        {
            try
            {
                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                const string query = @"
SELECT 
    bc.bite_case_id,
    bc.patient_id,
    p.registration_no,
    p.last_name,
    p.first_name,
    p.middle_name,
    p.birth_date,
    timestampdiff(YEAR, p.birth_date, curdate()) AS age,
    p.sex,
    p.civil_status,
    p.address,
    p.contact_no,
    p.weight,
    bc.exposure_date,
    bc.incident_place,
    bc.animal_type,
    bc.animal_classification,
    bc.animal_status,
    bc.is_wound_washed,
    bc.wound_type,
    bc.wound_count,
    bc.wound_classification,
    bc.bite_locations,
    bc.bite_chart_path
FROM bite_cases bc
JOIN patients p ON bc.patient_id = p.patient_id
WHERE bc.bite_case_id = @bite_case_id
LIMIT 1;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@bite_case_id", biteCaseId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LoadBiteCase(reader);
                }
                else
                {
                    MessageBox.Show("Bite case not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bite case: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBiteChart(string? chartPath)
        {
            if (string.IsNullOrWhiteSpace(chartPath))
            {
                // Hide chart panel if no chart
                chartPanel.Visible = false;
                treatmentScheduleGroupBox.Visible = true;
                return;
            }

            try
            {
                // Check if path is relative or absolute
                string fullPath;
                if (Path.IsPathRooted(chartPath))
                {
                    fullPath = chartPath;
                }
                else
                {
                    // Relative path - combine with application directory
                    string appDirectory = Application.StartupPath;
                    fullPath = Path.Combine(appDirectory, chartPath);
                }

                if (File.Exists(fullPath))
                {
                    using (var tempImage = Image.FromFile(fullPath))
                    {
                        biteChartPictureBox.Image = new Bitmap(tempImage);
                    }
                    chartPanel.Visible = true;
                    treatmentScheduleGroupBox.Visible = true;
                }
                else
                {
                    chartPanel.Visible = false;
                    treatmentScheduleGroupBox.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bite chart: {ex.Message}", "Image Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chartPanel.Visible = false;
                treatmentScheduleGroupBox.Visible = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}