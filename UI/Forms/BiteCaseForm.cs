using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Shared.Components;
using ABMS_2026.UI.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class BiteCaseForm : Form
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private int _selectedPatientId;
        private int? _biteCaseId;

        public BiteCaseForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        public BiteCaseForm(int patientId)
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
            _selectedPatientId = patientId;
        }

        public BiteCaseForm(int biteCaseId, bool isEditMode)
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
            _biteCaseId = biteCaseId;
            LoadPatient(biteCaseId);
        }

        private void BiteCaseForm_Load(object sender, EventArgs e)
        {
            if (_biteCaseId.HasValue)
            {
                // Edit mode - patient ID was loaded in constructor
                LoadPatientInfo(_selectedPatientId);
                LoadTabPages(true);
            }
            else
            {
                // Create mode - clear and load provided patient
                ClearPatientInfo();
                LoadPatientInfo(_selectedPatientId);
                LoadTabPages(false);
            }
        }

        private void LoadTabPages(bool isEditMode)
        {
            var upsertControl = new UpsertBiteCaseUserControl();
            
            var context = new ModuleRecordContext
            {
                IsEditMode = isEditMode,
                SourceName = "bite_cases",
                TargetTableName = "bite_cases",
                PrimaryKeyColumn = "bite_case_id",
                PrimaryKeyValue = _biteCaseId,
                Values = new Dictionary<string, object?>
                {
                    { "patient_id", _selectedPatientId }
                }
            };
            
            upsertControl.LoadModuleRecord(context);
            UserControlLoaderHelper.Load(exposureDetailsTabPage, upsertControl);
        }

        private void patientPickerButton_Click(object sender, EventArgs e)
        {
            using (var pickerForm = new PatientPickerForm())
            {
                if (pickerForm.ShowDialog() == DialogResult.OK)
                {
                    _selectedPatientId = pickerForm.SelectedPatientId;
                    patientTextBox.Text = pickerForm.SelectedPatientName;
                    LoadPatientInfo(_selectedPatientId);
                }
            }
        }

        private void LoadPatient(int biteCaseId)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                const string sql = @"
SELECT
    bite_case_id,
    patient_id
FROM v_bite_case_details
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

                using MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@bite_case_id", biteCaseId);

                using MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Patient record not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _selectedPatientId = Convert.ToInt32(reader["patient_id"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load patient.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPatientInfo(int patientId)
        {
            try
            {
                using (var connection = _connectionHelper.GetConnection())
                {
                    connection.Open();

                    const string sql = @"
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
    image
FROM v_patients
WHERE patient_id = @patient_id
LIMIT 1;";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@patient_id", patientId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Update labels with patient information
                                addressLabel.Text = $"Address: {reader["address"]?.ToString() ?? "N/A"}";
                                registrationLabel.Text = $"Reg No: {reader["registration_no"]?.ToString() ?? "N/A"}";
                                
                                if (reader["birth_date"] != DBNull.Value)
                                {
                                    DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                                    birthDateLabel.Text = $"Birth: {birthDate:yyyy-MM-dd}";
                                }
                                else
                                {
                                    birthDateLabel.Text = "Birth: N/A";
                                }

                                civilStatusLabel.Text = $"Civil Status: {reader["civil_status"]?.ToString() ?? "N/A"}";
                                contactLabel.Text = $"Contact: {reader["contact_no"]?.ToString() ?? "N/A"}";
                                ageLabel.Text = $"Age: {reader["age"]?.ToString() ?? "0"}";
                                sexLabel.Text = $"Sex: {reader["sex"]?.ToString() ?? "N/A"}";

                                // Load patient image
                                LoadPatientImage(reader["image"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load patient information.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadPatientImage(object imageValue)
        {
            if (imageValue == DBNull.Value || imageValue == null)
            {
                // Clear existing image
                if (patientImagePictureBox.Image != null)
                {
                    var oldImage = patientImagePictureBox.Image;
                    patientImagePictureBox.Image = null;
                    oldImage.Dispose();
                }
                return;
            }

            try
            {
                byte[] imageBytes = (byte[])imageValue;
                using (var ms = new MemoryStream(imageBytes))
                {
                    using (var tempImage = Image.FromStream(ms))
                    {
                        // Dispose old image
                        if (patientImagePictureBox.Image != null)
                        {
                            var oldImage = patientImagePictureBox.Image;
                            patientImagePictureBox.Image = null;
                            oldImage.Dispose();
                        }

                        // Set new image
                        patientImagePictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load patient image.\n\n{ex.Message}",
                    "Image Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void ClearPatientInfo()
        {
            patientTextBox.Clear();
            addressLabel.Text = "Address: -";
            registrationLabel.Text = "Reg No: -";
            birthDateLabel.Text = "Birth: -";
            civilStatusLabel.Text = "Civil Status: -";
            contactLabel.Text = "Contact: -";
            ageLabel.Text = "Age: 0";
            sexLabel.Text = "Sex: -";

            // Clear patient image
            if (patientImagePictureBox.Image != null)
            {
                var oldImage = patientImagePictureBox.Image;
                patientImagePictureBox.Image = null;
                oldImage.Dispose();
            }
        }
    }
}
