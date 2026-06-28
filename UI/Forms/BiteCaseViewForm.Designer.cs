using System.Drawing;
using System.Windows.Forms;
using ABMS_2026.UI.UserControls;

namespace ABMS_2026.UI.Forms
{
    partial class BiteCaseViewForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formTitleLabel = new Label();
            this.basicInfoGroupBox = new GroupBox();
            this.patientNameLabel = new Label();
            this.registrationNoLabel = new Label();
            this.patientIdLabel = new Label();
            this.biteCaseIdLabel = new Label();
            this.exposureDetailsGroupBox = new GroupBox();
            this.animalStatusLabel = new Label();
            this.animalClassificationLabel = new Label();
            this.animalTypeLabel = new Label();
            this.incidentPlaceLabel = new Label();
            this.exposureDateLabel = new Label();
            this.woundDetailsGroupBox = new GroupBox();
            this.biteLocationsLabel = new Label();
            this.woundClassificationLabel = new Label();
            this.woundCountLabel = new Label();
            this.woundTypeLabel = new Label();
            this.isWoundWashedLabel = new Label();
            this.patientInfoGroupBox = new GroupBox();
            this.weightLabel = new Label();
            this.contactLabel = new Label();
            this.addressLabel = new Label();
            this.civilStatusLabel = new Label();
            this.sexLabel = new Label();
            this.ageLabel = new Label();
            this.birthDateLabel = new Label();
            this.chartPanel = new Panel();
            this.biteChartPictureBox = new PictureBox();
            this.closeButton = new Button();
            this.treatmentScheduleGroupBox = new GroupBox();
            this.treatmentScheduleUserControl = new TreatmentScheduleUserControl();
            this.basicInfoGroupBox.SuspendLayout();
            this.exposureDetailsGroupBox.SuspendLayout();
            this.woundDetailsGroupBox.SuspendLayout();
            this.patientInfoGroupBox.SuspendLayout();
            this.chartPanel.SuspendLayout();
            this.treatmentScheduleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biteChartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.formTitleLabel.ForeColor = Color.FromArgb(22, 54, 105);
            this.formTitleLabel.Location = new Point(20, 20);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new Size(200, 30);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "BITE CASE DETAILS";
            // 
            // basicInfoGroupBox
            // 
            this.basicInfoGroupBox.Controls.Add(this.patientNameLabel);
            this.basicInfoGroupBox.Controls.Add(this.registrationNoLabel);
            this.basicInfoGroupBox.Controls.Add(this.patientIdLabel);
            this.basicInfoGroupBox.Controls.Add(this.biteCaseIdLabel);
            this.basicInfoGroupBox.Location = new Point(20, 60);
            this.basicInfoGroupBox.Name = "basicInfoGroupBox";
            this.basicInfoGroupBox.Size = new Size(560, 120);
            this.basicInfoGroupBox.TabIndex = 1;
            this.basicInfoGroupBox.TabStop = false;
            this.basicInfoGroupBox.Text = "Basic Information";
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.AutoSize = true;
            this.patientNameLabel.Location = new Point(20, 85);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new Size(95, 15);
            this.patientNameLabel.TabIndex = 3;
            this.patientNameLabel.Text = "Patient Name: N/A";
            // 
            // registrationNoLabel
            // 
            this.registrationNoLabel.AutoSize = true;
            this.registrationNoLabel.Location = new Point(20, 65);
            this.registrationNoLabel.Name = "registrationNoLabel";
            this.registrationNoLabel.Size = new Size(126, 15);
            this.registrationNoLabel.TabIndex = 2;
            this.registrationNoLabel.Text = "Registration No: N/A";
            // 
            // patientIdLabel
            // 
            this.patientIdLabel.AutoSize = true;
            this.patientIdLabel.Location = new Point(300, 45);
            this.patientIdLabel.Name = "patientIdLabel";
            this.patientIdLabel.Size = new Size(89, 15);
            this.patientIdLabel.TabIndex = 1;
            this.patientIdLabel.Text = "Patient ID: N/A";
            // 
            // biteCaseIdLabel
            // 
            this.biteCaseIdLabel.AutoSize = true;
            this.biteCaseIdLabel.Location = new Point(20, 45);
            this.biteCaseIdLabel.Name = "biteCaseIdLabel";
            this.biteCaseIdLabel.Size = new Size(117, 15);
            this.biteCaseIdLabel.TabIndex = 0;
            this.biteCaseIdLabel.Text = "Bite Case ID: N/A";
            // 
            // exposureDetailsGroupBox
            // 
            this.exposureDetailsGroupBox.Controls.Add(this.animalStatusLabel);
            this.exposureDetailsGroupBox.Controls.Add(this.animalClassificationLabel);
            this.exposureDetailsGroupBox.Controls.Add(this.animalTypeLabel);
            this.exposureDetailsGroupBox.Controls.Add(this.incidentPlaceLabel);
            this.exposureDetailsGroupBox.Controls.Add(this.exposureDateLabel);
            this.exposureDetailsGroupBox.Location = new Point(600, 60);
            this.exposureDetailsGroupBox.Name = "exposureDetailsGroupBox";
            this.exposureDetailsGroupBox.Size = new Size(560, 120);
            this.exposureDetailsGroupBox.TabIndex = 2;
            this.exposureDetailsGroupBox.TabStop = false;
            this.exposureDetailsGroupBox.Text = "Exposure Details";
            // 
            // animalStatusLabel
            // 
            this.animalStatusLabel.AutoSize = true;
            this.animalStatusLabel.Location = new Point(20, 85);
            this.animalStatusLabel.Name = "animalStatusLabel";
            this.animalStatusLabel.Size = new Size(112, 15);
            this.animalStatusLabel.TabIndex = 4;
            this.animalStatusLabel.Text = "Animal Status: N/A";
            // 
            // animalClassificationLabel
            // 
            this.animalClassificationLabel.AutoSize = true;
            this.animalClassificationLabel.Location = new Point(20, 65);
            this.animalClassificationLabel.Name = "animalClassificationLabel";
            this.animalClassificationLabel.Size = new Size(157, 15);
            this.animalClassificationLabel.TabIndex = 3;
            this.animalClassificationLabel.Text = "Animal Classification: N/A";
            // 
            // animalTypeLabel
            // 
            this.animalTypeLabel.AutoSize = true;
            this.animalTypeLabel.Location = new Point(20, 45);
            this.animalTypeLabel.Name = "animalTypeLabel";
            this.animalTypeLabel.Size = new Size(94, 15);
            this.animalTypeLabel.TabIndex = 2;
            this.animalTypeLabel.Text = "Animal Type: N/A";
            // 
            // incidentPlaceLabel
            // 
            this.incidentPlaceLabel.AutoSize = true;
            this.incidentPlaceLabel.Location = new Point(300, 45);
            this.incidentPlaceLabel.Name = "incidentPlaceLabel";
            this.incidentPlaceLabel.Size = new Size(115, 15);
            this.incidentPlaceLabel.TabIndex = 1;
            this.incidentPlaceLabel.Text = "Incident Place: N/A";
            // 
            // exposureDateLabel
            // 
            this.exposureDateLabel.AutoSize = true;
            this.exposureDateLabel.Location = new Point(300, 65);
            this.exposureDateLabel.Name = "exposureDateLabel";
            this.exposureDateLabel.Size = new Size(117, 15);
            this.exposureDateLabel.TabIndex = 0;
            this.exposureDateLabel.Text = "Exposure Date: N/A";
            // 
            // woundDetailsGroupBox
            // 
            this.woundDetailsGroupBox.Controls.Add(this.biteLocationsLabel);
            this.woundDetailsGroupBox.Controls.Add(this.woundClassificationLabel);
            this.woundDetailsGroupBox.Controls.Add(this.woundCountLabel);
            this.woundDetailsGroupBox.Controls.Add(this.woundTypeLabel);
            this.woundDetailsGroupBox.Controls.Add(this.isWoundWashedLabel);
            this.woundDetailsGroupBox.Location = new Point(20, 190);
            this.woundDetailsGroupBox.Name = "woundDetailsGroupBox";
            this.woundDetailsGroupBox.Size = new Size(560, 120);
            this.woundDetailsGroupBox.TabIndex = 3;
            this.woundDetailsGroupBox.TabStop = false;
            this.woundDetailsGroupBox.Text = "Wound Details";
            // 
            // biteLocationsLabel
            // 
            this.biteLocationsLabel.AutoSize = true;
            this.biteLocationsLabel.Location = new Point(20, 85);
            this.biteLocationsLabel.Name = "biteLocationsLabel";
            this.biteLocationsLabel.Size = new Size(106, 15);
            this.biteLocationsLabel.TabIndex = 4;
            this.biteLocationsLabel.Text = "Bite Locations: N/A";
            // 
            // woundClassificationLabel
            // 
            this.woundClassificationLabel.AutoSize = true;
            this.woundClassificationLabel.Location = new Point(20, 65);
            this.woundClassificationLabel.Name = "woundClassificationLabel";
            this.woundClassificationLabel.Size = new Size(147, 15);
            this.woundClassificationLabel.TabIndex = 3;
            this.woundClassificationLabel.Text = "Wound Classification: N/A";
            // 
            // woundCountLabel
            // 
            this.woundCountLabel.AutoSize = true;
            this.woundCountLabel.Location = new Point(20, 45);
            this.woundCountLabel.Name = "woundCountLabel";
            this.woundCountLabel.Size = new Size(107, 15);
            this.woundCountLabel.TabIndex = 2;
            this.woundCountLabel.Text = "Wound Count: N/A";
            // 
            // woundTypeLabel
            // 
            this.woundTypeLabel.AutoSize = true;
            this.woundTypeLabel.Location = new Point(300, 45);
            this.woundTypeLabel.Name = "woundTypeLabel";
            this.woundTypeLabel.Size = new Size(89, 15);
            this.woundTypeLabel.TabIndex = 1;
            this.woundTypeLabel.Text = "Wound Type: N/A";
            // 
            // isWoundWashedLabel
            // 
            this.isWoundWashedLabel.AutoSize = true;
            this.isWoundWashedLabel.Location = new Point(300, 65);
            this.isWoundWashedLabel.Name = "isWoundWashedLabel";
            this.isWoundWashedLabel.Size = new Size(117, 15);
            this.isWoundWashedLabel.TabIndex = 0;
            this.isWoundWashedLabel.Text = "Wound Washed: N/A";
            // 
            // patientInfoGroupBox
            // 
            this.patientInfoGroupBox.Controls.Add(this.weightLabel);
            this.patientInfoGroupBox.Controls.Add(this.contactLabel);
            this.patientInfoGroupBox.Controls.Add(this.addressLabel);
            this.patientInfoGroupBox.Controls.Add(this.civilStatusLabel);
            this.patientInfoGroupBox.Controls.Add(this.sexLabel);
            this.patientInfoGroupBox.Controls.Add(this.ageLabel);
            this.patientInfoGroupBox.Controls.Add(this.birthDateLabel);
            this.patientInfoGroupBox.Location = new Point(600, 190);
            this.patientInfoGroupBox.Name = "patientInfoGroupBox";
            this.patientInfoGroupBox.Size = new Size(560, 120);
            this.patientInfoGroupBox.TabIndex = 4;
            this.patientInfoGroupBox.TabStop = false;
            this.patientInfoGroupBox.Text = "Patient Information";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new Point(300, 85);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new Size(73, 15);
            this.weightLabel.TabIndex = 6;
            this.weightLabel.Text = "Weight: N/A";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Location = new Point(20, 85);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new Size(73, 15);
            this.contactLabel.TabIndex = 5;
            this.contactLabel.Text = "Contact: N/A";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new Point(20, 65);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new Size(72, 15);
            this.addressLabel.TabIndex = 4;
            this.addressLabel.Text = "Address: N/A";
            // 
            // civilStatusLabel
            // 
            this.civilStatusLabel.AutoSize = true;
            this.civilStatusLabel.Location = new Point(300, 45);
            this.civilStatusLabel.Name = "civilStatusLabel";
            this.civilStatusLabel.Size = new Size(119, 15);
            this.civilStatusLabel.TabIndex = 3;
            this.civilStatusLabel.Text = "Civil Status: N/A";
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new Point(20, 45);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new Size(61, 15);
            this.sexLabel.TabIndex = 2;
            this.sexLabel.Text = "Sex: N/A";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new Point(300, 65);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new Size(59, 15);
            this.ageLabel.TabIndex = 1;
            this.ageLabel.Text = "Age: N/A";
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.Location = new Point(20, 45);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new Size(112, 15);
            this.birthDateLabel.TabIndex = 0;
            this.birthDateLabel.Text = "Birth Date: N/A";
            // 
            // chartPanel
            // 
            this.chartPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.chartPanel.Controls.Add(this.biteChartPictureBox);
            this.chartPanel.Location = new Point(20, 320);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new Size(1160, 200);
            this.chartPanel.TabIndex = 5;
            this.chartPanel.Visible = false;
            // 
            // biteChartPictureBox
            // 
            this.biteChartPictureBox.Dock = DockStyle.Fill;
            this.biteChartPictureBox.Location = new Point(0, 0);
            this.biteChartPictureBox.Name = "biteChartPictureBox";
            this.biteChartPictureBox.Size = new Size(1160, 200);
            this.biteChartPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.biteChartPictureBox.TabIndex = 0;
            this.biteChartPictureBox.TabStop = false;
            // 
            // treatmentScheduleGroupBox
            // 
            this.treatmentScheduleGroupBox.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.treatmentScheduleGroupBox.Controls.Add(this.treatmentScheduleUserControl);
            this.treatmentScheduleGroupBox.Location = new Point(20, 320);
            this.treatmentScheduleGroupBox.Name = "treatmentScheduleGroupBox";
            this.treatmentScheduleGroupBox.Size = new Size(1160, 400);
            this.treatmentScheduleGroupBox.TabIndex = 7;
            this.treatmentScheduleGroupBox.TabStop = false;
            this.treatmentScheduleGroupBox.Text = "Treatment Schedule";
            // 
            // treatmentScheduleUserControl
            // 
            this.treatmentScheduleUserControl.Dock = DockStyle.Fill;
            this.treatmentScheduleUserControl.Location = new Point(3, 18);
            this.treatmentScheduleUserControl.Name = "treatmentScheduleUserControl";
            this.treatmentScheduleUserControl.Size = new Size(1154, 379);
            this.treatmentScheduleUserControl.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.closeButton.BackColor = Color.FromArgb(22, 54, 105);
            this.closeButton.FlatStyle = FlatStyle.Flat;
            this.closeButton.ForeColor = Color.White;
            this.closeButton.Location = new Point(1000, 740);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new Size(100, 35);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new EventHandler(this.closeButton_Click);
            // 
            // BiteCaseViewForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1200, 790);
            this.Controls.Add(this.treatmentScheduleGroupBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.patientInfoGroupBox);
            this.Controls.Add(this.woundDetailsGroupBox);
            this.Controls.Add(this.exposureDetailsGroupBox);
            this.Controls.Add(this.basicInfoGroupBox);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BiteCaseViewForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Bite Case Details";
            this.basicInfoGroupBox.ResumeLayout(false);
            this.basicInfoGroupBox.PerformLayout();
            this.exposureDetailsGroupBox.ResumeLayout(false);
            this.exposureDetailsGroupBox.PerformLayout();
            this.woundDetailsGroupBox.ResumeLayout(false);
            this.woundDetailsGroupBox.PerformLayout();
            this.patientInfoGroupBox.ResumeLayout(false);
            this.patientInfoGroupBox.PerformLayout();
            this.chartPanel.ResumeLayout(false);
            this.treatmentScheduleGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.biteChartPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label formTitleLabel;
        private GroupBox basicInfoGroupBox;
        private Label patientNameLabel;
        private Label registrationNoLabel;
        private Label patientIdLabel;
        private Label biteCaseIdLabel;
        private GroupBox exposureDetailsGroupBox;
        private Label animalStatusLabel;
        private Label animalClassificationLabel;
        private Label animalTypeLabel;
        private Label incidentPlaceLabel;
        private Label exposureDateLabel;
        private GroupBox woundDetailsGroupBox;
        private Label biteLocationsLabel;
        private Label woundClassificationLabel;
        private Label woundCountLabel;
        private Label woundTypeLabel;
        private Label isWoundWashedLabel;
        private GroupBox patientInfoGroupBox;
        private Label weightLabel;
        private Label contactLabel;
        private Label addressLabel;
        private Label civilStatusLabel;
        private Label sexLabel;
        private Label ageLabel;
        private Label birthDateLabel;
        private Panel chartPanel;
        private PictureBox biteChartPictureBox;
        private Button closeButton;
        private GroupBox treatmentScheduleGroupBox;
        private TreatmentScheduleUserControl treatmentScheduleUserControl;
    }
}