using ABMS_2026.Common.Helpers;
using ABMS_2026.UI.UserControls;
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
    public partial class BiteCaseForm : Form
    {
        private readonly int _patientId;
        private int? _biteCaseId;
        private BiteCaseDetailsUserControl? _biteCaseDetailsUserControl;
        private DoctorsOrdersUserControl? _doctorsOrdersUserControl;
        private TreatmentUserControl? _treatmentUserControl;
        private BillingPaymentsUserControl? _billingPaymentsUserControl;

        public BiteCaseForm(int patientId)
        {
            _patientId = patientId;
            InitializeComponent();
        }

        private void BiteCaseForm_Load(object sender, EventArgs e)
        {
            this.Text = "New Bite Case";
            LoadPatientData();
            LoadUserControls();
        }

        private void LoadUserControls()
        {
            // Load bite case details for creating new case
            _biteCaseDetailsUserControl = new BiteCaseDetailsUserControl(_patientId, null);
            _biteCaseDetailsUserControl.BiteCaseSaved += OnBiteCaseSaved;
            UserControlLoaderHelper.Load(biteCaseDetailPanel, _biteCaseDetailsUserControl);

            // Don't load doctor orders, treatment schedules, and billing yet - will be loaded after bite case is saved
        }

        private void OnBiteCaseSaved(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            LoadDoctorOrdersForBiteCase(biteCaseId);
            LoadTreatmentSchedulesForBiteCase(biteCaseId);
            LoadBillingPaymentsForBiteCase(biteCaseId);
        }

        private void LoadDoctorOrdersForBiteCase(int biteCaseId)
        {
            _doctorsOrdersUserControl = new DoctorsOrdersUserControl(biteCaseId);
            UserControlLoaderHelper.Load(doctorsOrderPanel, _doctorsOrdersUserControl);
        }

        private void LoadTreatmentSchedulesForBiteCase(int biteCaseId)
        {
            _treatmentUserControl = new TreatmentUserControl(biteCaseId);
            UserControlLoaderHelper.Load(treatmentSchedulePanel, _treatmentUserControl);
        }

        private void LoadBillingPaymentsForBiteCase(int biteCaseId)
        {
            _billingPaymentsUserControl = new BillingPaymentsUserControl(biteCaseId);
            //UserControlLoaderHelper.Load(billingPaymentsPanel, _billingPaymentsUserControl);
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

                using (Bitmap bmp = new Bitmap(patientPictureBox.Image))
                {
                    bmp.Save(tempFile, ImageFormat.Png);
                }

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
