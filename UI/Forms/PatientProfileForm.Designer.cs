namespace ABMS_2026.UI.Forms
{
    partial class PatientProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label middleNameLabel;
        private System.Windows.Forms.TextBox middleNameTextBox;

        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.DateTimePicker birthDateDateTimePicker;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.Label civilStatusLabel;
        private System.Windows.Forms.ComboBox civilStatusComboBox;

        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label contactNoLabel;
        private System.Windows.Forms.TextBox contactNoTextBox;
        private System.Windows.Forms.Label weightLabel;

        private System.Windows.Forms.GroupBox imageGroupBox;
        private System.Windows.Forms.Button browseImageButton;
        private System.Windows.Forms.Button removeImageButton;

        private System.Windows.Forms.Button saveButton;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientProfileForm));
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            middleNameLabel = new Label();
            middleNameTextBox = new TextBox();
            birthDateLabel = new Label();
            birthDateDateTimePicker = new DateTimePicker();
            ageLabel = new Label();
            ageTextBox = new TextBox();
            sexLabel = new Label();
            sexComboBox = new ComboBox();
            civilStatusLabel = new Label();
            civilStatusComboBox = new ComboBox();
            addressLabel = new Label();
            addressTextBox = new TextBox();
            contactNoLabel = new Label();
            contactNoTextBox = new TextBox();
            weightLabel = new Label();
            imageGroupBox = new GroupBox();
            patientPictureBox = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            cameraCaptureButton = new Button();
            browseImageButton = new Button();
            removeImageButton = new Button();
            saveButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            formTitleLabel = new Label();
            weightNumericUpDown = new NumericUpDown();
            imageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)patientPictureBox).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)weightNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(29, 72);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(66, 15);
            lastNameLabel.TabIndex = 1;
            lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(133, 68);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(360, 23);
            lastNameTextBox.TabIndex = 2;
            lastNameTextBox.Leave += lastNameTextBox_Leave;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(29, 112);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(67, 15);
            firstNameLabel.TabIndex = 3;
            firstNameLabel.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(133, 108);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(360, 23);
            firstNameTextBox.TabIndex = 4;
            firstNameTextBox.Leave += firstNameTextBox_Leave;
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new Point(29, 152);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new Size(82, 15);
            middleNameLabel.TabIndex = 5;
            middleNameLabel.Text = "Middle Name:";
            // 
            // middleNameTextBox
            // 
            middleNameTextBox.Location = new Point(133, 148);
            middleNameTextBox.Name = "middleNameTextBox";
            middleNameTextBox.Size = new Size(360, 23);
            middleNameTextBox.TabIndex = 6;
            middleNameTextBox.Leave += middleNameTextBox_Leave;
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new Point(29, 192);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new Size(62, 15);
            birthDateLabel.TabIndex = 7;
            birthDateLabel.Text = "Birth Date:";
            // 
            // birthDateDateTimePicker
            // 
            birthDateDateTimePicker.Format = DateTimePickerFormat.Short;
            birthDateDateTimePicker.Location = new Point(133, 188);
            birthDateDateTimePicker.Name = "birthDateDateTimePicker";
            birthDateDateTimePicker.Size = new Size(140, 23);
            birthDateDateTimePicker.TabIndex = 8;
            birthDateDateTimePicker.ValueChanged += birthDateDateTimePicker_ValueChanged;
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(297, 192);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(31, 15);
            ageLabel.TabIndex = 9;
            ageLabel.Text = "Age:";
            // 
            // ageTextBox
            // 
            ageTextBox.Location = new Point(377, 188);
            ageTextBox.Name = "ageTextBox";
            ageTextBox.Size = new Size(116, 23);
            ageTextBox.TabIndex = 10;
            // 
            // sexLabel
            // 
            sexLabel.AutoSize = true;
            sexLabel.Location = new Point(29, 232);
            sexLabel.Name = "sexLabel";
            sexLabel.Size = new Size(28, 15);
            sexLabel.TabIndex = 11;
            sexLabel.Text = "Sex:";
            // 
            // sexComboBox
            // 
            sexComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sexComboBox.FormattingEnabled = true;
            sexComboBox.Items.AddRange(new object[] { "Male", "Female" });
            sexComboBox.Location = new Point(133, 228);
            sexComboBox.Name = "sexComboBox";
            sexComboBox.Size = new Size(89, 23);
            sexComboBox.TabIndex = 12;
            // 
            // civilStatusLabel
            // 
            civilStatusLabel.AutoSize = true;
            civilStatusLabel.Location = new Point(251, 236);
            civilStatusLabel.Name = "civilStatusLabel";
            civilStatusLabel.Size = new Size(68, 15);
            civilStatusLabel.TabIndex = 13;
            civilStatusLabel.Text = "Civil Status:";
            // 
            // civilStatusComboBox
            // 
            civilStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            civilStatusComboBox.FormattingEnabled = true;
            civilStatusComboBox.Items.AddRange(new object[] { "Single", "Married", "Widowed", "Separated", "Annulled" });
            civilStatusComboBox.Location = new Point(337, 228);
            civilStatusComboBox.Name = "civilStatusComboBox";
            civilStatusComboBox.Size = new Size(156, 23);
            civilStatusComboBox.TabIndex = 14;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(29, 276);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(52, 15);
            addressLabel.TabIndex = 15;
            addressLabel.Text = "Address:";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(133, 272);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.ScrollBars = ScrollBars.Vertical;
            addressTextBox.Size = new Size(360, 23);
            addressTextBox.TabIndex = 16;
            addressTextBox.TextChanged += addressTextBox_TextChanged;
            addressTextBox.Leave += addressTextBox_Leave;
            // 
            // contactNoLabel
            // 
            contactNoLabel.AutoSize = true;
            contactNoLabel.Location = new Point(29, 321);
            contactNoLabel.Name = "contactNoLabel";
            contactNoLabel.Size = new Size(74, 15);
            contactNoLabel.TabIndex = 17;
            contactNoLabel.Text = "Contact No.:";
            // 
            // contactNoTextBox
            // 
            contactNoTextBox.Location = new Point(133, 317);
            contactNoTextBox.Name = "contactNoTextBox";
            contactNoTextBox.Size = new Size(140, 23);
            contactNoTextBox.TabIndex = 18;
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Location = new Point(297, 324);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new Size(48, 15);
            weightLabel.TabIndex = 19;
            weightLabel.Text = "Weight:";
            weightLabel.Click += weightLabel_Click;
            // 
            // imageGroupBox
            // 
            imageGroupBox.Controls.Add(patientPictureBox);
            imageGroupBox.Controls.Add(tableLayoutPanel1);
            imageGroupBox.Location = new Point(553, 12);
            imageGroupBox.Name = "imageGroupBox";
            imageGroupBox.Size = new Size(340, 367);
            imageGroupBox.TabIndex = 21;
            imageGroupBox.TabStop = false;
            imageGroupBox.Text = "Patient Image";
            // 
            // patientPictureBox
            // 
            patientPictureBox.BorderStyle = BorderStyle.FixedSingle;
            patientPictureBox.Dock = DockStyle.Fill;
            patientPictureBox.Image = (Image)resources.GetObject("patientPictureBox.Image");
            patientPictureBox.Location = new Point(3, 19);
            patientPictureBox.Name = "patientPictureBox";
            patientPictureBox.Size = new Size(334, 295);
            patientPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            patientPictureBox.TabIndex = 2;
            patientPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(cameraCaptureButton, 0, 0);
            tableLayoutPanel1.Controls.Add(browseImageButton, 1, 0);
            tableLayoutPanel1.Controls.Add(removeImageButton, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(3, 314);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(334, 50);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // cameraCaptureButton
            // 
            cameraCaptureButton.Dock = DockStyle.Fill;
            cameraCaptureButton.Location = new Point(3, 3);
            cameraCaptureButton.Name = "cameraCaptureButton";
            cameraCaptureButton.Size = new Size(105, 44);
            cameraCaptureButton.TabIndex = 26;
            cameraCaptureButton.Text = "Open Camera";
            cameraCaptureButton.UseVisualStyleBackColor = true;
            cameraCaptureButton.Click += cameraCaptureButton_Click;
            // 
            // browseImageButton
            // 
            browseImageButton.Dock = DockStyle.Fill;
            browseImageButton.Location = new Point(114, 3);
            browseImageButton.Name = "browseImageButton";
            browseImageButton.Size = new Size(105, 44);
            browseImageButton.TabIndex = 1;
            browseImageButton.Text = "Browse Image";
            browseImageButton.UseVisualStyleBackColor = true;
            browseImageButton.Click += browseImageButton_Click;
            // 
            // removeImageButton
            // 
            removeImageButton.Dock = DockStyle.Fill;
            removeImageButton.Location = new Point(225, 3);
            removeImageButton.Name = "removeImageButton";
            removeImageButton.Size = new Size(106, 44);
            removeImageButton.TabIndex = 2;
            removeImageButton.Text = "Remove";
            removeImageButton.UseVisualStyleBackColor = true;
            removeImageButton.Click += removeImageButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.RoyalBlue;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(773, 396);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(120, 38);
            saveButton.TabIndex = 22;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Select Patient Image";
            // 
            // formTitleLabel
            // 
            formTitleLabel.AutoSize = true;
            formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            formTitleLabel.ForeColor = Color.MidnightBlue;
            formTitleLabel.Location = new Point(29, 18);
            formTitleLabel.Name = "formTitleLabel";
            formTitleLabel.Size = new Size(193, 30);
            formTitleLabel.TabIndex = 23;
            formTitleLabel.Text = "PATIENT PROFILE";
            // 
            // weightNumericUpDown
            // 
            weightNumericUpDown.DecimalPlaces = 2;
            weightNumericUpDown.Location = new Point(377, 316);
            weightNumericUpDown.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            weightNumericUpDown.Name = "weightNumericUpDown";
            weightNumericUpDown.Size = new Size(116, 23);
            weightNumericUpDown.TabIndex = 24;
            weightNumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // PatientProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(915, 446);
            Controls.Add(weightNumericUpDown);
            Controls.Add(formTitleLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(middleNameLabel);
            Controls.Add(middleNameTextBox);
            Controls.Add(birthDateLabel);
            Controls.Add(birthDateDateTimePicker);
            Controls.Add(ageLabel);
            Controls.Add(ageTextBox);
            Controls.Add(sexLabel);
            Controls.Add(sexComboBox);
            Controls.Add(civilStatusLabel);
            Controls.Add(civilStatusComboBox);
            Controls.Add(addressLabel);
            Controls.Add(addressTextBox);
            Controls.Add(contactNoLabel);
            Controls.Add(contactNoTextBox);
            Controls.Add(weightLabel);
            Controls.Add(imageGroupBox);
            Controls.Add(saveButton);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PatientProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Patient Profile";
            Load += PatientProfileForm_Load;
            imageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)patientPictureBox).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)weightNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cameraCaptureButton;
        private Label formTitleLabel;
        private PictureBox patientPictureBox;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown weightNumericUpDown;
    }
}