namespace ABMS_2026.UI.Forms
{
    partial class EditBiteCaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBiteCaseForm));
            patientInfoPanel = new Panel();
            weightLabel = new Label();
            contactNoLabel = new Label();
            statusLabel = new Label();
            sexLabel = new Label();
            patientPictureBox = new PictureBox();
            ageLabel = new Label();
            addressLabel = new Label();
            patientNameLabel = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            biteCaseDetailPanel = new Panel();
            tabPage2 = new TabPage();
            doctorsOrderPanel = new Panel();
            tabPage3 = new TabPage();
            treatmentSchedulePanel = new Panel();
            patientInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)patientPictureBox).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // patientInfoPanel
            // 
            patientInfoPanel.Controls.Add(weightLabel);
            patientInfoPanel.Controls.Add(contactNoLabel);
            patientInfoPanel.Controls.Add(statusLabel);
            patientInfoPanel.Controls.Add(sexLabel);
            patientInfoPanel.Controls.Add(patientPictureBox);
            patientInfoPanel.Controls.Add(ageLabel);
            patientInfoPanel.Controls.Add(addressLabel);
            patientInfoPanel.Controls.Add(patientNameLabel);
            patientInfoPanel.Dock = DockStyle.Top;
            patientInfoPanel.Location = new Point(0, 0);
            patientInfoPanel.Name = "patientInfoPanel";
            patientInfoPanel.Size = new Size(1200, 100);
            patientInfoPanel.TabIndex = 0;
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Location = new Point(1001, 54);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new Size(72, 15);
            weightLabel.TabIndex = 9;
            weightLabel.Text = "Weight (kg):";
            // 
            // contactNoLabel
            // 
            contactNoLabel.AutoSize = true;
            contactNoLabel.Location = new Point(806, 54);
            contactNoLabel.Name = "contactNoLabel";
            contactNoLabel.Size = new Size(71, 15);
            contactNoLabel.TabIndex = 8;
            contactNoLabel.Text = "Contact No:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(672, 54);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 15);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "Status";
            // 
            // sexLabel
            // 
            sexLabel.AutoSize = true;
            sexLabel.Location = new Point(580, 54);
            sexLabel.Name = "sexLabel";
            sexLabel.Size = new Size(25, 15);
            sexLabel.TabIndex = 6;
            sexLabel.Text = "Sex";
            // 
            // patientPictureBox
            // 
            patientPictureBox.Dock = DockStyle.Right;
            patientPictureBox.Image = (Image)resources.GetObject("patientPictureBox.Image");
            patientPictureBox.Location = new Point(1100, 0);
            patientPictureBox.Name = "patientPictureBox";
            patientPictureBox.Size = new Size(100, 100);
            patientPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            patientPictureBox.TabIndex = 5;
            patientPictureBox.TabStop = false;
            patientPictureBox.Click += patientPictureBox_Click;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(502, 54);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(31, 15);
            ageLabel.TabIndex = 4;
            ageLabel.Text = "Age:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(23, 54);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(55, 15);
            addressLabel.TabIndex = 3;
            addressLabel.Text = "Address: ";
            // 
            // patientNameLabel
            // 
            patientNameLabel.AutoSize = true;
            patientNameLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            patientNameLabel.ForeColor = Color.FromArgb(22, 54, 105);
            patientNameLabel.Location = new Point(23, 13);
            patientNameLabel.Name = "patientNameLabel";
            patientNameLabel.Size = new Size(99, 30);
            patientNameLabel.TabIndex = 1;
            patientNameLabel.Text = "Patient: ";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 100);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1200, 700);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(biteCaseDetailPanel);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1192, 672);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Bite Case Details";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // biteCaseDetailPanel
            // 
            biteCaseDetailPanel.Dock = DockStyle.Fill;
            biteCaseDetailPanel.Location = new Point(3, 3);
            biteCaseDetailPanel.Name = "biteCaseDetailPanel";
            biteCaseDetailPanel.Size = new Size(1186, 666);
            biteCaseDetailPanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(doctorsOrderPanel);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1192, 672);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Doctors Orders";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // doctorsOrderPanel
            // 
            doctorsOrderPanel.Dock = DockStyle.Fill;
            doctorsOrderPanel.Location = new Point(3, 3);
            doctorsOrderPanel.Name = "doctorsOrderPanel";
            doctorsOrderPanel.Size = new Size(1186, 666);
            doctorsOrderPanel.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(treatmentSchedulePanel);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1192, 672);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Treatment Schedules";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // treatmentSchedulePanel
            // 
            treatmentSchedulePanel.Dock = DockStyle.Fill;
            treatmentSchedulePanel.Location = new Point(3, 3);
            treatmentSchedulePanel.Name = "treatmentSchedulePanel";
            treatmentSchedulePanel.Size = new Size(1186, 666);
            treatmentSchedulePanel.TabIndex = 0;
            // 
            // BiteCaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(tabControl1);
            Controls.Add(patientInfoPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditBiteCaseForm";
            Text = "EditBiteCaseForm";
            WindowState = FormWindowState.Maximized;
            Load += EditBiteCaseForm_Load;
            patientInfoPanel.ResumeLayout(false);
            patientInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)patientPictureBox).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel patientInfoPanel;
        private Label label1;
        private Label PatientNameLabel;
        private Label addressLabel;
        private Label ageLabel;
        private PictureBox patientPictureBox;
        private Label weightLabel;
        private Label contactNoLabel;
        private Label statusLabel;
        private Label sexLabel;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label patientNameLabel;
        private TabPage tabPage1;
        private Panel biteCaseDetailPanel;
        private Panel doctorsOrderPanel;
        private Panel treatmentSchedulePanel;
    }
}