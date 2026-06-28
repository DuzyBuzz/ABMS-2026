using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class EditBiteCaseForm : Form
    {
        private readonly int _biteCaseId;
        private int _patientId;
        private int? _doctorOrderId;
        private BiteCaseDetailsUserControl? _biteCaseDetailsUserControl;
        private DoctorsOrdersUserControl? _doctorsOrdersUserControl;
        private TreatmentUserControl? _treatmentUserControl;
        private readonly MySqlConnectionHelper _connectionHelper;

        public EditBiteCaseForm(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            _connectionHelper = new MySqlConnectionHelper();
            InitializeComponent();
        }

        private void EditBiteCaseForm_Load(object sender, EventArgs e)
        {
            this.Text = "Edit Bite Case";
            LoadPatientIdFromBiteCase();
            LoadDoctorOrderIdFromBiteCase();
            LoadPatientData();
            LoadUserControls();
        }

        private void LoadPatientIdFromBiteCase()
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT patient_id
FROM bite_cases
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    _patientId = Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Patient not found for this bite case.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient ID: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LoadDoctorOrderIdFromBiteCase()
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string query = @"
SELECT doctor_order_id
FROM doctor_orders
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    _doctorOrderId = Convert.ToInt32(result);
                }
                else
                {
                    _doctorOrderId = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor order ID: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _doctorOrderId = null;
            }
        }

        private void LoadUserControls()
        {
            // Load bite case details for editing
            _biteCaseDetailsUserControl = new BiteCaseDetailsUserControl(_patientId, _biteCaseId);
            UserControlLoaderHelper.Load(biteCaseDetailPanel, _biteCaseDetailsUserControl);

            // Load doctor orders with existing doctor order ID if available
            _doctorsOrdersUserControl = new DoctorsOrdersUserControl(_biteCaseId, _doctorOrderId);
            UserControlLoaderHelper.Load(doctorsOrderPanel, _doctorsOrdersUserControl);

            // Load treatment schedules
            _treatmentUserControl = new TreatmentUserControl(_biteCaseId);
            UserControlLoaderHelper.Load(treatmentSchedulePanel, _treatmentUserControl);
        }

        private void LoadPatientData()
        {
            var patient = PatientInfoHelper.GetPatient(_patientId);

            if (patient != null)
            {
                patientNameLabel.Text = "Patient: " + patient.FullName.ToUpper();
                ageLabel.Text = "Age: " + patient.Age?.ToString();
                sexLabel.Text = "Sex: " + patient.Sex;
                statusLabel.Text = "Status: " + patient.CivilStatus;
                addressLabel.Text = "Address: " + patient.Address;
                contactNoLabel.Text = "Contact No: " + patient.ContactNo;
                weightLabel.Text = "Weight: " + patient.Weight?.ToString();

                if (patient.Image != null)
                {
                    using var ms = new MemoryStream(patient.Image);
                    patientPictureBox.Image = Image.FromStream(ms);
                }
                else
                {
                    patientPictureBox.Image = null;
                }
            }
        }

        private void patientPictureBox_Click(object sender, EventArgs e)
        {
            if (patientPictureBox.Image == null)
            {
                MessageBox.Show(
                    "No image available.",
                    "Patient Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                string tempFile = Path.Combine(
                    Path.GetTempPath(),
                    $"ABMS_Patient_{Guid.NewGuid()}.png");

                patientPictureBox.Image.Save(tempFile, ImageFormat.Png);

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to open image.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
