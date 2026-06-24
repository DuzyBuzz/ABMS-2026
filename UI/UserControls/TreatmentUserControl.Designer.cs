namespace ABMS_2026.UI.UserControls
{
    partial class TreatmentUserControl
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

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel headerLayout;
        private System.Windows.Forms.Panel panelHeaderText;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Button btnCreateNewSchedule;

        private System.Windows.Forms.Panel panelCaseInfo;
        private System.Windows.Forms.TableLayoutPanel caseInfoLayout;
        private System.Windows.Forms.Panel cardCaseId;
        private System.Windows.Forms.Label lblCaseIdCaption;
        private System.Windows.Forms.Label lblCaseIdValue;
        private System.Windows.Forms.Panel cardPatient;
        private System.Windows.Forms.Label lblPatientCaption;
        private System.Windows.Forms.Label lblPatientValue;
        private System.Windows.Forms.Panel cardDateOfBite;
        private System.Windows.Forms.Label lblDateOfBiteCaption;
        private System.Windows.Forms.Label lblDateOfBiteValue;
        private System.Windows.Forms.Panel cardCategory;
        private System.Windows.Forms.Label lblCategoryCaption;
        private System.Windows.Forms.Label lblCategoryValue;
        private System.Windows.Forms.Panel cardDoctor;
        private System.Windows.Forms.Label lblDoctorCaption;
        private System.Windows.Forms.Label lblDoctorValue;

        private System.Windows.Forms.Panel panelRabiesCard;
        private System.Windows.Forms.TableLayoutPanel rabiesCardLayout;
        private System.Windows.Forms.Panel panelRabiesHeader;
        private System.Windows.Forms.Label lblRabiesTitle;
        private System.Windows.Forms.FlowLayoutPanel flowRabiesBadges;
        private System.Windows.Forms.Label lblRabiesRouteBadge;
        private System.Windows.Forms.Label lblRabiesVaccineBadge;
        private System.Windows.Forms.DataGridView dgvRabiesSchedules;

        private System.Windows.Forms.Panel panelTetanusCard;
        private System.Windows.Forms.TableLayoutPanel tetanusCardLayout;
        private System.Windows.Forms.Panel panelTetanusHeader;
        private System.Windows.Forms.Label lblTetanusTitle;
        private System.Windows.Forms.FlowLayoutPanel flowTetanusBadges;
        private System.Windows.Forms.Label lblTetanusVaccineBadge;
        private System.Windows.Forms.DataGridView dgvTetanusSchedules;

        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.Panel panelNotesCard;
        private System.Windows.Forms.Label lblNotesTitle;
        private System.Windows.Forms.Label lblNotesBody;

        private System.Windows.Forms.Panel panelSummaryCard;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.TableLayoutPanel summaryGrid;
        private System.Windows.Forms.Panel cardTotalSchedules;
        private System.Windows.Forms.Label lblTotalSchedulesCaption;
        private System.Windows.Forms.Label lblTotalSchedulesValue;
        private System.Windows.Forms.Panel cardCompleted;
        private System.Windows.Forms.Label lblCompletedCaption;
        private System.Windows.Forms.Label lblCompletedValue;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Label lblPendingCaption;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Panel cardScheduled;
        private System.Windows.Forms.Label lblScheduledCaption;
        private System.Windows.Forms.Label lblScheduledValue;

        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesScheduledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesAdministeredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesVaccineBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRabiesAdministeredBy;
        private System.Windows.Forms.DataGridViewButtonColumn colRabiesAction;

        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusDoseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusScheduledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusAdministeredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusVaccineBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetanusAdministeredBy;
        private System.Windows.Forms.DataGridViewButtonColumn colTetanusAction;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();

            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.headerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeaderText = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.btnCreateNewSchedule = new System.Windows.Forms.Button();

            this.panelCaseInfo = new System.Windows.Forms.Panel();
            this.caseInfoLayout = new System.Windows.Forms.TableLayoutPanel();

            this.cardCaseId = new System.Windows.Forms.Panel();
            this.lblCaseIdCaption = new System.Windows.Forms.Label();
            this.lblCaseIdValue = new System.Windows.Forms.Label();

            this.cardPatient = new System.Windows.Forms.Panel();
            this.lblPatientCaption = new System.Windows.Forms.Label();
            this.lblPatientValue = new System.Windows.Forms.Label();

            this.cardDateOfBite = new System.Windows.Forms.Panel();
            this.lblDateOfBiteCaption = new System.Windows.Forms.Label();
            this.lblDateOfBiteValue = new System.Windows.Forms.Label();

            this.cardCategory = new System.Windows.Forms.Panel();
            this.lblCategoryCaption = new System.Windows.Forms.Label();
            this.lblCategoryValue = new System.Windows.Forms.Label();

            this.cardDoctor = new System.Windows.Forms.Panel();
            this.lblDoctorCaption = new System.Windows.Forms.Label();
            this.lblDoctorValue = new System.Windows.Forms.Label();

            this.panelRabiesCard = new System.Windows.Forms.Panel();
            this.rabiesCardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelRabiesHeader = new System.Windows.Forms.Panel();
            this.lblRabiesTitle = new System.Windows.Forms.Label();
            this.flowRabiesBadges = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRabiesRouteBadge = new System.Windows.Forms.Label();
            this.lblRabiesVaccineBadge = new System.Windows.Forms.Label();
            this.dgvRabiesSchedules = new System.Windows.Forms.DataGridView();

            this.panelTetanusCard = new System.Windows.Forms.Panel();
            this.tetanusCardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelTetanusHeader = new System.Windows.Forms.Panel();
            this.lblTetanusTitle = new System.Windows.Forms.Label();
            this.flowTetanusBadges = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTetanusVaccineBadge = new System.Windows.Forms.Label();
            this.dgvTetanusSchedules = new System.Windows.Forms.DataGridView();

            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelNotesCard = new System.Windows.Forms.Panel();
            this.lblNotesTitle = new System.Windows.Forms.Label();
            this.lblNotesBody = new System.Windows.Forms.Label();

            this.panelSummaryCard = new System.Windows.Forms.Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.summaryGrid = new System.Windows.Forms.TableLayoutPanel();

            this.cardTotalSchedules = new System.Windows.Forms.Panel();
            this.lblTotalSchedulesCaption = new System.Windows.Forms.Label();
            this.lblTotalSchedulesValue = new System.Windows.Forms.Label();

            this.cardCompleted = new System.Windows.Forms.Panel();
            this.lblCompletedCaption = new System.Windows.Forms.Label();
            this.lblCompletedValue = new System.Windows.Forms.Label();

            this.cardPending = new System.Windows.Forms.Panel();
            this.lblPendingCaption = new System.Windows.Forms.Label();
            this.lblPendingValue = new System.Windows.Forms.Label();

            this.cardScheduled = new System.Windows.Forms.Panel();
            this.lblScheduledCaption = new System.Windows.Forms.Label();
            this.lblScheduledValue = new System.Windows.Forms.Label();

            this.colRabiesDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesScheduledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesAdministeredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesVaccineBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesAdministeredBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRabiesAction = new System.Windows.Forms.DataGridViewButtonColumn();

            this.colTetanusDoseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusScheduledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusAdministeredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusVaccineBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusAdministeredBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetanusAction = new System.Windows.Forms.DataGridViewButtonColumn();

            this.mainLayout.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.headerLayout.SuspendLayout();
            this.panelHeaderText.SuspendLayout();
            this.panelCaseInfo.SuspendLayout();
            this.caseInfoLayout.SuspendLayout();
            this.cardCaseId.SuspendLayout();
            this.cardPatient.SuspendLayout();
            this.cardDateOfBite.SuspendLayout();
            this.cardCategory.SuspendLayout();
            this.cardDoctor.SuspendLayout();
            this.panelRabiesCard.SuspendLayout();
            this.rabiesCardLayout.SuspendLayout();
            this.panelRabiesHeader.SuspendLayout();
            this.flowRabiesBadges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRabiesSchedules)).BeginInit();
            this.panelTetanusCard.SuspendLayout();
            this.tetanusCardLayout.SuspendLayout();
            this.panelTetanusHeader.SuspendLayout();
            this.flowTetanusBadges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTetanusSchedules)).BeginInit();
            this.bottomLayout.SuspendLayout();
            this.panelNotesCard.SuspendLayout();
            this.panelSummaryCard.SuspendLayout();
            this.summaryGrid.SuspendLayout();
            this.cardTotalSchedules.SuspendLayout();
            this.cardCompleted.SuspendLayout();
            this.cardPending.SuspendLayout();
            this.cardScheduled.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(20, 20);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1240, 780);
            this.mainLayout.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.headerLayout);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelHeader.Size = new System.Drawing.Size(1234, 69);
            this.panelHeader.TabIndex = 0;
            // 
            // headerLayout
            // 
            this.headerLayout.ColumnCount = 2;
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.headerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLayout.Location = new System.Drawing.Point(0, 0);
            this.headerLayout.Name = "headerLayout";
            this.headerLayout.RowCount = 1;
            this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerLayout.Size = new System.Drawing.Size(1234, 69);
            this.headerLayout.TabIndex = 0;
            // 
            // panelHeaderText
            // 
            this.panelHeaderText.Controls.Add(this.lblPageTitle);
            this.panelHeaderText.Controls.Add(this.lblPageSubtitle);
            this.panelHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeaderText.Location = new System.Drawing.Point(3, 3);
            this.panelHeaderText.Name = "panelHeaderText";
            this.panelHeaderText.Size = new System.Drawing.Size(988, 63);
            this.panelHeaderText.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblPageTitle.Location = new System.Drawing.Point(0, 2);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(226, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Treatment Schedule";
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblPageSubtitle.Location = new System.Drawing.Point(2, 38);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(413, 17);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Manage rabies and tetanus treatment schedules for the selected bite case.";
            // 
            // btnCreateNewSchedule
            // 
            this.btnCreateNewSchedule.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateNewSchedule.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnCreateNewSchedule.FlatAppearance.BorderSize = 0;
            this.btnCreateNewSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateNewSchedule.ForeColor = System.Drawing.Color.White;
            this.btnCreateNewSchedule.Location = new System.Drawing.Point(1030, 16);
            this.btnCreateNewSchedule.Name = "btnCreateNewSchedule";
            this.btnCreateNewSchedule.Size = new System.Drawing.Size(180, 36);
            this.btnCreateNewSchedule.TabIndex = 1;
            this.btnCreateNewSchedule.Text = "+ Create New Schedule";
            this.btnCreateNewSchedule.UseVisualStyleBackColor = false;
            // 
            // panelCaseInfo
            // 
            this.panelCaseInfo.BackColor = System.Drawing.Color.White;
            this.panelCaseInfo.Controls.Add(this.caseInfoLayout);
            this.panelCaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCaseInfo.Location = new System.Drawing.Point(3, 96);
            this.panelCaseInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.panelCaseInfo.Name = "panelCaseInfo";
            this.panelCaseInfo.Padding = new System.Windows.Forms.Padding(12);
            this.panelCaseInfo.Size = new System.Drawing.Size(1234, 78);
            this.panelCaseInfo.TabIndex = 1;
            // 
            // caseInfoLayout
            // 
            this.caseInfoLayout.ColumnCount = 5;
            this.caseInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.caseInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.caseInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.caseInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.caseInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.caseInfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caseInfoLayout.Location = new System.Drawing.Point(12, 12);
            this.caseInfoLayout.Name = "caseInfoLayout";
            this.caseInfoLayout.RowCount = 1;
            this.caseInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.caseInfoLayout.Size = new System.Drawing.Size(1210, 54);
            this.caseInfoLayout.TabIndex = 0;
            // 
            // cardCaseId
            // 
            this.cardCaseId.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cardCaseId.Controls.Add(this.lblCaseIdCaption);
            this.cardCaseId.Controls.Add(this.lblCaseIdValue);
            this.cardCaseId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCaseId.Location = new System.Drawing.Point(3, 3);
            this.cardCaseId.Name = "cardCaseId";
            this.cardCaseId.Size = new System.Drawing.Size(236, 48);
            this.cardCaseId.TabIndex = 0;
            // 
            // lblCaseIdCaption
            // 
            this.lblCaseIdCaption.AutoSize = true;
            this.lblCaseIdCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaseIdCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCaseIdCaption.Location = new System.Drawing.Point(12, 8);
            this.lblCaseIdCaption.Name = "lblCaseIdCaption";
            this.lblCaseIdCaption.Size = new System.Drawing.Size(67, 15);
            this.lblCaseIdCaption.TabIndex = 0;
            this.lblCaseIdCaption.Text = "Bite Case ID";
            // 
            // lblCaseIdValue
            // 
            this.lblCaseIdValue.AutoSize = true;
            this.lblCaseIdValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaseIdValue.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblCaseIdValue.Location = new System.Drawing.Point(12, 24);
            this.lblCaseIdValue.Name = "lblCaseIdValue";
            this.lblCaseIdValue.Size = new System.Drawing.Size(118, 20);
            this.lblCaseIdValue.TabIndex = 1;
            this.lblCaseIdValue.Text = "BC-2025-000123";
            // 
            // cardPatient
            // 
            this.cardPatient.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cardPatient.Controls.Add(this.lblPatientCaption);
            this.cardPatient.Controls.Add(this.lblPatientValue);
            this.cardPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPatient.Location = new System.Drawing.Point(245, 3);
            this.cardPatient.Name = "cardPatient";
            this.cardPatient.Size = new System.Drawing.Size(236, 48);
            this.cardPatient.TabIndex = 1;
            // 
            // lblPatientCaption
            // 
            this.lblPatientCaption.AutoSize = true;
            this.lblPatientCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatientCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblPatientCaption.Location = new System.Drawing.Point(12, 8);
            this.lblPatientCaption.Name = "lblPatientCaption";
            this.lblPatientCaption.Size = new System.Drawing.Size(46, 15);
            this.lblPatientCaption.TabIndex = 0;
            this.lblPatientCaption.Text = "Patient";
            // 
            // lblPatientValue
            // 
            this.lblPatientValue.AutoSize = true;
            this.lblPatientValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPatientValue.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblPatientValue.Location = new System.Drawing.Point(12, 24);
            this.lblPatientValue.Name = "lblPatientValue";
            this.lblPatientValue.Size = new System.Drawing.Size(125, 20);
            this.lblPatientValue.TabIndex = 1;
            this.lblPatientValue.Text = "Maria Santos (28/F)";
            // 
            // cardDateOfBite
            // 
            this.cardDateOfBite.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cardDateOfBite.Controls.Add(this.lblDateOfBiteCaption);
            this.cardDateOfBite.Controls.Add(this.lblDateOfBiteValue);
            this.cardDateOfBite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDateOfBite.Location = new System.Drawing.Point(487, 3);
            this.cardDateOfBite.Name = "cardDateOfBite";
            this.cardDateOfBite.Size = new System.Drawing.Size(236, 48);
            this.cardDateOfBite.TabIndex = 2;
            // 
            // lblDateOfBiteCaption
            // 
            this.lblDateOfBiteCaption.AutoSize = true;
            this.lblDateOfBiteCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDateOfBiteCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDateOfBiteCaption.Location = new System.Drawing.Point(12, 8);
            this.lblDateOfBiteCaption.Name = "lblDateOfBiteCaption";
            this.lblDateOfBiteCaption.Size = new System.Drawing.Size(67, 15);
            this.lblDateOfBiteCaption.TabIndex = 0;
            this.lblDateOfBiteCaption.Text = "Date of Bite";
            // 
            // lblDateOfBiteValue
            // 
            this.lblDateOfBiteValue.AutoSize = true;
            this.lblDateOfBiteValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDateOfBiteValue.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblDateOfBiteValue.Location = new System.Drawing.Point(12, 24);
            this.lblDateOfBiteValue.Name = "lblDateOfBiteValue";
            this.lblDateOfBiteValue.Size = new System.Drawing.Size(88, 20);
            this.lblDateOfBiteValue.TabIndex = 1;
            this.lblDateOfBiteValue.Text = "May 20, 2025";
            // 
            // cardCategory
            // 
            this.cardCategory.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cardCategory.Controls.Add(this.lblCategoryCaption);
            this.cardCategory.Controls.Add(this.lblCategoryValue);
            this.cardCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCategory.Location = new System.Drawing.Point(729, 3);
            this.cardCategory.Name = "cardCategory";
            this.cardCategory.Size = new System.Drawing.Size(236, 48);
            this.cardCategory.TabIndex = 3;
            // 
            // lblCategoryCaption
            // 
            this.lblCategoryCaption.AutoSize = true;
            this.lblCategoryCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCategoryCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCategoryCaption.Location = new System.Drawing.Point(12, 8);
            this.lblCategoryCaption.Name = "lblCategoryCaption";
            this.lblCategoryCaption.Size = new System.Drawing.Size(54, 15);
            this.lblCategoryCaption.TabIndex = 0;
            this.lblCategoryCaption.Text = "Category";
            // 
            // lblCategoryValue
            // 
            this.lblCategoryValue.AutoSize = true;
            this.lblCategoryValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCategoryValue.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblCategoryValue.Location = new System.Drawing.Point(12, 24);
            this.lblCategoryValue.Name = "lblCategoryValue";
            this.lblCategoryValue.Size = new System.Drawing.Size(20, 20);
            this.lblCategoryValue.TabIndex = 1;
            this.lblCategoryValue.Text = "III";
            // 
            // cardDoctor
            // 
            this.cardDoctor.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cardDoctor.Controls.Add(this.lblDoctorCaption);
            this.cardDoctor.Controls.Add(this.lblDoctorValue);
            this.cardDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDoctor.Location = new System.Drawing.Point(971, 3);
            this.cardDoctor.Name = "cardDoctor";
            this.cardDoctor.Size = new System.Drawing.Size(236, 48);
            this.cardDoctor.TabIndex = 4;
            // 
            // lblDoctorCaption
            // 
            this.lblDoctorCaption.AutoSize = true;
            this.lblDoctorCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDoctorCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDoctorCaption.Location = new System.Drawing.Point(12, 8);
            this.lblDoctorCaption.Name = "lblDoctorCaption";
            this.lblDoctorCaption.Size = new System.Drawing.Size(92, 15);
            this.lblDoctorCaption.TabIndex = 0;
            this.lblDoctorCaption.Text = "Attending Doctor";
            // 
            // lblDoctorValue
            // 
            this.lblDoctorValue.AutoSize = true;
            this.lblDoctorValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDoctorValue.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblDoctorValue.Location = new System.Drawing.Point(12, 24);
            this.lblDoctorValue.Name = "lblDoctorValue";
            this.lblDoctorValue.Size = new System.Drawing.Size(120, 20);
            this.lblDoctorValue.TabIndex = 1;
            this.lblDoctorValue.Text = "Dr. Juan Dela Cruz";
            // 
            // panelRabiesCard
            // 
            this.panelRabiesCard.BackColor = System.Drawing.Color.White;
            this.panelRabiesCard.Controls.Add(this.rabiesCardLayout);
            this.panelRabiesCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRabiesCard.Location = new System.Drawing.Point(3, 186);
            this.panelRabiesCard.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.panelRabiesCard.Name = "panelRabiesCard";
            this.panelRabiesCard.Padding = new System.Windows.Forms.Padding(12);
            this.panelRabiesCard.Size = new System.Drawing.Size(1234, 318);
            this.panelRabiesCard.TabIndex = 2;
            // 
            // rabiesCardLayout
            // 
            this.rabiesCardLayout.ColumnCount = 1;
            this.rabiesCardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rabiesCardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rabiesCardLayout.Location = new System.Drawing.Point(12, 12);
            this.rabiesCardLayout.Name = "rabiesCardLayout";
            this.rabiesCardLayout.RowCount = 2;
            this.rabiesCardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.rabiesCardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rabiesCardLayout.Size = new System.Drawing.Size(1210, 294);
            this.rabiesCardLayout.TabIndex = 0;
            // 
            // panelRabiesHeader
            // 
            this.panelRabiesHeader.Controls.Add(this.lblRabiesTitle);
            this.panelRabiesHeader.Controls.Add(this.flowRabiesBadges);
            this.panelRabiesHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRabiesHeader.Location = new System.Drawing.Point(3, 3);
            this.panelRabiesHeader.Name = "panelRabiesHeader";
            this.panelRabiesHeader.Size = new System.Drawing.Size(1204, 38);
            this.panelRabiesHeader.TabIndex = 0;
            // 
            // lblRabiesTitle
            // 
            this.lblRabiesTitle.AutoSize = true;
            this.lblRabiesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRabiesTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblRabiesTitle.Location = new System.Drawing.Point(0, 9);
            this.lblRabiesTitle.Name = "lblRabiesTitle";
            this.lblRabiesTitle.Size = new System.Drawing.Size(202, 21);
            this.lblRabiesTitle.TabIndex = 0;
            this.lblRabiesTitle.Text = "Rabies Vaccination Schedule";
            // 
            // flowRabiesBadges
            // 
            this.flowRabiesBadges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowRabiesBadges.AutoSize = true;
            this.flowRabiesBadges.Controls.Add(this.lblRabiesRouteBadge);
            this.flowRabiesBadges.Controls.Add(this.lblRabiesVaccineBadge);
            this.flowRabiesBadges.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowRabiesBadges.Location = new System.Drawing.Point(918, 3);
            this.flowRabiesBadges.Name = "flowRabiesBadges";
            this.flowRabiesBadges.Size = new System.Drawing.Size(286, 29);
            this.flowRabiesBadges.TabIndex = 1;
            this.flowRabiesBadges.WrapContents = false;
            // 
            // lblRabiesRouteBadge
            // 
            this.lblRabiesRouteBadge.AutoSize = true;
            this.lblRabiesRouteBadge.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.lblRabiesRouteBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRabiesRouteBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRabiesRouteBadge.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblRabiesRouteBadge.Location = new System.Drawing.Point(3, 0);
            this.lblRabiesRouteBadge.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.lblRabiesRouteBadge.Name = "lblRabiesRouteBadge";
            this.lblRabiesRouteBadge.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.lblRabiesRouteBadge.Size = new System.Drawing.Size(118, 27);
            this.lblRabiesRouteBadge.TabIndex = 0;
            this.lblRabiesRouteBadge.Text = "Route: Intradermal";
            // 
            // lblRabiesVaccineBadge
            // 
            this.lblRabiesVaccineBadge.AutoSize = true;
            this.lblRabiesVaccineBadge.BackColor = System.Drawing.Color.FromArgb(245, 243, 255);
            this.lblRabiesVaccineBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRabiesVaccineBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRabiesVaccineBadge.ForeColor = System.Drawing.Color.FromArgb(109, 40, 217);
            this.lblRabiesVaccineBadge.Location = new System.Drawing.Point(129, 0);
            this.lblRabiesVaccineBadge.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRabiesVaccineBadge.Name = "lblRabiesVaccineBadge";
            this.lblRabiesVaccineBadge.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.lblRabiesVaccineBadge.Size = new System.Drawing.Size(141, 27);
            this.lblRabiesVaccineBadge.TabIndex = 1;
            this.lblRabiesVaccineBadge.Text = "Vaccine: VERORAB";
            // 
            // dgvRabiesSchedules
            // 
            this.dgvRabiesSchedules.AllowUserToAddRows = false;
            this.dgvRabiesSchedules.AllowUserToDeleteRows = false;
            this.dgvRabiesSchedules.AllowUserToResizeRows = false;
            this.dgvRabiesSchedules.BackgroundColor = System.Drawing.Color.White;
            this.dgvRabiesSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRabiesSchedules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRabiesSchedules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRabiesSchedules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRabiesSchedules.ColumnHeadersHeight = 38;
            this.dgvRabiesSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRabiesDay,
            this.colRabiesScheduledDate,
            this.colRabiesStatus,
            this.colRabiesAdministeredDate,
            this.colRabiesVaccineBrand,
            this.colRabiesDose,
            this.colRabiesRoute,
            this.colRabiesAdministeredBy,
            this.colRabiesAction});
            this.dgvRabiesSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRabiesSchedules.EnableHeadersVisualStyles = false;
            this.dgvRabiesSchedules.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvRabiesSchedules.Location = new System.Drawing.Point(3, 47);
            this.dgvRabiesSchedules.MultiSelect = false;
            this.dgvRabiesSchedules.Name = "dgvRabiesSchedules";
            this.dgvRabiesSchedules.ReadOnly = true;
            this.dgvRabiesSchedules.RowHeadersVisible = false;
            this.dgvRabiesSchedules.RowTemplate.Height = 34;
            this.dgvRabiesSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRabiesSchedules.Size = new System.Drawing.Size(1204, 244);
            this.dgvRabiesSchedules.TabIndex = 1;
            // 
            // colRabiesDay
            // 
            this.colRabiesDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRabiesDay.HeaderText = "DAY";
            this.colRabiesDay.MinimumWidth = 80;
            this.colRabiesDay.Name = "colRabiesDay";
            this.colRabiesDay.ReadOnly = true;
            this.colRabiesDay.Width = 80;
            // 
            // colRabiesScheduledDate
            // 
            this.colRabiesScheduledDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRabiesScheduledDate.HeaderText = "SCHEDULED DATE";
            this.colRabiesScheduledDate.MinimumWidth = 130;
            this.colRabiesScheduledDate.Name = "colRabiesScheduledDate";
            this.colRabiesScheduledDate.ReadOnly = true;
            // 
            // colRabiesStatus
            // 
            this.colRabiesStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRabiesStatus.HeaderText = "STATUS";
            this.colRabiesStatus.MinimumWidth = 100;
            this.colRabiesStatus.Name = "colRabiesStatus";
            this.colRabiesStatus.ReadOnly = true;
            this.colRabiesStatus.Width = 100;
            // 
            // colRabiesAdministeredDate
            // 
            this.colRabiesAdministeredDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRabiesAdministeredDate.HeaderText = "ADMINISTERED DATE";
            this.colRabiesAdministeredDate.MinimumWidth = 150;
            this.colRabiesAdministeredDate.Name = "colRabiesAdministeredDate";
            this.colRabiesAdministeredDate.ReadOnly = true;
            // 
            // colRabiesVaccineBrand
            // 
            this.colRabiesVaccineBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRabiesVaccineBrand.HeaderText = "VACCINE / BRAND";
            this.colRabiesVaccineBrand.MinimumWidth = 140;
            this.colRabiesVaccineBrand.Name = "colRabiesVaccineBrand";
            this.colRabiesVaccineBrand.ReadOnly = true;
            this.colRabiesVaccineBrand.Width = 140;
            // 
            // colRabiesDose
            // 
            this.colRabiesDose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRabiesDose.HeaderText = "DOSE";
            this.colRabiesDose.MinimumWidth = 80;
            this.colRabiesDose.Name = "colRabiesDose";
            this.colRabiesDose.ReadOnly = true;
            this.colRabiesDose.Width = 80;
            // 
            // colRabiesRoute
            // 
            this.colRabiesRoute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRabiesRoute.HeaderText = "ROUTE";
            this.colRabiesRoute.MinimumWidth = 80;
            this.colRabiesRoute.Name = "colRabiesRoute";
            this.colRabiesRoute.ReadOnly = true;
            this.colRabiesRoute.Width = 80;
            // 
            // colRabiesAdministeredBy
            // 
            this.colRabiesAdministeredBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRabiesAdministeredBy.HeaderText = "ADMINISTERED BY";
            this.colRabiesAdministeredBy.MinimumWidth = 160;
            this.colRabiesAdministeredBy.Name = "colRabiesAdministeredBy";
            this.colRabiesAdministeredBy.ReadOnly = true;
            // 
            // colRabiesAction
            // 
            this.colRabiesAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRabiesAction.HeaderText = "ACTION";
            this.colRabiesAction.MinimumWidth = 100;
            this.colRabiesAction.Name = "colRabiesAction";
            this.colRabiesAction.ReadOnly = true;
            this.colRabiesAction.Text = "View";
            this.colRabiesAction.UseColumnTextForButtonValue = true;
            this.colRabiesAction.Width = 100;
            // 
            // panelTetanusCard
            // 
            this.panelTetanusCard.BackColor = System.Drawing.Color.White;
            this.panelTetanusCard.Controls.Add(this.tetanusCardLayout);
            this.panelTetanusCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTetanusCard.Location = new System.Drawing.Point(3, 516);
            this.panelTetanusCard.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.panelTetanusCard.Name = "panelTetanusCard";
            this.panelTetanusCard.Padding = new System.Windows.Forms.Padding(12);
            this.panelTetanusCard.Size = new System.Drawing.Size(1234, 224);
            this.panelTetanusCard.TabIndex = 3;
            // 
            // tetanusCardLayout
            // 
            this.tetanusCardLayout.ColumnCount = 1;
            this.tetanusCardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tetanusCardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tetanusCardLayout.Location = new System.Drawing.Point(12, 12);
            this.tetanusCardLayout.Name = "tetanusCardLayout";
            this.tetanusCardLayout.RowCount = 2;
            this.tetanusCardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tetanusCardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tetanusCardLayout.Size = new System.Drawing.Size(1210, 200);
            this.tetanusCardLayout.TabIndex = 0;
            // 
            // panelTetanusHeader
            // 
            this.panelTetanusHeader.Controls.Add(this.lblTetanusTitle);
            this.panelTetanusHeader.Controls.Add(this.flowTetanusBadges);
            this.panelTetanusHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTetanusHeader.Location = new System.Drawing.Point(3, 3);
            this.panelTetanusHeader.Name = "panelTetanusHeader";
            this.panelTetanusHeader.Size = new System.Drawing.Size(1204, 38);
            this.panelTetanusHeader.TabIndex = 0;
            // 
            // lblTetanusTitle
            // 
            this.lblTetanusTitle.AutoSize = true;
            this.lblTetanusTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTetanusTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblTetanusTitle.Location = new System.Drawing.Point(0, 9);
            this.lblTetanusTitle.Name = "lblTetanusTitle";
            this.lblTetanusTitle.Size = new System.Drawing.Size(191, 21);
            this.lblTetanusTitle.TabIndex = 0;
            this.lblTetanusTitle.Text = "Tetanus Immunization Schedule";
            // 
            // flowTetanusBadges
            // 
            this.flowTetanusBadges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowTetanusBadges.AutoSize = true;
            this.flowTetanusBadges.Controls.Add(this.lblTetanusVaccineBadge);
            this.flowTetanusBadges.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowTetanusBadges.Location = new System.Drawing.Point(1026, 3);
            this.flowTetanusBadges.Name = "flowTetanusBadges";
            this.flowTetanusBadges.Size = new System.Drawing.Size(178, 29);
            this.flowTetanusBadges.TabIndex = 1;
            this.flowTetanusBadges.WrapContents = false;
            // 
            // lblTetanusVaccineBadge
            // 
            this.lblTetanusVaccineBadge.AutoSize = true;
            this.lblTetanusVaccineBadge.BackColor = System.Drawing.Color.FromArgb(245, 243, 255);
            this.lblTetanusVaccineBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTetanusVaccineBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTetanusVaccineBadge.ForeColor = System.Drawing.Color.FromArgb(109, 40, 217);
            this.lblTetanusVaccineBadge.Location = new System.Drawing.Point(3, 0);
            this.lblTetanusVaccineBadge.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblTetanusVaccineBadge.Name = "lblTetanusVaccineBadge";
            this.lblTetanusVaccineBadge.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.lblTetanusVaccineBadge.Size = new System.Drawing.Size(172, 27);
            this.lblTetanusVaccineBadge.TabIndex = 0;
            this.lblTetanusVaccineBadge.Text = "Vaccine: TETANUS TOXOID";
            // 
            // dgvTetanusSchedules
            // 
            this.dgvTetanusSchedules.AllowUserToAddRows = false;
            this.dgvTetanusSchedules.AllowUserToDeleteRows = false;
            this.dgvTetanusSchedules.AllowUserToResizeRows = false;
            this.dgvTetanusSchedules.BackgroundColor = System.Drawing.Color.White;
            this.dgvTetanusSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTetanusSchedules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTetanusSchedules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTetanusSchedules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTetanusSchedules.ColumnHeadersHeight = 38;
            this.dgvTetanusSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTetanusDoseNo,
            this.colTetanusScheduledDate,
            this.colTetanusStatus,
            this.colTetanusAdministeredDate,
            this.colTetanusVaccineBrand,
            this.colTetanusDose,
            this.colTetanusRoute,
            this.colTetanusAdministeredBy,
            this.colTetanusAction});
            this.dgvTetanusSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTetanusSchedules.EnableHeadersVisualStyles = false;
            this.dgvTetanusSchedules.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvTetanusSchedules.Location = new System.Drawing.Point(3, 47);
            this.dgvTetanusSchedules.MultiSelect = false;
            this.dgvTetanusSchedules.Name = "dgvTetanusSchedules";
            this.dgvTetanusSchedules.ReadOnly = true;
            this.dgvTetanusSchedules.RowHeadersVisible = false;
            this.dgvTetanusSchedules.RowTemplate.Height = 34;
            this.dgvTetanusSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTetanusSchedules.Size = new System.Drawing.Size(1204, 150);
            this.dgvTetanusSchedules.TabIndex = 1;
            // 
            // colTetanusDoseNo
            // 
            this.colTetanusDoseNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTetanusDoseNo.HeaderText = "DOSE";
            this.colTetanusDoseNo.MinimumWidth = 80;
            this.colTetanusDoseNo.Name = "colTetanusDoseNo";
            this.colTetanusDoseNo.ReadOnly = true;
            this.colTetanusDoseNo.Width = 80;
            // 
            // colTetanusScheduledDate
            // 
            this.colTetanusScheduledDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTetanusScheduledDate.HeaderText = "SCHEDULED DATE";
            this.colTetanusScheduledDate.MinimumWidth = 130;
            this.colTetanusScheduledDate.Name = "colTetanusScheduledDate";
            this.colTetanusScheduledDate.ReadOnly = true;
            // 
            // colTetanusStatus
            // 
            this.colTetanusStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTetanusStatus.HeaderText = "STATUS";
            this.colTetanusStatus.MinimumWidth = 100;
            this.colTetanusStatus.Name = "colTetanusStatus";
            this.colTetanusStatus.ReadOnly = true;
            this.colTetanusStatus.Width = 100;
            // 
            // colTetanusAdministeredDate
            // 
            this.colTetanusAdministeredDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTetanusAdministeredDate.HeaderText = "ADMINISTERED DATE";
            this.colTetanusAdministeredDate.MinimumWidth = 150;
            this.colTetanusAdministeredDate.Name = "colTetanusAdministeredDate";
            this.colTetanusAdministeredDate.ReadOnly = true;
            // 
            // colTetanusVaccineBrand
            // 
            this.colTetanusVaccineBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTetanusVaccineBrand.HeaderText = "VACCINE / BRAND";
            this.colTetanusVaccineBrand.MinimumWidth = 140;
            this.colTetanusVaccineBrand.Name = "colTetanusVaccineBrand";
            this.colTetanusVaccineBrand.ReadOnly = true;
            this.colTetanusVaccineBrand.Width = 140;
            // 
            // colTetanusDose
            // 
            this.colTetanusDose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTetanusDose.HeaderText = "DOSE";
            this.colTetanusDose.MinimumWidth = 80;
            this.colTetanusDose.Name = "colTetanusDose";
            this.colTetanusDose.ReadOnly = true;
            this.colTetanusDose.Width = 80;
            // 
            // colTetanusRoute
            // 
            this.colTetanusRoute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTetanusRoute.HeaderText = "ROUTE";
            this.colTetanusRoute.MinimumWidth = 80;
            this.colTetanusRoute.Name = "colTetanusRoute";
            this.colTetanusRoute.ReadOnly = true;
            this.colTetanusRoute.Width = 80;
            // 
            // colTetanusAdministeredBy
            // 
            this.colTetanusAdministeredBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTetanusAdministeredBy.HeaderText = "ADMINISTERED BY";
            this.colTetanusAdministeredBy.MinimumWidth = 160;
            this.colTetanusAdministeredBy.Name = "colTetanusAdministeredBy";
            this.colTetanusAdministeredBy.ReadOnly = true;
            // 
            // colTetanusAction
            // 
            this.colTetanusAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTetanusAction.HeaderText = "ACTION";
            this.colTetanusAction.MinimumWidth = 100;
            this.colTetanusAction.Name = "colTetanusAction";
            this.colTetanusAction.ReadOnly = true;
            this.colTetanusAction.Text = "View";
            this.colTetanusAction.UseColumnTextForButtonValue = true;
            this.colTetanusAction.Width = 100;
            // 
            // bottomLayout
            // 
            this.bottomLayout.ColumnCount = 2;
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.bottomLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomLayout.Location = new System.Drawing.Point(3, 756);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.Size = new System.Drawing.Size(1234, 21);
            this.bottomLayout.TabIndex = 4;
            // 
            // panelNotesCard
            // 
            this.panelNotesCard.BackColor = System.Drawing.Color.White;
            this.panelNotesCard.Controls.Add(this.lblNotesBody);
            this.panelNotesCard.Controls.Add(this.lblNotesTitle);
            this.panelNotesCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNotesCard.Location = new System.Drawing.Point(3, 3);
            this.panelNotesCard.Name = "panelNotesCard";
            this.panelNotesCard.Padding = new System.Windows.Forms.Padding(16);
            this.panelNotesCard.Size = new System.Drawing.Size(548, 15);
            this.panelNotesCard.TabIndex = 0;
            // 
            // lblNotesTitle
            // 
            this.lblNotesTitle.AutoSize = true;
            this.lblNotesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblNotesTitle.Location = new System.Drawing.Point(16, 14);
            this.lblNotesTitle.Name = "lblNotesTitle";
            this.lblNotesTitle.Size = new System.Drawing.Size(53, 20);
            this.lblNotesTitle.TabIndex = 0;
            this.lblNotesTitle.Text = "Notes";
            // 
            // lblNotesBody
            // 
            this.lblNotesBody.AutoSize = false;
            this.lblNotesBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotesBody.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNotesBody.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNotesBody.Location = new System.Drawing.Point(16, 42);
            this.lblNotesBody.Name = "lblNotesBody";
            this.lblNotesBody.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblNotesBody.Size = new System.Drawing.Size(516, 0);
            this.lblNotesBody.TabIndex = 1;
            this.lblNotesBody.Text = "• Ensure the patient completes the full schedule.\r\n• Do not administer a dose without a valid schedule record.\r\n• Deduct inventory only when treatment is marked completed.";
            // 
            // panelSummaryCard
            // 
            this.panelSummaryCard.BackColor = System.Drawing.Color.White;
            this.panelSummaryCard.Controls.Add(this.summaryGrid);
            this.panelSummaryCard.Controls.Add(this.lblSummaryTitle);
            this.panelSummaryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSummaryCard.Location = new System.Drawing.Point(557, 3);
            this.panelSummaryCard.Name = "panelSummaryCard";
            this.panelSummaryCard.Padding = new System.Windows.Forms.Padding(16);
            this.panelSummaryCard.Size = new System.Drawing.Size(674, 15);
            this.panelSummaryCard.TabIndex = 1;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblSummaryTitle.Location = new System.Drawing.Point(16, 14);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(67, 20);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Summary";
            // 
            // summaryGrid
            // 
            this.summaryGrid.ColumnCount = 4;
            this.summaryGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.summaryGrid.Location = new System.Drawing.Point(16, 52);
            this.summaryGrid.Name = "summaryGrid";
            this.summaryGrid.RowCount = 1;
            this.summaryGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.summaryGrid.Size = new System.Drawing.Size(642, 1);
            this.summaryGrid.TabIndex = 1;
            // 
            // cardTotalSchedules
            // 
            this.cardTotalSchedules.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.cardTotalSchedules.Controls.Add(this.lblTotalSchedulesValue);
            this.cardTotalSchedules.Controls.Add(this.lblTotalSchedulesCaption);
            this.cardTotalSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalSchedules.Location = new System.Drawing.Point(3, 3);
            this.cardTotalSchedules.Name = "cardTotalSchedules";
            this.cardTotalSchedules.Size = new System.Drawing.Size(153, 1);
            this.cardTotalSchedules.TabIndex = 0;
            // 
            // lblTotalSchedulesCaption
            // 
            this.lblTotalSchedulesCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalSchedulesCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSchedulesCaption.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblTotalSchedulesCaption.Location = new System.Drawing.Point(0, 0);
            this.lblTotalSchedulesCaption.Name = "lblTotalSchedulesCaption";
            this.lblTotalSchedulesCaption.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblTotalSchedulesCaption.Size = new System.Drawing.Size(153, 27);
            this.lblTotalSchedulesCaption.TabIndex = 0;
            this.lblTotalSchedulesCaption.Text = "Total Schedules";
            this.lblTotalSchedulesCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalSchedulesValue
            // 
            this.lblTotalSchedulesValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalSchedulesValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSchedulesValue.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblTotalSchedulesValue.Location = new System.Drawing.Point(0, 27);
            this.lblTotalSchedulesValue.Name = "lblTotalSchedulesValue";
            this.lblTotalSchedulesValue.Size = new System.Drawing.Size(153, 0);
            this.lblTotalSchedulesValue.TabIndex = 1;
            this.lblTotalSchedulesValue.Text = "8";
            this.lblTotalSchedulesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardCompleted
            // 
            this.cardCompleted.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.cardCompleted.Controls.Add(this.lblCompletedValue);
            this.cardCompleted.Controls.Add(this.lblCompletedCaption);
            this.cardCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCompleted.Location = new System.Drawing.Point(162, 3);
            this.cardCompleted.Name = "cardCompleted";
            this.cardCompleted.Size = new System.Drawing.Size(153, 1);
            this.cardCompleted.TabIndex = 1;
            // 
            // lblCompletedCaption
            // 
            this.lblCompletedCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompletedCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompletedCaption.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblCompletedCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCompletedCaption.Name = "lblCompletedCaption";
            this.lblCompletedCaption.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblCompletedCaption.Size = new System.Drawing.Size(153, 27);
            this.lblCompletedCaption.TabIndex = 0;
            this.lblCompletedCaption.Text = "Completed";
            this.lblCompletedCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCompletedValue
            // 
            this.lblCompletedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompletedValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompletedValue.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblCompletedValue.Location = new System.Drawing.Point(0, 27);
            this.lblCompletedValue.Name = "lblCompletedValue";
            this.lblCompletedValue.Size = new System.Drawing.Size(153, 0);
            this.lblCompletedValue.TabIndex = 1;
            this.lblCompletedValue.Text = "4";
            this.lblCompletedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardPending
            // 
            this.cardPending.BackColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.cardPending.Controls.Add(this.lblPendingValue);
            this.cardPending.Controls.Add(this.lblPendingCaption);
            this.cardPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPending.Location = new System.Drawing.Point(321, 3);
            this.cardPending.Name = "cardPending";
            this.cardPending.Size = new System.Drawing.Size(153, 1);
            this.cardPending.TabIndex = 2;
            // 
            // lblPendingCaption
            // 
            this.lblPendingCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPendingCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingCaption.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblPendingCaption.Location = new System.Drawing.Point(0, 0);
            this.lblPendingCaption.Name = "lblPendingCaption";
            this.lblPendingCaption.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPendingCaption.Size = new System.Drawing.Size(153, 27);
            this.lblPendingCaption.TabIndex = 0;
            this.lblPendingCaption.Text = "Pending";
            this.lblPendingCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPendingValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingValue.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblPendingValue.Location = new System.Drawing.Point(0, 27);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(153, 0);
            this.lblPendingValue.TabIndex = 1;
            this.lblPendingValue.Text = "1";
            this.lblPendingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardScheduled
            // 
            this.cardScheduled.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.cardScheduled.Controls.Add(this.lblScheduledValue);
            this.cardScheduled.Controls.Add(this.lblScheduledCaption);
            this.cardScheduled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardScheduled.Location = new System.Drawing.Point(480, 3);
            this.cardScheduled.Name = "cardScheduled";
            this.cardScheduled.Size = new System.Drawing.Size(159, 1);
            this.cardScheduled.TabIndex = 3;
            // 
            // lblScheduledCaption
            // 
            this.lblScheduledCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScheduledCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScheduledCaption.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblScheduledCaption.Location = new System.Drawing.Point(0, 0);
            this.lblScheduledCaption.Name = "lblScheduledCaption";
            this.lblScheduledCaption.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblScheduledCaption.Size = new System.Drawing.Size(159, 27);
            this.lblScheduledCaption.TabIndex = 0;
            this.lblScheduledCaption.Text = "Scheduled";
            this.lblScheduledCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblScheduledValue
            // 
            this.lblScheduledValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduledValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScheduledValue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblScheduledValue.Location = new System.Drawing.Point(0, 27);
            this.lblScheduledValue.Name = "lblScheduledValue";
            this.lblScheduledValue.Size = new System.Drawing.Size(159, 0);
            this.lblScheduledValue.TabIndex = 1;
            this.lblScheduledValue.Text = "3";
            this.lblScheduledValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreatmentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.Controls.Add(this.mainLayout);
            this.Name = "TreatmentUserControl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1280, 820);

            this.mainLayout.Controls.Add(this.panelHeader, 0, 0);
            this.mainLayout.Controls.Add(this.panelCaseInfo, 0, 1);
            this.mainLayout.Controls.Add(this.panelRabiesCard, 0, 2);
            this.mainLayout.Controls.Add(this.panelTetanusCard, 0, 3);
            this.mainLayout.Controls.Add(this.bottomLayout, 0, 4);

            this.panelHeader.Controls.Add(this.headerLayout);
            this.headerLayout.Controls.Add(this.panelHeaderText, 0, 0);
            this.headerLayout.Controls.Add(this.btnCreateNewSchedule, 1, 0);

            this.panelHeaderText.Controls.Add(this.lblPageTitle);
            this.panelHeaderText.Controls.Add(this.lblPageSubtitle);

            this.panelCaseInfo.Controls.Add(this.caseInfoLayout);
            this.caseInfoLayout.Controls.Add(this.cardCaseId, 0, 0);
            this.caseInfoLayout.Controls.Add(this.cardPatient, 1, 0);
            this.caseInfoLayout.Controls.Add(this.cardDateOfBite, 2, 0);
            this.caseInfoLayout.Controls.Add(this.cardCategory, 3, 0);
            this.caseInfoLayout.Controls.Add(this.cardDoctor, 4, 0);

            this.panelRabiesCard.Controls.Add(this.rabiesCardLayout);
            this.rabiesCardLayout.Controls.Add(this.panelRabiesHeader, 0, 0);
            this.rabiesCardLayout.Controls.Add(this.dgvRabiesSchedules, 0, 1);

            this.panelTetanusCard.Controls.Add(this.tetanusCardLayout);
            this.tetanusCardLayout.Controls.Add(this.panelTetanusHeader, 0, 0);
            this.tetanusCardLayout.Controls.Add(this.dgvTetanusSchedules, 0, 1);

            this.bottomLayout.Controls.Add(this.panelNotesCard, 0, 0);
            this.bottomLayout.Controls.Add(this.panelSummaryCard, 1, 0);

            this.panelSummaryCard.Controls.Add(this.summaryGrid);
            this.panelSummaryCard.Controls.Add(this.lblSummaryTitle);

            this.summaryGrid.Controls.Add(this.cardTotalSchedules, 0, 0);
            this.summaryGrid.Controls.Add(this.cardCompleted, 1, 0);
            this.summaryGrid.Controls.Add(this.cardPending, 2, 0);
            this.summaryGrid.Controls.Add(this.cardScheduled, 3, 0);

            this.cardTotalSchedules.Controls.Add(this.lblTotalSchedulesCaption);
            this.cardTotalSchedules.Controls.Add(this.lblTotalSchedulesValue);
            this.cardCompleted.Controls.Add(this.lblCompletedCaption);
            this.cardCompleted.Controls.Add(this.lblCompletedValue);
            this.cardPending.Controls.Add(this.lblPendingCaption);
            this.cardPending.Controls.Add(this.lblPendingValue);
            this.cardScheduled.Controls.Add(this.lblScheduledCaption);
            this.cardScheduled.Controls.Add(this.lblScheduledValue);

            this.lblNotesBody.BringToFront();

            this.ResumeLayout(false);
        }

        #endregion
    }
}