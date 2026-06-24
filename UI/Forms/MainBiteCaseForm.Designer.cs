namespace ABMS_2026.UI.Forms
{
    partial class MainBiteCaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUserRole;

        private System.Windows.Forms.Panel panelPatientHeader;
        private System.Windows.Forms.PictureBox picPatient;
        private System.Windows.Forms.TableLayoutPanel patientInfoLayout;
        private System.Windows.Forms.Label lblPatientNameCaption;
        private System.Windows.Forms.Label lblPatientNameValue;
        private System.Windows.Forms.Label lblRegNoCaption;
        private System.Windows.Forms.Label lblRegNoValue;
        private System.Windows.Forms.Label lblAgeSexCaption;
        private System.Windows.Forms.Label lblAgeSexValue;
        private System.Windows.Forms.Label lblContactCaption;
        private System.Windows.Forms.Label lblContactValue;
        private System.Windows.Forms.Label lblAddressCaption;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblQueueCaption;
        private System.Windows.Forms.Label lblQueueValue;

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox groupAnatomical;
        private System.Windows.Forms.Panel panelAnatomicalToolbar;
        private System.Windows.Forms.Button btnFrontView;
        private System.Windows.Forms.Button btnBackView;
        private System.Windows.Forms.Button btnResetMap;
        private System.Windows.Forms.Label lblSelectedLocation;
        private System.Windows.Forms.Panel panelAnatomicalMapHost;
        private System.Windows.Forms.PictureBox picAnatomicalMap;

        private System.Windows.Forms.GroupBox groupExposure;
        private System.Windows.Forms.TableLayoutPanel exposureLayout;
        private System.Windows.Forms.Label lblDateOfBite;
        private System.Windows.Forms.DateTimePicker dtpDateOfBite;
        private System.Windows.Forms.Label lblTimeOfBite;
        private System.Windows.Forms.DateTimePicker dtpTimeOfBite;
        private System.Windows.Forms.Label lblPlaceOfOccurrence;
        private System.Windows.Forms.ComboBox cboPlaceOfOccurrence;
        private System.Windows.Forms.Label lblMunicipality;
        private System.Windows.Forms.TextBox txtMunicipality;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.Label lblAnimalType;
        private System.Windows.Forms.ComboBox cboAnimalType;
        private System.Windows.Forms.Label lblAnimalStatus;
        private System.Windows.Forms.ComboBox cboAnimalStatus;
        private System.Windows.Forms.Label lblExposureType;
        private System.Windows.Forms.ComboBox cboExposureType;
        private System.Windows.Forms.Label lblExposureCategory;
        private System.Windows.Forms.ComboBox cboExposureCategory;
        private System.Windows.Forms.Label lblProphylaxis;
        private System.Windows.Forms.ComboBox cboProphylaxis;
        private System.Windows.Forms.CheckBox chkWoundWashed;
        private System.Windows.Forms.CheckBox chkWithBleeding;
        private System.Windows.Forms.CheckBox chkWithoutBleeding;
        private System.Windows.Forms.CheckBox chkDueToUnknownReason;
        private System.Windows.Forms.CheckBox chkDueToRabiesFat;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtExposureRemarks;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDoctorOrder;
        private System.Windows.Forms.TabPage tabVaccination;
        private System.Windows.Forms.TabPage tabProgressNotes;
        private System.Windows.Forms.TabPage tabBilling;

        private System.Windows.Forms.TableLayoutPanel doctorLayout;
        private System.Windows.Forms.GroupBox groupDoctorAssessment;
        private System.Windows.Forms.TextBox txtHistoryOfPresentIllness;
        private System.Windows.Forms.TextBox txtPhysicalExamination;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.TextBox txtManagement;
        private System.Windows.Forms.TextBox txtOtherManagement;
        private System.Windows.Forms.GroupBox groupMedicines;
        private System.Windows.Forms.CheckBox chkAntibiotic;
        private System.Windows.Forms.TextBox txtAntibiotic;
        private System.Windows.Forms.CheckBox chkNsaid;
        private System.Windows.Forms.TextBox txtNsaid;
        private System.Windows.Forms.CheckBox chkOtherMedication;
        private System.Windows.Forms.TextBox txtOtherMedication;
        private System.Windows.Forms.CheckBox chkPep;
        private System.Windows.Forms.TextBox txtPepPreparation;
        private System.Windows.Forms.TextBox txtErig;
        private System.Windows.Forms.TextBox txtTetanusDiphtheria;
        private System.Windows.Forms.TextBox txtTetanusToxoid;
        private System.Windows.Forms.TextBox txtAntiTetanusSerum;
        private System.Windows.Forms.TextBox txtPhysicianName;
        private System.Windows.Forms.Button btnSendToVaccination;
        private System.Windows.Forms.Button btnSaveDoctorOrder;

        private System.Windows.Forms.GroupBox groupVaccinationSchedule;
        private System.Windows.Forms.DataGridView dgvVaccinationSchedule;
        private System.Windows.Forms.GroupBox groupVaccinationDetails;
        private System.Windows.Forms.TextBox txtVaccineBrand;
        private System.Windows.Forms.TextBox txtVaccineLotNo;
        private System.Windows.Forms.ComboBox cboVaccineRoute;
        private System.Windows.Forms.DateTimePicker dtpVaccineDate;
        private System.Windows.Forms.TextBox txtVaccineRemarks;
        private System.Windows.Forms.Button btnSaveVaccination;
        private System.Windows.Forms.Button btnGenerateSchedule;

        private System.Windows.Forms.GroupBox groupProgressNotes;
        private System.Windows.Forms.TextBox txtProgressNotes;
        private System.Windows.Forms.TextBox txtSoapSubjective;
        private System.Windows.Forms.TextBox txtSoapObjective;
        private System.Windows.Forms.TextBox txtSoapAssessment;
        private System.Windows.Forms.TextBox txtSoapPlan;
        private System.Windows.Forms.Button btnSaveProgressNotes;

        private System.Windows.Forms.GroupBox groupBillingSummary;
        private System.Windows.Forms.Label lblInvoiceNoCaption;
        private System.Windows.Forms.Label lblInvoiceNoValue;
        private System.Windows.Forms.Label lblSubtotalCaption;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblDiscountCaption;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblVatCaption;
        private System.Windows.Forms.Label lblVatValue;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblPaidCaption;
        private System.Windows.Forms.Label lblPaidValue;
        private System.Windows.Forms.Label lblBalanceCaption;
        private System.Windows.Forms.Label lblBalanceValue;
        private System.Windows.Forms.DataGridView dgvBillingItems;
        private System.Windows.Forms.Button btnGenerateInvoice;
        private System.Windows.Forms.Button btnRecordPayment;
        private System.Windows.Forms.Button btnPrintInvoice;

        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnCompleteCase;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFooterStatus;

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
            panelHeader = new Panel();
            lblUserRole = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelPatientHeader = new Panel();
            patientInfoLayout = new TableLayoutPanel();
            lblPatientNameCaption = new Label();
            lblPatientNameValue = new Label();
            lblRegNoCaption = new Label();
            lblRegNoValue = new Label();
            lblAgeSexCaption = new Label();
            lblAgeSexValue = new Label();
            lblContactCaption = new Label();
            lblContactValue = new Label();
            lblAddressCaption = new Label();
            lblAddressValue = new Label();
            lblQueueCaption = new Label();
            lblQueueValue = new Label();
            picPatient = new PictureBox();
            mainLayout = new TableLayoutPanel();
            groupAnatomical = new GroupBox();
            panelAnatomicalMapHost = new Panel();
            picAnatomicalMap = new PictureBox();
            panelAnatomicalToolbar = new Panel();
            lblSelectedLocation = new Label();
            btnFrontView = new Button();
            btnBackView = new Button();
            btnResetMap = new Button();
            groupExposure = new GroupBox();
            exposureLayout = new TableLayoutPanel();
            lblDateOfBite = new Label();
            dtpDateOfBite = new DateTimePicker();
            lblTimeOfBite = new Label();
            dtpTimeOfBite = new DateTimePicker();
            lblPlaceOfOccurrence = new Label();
            cboPlaceOfOccurrence = new ComboBox();
            lblMunicipality = new Label();
            txtMunicipality = new TextBox();
            lblProvince = new Label();
            txtProvince = new TextBox();
            lblAnimalType = new Label();
            cboAnimalType = new ComboBox();
            lblAnimalStatus = new Label();
            cboAnimalStatus = new ComboBox();
            lblExposureType = new Label();
            cboExposureType = new ComboBox();
            lblExposureCategory = new Label();
            cboExposureCategory = new ComboBox();
            lblProphylaxis = new Label();
            cboProphylaxis = new ComboBox();
            chkWoundWashed = new CheckBox();
            chkWithBleeding = new CheckBox();
            chkWithoutBleeding = new CheckBox();
            chkDueToUnknownReason = new CheckBox();
            chkDueToRabiesFat = new CheckBox();
            lblRemarks = new Label();
            txtExposureRemarks = new TextBox();
            tabMain = new TabControl();
            tabDoctorOrder = new TabPage();
            doctorLayout = new TableLayoutPanel();
            groupDoctorAssessment = new GroupBox();
            txtOtherManagement = new TextBox();
            txtManagement = new TextBox();
            txtDiagnosis = new TextBox();
            txtPhysicalExamination = new TextBox();
            txtHistoryOfPresentIllness = new TextBox();
            groupMedicines = new GroupBox();
            btnSaveDoctorOrder = new Button();
            btnSendToVaccination = new Button();
            txtPhysicianName = new TextBox();
            txtAntiTetanusSerum = new TextBox();
            txtTetanusToxoid = new TextBox();
            txtTetanusDiphtheria = new TextBox();
            txtErig = new TextBox();
            txtPepPreparation = new TextBox();
            chkPep = new CheckBox();
            txtOtherMedication = new TextBox();
            chkOtherMedication = new CheckBox();
            txtNsaid = new TextBox();
            chkNsaid = new CheckBox();
            txtAntibiotic = new TextBox();
            chkAntibiotic = new CheckBox();
            tabVaccination = new TabPage();
            groupVaccinationDetails = new GroupBox();
            btnGenerateSchedule = new Button();
            btnSaveVaccination = new Button();
            txtVaccineRemarks = new TextBox();
            dtpVaccineDate = new DateTimePicker();
            cboVaccineRoute = new ComboBox();
            txtVaccineLotNo = new TextBox();
            txtVaccineBrand = new TextBox();
            groupVaccinationSchedule = new GroupBox();
            dgvVaccinationSchedule = new DataGridView();
            tabProgressNotes = new TabPage();
            groupProgressNotes = new GroupBox();
            btnSaveProgressNotes = new Button();
            txtSoapPlan = new TextBox();
            txtSoapAssessment = new TextBox();
            txtSoapObjective = new TextBox();
            txtSoapSubjective = new TextBox();
            txtProgressNotes = new TextBox();
            tabBilling = new TabPage();
            groupBillingSummary = new GroupBox();
            btnPrintInvoice = new Button();
            btnRecordPayment = new Button();
            btnGenerateInvoice = new Button();
            dgvBillingItems = new DataGridView();
            lblBalanceValue = new Label();
            lblBalanceCaption = new Label();
            lblPaidValue = new Label();
            lblPaidCaption = new Label();
            lblTotalValue = new Label();
            lblTotalCaption = new Label();
            lblVatValue = new Label();
            lblVatCaption = new Label();
            lblDiscountValue = new Label();
            lblDiscountCaption = new Label();
            lblSubtotalValue = new Label();
            lblSubtotalCaption = new Label();
            lblInvoiceNoValue = new Label();
            lblInvoiceNoCaption = new Label();
            panelFooter = new Panel();
            lblFooterStatus = new Label();
            btnCancel = new Button();
            btnCompleteCase = new Button();
            btnSaveAll = new Button();
            panelHeader.SuspendLayout();
            panelPatientHeader.SuspendLayout();
            patientInfoLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPatient).BeginInit();
            mainLayout.SuspendLayout();
            groupAnatomical.SuspendLayout();
            panelAnatomicalMapHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnatomicalMap).BeginInit();
            panelAnatomicalToolbar.SuspendLayout();
            groupExposure.SuspendLayout();
            exposureLayout.SuspendLayout();
            tabMain.SuspendLayout();
            tabDoctorOrder.SuspendLayout();
            doctorLayout.SuspendLayout();
            groupDoctorAssessment.SuspendLayout();
            groupMedicines.SuspendLayout();
            tabVaccination.SuspendLayout();
            groupVaccinationDetails.SuspendLayout();
            groupVaccinationSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVaccinationSchedule).BeginInit();
            tabProgressNotes.SuspendLayout();
            groupProgressNotes.SuspendLayout();
            tabBilling.SuspendLayout();
            groupBillingSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillingItems).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblUserRole);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1600, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblUserRole
            // 
            lblUserRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserRole.ForeColor = Color.MidnightBlue;
            lblUserRole.Location = new Point(1240, 18);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(340, 24);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Nurse | User";
            lblUserRole.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = SystemColors.GrayText;
            lblSubtitle.Location = new Point(22, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(284, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Exposure assessment, treatment, and follow-up";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(345, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ANIMAL BITE CASE FORM";
            // 
            // panelPatientHeader
            // 
            panelPatientHeader.BackColor = Color.White;
            panelPatientHeader.Controls.Add(patientInfoLayout);
            panelPatientHeader.Controls.Add(picPatient);
            panelPatientHeader.Dock = DockStyle.Top;
            panelPatientHeader.Location = new Point(0, 70);
            panelPatientHeader.Name = "panelPatientHeader";
            panelPatientHeader.Padding = new Padding(16, 12, 16, 12);
            panelPatientHeader.Size = new Size(1600, 120);
            panelPatientHeader.TabIndex = 1;
            // 
            // patientInfoLayout
            // 
            patientInfoLayout.ColumnCount = 6;
            patientInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            patientInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            patientInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            patientInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            patientInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            patientInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            patientInfoLayout.Controls.Add(lblPatientNameCaption, 0, 0);
            patientInfoLayout.Controls.Add(lblPatientNameValue, 0, 1);
            patientInfoLayout.Controls.Add(lblRegNoCaption, 1, 0);
            patientInfoLayout.Controls.Add(lblRegNoValue, 1, 1);
            patientInfoLayout.Controls.Add(lblAgeSexCaption, 2, 0);
            patientInfoLayout.Controls.Add(lblAgeSexValue, 2, 1);
            patientInfoLayout.Controls.Add(lblContactCaption, 3, 0);
            patientInfoLayout.Controls.Add(lblContactValue, 3, 1);
            patientInfoLayout.Controls.Add(lblAddressCaption, 4, 0);
            patientInfoLayout.Controls.Add(lblAddressValue, 4, 1);
            patientInfoLayout.Controls.Add(lblQueueCaption, 5, 0);
            patientInfoLayout.Controls.Add(lblQueueValue, 5, 1);
            patientInfoLayout.Location = new Point(120, 14);
            patientInfoLayout.Name = "patientInfoLayout";
            patientInfoLayout.RowCount = 2;
            patientInfoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            patientInfoLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            patientInfoLayout.Size = new Size(1460, 92);
            patientInfoLayout.TabIndex = 1;
            // 
            // lblPatientNameCaption
            // 
            lblPatientNameCaption.AutoSize = true;
            lblPatientNameCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPatientNameCaption.ForeColor = SystemColors.GrayText;
            lblPatientNameCaption.Location = new Point(3, 0);
            lblPatientNameCaption.Name = "lblPatientNameCaption";
            lblPatientNameCaption.Size = new Size(90, 15);
            lblPatientNameCaption.TabIndex = 0;
            lblPatientNameCaption.Text = "PATIENT NAME";
            // 
            // lblPatientNameValue
            // 
            lblPatientNameValue.AutoSize = true;
            lblPatientNameValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPatientNameValue.Location = new Point(3, 24);
            lblPatientNameValue.Name = "lblPatientNameValue";
            lblPatientNameValue.Size = new Size(24, 20);
            lblPatientNameValue.TabIndex = 1;
            lblPatientNameValue.Text = "—";
            // 
            // lblRegNoCaption
            // 
            lblRegNoCaption.AutoSize = true;
            lblRegNoCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRegNoCaption.ForeColor = SystemColors.GrayText;
            lblRegNoCaption.Location = new Point(265, 0);
            lblRegNoCaption.Name = "lblRegNoCaption";
            lblRegNoCaption.Size = new Size(57, 15);
            lblRegNoCaption.TabIndex = 2;
            lblRegNoCaption.Text = "REG. NO.";
            // 
            // lblRegNoValue
            // 
            lblRegNoValue.AutoSize = true;
            lblRegNoValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRegNoValue.Location = new Point(265, 24);
            lblRegNoValue.Name = "lblRegNoValue";
            lblRegNoValue.Size = new Size(24, 20);
            lblRegNoValue.TabIndex = 3;
            lblRegNoValue.Text = "—";
            // 
            // lblAgeSexCaption
            // 
            lblAgeSexCaption.AutoSize = true;
            lblAgeSexCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAgeSexCaption.ForeColor = SystemColors.GrayText;
            lblAgeSexCaption.Location = new Point(513, 0);
            lblAgeSexCaption.Name = "lblAgeSexCaption";
            lblAgeSexCaption.Size = new Size(62, 15);
            lblAgeSexCaption.TabIndex = 4;
            lblAgeSexCaption.Text = "AGE / SEX";
            // 
            // lblAgeSexValue
            // 
            lblAgeSexValue.AutoSize = true;
            lblAgeSexValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAgeSexValue.Location = new Point(513, 24);
            lblAgeSexValue.Name = "lblAgeSexValue";
            lblAgeSexValue.Size = new Size(24, 20);
            lblAgeSexValue.TabIndex = 5;
            lblAgeSexValue.Text = "—";
            // 
            // lblContactCaption
            // 
            lblContactCaption.AutoSize = true;
            lblContactCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblContactCaption.ForeColor = SystemColors.GrayText;
            lblContactCaption.Location = new Point(732, 0);
            lblContactCaption.Name = "lblContactCaption";
            lblContactCaption.Size = new Size(84, 15);
            lblContactCaption.TabIndex = 6;
            lblContactCaption.Text = "CONTACT NO.";
            // 
            // lblContactValue
            // 
            lblContactValue.AutoSize = true;
            lblContactValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContactValue.Location = new Point(732, 24);
            lblContactValue.Name = "lblContactValue";
            lblContactValue.Size = new Size(24, 20);
            lblContactValue.TabIndex = 7;
            lblContactValue.Text = "—";
            // 
            // lblAddressCaption
            // 
            lblAddressCaption.AutoSize = true;
            lblAddressCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAddressCaption.ForeColor = SystemColors.GrayText;
            lblAddressCaption.Location = new Point(994, 0);
            lblAddressCaption.Name = "lblAddressCaption";
            lblAddressCaption.Size = new Size(61, 15);
            lblAddressCaption.TabIndex = 8;
            lblAddressCaption.Text = "ADDRESS";
            // 
            // lblAddressValue
            // 
            lblAddressValue.AutoSize = true;
            lblAddressValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddressValue.Location = new Point(994, 24);
            lblAddressValue.Name = "lblAddressValue";
            lblAddressValue.Size = new Size(23, 19);
            lblAddressValue.TabIndex = 9;
            lblAddressValue.Text = "—";
            // 
            // lblQueueCaption
            // 
            lblQueueCaption.AutoSize = true;
            lblQueueCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblQueueCaption.ForeColor = SystemColors.GrayText;
            lblQueueCaption.Location = new Point(1256, 0);
            lblQueueCaption.Name = "lblQueueCaption";
            lblQueueCaption.Size = new Size(103, 15);
            lblQueueCaption.TabIndex = 10;
            lblQueueCaption.Text = "CURRENT QUEUE";
            // 
            // lblQueueValue
            // 
            lblQueueValue.AutoSize = true;
            lblQueueValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQueueValue.Location = new Point(1256, 24);
            lblQueueValue.Name = "lblQueueValue";
            lblQueueValue.Size = new Size(24, 20);
            lblQueueValue.TabIndex = 11;
            lblQueueValue.Text = "—";
            // 
            // picPatient
            // 
            picPatient.BackColor = Color.WhiteSmoke;
            picPatient.BorderStyle = BorderStyle.FixedSingle;
            picPatient.Location = new Point(16, 14);
            picPatient.Name = "picPatient";
            picPatient.Size = new Size(92, 92);
            picPatient.SizeMode = PictureBoxSizeMode.Zoom;
            picPatient.TabIndex = 0;
            picPatient.TabStop = false;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            mainLayout.Controls.Add(groupAnatomical, 0, 0);
            mainLayout.Controls.Add(groupExposure, 1, 0);
            mainLayout.Controls.Add(tabMain, 0, 1);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 190);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
            mainLayout.Size = new Size(1600, 750);
            mainLayout.TabIndex = 2;
            // 
            // groupAnatomical
            // 
            groupAnatomical.Controls.Add(panelAnatomicalMapHost);
            groupAnatomical.Controls.Add(panelAnatomicalToolbar);
            groupAnatomical.Dock = DockStyle.Fill;
            groupAnatomical.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupAnatomical.Location = new Point(12, 12);
            groupAnatomical.Margin = new Padding(12);
            groupAnatomical.Name = "groupAnatomical";
            groupAnatomical.Padding = new Padding(12, 22, 12, 12);
            groupAnatomical.Size = new Size(696, 336);
            groupAnatomical.TabIndex = 0;
            groupAnatomical.TabStop = false;
            groupAnatomical.Text = "ANATOMICAL LOCATION";
            // 
            // panelAnatomicalMapHost
            // 
            panelAnatomicalMapHost.Controls.Add(picAnatomicalMap);
            panelAnatomicalMapHost.Dock = DockStyle.Fill;
            panelAnatomicalMapHost.Location = new Point(12, 82);
            panelAnatomicalMapHost.Name = "panelAnatomicalMapHost";
            panelAnatomicalMapHost.Padding = new Padding(6);
            panelAnatomicalMapHost.Size = new Size(672, 242);
            panelAnatomicalMapHost.TabIndex = 1;
            // 
            // picAnatomicalMap
            // 
            picAnatomicalMap.BackColor = Color.White;
            picAnatomicalMap.BorderStyle = BorderStyle.FixedSingle;
            picAnatomicalMap.Dock = DockStyle.Fill;
            picAnatomicalMap.Location = new Point(6, 6);
            picAnatomicalMap.Name = "picAnatomicalMap";
            picAnatomicalMap.Size = new Size(660, 230);
            picAnatomicalMap.SizeMode = PictureBoxSizeMode.Zoom;
            picAnatomicalMap.TabIndex = 0;
            picAnatomicalMap.TabStop = false;
            // 
            // panelAnatomicalToolbar
            // 
            panelAnatomicalToolbar.Controls.Add(lblSelectedLocation);
            panelAnatomicalToolbar.Controls.Add(btnFrontView);
            panelAnatomicalToolbar.Controls.Add(btnBackView);
            panelAnatomicalToolbar.Controls.Add(btnResetMap);
            panelAnatomicalToolbar.Dock = DockStyle.Top;
            panelAnatomicalToolbar.Location = new Point(12, 40);
            panelAnatomicalToolbar.Name = "panelAnatomicalToolbar";
            panelAnatomicalToolbar.Size = new Size(672, 42);
            panelAnatomicalToolbar.TabIndex = 0;
            // 
            // lblSelectedLocation
            // 
            lblSelectedLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectedLocation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectedLocation.ForeColor = Color.MidnightBlue;
            lblSelectedLocation.Location = new Point(320, 8);
            lblSelectedLocation.Name = "lblSelectedLocation";
            lblSelectedLocation.Size = new Size(352, 24);
            lblSelectedLocation.TabIndex = 0;
            lblSelectedLocation.Text = "Selected: —";
            lblSelectedLocation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnFrontView
            // 
            btnFrontView.Location = new Point(0, 5);
            btnFrontView.Name = "btnFrontView";
            btnFrontView.Size = new Size(84, 30);
            btnFrontView.TabIndex = 1;
            btnFrontView.Text = "Front";
            btnFrontView.UseVisualStyleBackColor = true;
            // 
            // btnBackView
            // 
            btnBackView.Location = new Point(90, 5);
            btnBackView.Name = "btnBackView";
            btnBackView.Size = new Size(84, 30);
            btnBackView.TabIndex = 2;
            btnBackView.Text = "Back";
            btnBackView.UseVisualStyleBackColor = true;
            // 
            // btnResetMap
            // 
            btnResetMap.Location = new Point(180, 5);
            btnResetMap.Name = "btnResetMap";
            btnResetMap.Size = new Size(84, 30);
            btnResetMap.TabIndex = 3;
            btnResetMap.Text = "Reset";
            btnResetMap.UseVisualStyleBackColor = true;
            // 
            // groupExposure
            // 
            groupExposure.Controls.Add(exposureLayout);
            groupExposure.Dock = DockStyle.Fill;
            groupExposure.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupExposure.Location = new Point(732, 12);
            groupExposure.Margin = new Padding(12);
            groupExposure.Name = "groupExposure";
            groupExposure.Padding = new Padding(12, 22, 12, 12);
            groupExposure.Size = new Size(856, 336);
            groupExposure.TabIndex = 1;
            groupExposure.TabStop = false;
            groupExposure.Text = "EXPOSURE HISTORY";
            // 
            // exposureLayout
            // 
            exposureLayout.ColumnCount = 4;
            exposureLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            exposureLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            exposureLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            exposureLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            exposureLayout.Controls.Add(lblDateOfBite, 0, 0);
            exposureLayout.Controls.Add(dtpDateOfBite, 0, 1);
            exposureLayout.Controls.Add(lblTimeOfBite, 1, 0);
            exposureLayout.Controls.Add(dtpTimeOfBite, 1, 1);
            exposureLayout.Controls.Add(lblPlaceOfOccurrence, 2, 0);
            exposureLayout.Controls.Add(cboPlaceOfOccurrence, 2, 1);
            exposureLayout.Controls.Add(lblMunicipality, 3, 0);
            exposureLayout.Controls.Add(txtMunicipality, 3, 1);
            exposureLayout.Controls.Add(lblProvince, 0, 2);
            exposureLayout.Controls.Add(txtProvince, 0, 3);
            exposureLayout.Controls.Add(lblAnimalType, 1, 2);
            exposureLayout.Controls.Add(cboAnimalType, 1, 3);
            exposureLayout.Controls.Add(lblAnimalStatus, 2, 2);
            exposureLayout.Controls.Add(cboAnimalStatus, 2, 3);
            exposureLayout.Controls.Add(lblExposureType, 3, 2);
            exposureLayout.Controls.Add(cboExposureType, 3, 3);
            exposureLayout.Controls.Add(lblExposureCategory, 0, 4);
            exposureLayout.Controls.Add(cboExposureCategory, 0, 5);
            exposureLayout.Controls.Add(lblProphylaxis, 1, 4);
            exposureLayout.Controls.Add(cboProphylaxis, 1, 5);
            exposureLayout.Controls.Add(chkWoundWashed, 2, 4);
            exposureLayout.Controls.Add(chkWithBleeding, 2, 5);
            exposureLayout.Controls.Add(chkWithoutBleeding, 3, 4);
            exposureLayout.Controls.Add(chkDueToUnknownReason, 3, 5);
            exposureLayout.Controls.Add(chkDueToRabiesFat, 0, 6);
            exposureLayout.Controls.Add(lblRemarks, 0, 7);
            exposureLayout.Controls.Add(txtExposureRemarks, 0, 8);
            exposureLayout.Dock = DockStyle.Fill;
            exposureLayout.Location = new Point(12, 40);
            exposureLayout.Name = "exposureLayout";
            exposureLayout.RowCount = 9;
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            exposureLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            exposureLayout.Size = new Size(832, 284);
            exposureLayout.TabIndex = 0;
            // 
            // lblDateOfBite
            // 
            lblDateOfBite.AutoSize = true;
            lblDateOfBite.Location = new Point(3, 0);
            lblDateOfBite.Name = "lblDateOfBite";
            lblDateOfBite.Size = new Size(88, 19);
            lblDateOfBite.TabIndex = 0;
            lblDateOfBite.Text = "Date of Bite";
            // 
            // dtpDateOfBite
            // 
            dtpDateOfBite.Dock = DockStyle.Fill;
            dtpDateOfBite.Format = DateTimePickerFormat.Short;
            dtpDateOfBite.Location = new Point(3, 25);
            dtpDateOfBite.Name = "dtpDateOfBite";
            dtpDateOfBite.Size = new Size(202, 25);
            dtpDateOfBite.TabIndex = 1;
            // 
            // lblTimeOfBite
            // 
            lblTimeOfBite.AutoSize = true;
            lblTimeOfBite.Location = new Point(211, 0);
            lblTimeOfBite.Name = "lblTimeOfBite";
            lblTimeOfBite.Size = new Size(90, 19);
            lblTimeOfBite.TabIndex = 2;
            lblTimeOfBite.Text = "Time of Bite";
            // 
            // dtpTimeOfBite
            // 
            dtpTimeOfBite.Dock = DockStyle.Fill;
            dtpTimeOfBite.Format = DateTimePickerFormat.Time;
            dtpTimeOfBite.Location = new Point(211, 25);
            dtpTimeOfBite.Name = "dtpTimeOfBite";
            dtpTimeOfBite.ShowUpDown = true;
            dtpTimeOfBite.Size = new Size(202, 25);
            dtpTimeOfBite.TabIndex = 3;
            // 
            // lblPlaceOfOccurrence
            // 
            lblPlaceOfOccurrence.AutoSize = true;
            lblPlaceOfOccurrence.Location = new Point(419, 0);
            lblPlaceOfOccurrence.Name = "lblPlaceOfOccurrence";
            lblPlaceOfOccurrence.Size = new Size(143, 19);
            lblPlaceOfOccurrence.TabIndex = 4;
            lblPlaceOfOccurrence.Text = "Place of Occurrence";
            // 
            // cboPlaceOfOccurrence
            // 
            cboPlaceOfOccurrence.Dock = DockStyle.Fill;
            cboPlaceOfOccurrence.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlaceOfOccurrence.Location = new Point(419, 25);
            cboPlaceOfOccurrence.Name = "cboPlaceOfOccurrence";
            cboPlaceOfOccurrence.Size = new Size(202, 25);
            cboPlaceOfOccurrence.TabIndex = 5;
            // 
            // lblMunicipality
            // 
            lblMunicipality.AutoSize = true;
            lblMunicipality.Location = new Point(627, 0);
            lblMunicipality.Name = "lblMunicipality";
            lblMunicipality.Size = new Size(91, 19);
            lblMunicipality.TabIndex = 6;
            lblMunicipality.Text = "Municipality";
            // 
            // txtMunicipality
            // 
            txtMunicipality.Dock = DockStyle.Fill;
            txtMunicipality.Location = new Point(627, 25);
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new Size(202, 25);
            txtMunicipality.TabIndex = 7;
            // 
            // lblProvince
            // 
            lblProvince.AutoSize = true;
            lblProvince.Location = new Point(3, 56);
            lblProvince.Name = "lblProvince";
            lblProvince.Size = new Size(68, 19);
            lblProvince.TabIndex = 8;
            lblProvince.Text = "Province";
            // 
            // txtProvince
            // 
            txtProvince.Dock = DockStyle.Fill;
            txtProvince.Location = new Point(3, 81);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(202, 25);
            txtProvince.TabIndex = 9;
            // 
            // lblAnimalType
            // 
            lblAnimalType.AutoSize = true;
            lblAnimalType.Location = new Point(211, 56);
            lblAnimalType.Name = "lblAnimalType";
            lblAnimalType.Size = new Size(92, 19);
            lblAnimalType.TabIndex = 10;
            lblAnimalType.Text = "Animal Type";
            // 
            // cboAnimalType
            // 
            cboAnimalType.Dock = DockStyle.Fill;
            cboAnimalType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAnimalType.Location = new Point(211, 81);
            cboAnimalType.Name = "cboAnimalType";
            cboAnimalType.Size = new Size(202, 25);
            cboAnimalType.TabIndex = 11;
            // 
            // lblAnimalStatus
            // 
            lblAnimalStatus.AutoSize = true;
            lblAnimalStatus.Location = new Point(419, 56);
            lblAnimalStatus.Name = "lblAnimalStatus";
            lblAnimalStatus.Size = new Size(100, 19);
            lblAnimalStatus.TabIndex = 12;
            lblAnimalStatus.Text = "Animal Status";
            // 
            // cboAnimalStatus
            // 
            cboAnimalStatus.Dock = DockStyle.Fill;
            cboAnimalStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAnimalStatus.Location = new Point(419, 81);
            cboAnimalStatus.Name = "cboAnimalStatus";
            cboAnimalStatus.Size = new Size(202, 25);
            cboAnimalStatus.TabIndex = 13;
            // 
            // lblExposureType
            // 
            lblExposureType.AutoSize = true;
            lblExposureType.Location = new Point(627, 56);
            lblExposureType.Name = "lblExposureType";
            lblExposureType.Size = new Size(106, 19);
            lblExposureType.TabIndex = 14;
            lblExposureType.Text = "Exposure Type";
            // 
            // cboExposureType
            // 
            cboExposureType.Dock = DockStyle.Fill;
            cboExposureType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExposureType.Location = new Point(627, 81);
            cboExposureType.Name = "cboExposureType";
            cboExposureType.Size = new Size(202, 25);
            cboExposureType.TabIndex = 15;
            // 
            // lblExposureCategory
            // 
            lblExposureCategory.AutoSize = true;
            lblExposureCategory.Location = new Point(3, 112);
            lblExposureCategory.Name = "lblExposureCategory";
            lblExposureCategory.Size = new Size(137, 19);
            lblExposureCategory.TabIndex = 16;
            lblExposureCategory.Text = "Exposure Category";
            // 
            // cboExposureCategory
            // 
            cboExposureCategory.Dock = DockStyle.Fill;
            cboExposureCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExposureCategory.Location = new Point(3, 137);
            cboExposureCategory.Name = "cboExposureCategory";
            cboExposureCategory.Size = new Size(202, 25);
            cboExposureCategory.TabIndex = 17;
            // 
            // lblProphylaxis
            // 
            lblProphylaxis.AutoSize = true;
            lblProphylaxis.Location = new Point(211, 112);
            lblProphylaxis.Name = "lblProphylaxis";
            lblProphylaxis.Size = new Size(88, 19);
            lblProphylaxis.TabIndex = 18;
            lblProphylaxis.Text = "Prophylaxis";
            // 
            // cboProphylaxis
            // 
            cboProphylaxis.Dock = DockStyle.Fill;
            cboProphylaxis.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProphylaxis.Location = new Point(211, 137);
            cboProphylaxis.Name = "cboProphylaxis";
            cboProphylaxis.Size = new Size(202, 25);
            cboProphylaxis.TabIndex = 19;
            // 
            // chkWoundWashed
            // 
            chkWoundWashed.AutoSize = true;
            chkWoundWashed.Location = new Point(419, 115);
            chkWoundWashed.Name = "chkWoundWashed";
            chkWoundWashed.Size = new Size(132, 16);
            chkWoundWashed.TabIndex = 20;
            chkWoundWashed.Text = "Wound Washed";
            // 
            // chkWithBleeding
            // 
            chkWithBleeding.AutoSize = true;
            chkWithBleeding.Location = new Point(419, 137);
            chkWithBleeding.Name = "chkWithBleeding";
            chkWithBleeding.Size = new Size(122, 23);
            chkWithBleeding.TabIndex = 21;
            chkWithBleeding.Text = "With Bleeding";
            // 
            // chkWithoutBleeding
            // 
            chkWithoutBleeding.AutoSize = true;
            chkWithoutBleeding.Location = new Point(627, 115);
            chkWithoutBleeding.Name = "chkWithoutBleeding";
            chkWithoutBleeding.Size = new Size(144, 16);
            chkWithoutBleeding.TabIndex = 22;
            chkWithoutBleeding.Text = "Without Bleeding";
            // 
            // chkDueToUnknownReason
            // 
            chkDueToUnknownReason.AutoSize = true;
            chkDueToUnknownReason.Location = new Point(627, 137);
            chkDueToUnknownReason.Name = "chkDueToUnknownReason";
            chkDueToUnknownReason.Size = new Size(190, 23);
            chkDueToUnknownReason.TabIndex = 23;
            chkDueToUnknownReason.Text = "Due to Unknown Reason";
            // 
            // chkDueToRabiesFat
            // 
            chkDueToRabiesFat.AutoSize = true;
            chkDueToRabiesFat.Location = new Point(3, 171);
            chkDueToRabiesFat.Name = "chkDueToRabiesFat";
            chkDueToRabiesFat.Size = new Size(154, 18);
            chkDueToRabiesFat.TabIndex = 24;
            chkDueToRabiesFat.Text = "Due to Rabies (Fat)";
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(3, 192);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(67, 19);
            lblRemarks.TabIndex = 25;
            lblRemarks.Text = "Remarks";
            // 
            // txtExposureRemarks
            // 
            txtExposureRemarks.Dock = DockStyle.Fill;
            txtExposureRemarks.Location = new Point(3, 217);
            txtExposureRemarks.Multiline = true;
            txtExposureRemarks.Name = "txtExposureRemarks";
            txtExposureRemarks.ScrollBars = ScrollBars.Vertical;
            txtExposureRemarks.Size = new Size(202, 64);
            txtExposureRemarks.TabIndex = 26;
            // 
            // tabMain
            // 
            mainLayout.SetColumnSpan(tabMain, 2);
            tabMain.Controls.Add(tabDoctorOrder);
            tabMain.Controls.Add(tabVaccination);
            tabMain.Controls.Add(tabProgressNotes);
            tabMain.Controls.Add(tabBilling);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(12, 372);
            tabMain.Margin = new Padding(12);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1576, 366);
            tabMain.TabIndex = 2;
            // 
            // tabDoctorOrder
            // 
            tabDoctorOrder.Controls.Add(doctorLayout);
            tabDoctorOrder.Location = new Point(4, 24);
            tabDoctorOrder.Name = "tabDoctorOrder";
            tabDoctorOrder.Padding = new Padding(3);
            tabDoctorOrder.Size = new Size(1568, 338);
            tabDoctorOrder.TabIndex = 0;
            tabDoctorOrder.Text = "Doctor Order";
            tabDoctorOrder.UseVisualStyleBackColor = true;
            // 
            // doctorLayout
            // 
            doctorLayout.ColumnCount = 2;
            doctorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            doctorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            doctorLayout.Controls.Add(groupDoctorAssessment, 0, 0);
            doctorLayout.Controls.Add(groupMedicines, 1, 0);
            doctorLayout.Dock = DockStyle.Fill;
            doctorLayout.Location = new Point(3, 3);
            doctorLayout.Name = "doctorLayout";
            doctorLayout.RowCount = 1;
            doctorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            doctorLayout.Size = new Size(1562, 332);
            doctorLayout.TabIndex = 0;
            // 
            // groupDoctorAssessment
            // 
            groupDoctorAssessment.Controls.Add(txtOtherManagement);
            groupDoctorAssessment.Controls.Add(txtManagement);
            groupDoctorAssessment.Controls.Add(txtDiagnosis);
            groupDoctorAssessment.Controls.Add(txtPhysicalExamination);
            groupDoctorAssessment.Controls.Add(txtHistoryOfPresentIllness);
            groupDoctorAssessment.Dock = DockStyle.Fill;
            groupDoctorAssessment.Location = new Point(3, 3);
            groupDoctorAssessment.Name = "groupDoctorAssessment";
            groupDoctorAssessment.Padding = new Padding(12, 22, 12, 12);
            groupDoctorAssessment.Size = new Size(931, 326);
            groupDoctorAssessment.TabIndex = 0;
            groupDoctorAssessment.TabStop = false;
            groupDoctorAssessment.Text = "Doctor Assessment";
            // 
            // txtOtherManagement
            // 
            txtOtherManagement.Dock = DockStyle.Top;
            txtOtherManagement.Location = new Point(12, 246);
            txtOtherManagement.Multiline = true;
            txtOtherManagement.Name = "txtOtherManagement";
            txtOtherManagement.PlaceholderText = "Other management";
            txtOtherManagement.Size = new Size(907, 52);
            txtOtherManagement.TabIndex = 1;
            // 
            // txtManagement
            // 
            txtManagement.Dock = DockStyle.Top;
            txtManagement.Location = new Point(12, 194);
            txtManagement.Multiline = true;
            txtManagement.Name = "txtManagement";
            txtManagement.PlaceholderText = "Management";
            txtManagement.Size = new Size(907, 52);
            txtManagement.TabIndex = 2;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.Dock = DockStyle.Top;
            txtDiagnosis.Location = new Point(12, 142);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.PlaceholderText = "Diagnosis";
            txtDiagnosis.Size = new Size(907, 52);
            txtDiagnosis.TabIndex = 3;
            // 
            // txtPhysicalExamination
            // 
            txtPhysicalExamination.Dock = DockStyle.Top;
            txtPhysicalExamination.Location = new Point(12, 90);
            txtPhysicalExamination.Multiline = true;
            txtPhysicalExamination.Name = "txtPhysicalExamination";
            txtPhysicalExamination.PlaceholderText = "Pertinent physical examination";
            txtPhysicalExamination.Size = new Size(907, 52);
            txtPhysicalExamination.TabIndex = 4;
            // 
            // txtHistoryOfPresentIllness
            // 
            txtHistoryOfPresentIllness.Dock = DockStyle.Top;
            txtHistoryOfPresentIllness.Location = new Point(12, 38);
            txtHistoryOfPresentIllness.Multiline = true;
            txtHistoryOfPresentIllness.Name = "txtHistoryOfPresentIllness";
            txtHistoryOfPresentIllness.PlaceholderText = "History of present illness";
            txtHistoryOfPresentIllness.Size = new Size(907, 52);
            txtHistoryOfPresentIllness.TabIndex = 5;
            // 
            // groupMedicines
            // 
            groupMedicines.Controls.Add(btnSaveDoctorOrder);
            groupMedicines.Controls.Add(btnSendToVaccination);
            groupMedicines.Controls.Add(txtPhysicianName);
            groupMedicines.Controls.Add(txtAntiTetanusSerum);
            groupMedicines.Controls.Add(txtTetanusToxoid);
            groupMedicines.Controls.Add(txtTetanusDiphtheria);
            groupMedicines.Controls.Add(txtErig);
            groupMedicines.Controls.Add(txtPepPreparation);
            groupMedicines.Controls.Add(chkPep);
            groupMedicines.Controls.Add(txtOtherMedication);
            groupMedicines.Controls.Add(chkOtherMedication);
            groupMedicines.Controls.Add(txtNsaid);
            groupMedicines.Controls.Add(chkNsaid);
            groupMedicines.Controls.Add(txtAntibiotic);
            groupMedicines.Controls.Add(chkAntibiotic);
            groupMedicines.Dock = DockStyle.Fill;
            groupMedicines.Location = new Point(940, 3);
            groupMedicines.Name = "groupMedicines";
            groupMedicines.Padding = new Padding(12, 22, 12, 12);
            groupMedicines.Size = new Size(619, 326);
            groupMedicines.TabIndex = 1;
            groupMedicines.TabStop = false;
            groupMedicines.Text = "Medications / Orders";
            // 
            // btnSaveDoctorOrder
            // 
            btnSaveDoctorOrder.Dock = DockStyle.Bottom;
            btnSaveDoctorOrder.Location = new Point(12, 245);
            btnSaveDoctorOrder.Name = "btnSaveDoctorOrder";
            btnSaveDoctorOrder.Size = new Size(595, 23);
            btnSaveDoctorOrder.TabIndex = 0;
            btnSaveDoctorOrder.Text = "Save Doctor Order";
            // 
            // btnSendToVaccination
            // 
            btnSendToVaccination.Dock = DockStyle.Bottom;
            btnSendToVaccination.Location = new Point(12, 268);
            btnSendToVaccination.Name = "btnSendToVaccination";
            btnSendToVaccination.Size = new Size(595, 23);
            btnSendToVaccination.TabIndex = 1;
            btnSendToVaccination.Text = "Send to Vaccination";
            // 
            // txtPhysicianName
            // 
            txtPhysicianName.Dock = DockStyle.Bottom;
            txtPhysicianName.Location = new Point(12, 291);
            txtPhysicianName.Name = "txtPhysicianName";
            txtPhysicianName.PlaceholderText = "Physician name";
            txtPhysicianName.Size = new Size(595, 23);
            txtPhysicianName.TabIndex = 0;
            // 
            // txtAntiTetanusSerum
            // 
            txtAntiTetanusSerum.Dock = DockStyle.Top;
            txtAntiTetanusSerum.Location = new Point(12, 199);
            txtAntiTetanusSerum.Name = "txtAntiTetanusSerum";
            txtAntiTetanusSerum.PlaceholderText = "Anti-tetanus serum";
            txtAntiTetanusSerum.Size = new Size(595, 23);
            txtAntiTetanusSerum.TabIndex = 2;
            // 
            // txtTetanusToxoid
            // 
            txtTetanusToxoid.Dock = DockStyle.Top;
            txtTetanusToxoid.Location = new Point(12, 176);
            txtTetanusToxoid.Name = "txtTetanusToxoid";
            txtTetanusToxoid.PlaceholderText = "Tetanus toxoid";
            txtTetanusToxoid.Size = new Size(595, 23);
            txtTetanusToxoid.TabIndex = 3;
            // 
            // txtTetanusDiphtheria
            // 
            txtTetanusDiphtheria.Dock = DockStyle.Top;
            txtTetanusDiphtheria.Location = new Point(12, 153);
            txtTetanusDiphtheria.Name = "txtTetanusDiphtheria";
            txtTetanusDiphtheria.PlaceholderText = "Tetanus diphtheria";
            txtTetanusDiphtheria.Size = new Size(595, 23);
            txtTetanusDiphtheria.TabIndex = 4;
            // 
            // txtErig
            // 
            txtErig.Dock = DockStyle.Top;
            txtErig.Location = new Point(12, 130);
            txtErig.Name = "txtErig";
            txtErig.PlaceholderText = "ERIG";
            txtErig.Size = new Size(595, 23);
            txtErig.TabIndex = 5;
            // 
            // txtPepPreparation
            // 
            txtPepPreparation.Dock = DockStyle.Top;
            txtPepPreparation.Location = new Point(12, 107);
            txtPepPreparation.Name = "txtPepPreparation";
            txtPepPreparation.PlaceholderText = "PEP preparation";
            txtPepPreparation.Size = new Size(595, 23);
            txtPepPreparation.TabIndex = 6;
            // 
            // chkPep
            // 
            chkPep.AutoSize = true;
            chkPep.Location = new Point(0, 0);
            chkPep.Name = "chkPep";
            chkPep.Size = new Size(46, 19);
            chkPep.TabIndex = 7;
            chkPep.Text = "PEP";
            // 
            // txtOtherMedication
            // 
            txtOtherMedication.Dock = DockStyle.Top;
            txtOtherMedication.Location = new Point(12, 84);
            txtOtherMedication.Name = "txtOtherMedication";
            txtOtherMedication.PlaceholderText = "Other medication details";
            txtOtherMedication.Size = new Size(595, 23);
            txtOtherMedication.TabIndex = 8;
            // 
            // chkOtherMedication
            // 
            chkOtherMedication.AutoSize = true;
            chkOtherMedication.Location = new Point(0, 0);
            chkOtherMedication.Name = "chkOtherMedication";
            chkOtherMedication.Size = new Size(119, 19);
            chkOtherMedication.TabIndex = 9;
            chkOtherMedication.Text = "Other Medication";
            // 
            // txtNsaid
            // 
            txtNsaid.Dock = DockStyle.Top;
            txtNsaid.Location = new Point(12, 61);
            txtNsaid.Name = "txtNsaid";
            txtNsaid.PlaceholderText = "NSAID details";
            txtNsaid.Size = new Size(595, 23);
            txtNsaid.TabIndex = 10;
            // 
            // chkNsaid
            // 
            chkNsaid.AutoSize = true;
            chkNsaid.Location = new Point(0, 0);
            chkNsaid.Name = "chkNsaid";
            chkNsaid.Size = new Size(60, 19);
            chkNsaid.TabIndex = 11;
            chkNsaid.Text = "NSAID";
            // 
            // txtAntibiotic
            // 
            txtAntibiotic.Dock = DockStyle.Top;
            txtAntibiotic.Location = new Point(12, 38);
            txtAntibiotic.Name = "txtAntibiotic";
            txtAntibiotic.PlaceholderText = "Antibiotic details";
            txtAntibiotic.Size = new Size(595, 23);
            txtAntibiotic.TabIndex = 12;
            // 
            // chkAntibiotic
            // 
            chkAntibiotic.AutoSize = true;
            chkAntibiotic.Location = new Point(0, 0);
            chkAntibiotic.Name = "chkAntibiotic";
            chkAntibiotic.Size = new Size(78, 19);
            chkAntibiotic.TabIndex = 13;
            chkAntibiotic.Text = "Antibiotic";
            // 
            // tabVaccination
            // 
            tabVaccination.Controls.Add(groupVaccinationDetails);
            tabVaccination.Controls.Add(groupVaccinationSchedule);
            tabVaccination.Location = new Point(4, 24);
            tabVaccination.Name = "tabVaccination";
            tabVaccination.Padding = new Padding(3);
            tabVaccination.Size = new Size(1568, 338);
            tabVaccination.TabIndex = 1;
            tabVaccination.Text = "Vaccination";
            tabVaccination.UseVisualStyleBackColor = true;
            // 
            // groupVaccinationDetails
            // 
            groupVaccinationDetails.Controls.Add(btnGenerateSchedule);
            groupVaccinationDetails.Controls.Add(btnSaveVaccination);
            groupVaccinationDetails.Controls.Add(txtVaccineRemarks);
            groupVaccinationDetails.Controls.Add(dtpVaccineDate);
            groupVaccinationDetails.Controls.Add(cboVaccineRoute);
            groupVaccinationDetails.Controls.Add(txtVaccineLotNo);
            groupVaccinationDetails.Controls.Add(txtVaccineBrand);
            groupVaccinationDetails.Dock = DockStyle.Fill;
            groupVaccinationDetails.Location = new Point(763, 3);
            groupVaccinationDetails.Name = "groupVaccinationDetails";
            groupVaccinationDetails.Padding = new Padding(12, 22, 12, 12);
            groupVaccinationDetails.Size = new Size(802, 332);
            groupVaccinationDetails.TabIndex = 1;
            groupVaccinationDetails.TabStop = false;
            groupVaccinationDetails.Text = "Vaccination Details";
            // 
            // btnGenerateSchedule
            // 
            btnGenerateSchedule.Dock = DockStyle.Bottom;
            btnGenerateSchedule.Location = new Point(12, 274);
            btnGenerateSchedule.Name = "btnGenerateSchedule";
            btnGenerateSchedule.Size = new Size(778, 23);
            btnGenerateSchedule.TabIndex = 0;
            btnGenerateSchedule.Text = "Generate Schedule";
            // 
            // btnSaveVaccination
            // 
            btnSaveVaccination.Dock = DockStyle.Bottom;
            btnSaveVaccination.Location = new Point(12, 297);
            btnSaveVaccination.Name = "btnSaveVaccination";
            btnSaveVaccination.Size = new Size(778, 23);
            btnSaveVaccination.TabIndex = 1;
            btnSaveVaccination.Text = "Save Vaccination";
            // 
            // txtVaccineRemarks
            // 
            txtVaccineRemarks.Dock = DockStyle.Fill;
            txtVaccineRemarks.Location = new Point(12, 130);
            txtVaccineRemarks.Multiline = true;
            txtVaccineRemarks.Name = "txtVaccineRemarks";
            txtVaccineRemarks.PlaceholderText = "Remarks";
            txtVaccineRemarks.Size = new Size(778, 190);
            txtVaccineRemarks.TabIndex = 2;
            // 
            // dtpVaccineDate
            // 
            dtpVaccineDate.Dock = DockStyle.Top;
            dtpVaccineDate.Format = DateTimePickerFormat.Short;
            dtpVaccineDate.Location = new Point(12, 107);
            dtpVaccineDate.Name = "dtpVaccineDate";
            dtpVaccineDate.Size = new Size(778, 23);
            dtpVaccineDate.TabIndex = 3;
            // 
            // cboVaccineRoute
            // 
            cboVaccineRoute.Dock = DockStyle.Top;
            cboVaccineRoute.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaccineRoute.Location = new Point(12, 84);
            cboVaccineRoute.Name = "cboVaccineRoute";
            cboVaccineRoute.Size = new Size(778, 23);
            cboVaccineRoute.TabIndex = 4;
            // 
            // txtVaccineLotNo
            // 
            txtVaccineLotNo.Dock = DockStyle.Top;
            txtVaccineLotNo.Location = new Point(12, 61);
            txtVaccineLotNo.Name = "txtVaccineLotNo";
            txtVaccineLotNo.PlaceholderText = "Lot no";
            txtVaccineLotNo.Size = new Size(778, 23);
            txtVaccineLotNo.TabIndex = 5;
            // 
            // txtVaccineBrand
            // 
            txtVaccineBrand.Dock = DockStyle.Top;
            txtVaccineBrand.Location = new Point(12, 38);
            txtVaccineBrand.Name = "txtVaccineBrand";
            txtVaccineBrand.PlaceholderText = "Vaccine brand";
            txtVaccineBrand.Size = new Size(778, 23);
            txtVaccineBrand.TabIndex = 6;
            // 
            // groupVaccinationSchedule
            // 
            groupVaccinationSchedule.Controls.Add(dgvVaccinationSchedule);
            groupVaccinationSchedule.Dock = DockStyle.Left;
            groupVaccinationSchedule.Location = new Point(3, 3);
            groupVaccinationSchedule.Name = "groupVaccinationSchedule";
            groupVaccinationSchedule.Padding = new Padding(12, 22, 12, 12);
            groupVaccinationSchedule.Size = new Size(760, 332);
            groupVaccinationSchedule.TabIndex = 0;
            groupVaccinationSchedule.TabStop = false;
            groupVaccinationSchedule.Text = "Schedule";
            // 
            // dgvVaccinationSchedule
            // 
            dgvVaccinationSchedule.AllowUserToAddRows = false;
            dgvVaccinationSchedule.AllowUserToDeleteRows = false;
            dgvVaccinationSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVaccinationSchedule.Dock = DockStyle.Fill;
            dgvVaccinationSchedule.Location = new Point(12, 38);
            dgvVaccinationSchedule.Name = "dgvVaccinationSchedule";
            dgvVaccinationSchedule.RowHeadersVisible = false;
            dgvVaccinationSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVaccinationSchedule.Size = new Size(736, 282);
            dgvVaccinationSchedule.TabIndex = 0;
            // 
            // tabProgressNotes
            // 
            tabProgressNotes.Controls.Add(groupProgressNotes);
            tabProgressNotes.Location = new Point(4, 24);
            tabProgressNotes.Name = "tabProgressNotes";
            tabProgressNotes.Padding = new Padding(3);
            tabProgressNotes.Size = new Size(1568, 338);
            tabProgressNotes.TabIndex = 2;
            tabProgressNotes.Text = "Progress Notes";
            tabProgressNotes.UseVisualStyleBackColor = true;
            // 
            // groupProgressNotes
            // 
            groupProgressNotes.Controls.Add(btnSaveProgressNotes);
            groupProgressNotes.Controls.Add(txtSoapPlan);
            groupProgressNotes.Controls.Add(txtSoapAssessment);
            groupProgressNotes.Controls.Add(txtSoapObjective);
            groupProgressNotes.Controls.Add(txtSoapSubjective);
            groupProgressNotes.Controls.Add(txtProgressNotes);
            groupProgressNotes.Dock = DockStyle.Fill;
            groupProgressNotes.Location = new Point(3, 3);
            groupProgressNotes.Name = "groupProgressNotes";
            groupProgressNotes.Padding = new Padding(12, 22, 12, 12);
            groupProgressNotes.Size = new Size(1562, 332);
            groupProgressNotes.TabIndex = 0;
            groupProgressNotes.TabStop = false;
            groupProgressNotes.Text = "SOAP / Progress Notes";
            // 
            // btnSaveProgressNotes
            // 
            btnSaveProgressNotes.Dock = DockStyle.Bottom;
            btnSaveProgressNotes.Location = new Point(12, 297);
            btnSaveProgressNotes.Name = "btnSaveProgressNotes";
            btnSaveProgressNotes.Size = new Size(1538, 23);
            btnSaveProgressNotes.TabIndex = 0;
            btnSaveProgressNotes.Text = "Save Progress Notes";
            // 
            // txtSoapPlan
            // 
            txtSoapPlan.Dock = DockStyle.Top;
            txtSoapPlan.Location = new Point(12, 176);
            txtSoapPlan.Multiline = true;
            txtSoapPlan.Name = "txtSoapPlan";
            txtSoapPlan.PlaceholderText = "P - Plan";
            txtSoapPlan.Size = new Size(1538, 46);
            txtSoapPlan.TabIndex = 1;
            // 
            // txtSoapAssessment
            // 
            txtSoapAssessment.Dock = DockStyle.Top;
            txtSoapAssessment.Location = new Point(12, 130);
            txtSoapAssessment.Multiline = true;
            txtSoapAssessment.Name = "txtSoapAssessment";
            txtSoapAssessment.PlaceholderText = "A - Assessment";
            txtSoapAssessment.Size = new Size(1538, 46);
            txtSoapAssessment.TabIndex = 2;
            // 
            // txtSoapObjective
            // 
            txtSoapObjective.Dock = DockStyle.Top;
            txtSoapObjective.Location = new Point(12, 84);
            txtSoapObjective.Multiline = true;
            txtSoapObjective.Name = "txtSoapObjective";
            txtSoapObjective.PlaceholderText = "O - Objective";
            txtSoapObjective.Size = new Size(1538, 46);
            txtSoapObjective.TabIndex = 3;
            // 
            // txtSoapSubjective
            // 
            txtSoapSubjective.Dock = DockStyle.Top;
            txtSoapSubjective.Location = new Point(12, 38);
            txtSoapSubjective.Multiline = true;
            txtSoapSubjective.Name = "txtSoapSubjective";
            txtSoapSubjective.PlaceholderText = "S - Subjective";
            txtSoapSubjective.Size = new Size(1538, 46);
            txtSoapSubjective.TabIndex = 4;
            // 
            // txtProgressNotes
            // 
            txtProgressNotes.Dock = DockStyle.Fill;
            txtProgressNotes.Location = new Point(12, 38);
            txtProgressNotes.Multiline = true;
            txtProgressNotes.Name = "txtProgressNotes";
            txtProgressNotes.PlaceholderText = "General progress notes";
            txtProgressNotes.ScrollBars = ScrollBars.Vertical;
            txtProgressNotes.Size = new Size(1538, 282);
            txtProgressNotes.TabIndex = 5;
            // 
            // tabBilling
            // 
            tabBilling.Controls.Add(groupBillingSummary);
            tabBilling.Location = new Point(4, 24);
            tabBilling.Name = "tabBilling";
            tabBilling.Padding = new Padding(3);
            tabBilling.Size = new Size(1568, 338);
            tabBilling.TabIndex = 3;
            tabBilling.Text = "Billing";
            tabBilling.UseVisualStyleBackColor = true;
            // 
            // groupBillingSummary
            // 
            groupBillingSummary.Controls.Add(btnPrintInvoice);
            groupBillingSummary.Controls.Add(btnRecordPayment);
            groupBillingSummary.Controls.Add(btnGenerateInvoice);
            groupBillingSummary.Controls.Add(dgvBillingItems);
            groupBillingSummary.Controls.Add(lblBalanceValue);
            groupBillingSummary.Controls.Add(lblBalanceCaption);
            groupBillingSummary.Controls.Add(lblPaidValue);
            groupBillingSummary.Controls.Add(lblPaidCaption);
            groupBillingSummary.Controls.Add(lblTotalValue);
            groupBillingSummary.Controls.Add(lblTotalCaption);
            groupBillingSummary.Controls.Add(lblVatValue);
            groupBillingSummary.Controls.Add(lblVatCaption);
            groupBillingSummary.Controls.Add(lblDiscountValue);
            groupBillingSummary.Controls.Add(lblDiscountCaption);
            groupBillingSummary.Controls.Add(lblSubtotalValue);
            groupBillingSummary.Controls.Add(lblSubtotalCaption);
            groupBillingSummary.Controls.Add(lblInvoiceNoValue);
            groupBillingSummary.Controls.Add(lblInvoiceNoCaption);
            groupBillingSummary.Dock = DockStyle.Fill;
            groupBillingSummary.Location = new Point(3, 3);
            groupBillingSummary.Name = "groupBillingSummary";
            groupBillingSummary.Padding = new Padding(12, 22, 12, 12);
            groupBillingSummary.Size = new Size(1562, 332);
            groupBillingSummary.TabIndex = 0;
            groupBillingSummary.TabStop = false;
            groupBillingSummary.Text = "Billing";
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.Location = new Point(0, 0);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(75, 23);
            btnPrintInvoice.TabIndex = 0;
            btnPrintInvoice.Text = "Print Invoice";
            // 
            // btnRecordPayment
            // 
            btnRecordPayment.Location = new Point(0, 0);
            btnRecordPayment.Name = "btnRecordPayment";
            btnRecordPayment.Size = new Size(75, 23);
            btnRecordPayment.TabIndex = 1;
            btnRecordPayment.Text = "Record Payment";
            // 
            // btnGenerateInvoice
            // 
            btnGenerateInvoice.Location = new Point(0, 0);
            btnGenerateInvoice.Name = "btnGenerateInvoice";
            btnGenerateInvoice.Size = new Size(75, 23);
            btnGenerateInvoice.TabIndex = 2;
            btnGenerateInvoice.Text = "Generate Invoice";
            // 
            // dgvBillingItems
            // 
            dgvBillingItems.AllowUserToAddRows = false;
            dgvBillingItems.AllowUserToDeleteRows = false;
            dgvBillingItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillingItems.Location = new Point(12, 78);
            dgvBillingItems.Name = "dgvBillingItems";
            dgvBillingItems.RowHeadersVisible = false;
            dgvBillingItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillingItems.Size = new Size(1130, 220);
            dgvBillingItems.TabIndex = 3;
            // 
            // lblBalanceValue
            // 
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBalanceValue.Location = new Point(0, 0);
            lblBalanceValue.Name = "lblBalanceValue";
            lblBalanceValue.Size = new Size(46, 19);
            lblBalanceValue.TabIndex = 4;
            lblBalanceValue.Text = "₱0.00";
            // 
            // lblBalanceCaption
            // 
            lblBalanceCaption.AutoSize = true;
            lblBalanceCaption.Location = new Point(0, 0);
            lblBalanceCaption.Name = "lblBalanceCaption";
            lblBalanceCaption.Size = new Size(51, 15);
            lblBalanceCaption.TabIndex = 5;
            lblBalanceCaption.Text = "Balance:";
            // 
            // lblPaidValue
            // 
            lblPaidValue.AutoSize = true;
            lblPaidValue.Location = new Point(0, 0);
            lblPaidValue.Name = "lblPaidValue";
            lblPaidValue.Size = new Size(35, 15);
            lblPaidValue.TabIndex = 6;
            lblPaidValue.Text = "₱0.00";
            // 
            // lblPaidCaption
            // 
            lblPaidCaption.AutoSize = true;
            lblPaidCaption.Location = new Point(0, 0);
            lblPaidCaption.Name = "lblPaidCaption";
            lblPaidCaption.Size = new Size(33, 15);
            lblPaidCaption.TabIndex = 7;
            lblPaidCaption.Text = "Paid:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalValue.Location = new Point(0, 0);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(46, 19);
            lblTotalValue.TabIndex = 8;
            lblTotalValue.Text = "₱0.00";
            // 
            // lblTotalCaption
            // 
            lblTotalCaption.AutoSize = true;
            lblTotalCaption.Location = new Point(0, 0);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.Size = new Size(35, 15);
            lblTotalCaption.TabIndex = 9;
            lblTotalCaption.Text = "Total:";
            // 
            // lblVatValue
            // 
            lblVatValue.AutoSize = true;
            lblVatValue.Location = new Point(0, 0);
            lblVatValue.Name = "lblVatValue";
            lblVatValue.Size = new Size(35, 15);
            lblVatValue.TabIndex = 10;
            lblVatValue.Text = "₱0.00";
            // 
            // lblVatCaption
            // 
            lblVatCaption.AutoSize = true;
            lblVatCaption.Location = new Point(0, 0);
            lblVatCaption.Name = "lblVatCaption";
            lblVatCaption.Size = new Size(29, 15);
            lblVatCaption.TabIndex = 11;
            lblVatCaption.Text = "VAT:";
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Location = new Point(0, 0);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(35, 15);
            lblDiscountValue.TabIndex = 12;
            lblDiscountValue.Text = "₱0.00";
            // 
            // lblDiscountCaption
            // 
            lblDiscountCaption.AutoSize = true;
            lblDiscountCaption.Location = new Point(0, 0);
            lblDiscountCaption.Name = "lblDiscountCaption";
            lblDiscountCaption.Size = new Size(57, 15);
            lblDiscountCaption.TabIndex = 13;
            lblDiscountCaption.Text = "Discount:";
            // 
            // lblSubtotalValue
            // 
            lblSubtotalValue.AutoSize = true;
            lblSubtotalValue.Location = new Point(0, 0);
            lblSubtotalValue.Name = "lblSubtotalValue";
            lblSubtotalValue.Size = new Size(35, 15);
            lblSubtotalValue.TabIndex = 14;
            lblSubtotalValue.Text = "₱0.00";
            // 
            // lblSubtotalCaption
            // 
            lblSubtotalCaption.AutoSize = true;
            lblSubtotalCaption.Location = new Point(0, 0);
            lblSubtotalCaption.Name = "lblSubtotalCaption";
            lblSubtotalCaption.Size = new Size(54, 15);
            lblSubtotalCaption.TabIndex = 15;
            lblSubtotalCaption.Text = "Subtotal:";
            // 
            // lblInvoiceNoValue
            // 
            lblInvoiceNoValue.AutoSize = true;
            lblInvoiceNoValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInvoiceNoValue.Location = new Point(0, 0);
            lblInvoiceNoValue.Name = "lblInvoiceNoValue";
            lblInvoiceNoValue.Size = new Size(23, 19);
            lblInvoiceNoValue.TabIndex = 16;
            lblInvoiceNoValue.Text = "—";
            // 
            // lblInvoiceNoCaption
            // 
            lblInvoiceNoCaption.AutoSize = true;
            lblInvoiceNoCaption.Location = new Point(0, 0);
            lblInvoiceNoCaption.Name = "lblInvoiceNoCaption";
            lblInvoiceNoCaption.Size = new Size(67, 15);
            lblInvoiceNoCaption.TabIndex = 17;
            lblInvoiceNoCaption.Text = "Invoice No:";
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(lblFooterStatus);
            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnCompleteCase);
            panelFooter.Controls.Add(btnSaveAll);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 940);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(16, 10, 16, 10);
            panelFooter.Size = new Size(1600, 60);
            panelFooter.TabIndex = 3;
            // 
            // lblFooterStatus
            // 
            lblFooterStatus.AutoSize = true;
            lblFooterStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFooterStatus.ForeColor = Color.MidnightBlue;
            lblFooterStatus.Location = new Point(18, 18);
            lblFooterStatus.Name = "lblFooterStatus";
            lblFooterStatus.Size = new Size(141, 17);
            lblFooterStatus.TabIndex = 0;
            lblFooterStatus.Text = "Ready for assessment";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Location = new Point(1506, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(78, 32);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCompleteCase
            // 
            btnCompleteCase.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCompleteCase.Location = new Point(1368, 12);
            btnCompleteCase.Name = "btnCompleteCase";
            btnCompleteCase.Size = new Size(130, 32);
            btnCompleteCase.TabIndex = 2;
            btnCompleteCase.Text = "Complete Case";
            btnCompleteCase.UseVisualStyleBackColor = true;
            // 
            // btnSaveAll
            // 
            btnSaveAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveAll.Location = new Point(1250, 12);
            btnSaveAll.Name = "btnSaveAll";
            btnSaveAll.Size = new Size(110, 32);
            btnSaveAll.TabIndex = 3;
            btnSaveAll.Text = "Save All";
            btnSaveAll.UseVisualStyleBackColor = true;
            // 
            // MainBiteCaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 1000);
            Controls.Add(mainLayout);
            Controls.Add(panelPatientHeader);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1400, 900);
            Name = "MainBiteCaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Animal Bite Case Form";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelPatientHeader.ResumeLayout(false);
            patientInfoLayout.ResumeLayout(false);
            patientInfoLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPatient).EndInit();
            mainLayout.ResumeLayout(false);
            groupAnatomical.ResumeLayout(false);
            panelAnatomicalMapHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnatomicalMap).EndInit();
            panelAnatomicalToolbar.ResumeLayout(false);
            groupExposure.ResumeLayout(false);
            exposureLayout.ResumeLayout(false);
            exposureLayout.PerformLayout();
            tabMain.ResumeLayout(false);
            tabDoctorOrder.ResumeLayout(false);
            doctorLayout.ResumeLayout(false);
            groupDoctorAssessment.ResumeLayout(false);
            groupDoctorAssessment.PerformLayout();
            groupMedicines.ResumeLayout(false);
            groupMedicines.PerformLayout();
            tabVaccination.ResumeLayout(false);
            groupVaccinationDetails.ResumeLayout(false);
            groupVaccinationDetails.PerformLayout();
            groupVaccinationSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVaccinationSchedule).EndInit();
            tabProgressNotes.ResumeLayout(false);
            groupProgressNotes.ResumeLayout(false);
            groupProgressNotes.PerformLayout();
            tabBilling.ResumeLayout(false);
            groupBillingSummary.ResumeLayout(false);
            groupBillingSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillingItems).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}