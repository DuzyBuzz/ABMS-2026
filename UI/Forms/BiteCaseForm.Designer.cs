namespace ABMS_2026.UI.Forms
{
    partial class BiteCaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            sexLabel = new Label();
            ageLabel = new Label();
            patientPickerButton = new Button();
            patientTextBox = new TextBox();
            patientLabel = new Label();
            addressLabel = new Label();
            registrationLabel = new Label();
            birthDateLabel = new Label();
            civilStatusLabel = new Label();
            contactLabel = new Label();
            biteCaseInformationLabel = new Label();
            topPanel = new Panel();
            patientImagePictureBox = new PictureBox();
            biteCaseTabControl = new TabControl();
            exposureDetailsTabPage = new TabPage();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)patientImagePictureBox).BeginInit();
            biteCaseTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // sexLabel
            // 
            sexLabel.AutoSize = true;
            sexLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            sexLabel.Location = new Point(908, 94);
            sexLabel.Name = "sexLabel";
            sexLabel.Size = new Size(41, 21);
            sexLabel.TabIndex = 14;
            sexLabel.Text = "Sex:";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ageLabel.Location = new Point(816, 94);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(44, 21);
            ageLabel.TabIndex = 12;
            ageLabel.Text = "Age:";
            // 
            // patientPickerButton
            // 
            patientPickerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            patientPickerButton.Location = new Point(590, 47);
            patientPickerButton.Name = "patientPickerButton";
            patientPickerButton.Size = new Size(30, 25);
            patientPickerButton.TabIndex = 11;
            patientPickerButton.Text = "...";
            patientPickerButton.UseVisualStyleBackColor = true;
            patientPickerButton.Click += patientPickerButton_Click;
            // 
            // patientTextBox
            // 
            patientTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            patientTextBox.Location = new Point(109, 41);
            patientTextBox.Name = "patientTextBox";
            patientTextBox.Size = new Size(457, 29);
            patientTextBox.TabIndex = 10;
            // 
            // patientLabel
            // 
            patientLabel.AutoSize = true;
            patientLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            patientLabel.Location = new Point(11, 49);
            patientLabel.Name = "patientLabel";
            patientLabel.Size = new Size(69, 21);
            patientLabel.TabIndex = 9;
            patientLabel.Text = "Patient:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            addressLabel.Location = new Point(11, 94);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(74, 21);
            addressLabel.TabIndex = 7;
            addressLabel.Text = "Address:";
            // 
            // registrationLabel
            // 
            registrationLabel.AutoSize = true;
            registrationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            registrationLabel.Location = new Point(637, 49);
            registrationLabel.Name = "registrationLabel";
            registrationLabel.Size = new Size(80, 21);
            registrationLabel.TabIndex = 17;
            registrationLabel.Text = "Reg No: -";
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            birthDateLabel.Location = new Point(637, 94);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new Size(61, 21);
            birthDateLabel.TabIndex = 18;
            birthDateLabel.Text = "Birth: -";
            // 
            // civilStatusLabel
            // 
            civilStatusLabel.AutoSize = true;
            civilStatusLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            civilStatusLabel.Location = new Point(1144, 49);
            civilStatusLabel.Name = "civilStatusLabel";
            civilStatusLabel.Size = new Size(109, 21);
            civilStatusLabel.TabIndex = 19;
            civilStatusLabel.Text = "Civil Status: -";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            contactLabel.Location = new Point(1144, 94);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new Size(83, 21);
            contactLabel.TabIndex = 20;
            contactLabel.Text = "Contact: -";
            // 
            // biteCaseInformationLabel
            // 
            biteCaseInformationLabel.AutoSize = true;
            biteCaseInformationLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            biteCaseInformationLabel.ForeColor = Color.MidnightBlue;
            biteCaseInformationLabel.Location = new Point(11, 8);
            biteCaseInformationLabel.Name = "biteCaseInformationLabel";
            biteCaseInformationLabel.Size = new Size(199, 28);
            biteCaseInformationLabel.TabIndex = 1;
            biteCaseInformationLabel.Text = "Patient Information";
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.White;
            topPanel.BorderStyle = BorderStyle.FixedSingle;
            topPanel.Controls.Add(contactLabel);
            topPanel.Controls.Add(civilStatusLabel);
            topPanel.Controls.Add(birthDateLabel);
            topPanel.Controls.Add(registrationLabel);
            topPanel.Controls.Add(patientImagePictureBox);
            topPanel.Controls.Add(biteCaseInformationLabel);
            topPanel.Controls.Add(addressLabel);
            topPanel.Controls.Add(patientLabel);
            topPanel.Controls.Add(patientTextBox);
            topPanel.Controls.Add(patientPickerButton);
            topPanel.Controls.Add(ageLabel);
            topPanel.Controls.Add(sexLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1520, 130);
            topPanel.TabIndex = 0;
            // 
            // patientImagePictureBox
            // 
            patientImagePictureBox.Dock = DockStyle.Right;
            patientImagePictureBox.Location = new Point(1398, 0);
            patientImagePictureBox.Name = "patientImagePictureBox";
            patientImagePictureBox.Size = new Size(120, 128);
            patientImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            patientImagePictureBox.TabIndex = 15;
            patientImagePictureBox.TabStop = false;
            // 
            // biteCaseTabControl
            // 
            biteCaseTabControl.Controls.Add(exposureDetailsTabPage);
            biteCaseTabControl.Controls.Add(tabPage1);
            biteCaseTabControl.Controls.Add(tabPage2);
            biteCaseTabControl.Dock = DockStyle.Fill;
            biteCaseTabControl.Location = new Point(0, 130);
            biteCaseTabControl.Name = "biteCaseTabControl";
            biteCaseTabControl.SelectedIndex = 0;
            biteCaseTabControl.Size = new Size(1520, 932);
            biteCaseTabControl.TabIndex = 1;
            // 
            // exposureDetailsTabPage
            // 
            exposureDetailsTabPage.Location = new Point(4, 24);
            exposureDetailsTabPage.Name = "exposureDetailsTabPage";
            exposureDetailsTabPage.Size = new Size(1512, 904);
            exposureDetailsTabPage.TabIndex = 0;
            exposureDetailsTabPage.Text = "EXPOSURE DETAILS";
            exposureDetailsTabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1512, 904);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "DOCTOR'S ORDER ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1512, 904);
            tabPage2.TabIndex = 2;
            tabPage2.Text = "TREATMENT SCHEDULE";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // BiteCaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1520, 1062);
            Controls.Add(biteCaseTabControl);
            Controls.Add(topPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1400, 900);
            Name = "BiteCaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bite Case";
            Load += BiteCaseForm_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)patientImagePictureBox).EndInit();
            biteCaseTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label sexLabel;
        private Label ageLabel;
        private Button patientPickerButton;
        private TextBox patientTextBox;
        private Label patientLabel;
        private Label addressLabel;
        private Label registrationLabel;
        private Label birthDateLabel;
        private Label civilStatusLabel;
        private Label contactLabel;
        private Label biteCaseInformationLabel;
        private Panel topPanel;
        private PictureBox patientImagePictureBox;
        private TabControl biteCaseTabControl;
        private TabPage exposureDetailsTabPage;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}