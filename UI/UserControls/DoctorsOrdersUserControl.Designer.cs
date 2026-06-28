namespace ABMS_2026.UI.UserControls
{
    partial class DoctorsOrdersUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelMain = new TableLayoutPanel();
            panelLeft = new Panel();
            groupBoxClinicalAssessment = new GroupBox();
            tableLayoutPanelClinicalAssessment = new TableLayoutPanel();
            labelHistoryPresentIllness = new Label();
            richTextBoxHistoryPresentIllness = new RichTextBox();
            labelPhysicalExamination = new Label();
            richTextBoxPhysicalExamination = new RichTextBox();
            labelDiagnosis = new Label();
            richTextBoxDiagnosis = new RichTextBox();
            labelManagement = new Label();
            richTextBoxManagement = new RichTextBox();
            labelOtherManagement = new Label();
            richTextBoxOtherManagement = new RichTextBox();
            panelRight = new Panel();
            groupBoxDoctorInfo = new GroupBox();
            tableLayoutPanelDoctorInfo = new TableLayoutPanel();
            labelDoctorName = new Label();
            comboBoxDoctorName = new ComboBox();
            groupBoxTreatments = new GroupBox();
            tableLayoutPanelTreatments = new TableLayoutPanel();
            checkBoxIsPep = new CheckBox();
            checkBoxIsPrep = new CheckBox();
            checkBoxIsErig = new CheckBox();
            checkBoxIsHrig = new CheckBox();
            checkBoxIsTetanusDiphtheria = new CheckBox();
            checkBoxIsTetanusToxoid = new CheckBox();
            checkBoxIsAntiTetanusSerum = new CheckBox();
            labelPrepDetails = new Label();
            comboBoxPrepDetails = new ComboBox();
            labelErigDetails = new Label();
            comboBoxErigDetails = new ComboBox();
            labelHrigDetails = new Label();
            comboBoxHrigDetails = new ComboBox();
            labelTetanusToxoidDetails = new Label();
            comboBoxTetanusToxoidDetails = new ComboBox();
            labelAntiTetanusSerumDetails = new Label();
            comboBoxAntiTetanusSerumDetails = new ComboBox();
            groupBoxMedications = new GroupBox();
            tableLayoutPanelMedications = new TableLayoutPanel();
            labelMedicationAntibiotic = new Label();
            comboBoxMedicationAntibiotic = new ComboBox();
            labelMedicationNsaid = new Label();
            comboBoxMedicationNsaid = new ComboBox();
            labelMedicationOthers = new Label();
            comboBoxMedicationOthers = new ComboBox();
            panelBottom = new Panel();
            saveButton = new Button();
            tableLayoutPanelMain.SuspendLayout();
            panelLeft.SuspendLayout();
            groupBoxClinicalAssessment.SuspendLayout();
            tableLayoutPanelClinicalAssessment.SuspendLayout();
            panelRight.SuspendLayout();
            groupBoxDoctorInfo.SuspendLayout();
            tableLayoutPanelDoctorInfo.SuspendLayout();
            groupBoxTreatments.SuspendLayout();
            tableLayoutPanelTreatments.SuspendLayout();
            groupBoxMedications.SuspendLayout();
            tableLayoutPanelMedications.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(panelLeft, 0, 0);
            tableLayoutPanelMain.Controls.Add(panelRight, 1, 0);
            tableLayoutPanelMain.Controls.Add(panelBottom, 0, 1);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMain.Size = new Size(1280, 820);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(groupBoxClinicalAssessment);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(3, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(634, 764);
            panelLeft.TabIndex = 0;
            // 
            // groupBoxClinicalAssessment
            // 
            groupBoxClinicalAssessment.Controls.Add(tableLayoutPanelClinicalAssessment);
            groupBoxClinicalAssessment.Dock = DockStyle.Fill;
            groupBoxClinicalAssessment.Location = new Point(0, 0);
            groupBoxClinicalAssessment.Name = "groupBoxClinicalAssessment";
            groupBoxClinicalAssessment.Padding = new Padding(12);
            groupBoxClinicalAssessment.Size = new Size(634, 764);
            groupBoxClinicalAssessment.TabIndex = 0;
            groupBoxClinicalAssessment.TabStop = false;
            groupBoxClinicalAssessment.Text = "CLINICAL ASSESSMENT";
            // 
            // tableLayoutPanelClinicalAssessment
            // 
            tableLayoutPanelClinicalAssessment.ColumnCount = 1;
            tableLayoutPanelClinicalAssessment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelClinicalAssessment.Controls.Add(labelHistoryPresentIllness, 0, 0);
            tableLayoutPanelClinicalAssessment.Controls.Add(richTextBoxHistoryPresentIllness, 0, 1);
            tableLayoutPanelClinicalAssessment.Controls.Add(labelPhysicalExamination, 0, 2);
            tableLayoutPanelClinicalAssessment.Controls.Add(richTextBoxPhysicalExamination, 0, 3);
            tableLayoutPanelClinicalAssessment.Controls.Add(labelDiagnosis, 0, 4);
            tableLayoutPanelClinicalAssessment.Controls.Add(richTextBoxDiagnosis, 0, 5);
            tableLayoutPanelClinicalAssessment.Controls.Add(labelManagement, 0, 6);
            tableLayoutPanelClinicalAssessment.Controls.Add(richTextBoxManagement, 0, 7);
            tableLayoutPanelClinicalAssessment.Controls.Add(labelOtherManagement, 0, 8);
            tableLayoutPanelClinicalAssessment.Controls.Add(richTextBoxOtherManagement, 0, 9);
            tableLayoutPanelClinicalAssessment.Dock = DockStyle.Fill;
            tableLayoutPanelClinicalAssessment.Location = new Point(12, 28);
            tableLayoutPanelClinicalAssessment.Name = "tableLayoutPanelClinicalAssessment";
            tableLayoutPanelClinicalAssessment.RowCount = 10;
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelClinicalAssessment.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelClinicalAssessment.Size = new Size(610, 724);
            tableLayoutPanelClinicalAssessment.TabIndex = 0;
            // 
            // labelHistoryPresentIllness
            // 
            labelHistoryPresentIllness.AutoSize = true;
            labelHistoryPresentIllness.Dock = DockStyle.Fill;
            labelHistoryPresentIllness.Location = new Point(3, 0);
            labelHistoryPresentIllness.Name = "labelHistoryPresentIllness";
            labelHistoryPresentIllness.Size = new Size(604, 25);
            labelHistoryPresentIllness.TabIndex = 0;
            labelHistoryPresentIllness.Text = "History of Present Illness";
            labelHistoryPresentIllness.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxHistoryPresentIllness
            // 
            richTextBoxHistoryPresentIllness.Dock = DockStyle.Fill;
            richTextBoxHistoryPresentIllness.Location = new Point(3, 28);
            richTextBoxHistoryPresentIllness.Name = "richTextBoxHistoryPresentIllness";
            richTextBoxHistoryPresentIllness.Size = new Size(604, 113);
            richTextBoxHistoryPresentIllness.TabIndex = 1;
            richTextBoxHistoryPresentIllness.Text = "";
            // 
            // labelPhysicalExamination
            // 
            labelPhysicalExamination.AutoSize = true;
            labelPhysicalExamination.Dock = DockStyle.Fill;
            labelPhysicalExamination.Location = new Point(3, 144);
            labelPhysicalExamination.Name = "labelPhysicalExamination";
            labelPhysicalExamination.Size = new Size(604, 25);
            labelPhysicalExamination.TabIndex = 2;
            labelPhysicalExamination.Text = "Physical Examination";
            labelPhysicalExamination.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxPhysicalExamination
            // 
            richTextBoxPhysicalExamination.Dock = DockStyle.Fill;
            richTextBoxPhysicalExamination.Location = new Point(3, 172);
            richTextBoxPhysicalExamination.Name = "richTextBoxPhysicalExamination";
            richTextBoxPhysicalExamination.Size = new Size(604, 113);
            richTextBoxPhysicalExamination.TabIndex = 3;
            richTextBoxPhysicalExamination.Text = "";
            // 
            // labelDiagnosis
            // 
            labelDiagnosis.AutoSize = true;
            labelDiagnosis.Dock = DockStyle.Fill;
            labelDiagnosis.Location = new Point(3, 288);
            labelDiagnosis.Name = "labelDiagnosis";
            labelDiagnosis.Size = new Size(604, 25);
            labelDiagnosis.TabIndex = 4;
            labelDiagnosis.Text = "Diagnosis";
            labelDiagnosis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxDiagnosis
            // 
            richTextBoxDiagnosis.Dock = DockStyle.Fill;
            richTextBoxDiagnosis.Location = new Point(3, 316);
            richTextBoxDiagnosis.Name = "richTextBoxDiagnosis";
            richTextBoxDiagnosis.Size = new Size(604, 113);
            richTextBoxDiagnosis.TabIndex = 5;
            richTextBoxDiagnosis.Text = "";
            // 
            // labelManagement
            // 
            labelManagement.AutoSize = true;
            labelManagement.Dock = DockStyle.Fill;
            labelManagement.Location = new Point(3, 432);
            labelManagement.Name = "labelManagement";
            labelManagement.Size = new Size(604, 25);
            labelManagement.TabIndex = 6;
            labelManagement.Text = "Management";
            labelManagement.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxManagement
            // 
            richTextBoxManagement.Dock = DockStyle.Fill;
            richTextBoxManagement.Location = new Point(3, 460);
            richTextBoxManagement.Name = "richTextBoxManagement";
            richTextBoxManagement.Size = new Size(604, 113);
            richTextBoxManagement.TabIndex = 7;
            richTextBoxManagement.Text = "";
            // 
            // labelOtherManagement
            // 
            labelOtherManagement.AutoSize = true;
            labelOtherManagement.Dock = DockStyle.Fill;
            labelOtherManagement.Location = new Point(3, 576);
            labelOtherManagement.Name = "labelOtherManagement";
            labelOtherManagement.Size = new Size(604, 25);
            labelOtherManagement.TabIndex = 8;
            labelOtherManagement.Text = "Other Management";
            labelOtherManagement.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxOtherManagement
            // 
            richTextBoxOtherManagement.Dock = DockStyle.Fill;
            richTextBoxOtherManagement.Location = new Point(3, 604);
            richTextBoxOtherManagement.Name = "richTextBoxOtherManagement";
            richTextBoxOtherManagement.Size = new Size(604, 117);
            richTextBoxOtherManagement.TabIndex = 9;
            richTextBoxOtherManagement.Text = "";
            // 
            // panelRight
            // 
            panelRight.Controls.Add(groupBoxDoctorInfo);
            panelRight.Controls.Add(groupBoxTreatments);
            panelRight.Controls.Add(groupBoxMedications);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(643, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(634, 764);
            panelRight.TabIndex = 1;
            // 
            // groupBoxDoctorInfo
            // 
            groupBoxDoctorInfo.Controls.Add(tableLayoutPanelDoctorInfo);
            groupBoxDoctorInfo.Dock = DockStyle.Top;
            groupBoxDoctorInfo.Location = new Point(0, 485);
            groupBoxDoctorInfo.Name = "groupBoxDoctorInfo";
            groupBoxDoctorInfo.Padding = new Padding(12);
            groupBoxDoctorInfo.Size = new Size(634, 120);
            groupBoxDoctorInfo.TabIndex = 0;
            groupBoxDoctorInfo.TabStop = false;
            groupBoxDoctorInfo.Text = "DOCTOR INFORMATION";
            // 
            // tableLayoutPanelDoctorInfo
            // 
            tableLayoutPanelDoctorInfo.ColumnCount = 2;
            tableLayoutPanelDoctorInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelDoctorInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanelDoctorInfo.Controls.Add(labelDoctorName, 0, 0);
            tableLayoutPanelDoctorInfo.Controls.Add(comboBoxDoctorName, 1, 0);
            tableLayoutPanelDoctorInfo.Dock = DockStyle.Fill;
            tableLayoutPanelDoctorInfo.Location = new Point(12, 28);
            tableLayoutPanelDoctorInfo.Name = "tableLayoutPanelDoctorInfo";
            tableLayoutPanelDoctorInfo.RowCount = 1;
            tableLayoutPanelDoctorInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelDoctorInfo.Size = new Size(610, 80);
            tableLayoutPanelDoctorInfo.TabIndex = 0;
            // 
            // labelDoctorName
            // 
            labelDoctorName.AutoSize = true;
            labelDoctorName.Dock = DockStyle.Fill;
            labelDoctorName.Location = new Point(3, 0);
            labelDoctorName.Name = "labelDoctorName";
            labelDoctorName.Size = new Size(177, 80);
            labelDoctorName.TabIndex = 0;
            labelDoctorName.Text = "Doctor Name";
            labelDoctorName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxDoctorName
            // 
            comboBoxDoctorName.Dock = DockStyle.Fill;
            comboBoxDoctorName.FormattingEnabled = true;
            comboBoxDoctorName.Location = new Point(186, 3);
            comboBoxDoctorName.Name = "comboBoxDoctorName";
            comboBoxDoctorName.Size = new Size(421, 23);
            comboBoxDoctorName.TabIndex = 1;
            // 
            // groupBoxTreatments
            // 
            groupBoxTreatments.Controls.Add(tableLayoutPanelTreatments);
            groupBoxTreatments.Dock = DockStyle.Top;
            groupBoxTreatments.Location = new Point(0, 180);
            groupBoxTreatments.Name = "groupBoxTreatments";
            groupBoxTreatments.Padding = new Padding(12);
            groupBoxTreatments.Size = new Size(634, 305);
            groupBoxTreatments.TabIndex = 1;
            groupBoxTreatments.TabStop = false;
            groupBoxTreatments.Text = "TREATMENTS";
            // 
            // tableLayoutPanelTreatments
            // 
            tableLayoutPanelTreatments.ColumnCount = 3;
            tableLayoutPanelTreatments.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelTreatments.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelTreatments.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsPep, 0, 0);
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsPrep, 0, 1);
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsErig, 0, 2);
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsHrig, 0, 3);
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsTetanusDiphtheria, 0, 4);
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsTetanusToxoid, 0, 5);
            tableLayoutPanelTreatments.Controls.Add(checkBoxIsAntiTetanusSerum, 0, 6);
            tableLayoutPanelTreatments.Controls.Add(labelPrepDetails, 1, 1);
            tableLayoutPanelTreatments.Controls.Add(comboBoxPrepDetails, 2, 1);
            tableLayoutPanelTreatments.Controls.Add(labelErigDetails, 1, 2);
            tableLayoutPanelTreatments.Controls.Add(comboBoxErigDetails, 2, 2);
            tableLayoutPanelTreatments.Controls.Add(labelHrigDetails, 1, 3);
            tableLayoutPanelTreatments.Controls.Add(comboBoxHrigDetails, 2, 3);
            tableLayoutPanelTreatments.Controls.Add(labelTetanusToxoidDetails, 1, 5);
            tableLayoutPanelTreatments.Controls.Add(comboBoxTetanusToxoidDetails, 2, 5);
            tableLayoutPanelTreatments.Controls.Add(labelAntiTetanusSerumDetails, 1, 6);
            tableLayoutPanelTreatments.Controls.Add(comboBoxAntiTetanusSerumDetails, 2, 6);
            tableLayoutPanelTreatments.Dock = DockStyle.Fill;
            tableLayoutPanelTreatments.Location = new Point(12, 28);
            tableLayoutPanelTreatments.Name = "tableLayoutPanelTreatments";
            tableLayoutPanelTreatments.RowCount = 7;
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelTreatments.Size = new Size(610, 265);
            tableLayoutPanelTreatments.TabIndex = 0;
            // 
            // checkBoxIsPep
            // 
            checkBoxIsPep.AutoSize = true;
            checkBoxIsPep.Dock = DockStyle.Fill;
            checkBoxIsPep.Location = new Point(3, 3);
            checkBoxIsPep.Name = "checkBoxIsPep";
            checkBoxIsPep.Size = new Size(177, 29);
            checkBoxIsPep.TabIndex = 0;
            checkBoxIsPep.Text = "PEP (Post-Exposure Prophylaxis)";
            checkBoxIsPep.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsPrep
            // 
            checkBoxIsPrep.AutoSize = true;
            checkBoxIsPrep.Dock = DockStyle.Fill;
            checkBoxIsPrep.Location = new Point(3, 38);
            checkBoxIsPrep.Name = "checkBoxIsPrep";
            checkBoxIsPrep.Size = new Size(177, 29);
            checkBoxIsPrep.TabIndex = 1;
            checkBoxIsPrep.Text = "PrEP (Pre-Exposure Prophylaxis)";
            checkBoxIsPrep.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsErig
            // 
            checkBoxIsErig.AutoSize = true;
            checkBoxIsErig.Dock = DockStyle.Fill;
            checkBoxIsErig.Location = new Point(3, 73);
            checkBoxIsErig.Name = "checkBoxIsErig";
            checkBoxIsErig.Size = new Size(177, 29);
            checkBoxIsErig.TabIndex = 2;
            checkBoxIsErig.Text = "ERIG (Equine Rabies Immunoglobulin)";
            checkBoxIsErig.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsHrig
            // 
            checkBoxIsHrig.AutoSize = true;
            checkBoxIsHrig.Dock = DockStyle.Fill;
            checkBoxIsHrig.Location = new Point(3, 108);
            checkBoxIsHrig.Name = "checkBoxIsHrig";
            checkBoxIsHrig.Size = new Size(177, 29);
            checkBoxIsHrig.TabIndex = 3;
            checkBoxIsHrig.Text = "HRIG (Human Rabies Immunoglobulin)";
            checkBoxIsHrig.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsTetanusDiphtheria
            // 
            checkBoxIsTetanusDiphtheria.AutoSize = true;
            checkBoxIsTetanusDiphtheria.Dock = DockStyle.Fill;
            checkBoxIsTetanusDiphtheria.Location = new Point(3, 143);
            checkBoxIsTetanusDiphtheria.Name = "checkBoxIsTetanusDiphtheria";
            checkBoxIsTetanusDiphtheria.Size = new Size(177, 29);
            checkBoxIsTetanusDiphtheria.TabIndex = 4;
            checkBoxIsTetanusDiphtheria.Text = "Tetanus Diphtheria";
            checkBoxIsTetanusDiphtheria.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsTetanusToxoid
            // 
            checkBoxIsTetanusToxoid.AutoSize = true;
            checkBoxIsTetanusToxoid.Dock = DockStyle.Fill;
            checkBoxIsTetanusToxoid.Location = new Point(3, 178);
            checkBoxIsTetanusToxoid.Name = "checkBoxIsTetanusToxoid";
            checkBoxIsTetanusToxoid.Size = new Size(177, 29);
            checkBoxIsTetanusToxoid.TabIndex = 5;
            checkBoxIsTetanusToxoid.Text = "Tetanus Toxoid";
            checkBoxIsTetanusToxoid.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsAntiTetanusSerum
            // 
            checkBoxIsAntiTetanusSerum.AutoSize = true;
            checkBoxIsAntiTetanusSerum.Dock = DockStyle.Fill;
            checkBoxIsAntiTetanusSerum.Location = new Point(3, 213);
            checkBoxIsAntiTetanusSerum.Name = "checkBoxIsAntiTetanusSerum";
            checkBoxIsAntiTetanusSerum.Size = new Size(177, 49);
            checkBoxIsAntiTetanusSerum.TabIndex = 6;
            checkBoxIsAntiTetanusSerum.Text = "Anti-Tetanus Serum";
            checkBoxIsAntiTetanusSerum.UseVisualStyleBackColor = true;
            // 
            // labelPrepDetails
            // 
            labelPrepDetails.AutoSize = true;
            labelPrepDetails.Dock = DockStyle.Fill;
            labelPrepDetails.Location = new Point(186, 35);
            labelPrepDetails.Name = "labelPrepDetails";
            labelPrepDetails.Size = new Size(116, 35);
            labelPrepDetails.TabIndex = 7;
            labelPrepDetails.Text = "Details";
            labelPrepDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPrepDetails
            // 
            comboBoxPrepDetails.Dock = DockStyle.Fill;
            comboBoxPrepDetails.FormattingEnabled = true;
            comboBoxPrepDetails.Location = new Point(308, 38);
            comboBoxPrepDetails.Name = "comboBoxPrepDetails";
            comboBoxPrepDetails.Size = new Size(299, 23);
            comboBoxPrepDetails.TabIndex = 8;
            // 
            // labelErigDetails
            // 
            labelErigDetails.AutoSize = true;
            labelErigDetails.Dock = DockStyle.Fill;
            labelErigDetails.Location = new Point(186, 70);
            labelErigDetails.Name = "labelErigDetails";
            labelErigDetails.Size = new Size(116, 35);
            labelErigDetails.TabIndex = 9;
            labelErigDetails.Text = "Details";
            labelErigDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxErigDetails
            // 
            comboBoxErigDetails.Dock = DockStyle.Fill;
            comboBoxErigDetails.FormattingEnabled = true;
            comboBoxErigDetails.Location = new Point(308, 73);
            comboBoxErigDetails.Name = "comboBoxErigDetails";
            comboBoxErigDetails.Size = new Size(299, 23);
            comboBoxErigDetails.TabIndex = 10;
            // 
            // labelHrigDetails
            // 
            labelHrigDetails.AutoSize = true;
            labelHrigDetails.Dock = DockStyle.Fill;
            labelHrigDetails.Location = new Point(186, 105);
            labelHrigDetails.Name = "labelHrigDetails";
            labelHrigDetails.Size = new Size(116, 35);
            labelHrigDetails.TabIndex = 11;
            labelHrigDetails.Text = "Details";
            labelHrigDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxHrigDetails
            // 
            comboBoxHrigDetails.Dock = DockStyle.Fill;
            comboBoxHrigDetails.FormattingEnabled = true;
            comboBoxHrigDetails.Location = new Point(308, 108);
            comboBoxHrigDetails.Name = "comboBoxHrigDetails";
            comboBoxHrigDetails.Size = new Size(299, 23);
            comboBoxHrigDetails.TabIndex = 12;
            // 
            // labelTetanusToxoidDetails
            // 
            labelTetanusToxoidDetails.AutoSize = true;
            labelTetanusToxoidDetails.Dock = DockStyle.Fill;
            labelTetanusToxoidDetails.Location = new Point(186, 175);
            labelTetanusToxoidDetails.Name = "labelTetanusToxoidDetails";
            labelTetanusToxoidDetails.Size = new Size(116, 35);
            labelTetanusToxoidDetails.TabIndex = 13;
            labelTetanusToxoidDetails.Text = "Details";
            labelTetanusToxoidDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxTetanusToxoidDetails
            // 
            comboBoxTetanusToxoidDetails.Dock = DockStyle.Fill;
            comboBoxTetanusToxoidDetails.FormattingEnabled = true;
            comboBoxTetanusToxoidDetails.Location = new Point(308, 178);
            comboBoxTetanusToxoidDetails.Name = "comboBoxTetanusToxoidDetails";
            comboBoxTetanusToxoidDetails.Size = new Size(299, 23);
            comboBoxTetanusToxoidDetails.TabIndex = 14;
            // 
            // labelAntiTetanusSerumDetails
            // 
            labelAntiTetanusSerumDetails.AutoSize = true;
            labelAntiTetanusSerumDetails.Dock = DockStyle.Fill;
            labelAntiTetanusSerumDetails.Location = new Point(186, 210);
            labelAntiTetanusSerumDetails.Name = "labelAntiTetanusSerumDetails";
            labelAntiTetanusSerumDetails.Size = new Size(116, 55);
            labelAntiTetanusSerumDetails.TabIndex = 15;
            labelAntiTetanusSerumDetails.Text = "Details";
            labelAntiTetanusSerumDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxAntiTetanusSerumDetails
            // 
            comboBoxAntiTetanusSerumDetails.Dock = DockStyle.Fill;
            comboBoxAntiTetanusSerumDetails.FormattingEnabled = true;
            comboBoxAntiTetanusSerumDetails.Location = new Point(308, 213);
            comboBoxAntiTetanusSerumDetails.Name = "comboBoxAntiTetanusSerumDetails";
            comboBoxAntiTetanusSerumDetails.Size = new Size(299, 23);
            comboBoxAntiTetanusSerumDetails.TabIndex = 16;
            // 
            // groupBoxMedications
            // 
            groupBoxMedications.Controls.Add(tableLayoutPanelMedications);
            groupBoxMedications.Dock = DockStyle.Top;
            groupBoxMedications.Location = new Point(0, 0);
            groupBoxMedications.Name = "groupBoxMedications";
            groupBoxMedications.Padding = new Padding(12);
            groupBoxMedications.Size = new Size(634, 180);
            groupBoxMedications.TabIndex = 2;
            groupBoxMedications.TabStop = false;
            groupBoxMedications.Text = "MEDICATIONS";
            // 
            // tableLayoutPanelMedications
            // 
            tableLayoutPanelMedications.ColumnCount = 2;
            tableLayoutPanelMedications.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanelMedications.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanelMedications.Controls.Add(labelMedicationAntibiotic, 0, 0);
            tableLayoutPanelMedications.Controls.Add(comboBoxMedicationAntibiotic, 1, 0);
            tableLayoutPanelMedications.Controls.Add(labelMedicationNsaid, 0, 1);
            tableLayoutPanelMedications.Controls.Add(comboBoxMedicationNsaid, 1, 1);
            tableLayoutPanelMedications.Controls.Add(labelMedicationOthers, 0, 2);
            tableLayoutPanelMedications.Controls.Add(comboBoxMedicationOthers, 1, 2);
            tableLayoutPanelMedications.Dock = DockStyle.Fill;
            tableLayoutPanelMedications.Location = new Point(12, 28);
            tableLayoutPanelMedications.Name = "tableLayoutPanelMedications";
            tableLayoutPanelMedications.RowCount = 3;
            tableLayoutPanelMedications.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelMedications.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelMedications.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelMedications.Size = new Size(610, 140);
            tableLayoutPanelMedications.TabIndex = 0;
            // 
            // labelMedicationAntibiotic
            // 
            labelMedicationAntibiotic.AutoSize = true;
            labelMedicationAntibiotic.Dock = DockStyle.Fill;
            labelMedicationAntibiotic.Location = new Point(3, 0);
            labelMedicationAntibiotic.Name = "labelMedicationAntibiotic";
            labelMedicationAntibiotic.Size = new Size(207, 40);
            labelMedicationAntibiotic.TabIndex = 0;
            labelMedicationAntibiotic.Text = "Antibiotic";
            labelMedicationAntibiotic.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxMedicationAntibiotic
            // 
            comboBoxMedicationAntibiotic.Dock = DockStyle.Fill;
            comboBoxMedicationAntibiotic.FormattingEnabled = true;
            comboBoxMedicationAntibiotic.Location = new Point(216, 3);
            comboBoxMedicationAntibiotic.Name = "comboBoxMedicationAntibiotic";
            comboBoxMedicationAntibiotic.Size = new Size(391, 23);
            comboBoxMedicationAntibiotic.TabIndex = 1;
            // 
            // labelMedicationNsaid
            // 
            labelMedicationNsaid.AutoSize = true;
            labelMedicationNsaid.Dock = DockStyle.Fill;
            labelMedicationNsaid.Location = new Point(3, 40);
            labelMedicationNsaid.Name = "labelMedicationNsaid";
            labelMedicationNsaid.Size = new Size(207, 40);
            labelMedicationNsaid.TabIndex = 2;
            labelMedicationNsaid.Text = "NSAID";
            labelMedicationNsaid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxMedicationNsaid
            // 
            comboBoxMedicationNsaid.Dock = DockStyle.Fill;
            comboBoxMedicationNsaid.FormattingEnabled = true;
            comboBoxMedicationNsaid.Location = new Point(216, 43);
            comboBoxMedicationNsaid.Name = "comboBoxMedicationNsaid";
            comboBoxMedicationNsaid.Size = new Size(391, 23);
            comboBoxMedicationNsaid.TabIndex = 3;
            // 
            // labelMedicationOthers
            // 
            labelMedicationOthers.AutoSize = true;
            labelMedicationOthers.Dock = DockStyle.Fill;
            labelMedicationOthers.Location = new Point(3, 80);
            labelMedicationOthers.Name = "labelMedicationOthers";
            labelMedicationOthers.Size = new Size(207, 60);
            labelMedicationOthers.TabIndex = 4;
            labelMedicationOthers.Text = "Others";
            labelMedicationOthers.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxMedicationOthers
            // 
            comboBoxMedicationOthers.Dock = DockStyle.Fill;
            comboBoxMedicationOthers.FormattingEnabled = true;
            comboBoxMedicationOthers.Location = new Point(216, 83);
            comboBoxMedicationOthers.Name = "comboBoxMedicationOthers";
            comboBoxMedicationOthers.Size = new Size(391, 23);
            comboBoxMedicationOthers.TabIndex = 5;
            // 
            // panelBottom
            // 
            tableLayoutPanelMain.SetColumnSpan(panelBottom, 2);
            panelBottom.Controls.Add(saveButton);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(3, 773);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1274, 44);
            panelBottom.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.BackColor = Color.FromArgb(22, 163, 74);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(1189, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(82, 33);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            // 
            // DoctorsOrdersUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "DoctorsOrdersUserControl";
            Size = new Size(1280, 820);
            tableLayoutPanelMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            groupBoxClinicalAssessment.ResumeLayout(false);
            tableLayoutPanelClinicalAssessment.ResumeLayout(false);
            tableLayoutPanelClinicalAssessment.PerformLayout();
            panelRight.ResumeLayout(false);
            groupBoxDoctorInfo.ResumeLayout(false);
            tableLayoutPanelDoctorInfo.ResumeLayout(false);
            tableLayoutPanelDoctorInfo.PerformLayout();
            groupBoxTreatments.ResumeLayout(false);
            tableLayoutPanelTreatments.ResumeLayout(false);
            tableLayoutPanelTreatments.PerformLayout();
            groupBoxMedications.ResumeLayout(false);
            tableLayoutPanelMedications.ResumeLayout(false);
            tableLayoutPanelMedications.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox groupBoxClinicalAssessment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClinicalAssessment;
        private System.Windows.Forms.Label labelHistoryPresentIllness;
        private System.Windows.Forms.RichTextBox richTextBoxHistoryPresentIllness;
        private System.Windows.Forms.Label labelPhysicalExamination;
        private System.Windows.Forms.RichTextBox richTextBoxPhysicalExamination;
        private System.Windows.Forms.Label labelDiagnosis;
        private System.Windows.Forms.RichTextBox richTextBoxDiagnosis;
        private System.Windows.Forms.Label labelManagement;
        private System.Windows.Forms.RichTextBox richTextBoxManagement;
        private System.Windows.Forms.Label labelOtherManagement;
        private System.Windows.Forms.RichTextBox richTextBoxOtherManagement;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBoxMedications;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMedications;
        private System.Windows.Forms.Label labelMedicationAntibiotic;
        private System.Windows.Forms.ComboBox comboBoxMedicationAntibiotic;
        private System.Windows.Forms.Label labelMedicationNsaid;
        private System.Windows.Forms.ComboBox comboBoxMedicationNsaid;
        private System.Windows.Forms.Label labelMedicationOthers;
        private System.Windows.Forms.ComboBox comboBoxMedicationOthers;
        private System.Windows.Forms.GroupBox groupBoxTreatments;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTreatments;
        private System.Windows.Forms.CheckBox checkBoxIsPep;
        private System.Windows.Forms.CheckBox checkBoxIsPrep;
        private System.Windows.Forms.CheckBox checkBoxIsErig;
        private System.Windows.Forms.CheckBox checkBoxIsHrig;
        private System.Windows.Forms.CheckBox checkBoxIsTetanusDiphtheria;
        private System.Windows.Forms.CheckBox checkBoxIsTetanusToxoid;
        private System.Windows.Forms.CheckBox checkBoxIsAntiTetanusSerum;
        private System.Windows.Forms.Label labelPrepDetails;
        private System.Windows.Forms.ComboBox comboBoxPrepDetails;
        private System.Windows.Forms.Label labelErigDetails;
        private System.Windows.Forms.ComboBox comboBoxErigDetails;
        private System.Windows.Forms.Label labelHrigDetails;
        private System.Windows.Forms.ComboBox comboBoxHrigDetails;
        private System.Windows.Forms.Label labelTetanusToxoidDetails;
        private System.Windows.Forms.ComboBox comboBoxTetanusToxoidDetails;
        private System.Windows.Forms.Label labelAntiTetanusSerumDetails;
        private System.Windows.Forms.ComboBox comboBoxAntiTetanusSerumDetails;
        private System.Windows.Forms.GroupBox groupBoxDoctorInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDoctorInfo;
        private System.Windows.Forms.Label labelDoctorName;
        private System.Windows.Forms.ComboBox comboBoxDoctorName;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button saveButton;
    }
}
