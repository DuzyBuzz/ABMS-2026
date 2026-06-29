namespace ABMS_2026.UI.UserControls
{
    partial class BillingPaymentsUserControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanelMain = new TableLayoutPanel();
            panelTop = new Panel();
            groupBoxBillingInfo = new GroupBox();
            tableLayoutPanelBillingInfo = new TableLayoutPanel();
            labelBillingNo = new Label();
            textBoxBillingNo = new TextBox();
            labelBillingDate = new Label();
            dateTimePickerBillingDate = new DateTimePicker();
            labelPaymentMethod = new Label();
            comboBoxPaymentMethod = new ComboBox();
            labelPaymentStatus = new Label();
            comboBoxPaymentStatus = new ComboBox();
            panelMiddle = new Panel();
            groupBoxBillingItems = new GroupBox();
            tableLayoutPanelItems = new TableLayoutPanel();
            panelItemsButtons = new Panel();
            buttonAddItem = new Button();
            buttonRemoveItem = new Button();
            dataGridViewBillingItems = new DataGridView();
            itemDescriptionColumn = new DataGridViewTextBoxColumn();
            itemQuantityColumn = new DataGridViewTextBoxColumn();
            itemUnitPriceColumn = new DataGridViewTextBoxColumn();
            itemLineTotalColumn = new DataGridViewTextBoxColumn();
            panelBottom = new Panel();
            tableLayoutPanelBottom = new TableLayoutPanel();
            groupBoxTotals = new GroupBox();
            tableLayoutPanelTotals = new TableLayoutPanel();
            labelSubtotal = new Label();
            textBoxSubtotal = new TextBox();
            labelDiscount = new Label();
            textBoxDiscount = new TextBox();
            labelTotal = new Label();
            textBoxTotal = new TextBox();
            labelAmountPaid = new Label();
            textBoxAmountPaid = new TextBox();
            labelBalance = new Label();
            textBoxBalance = new TextBox();
            groupBoxRemarks = new GroupBox();
            tableLayoutPanelRemarks = new TableLayoutPanel();
            labelRemarks = new Label();
            richTextBoxRemarks = new RichTextBox();
            panelButtons = new Panel();
            buttonSave = new Button();
            buttonPrint = new Button();
            tableLayoutPanelMain.SuspendLayout();
            panelTop.SuspendLayout();
            groupBoxBillingInfo.SuspendLayout();
            tableLayoutPanelBillingInfo.SuspendLayout();
            panelMiddle.SuspendLayout();
            groupBoxBillingItems.SuspendLayout();
            tableLayoutPanelItems.SuspendLayout();
            panelItemsButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBillingItems).BeginInit();
            panelBottom.SuspendLayout();
            tableLayoutPanelBottom.SuspendLayout();
            groupBoxTotals.SuspendLayout();
            tableLayoutPanelTotals.SuspendLayout();
            groupBoxRemarks.SuspendLayout();
            tableLayoutPanelRemarks.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(panelTop, 0, 0);
            tableLayoutPanelMain.Controls.Add(panelMiddle, 0, 1);
            tableLayoutPanelMain.Controls.Add(panelBottom, 0, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            tableLayoutPanelMain.Size = new Size(1280, 820);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(groupBoxBillingInfo);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1274, 94);
            panelTop.TabIndex = 0;
            // 
            // groupBoxBillingInfo
            // 
            groupBoxBillingInfo.Controls.Add(tableLayoutPanelBillingInfo);
            groupBoxBillingInfo.Dock = DockStyle.Fill;
            groupBoxBillingInfo.Location = new Point(0, 0);
            groupBoxBillingInfo.Name = "groupBoxBillingInfo";
            groupBoxBillingInfo.Size = new Size(1274, 94);
            groupBoxBillingInfo.TabIndex = 0;
            groupBoxBillingInfo.TabStop = false;
            groupBoxBillingInfo.Text = "BILLING INFORMATION";
            // 
            // tableLayoutPanelBillingInfo
            // 
            tableLayoutPanelBillingInfo.ColumnCount = 4;
            tableLayoutPanelBillingInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelBillingInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelBillingInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelBillingInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelBillingInfo.Controls.Add(labelBillingNo, 0, 0);
            tableLayoutPanelBillingInfo.Controls.Add(textBoxBillingNo, 1, 0);
            tableLayoutPanelBillingInfo.Controls.Add(labelBillingDate, 2, 0);
            tableLayoutPanelBillingInfo.Controls.Add(dateTimePickerBillingDate, 3, 0);
            tableLayoutPanelBillingInfo.Controls.Add(labelPaymentMethod, 0, 1);
            tableLayoutPanelBillingInfo.Controls.Add(comboBoxPaymentMethod, 1, 1);
            tableLayoutPanelBillingInfo.Controls.Add(labelPaymentStatus, 2, 1);
            tableLayoutPanelBillingInfo.Controls.Add(comboBoxPaymentStatus, 3, 1);
            tableLayoutPanelBillingInfo.Dock = DockStyle.Fill;
            tableLayoutPanelBillingInfo.Location = new Point(3, 19);
            tableLayoutPanelBillingInfo.Name = "tableLayoutPanelBillingInfo";
            tableLayoutPanelBillingInfo.RowCount = 2;
            tableLayoutPanelBillingInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelBillingInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelBillingInfo.Size = new Size(1268, 72);
            tableLayoutPanelBillingInfo.TabIndex = 0;
            // 
            // labelBillingNo
            // 
            labelBillingNo.AutoSize = true;
            labelBillingNo.Dock = DockStyle.Fill;
            labelBillingNo.Location = new Point(3, 0);
            labelBillingNo.Name = "labelBillingNo";
            labelBillingNo.Size = new Size(148, 43);
            labelBillingNo.TabIndex = 0;
            labelBillingNo.Text = "Billing No:";
            labelBillingNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxBillingNo
            // 
            textBoxBillingNo.Dock = DockStyle.Fill;
            textBoxBillingNo.Location = new Point(157, 6);
            textBoxBillingNo.Margin = new Padding(3, 6, 3, 6);
            textBoxBillingNo.Name = "textBoxBillingNo";
            textBoxBillingNo.ReadOnly = true;
            textBoxBillingNo.Size = new Size(146, 23);
            textBoxBillingNo.TabIndex = 1;
            // 
            // labelBillingDate
            // 
            labelBillingDate.AutoSize = true;
            labelBillingDate.Dock = DockStyle.Fill;
            labelBillingDate.Location = new Point(309, 0);
            labelBillingDate.Name = "labelBillingDate";
            labelBillingDate.Size = new Size(148, 43);
            labelBillingDate.TabIndex = 2;
            labelBillingDate.Text = "Billing Date:";
            labelBillingDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerBillingDate
            // 
            dateTimePickerBillingDate.Dock = DockStyle.Fill;
            dateTimePickerBillingDate.Format = DateTimePickerFormat.Short;
            dateTimePickerBillingDate.Location = new Point(463, 6);
            dateTimePickerBillingDate.Margin = new Padding(3, 6, 3, 6);
            dateTimePickerBillingDate.Name = "dateTimePickerBillingDate";
            dateTimePickerBillingDate.Size = new Size(159, 23);
            dateTimePickerBillingDate.TabIndex = 3;
            // 
            // labelPaymentMethod
            // 
            labelPaymentMethod.AutoSize = true;
            labelPaymentMethod.Dock = DockStyle.Fill;
            labelPaymentMethod.Location = new Point(3, 43);
            labelPaymentMethod.Name = "labelPaymentMethod";
            labelPaymentMethod.Size = new Size(148, 43);
            labelPaymentMethod.TabIndex = 4;
            labelPaymentMethod.Text = "Payment Method:";
            labelPaymentMethod.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.Dock = DockStyle.Fill;
            comboBoxPaymentMethod.FormattingEnabled = true;
            comboBoxPaymentMethod.Location = new Point(157, 49);
            comboBoxPaymentMethod.Margin = new Padding(3, 6, 3, 6);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(146, 23);
            comboBoxPaymentMethod.TabIndex = 5;
            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.AutoSize = true;
            labelPaymentStatus.Dock = DockStyle.Fill;
            labelPaymentStatus.Location = new Point(309, 43);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new Size(148, 43);
            labelPaymentStatus.TabIndex = 6;
            labelPaymentStatus.Text = "Payment Status:";
            labelPaymentStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxPaymentStatus
            // 
            comboBoxPaymentStatus.Dock = DockStyle.Fill;
            comboBoxPaymentStatus.FormattingEnabled = true;
            comboBoxPaymentStatus.Location = new Point(463, 49);
            comboBoxPaymentStatus.Margin = new Padding(3, 6, 3, 6);
            comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            comboBoxPaymentStatus.Size = new Size(159, 23);
            comboBoxPaymentStatus.TabIndex = 7;
            // 
            // panelMiddle
            // 
            panelMiddle.Controls.Add(groupBoxBillingItems);
            panelMiddle.Dock = DockStyle.Fill;
            panelMiddle.Location = new Point(3, 123);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Size = new Size(1274, 517);
            panelMiddle.TabIndex = 1;
            // 
            // groupBoxBillingItems
            // 
            groupBoxBillingItems.Controls.Add(tableLayoutPanelItems);
            groupBoxBillingItems.Dock = DockStyle.Fill;
            groupBoxBillingItems.Location = new Point(0, 0);
            groupBoxBillingItems.Name = "groupBoxBillingItems";
            groupBoxBillingItems.Size = new Size(1274, 517);
            groupBoxBillingItems.TabIndex = 0;
            groupBoxBillingItems.TabStop = false;
            groupBoxBillingItems.Text = "BILLING ITEMS";
            // 
            // tableLayoutPanelItems
            // 
            tableLayoutPanelItems.ColumnCount = 1;
            tableLayoutPanelItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelItems.Controls.Add(panelItemsButtons, 0, 0);
            tableLayoutPanelItems.Controls.Add(dataGridViewBillingItems, 0, 1);
            tableLayoutPanelItems.Dock = DockStyle.Fill;
            tableLayoutPanelItems.Location = new Point(3, 19);
            tableLayoutPanelItems.Name = "tableLayoutPanelItems";
            tableLayoutPanelItems.RowCount = 2;
            tableLayoutPanelItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelItems.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelItems.Size = new Size(1268, 495);
            tableLayoutPanelItems.TabIndex = 0;
            // 
            // panelItemsButtons
            // 
            panelItemsButtons.Controls.Add(buttonAddItem);
            panelItemsButtons.Controls.Add(buttonRemoveItem);
            panelItemsButtons.Dock = DockStyle.Fill;
            panelItemsButtons.Location = new Point(3, 3);
            panelItemsButtons.Name = "panelItemsButtons";
            panelItemsButtons.Size = new Size(1262, 44);
            panelItemsButtons.TabIndex = 0;
            // 
            // buttonAddItem
            // 
            buttonAddItem.BackColor = Color.FromArgb(40, 167, 69);
            buttonAddItem.Cursor = Cursors.Hand;
            buttonAddItem.FlatAppearance.BorderSize = 0;
            buttonAddItem.FlatStyle = FlatStyle.Flat;
            buttonAddItem.ForeColor = Color.White;
            buttonAddItem.Location = new Point(3, 3);
            buttonAddItem.Name = "buttonAddItem";
            buttonAddItem.Size = new Size(100, 38);
            buttonAddItem.TabIndex = 0;
            buttonAddItem.Text = "Add Item";
            buttonAddItem.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveItem
            // 
            buttonRemoveItem.BackColor = Color.FromArgb(220, 53, 69);
            buttonRemoveItem.Cursor = Cursors.Hand;
            buttonRemoveItem.FlatAppearance.BorderSize = 0;
            buttonRemoveItem.FlatStyle = FlatStyle.Flat;
            buttonRemoveItem.ForeColor = Color.White;
            buttonRemoveItem.Location = new Point(109, 3);
            buttonRemoveItem.Name = "buttonRemoveItem";
            buttonRemoveItem.Size = new Size(120, 38);
            buttonRemoveItem.TabIndex = 1;
            buttonRemoveItem.Text = "Remove Item";
            buttonRemoveItem.UseVisualStyleBackColor = false;
            // 
            // dataGridViewBillingItems
            // 
            dataGridViewBillingItems.AllowUserToAddRows = false;
            dataGridViewBillingItems.AllowUserToDeleteRows = false;
            dataGridViewBillingItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBillingItems.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewBillingItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewBillingItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBillingItems.Columns.AddRange(new DataGridViewColumn[] { itemDescriptionColumn, itemQuantityColumn, itemUnitPriceColumn, itemLineTotalColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewBillingItems.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewBillingItems.Dock = DockStyle.Fill;
            dataGridViewBillingItems.Location = new Point(3, 50);
            dataGridViewBillingItems.Name = "dataGridViewBillingItems";
            dataGridViewBillingItems.ReadOnly = true;
            dataGridViewBillingItems.RowHeadersVisible = false;
            dataGridViewBillingItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBillingItems.Size = new Size(1262, 442);
            dataGridViewBillingItems.TabIndex = 1;
            // 
            // itemDescriptionColumn
            // 
            itemDescriptionColumn.HeaderText = "Description";
            itemDescriptionColumn.Name = "itemDescriptionColumn";
            itemDescriptionColumn.ReadOnly = true;
            // 
            // itemQuantityColumn
            // 
            itemQuantityColumn.HeaderText = "Quantity";
            itemQuantityColumn.Name = "itemQuantityColumn";
            itemQuantityColumn.ReadOnly = true;
            // 
            // itemUnitPriceColumn
            // 
            itemUnitPriceColumn.HeaderText = "Unit Price";
            itemUnitPriceColumn.Name = "itemUnitPriceColumn";
            itemUnitPriceColumn.ReadOnly = true;
            // 
            // itemLineTotalColumn
            // 
            itemLineTotalColumn.HeaderText = "Line Total";
            itemLineTotalColumn.Name = "itemLineTotalColumn";
            itemLineTotalColumn.ReadOnly = true;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(tableLayoutPanelBottom);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(3, 646);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1274, 171);
            panelBottom.TabIndex = 2;
            // 
            // tableLayoutPanelBottom
            // 
            tableLayoutPanelBottom.ColumnCount = 3;
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelBottom.Controls.Add(groupBoxTotals, 0, 0);
            tableLayoutPanelBottom.Controls.Add(groupBoxRemarks, 1, 0);
            tableLayoutPanelBottom.Controls.Add(panelButtons, 2, 0);
            tableLayoutPanelBottom.Dock = DockStyle.Fill;
            tableLayoutPanelBottom.Location = new Point(0, 0);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.RowCount = 1;
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Size = new Size(1274, 171);
            tableLayoutPanelBottom.TabIndex = 0;
            // 
            // groupBoxTotals
            // 
            groupBoxTotals.Controls.Add(tableLayoutPanelTotals);
            groupBoxTotals.Dock = DockStyle.Fill;
            groupBoxTotals.Location = new Point(3, 3);
            groupBoxTotals.Name = "groupBoxTotals";
            groupBoxTotals.Size = new Size(505, 165);
            groupBoxTotals.TabIndex = 0;
            groupBoxTotals.TabStop = false;
            groupBoxTotals.Text = "TOTALS";
            // 
            // tableLayoutPanelTotals
            // 
            tableLayoutPanelTotals.ColumnCount = 2;
            tableLayoutPanelTotals.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelTotals.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelTotals.Controls.Add(labelSubtotal, 0, 0);
            tableLayoutPanelTotals.Controls.Add(textBoxSubtotal, 1, 0);
            tableLayoutPanelTotals.Controls.Add(labelDiscount, 0, 1);
            tableLayoutPanelTotals.Controls.Add(textBoxDiscount, 1, 1);
            tableLayoutPanelTotals.Controls.Add(labelTotal, 0, 2);
            tableLayoutPanelTotals.Controls.Add(textBoxTotal, 1, 2);
            tableLayoutPanelTotals.Controls.Add(labelAmountPaid, 0, 3);
            tableLayoutPanelTotals.Controls.Add(textBoxAmountPaid, 1, 3);
            tableLayoutPanelTotals.Controls.Add(labelBalance, 0, 4);
            tableLayoutPanelTotals.Controls.Add(textBoxBalance, 1, 4);
            tableLayoutPanelTotals.Dock = DockStyle.Fill;
            tableLayoutPanelTotals.Location = new Point(3, 19);
            tableLayoutPanelTotals.Name = "tableLayoutPanelTotals";
            tableLayoutPanelTotals.RowCount = 5;
            tableLayoutPanelTotals.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelTotals.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelTotals.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelTotals.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelTotals.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelTotals.Size = new Size(499, 143);
            tableLayoutPanelTotals.TabIndex = 0;
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Dock = DockStyle.Fill;
            labelSubtotal.Location = new Point(3, 0);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(243, 28);
            labelSubtotal.TabIndex = 0;
            labelSubtotal.Text = "Subtotal:";
            labelSubtotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxSubtotal
            // 
            textBoxSubtotal.Dock = DockStyle.Fill;
            textBoxSubtotal.Location = new Point(252, 3);
            textBoxSubtotal.Margin = new Padding(3);
            textBoxSubtotal.Name = "textBoxSubtotal";
            textBoxSubtotal.ReadOnly = true;
            textBoxSubtotal.Size = new Size(244, 23);
            textBoxSubtotal.TabIndex = 1;
            textBoxSubtotal.Text = "0.00";
            textBoxSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // labelDiscount
            // 
            labelDiscount.AutoSize = true;
            labelDiscount.Dock = DockStyle.Fill;
            labelDiscount.Location = new Point(3, 28);
            labelDiscount.Name = "labelDiscount";
            labelDiscount.Size = new Size(243, 29);
            labelDiscount.TabIndex = 2;
            labelDiscount.Text = "Discount:";
            labelDiscount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDiscount
            // 
            textBoxDiscount.Dock = DockStyle.Fill;
            textBoxDiscount.Location = new Point(252, 31);
            textBoxDiscount.Margin = new Padding(3);
            textBoxDiscount.Name = "textBoxDiscount";
            textBoxDiscount.Size = new Size(244, 23);
            textBoxDiscount.TabIndex = 3;
            textBoxDiscount.Text = "0.00";
            textBoxDiscount.TextAlign = HorizontalAlignment.Right;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Dock = DockStyle.Fill;
            labelTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTotal.Location = new Point(3, 57);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(243, 29);
            labelTotal.TabIndex = 4;
            labelTotal.Text = "Total:";
            labelTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxTotal
            // 
            textBoxTotal.Dock = DockStyle.Fill;
            textBoxTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            textBoxTotal.Location = new Point(252, 60);
            textBoxTotal.Margin = new Padding(3);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(244, 23);
            textBoxTotal.TabIndex = 5;
            textBoxTotal.Text = "0.00";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // labelAmountPaid
            // 
            labelAmountPaid.AutoSize = true;
            labelAmountPaid.Dock = DockStyle.Fill;
            labelAmountPaid.Location = new Point(3, 86);
            labelAmountPaid.Name = "labelAmountPaid";
            labelAmountPaid.Size = new Size(243, 29);
            labelAmountPaid.TabIndex = 6;
            labelAmountPaid.Text = "Amount Paid:";
            labelAmountPaid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxAmountPaid
            // 
            textBoxAmountPaid.Dock = DockStyle.Fill;
            textBoxAmountPaid.Location = new Point(252, 89);
            textBoxAmountPaid.Margin = new Padding(3);
            textBoxAmountPaid.Name = "textBoxAmountPaid";
            textBoxAmountPaid.Size = new Size(244, 23);
            textBoxAmountPaid.TabIndex = 7;
            textBoxAmountPaid.Text = "0.00";
            textBoxAmountPaid.TextAlign = HorizontalAlignment.Right;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Dock = DockStyle.Fill;
            labelBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBalance.ForeColor = Color.FromArgb(220, 53, 69);
            labelBalance.Location = new Point(3, 115);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(243, 28);
            labelBalance.TabIndex = 8;
            labelBalance.Text = "Balance:";
            labelBalance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxBalance
            // 
            textBoxBalance.Dock = DockStyle.Fill;
            textBoxBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            textBoxBalance.ForeColor = Color.FromArgb(220, 53, 69);
            textBoxBalance.Location = new Point(252, 118);
            textBoxBalance.Margin = new Padding(3);
            textBoxBalance.Name = "textBoxBalance";
            textBoxBalance.ReadOnly = true;
            textBoxBalance.Size = new Size(244, 23);
            textBoxBalance.TabIndex = 9;
            textBoxBalance.Text = "0.00";
            textBoxBalance.TextAlign = HorizontalAlignment.Right;
            // 
            // groupBoxRemarks
            // 
            groupBoxRemarks.Controls.Add(tableLayoutPanelRemarks);
            groupBoxRemarks.Dock = DockStyle.Fill;
            groupBoxRemarks.Location = new Point(514, 3);
            groupBoxRemarks.Name = "groupBoxRemarks";
            groupBoxRemarks.Size = new Size(437, 165);
            groupBoxRemarks.TabIndex = 1;
            groupBoxRemarks.TabStop = false;
            groupBoxRemarks.Text = "REMARKS";
            // 
            // tableLayoutPanelRemarks
            // 
            tableLayoutPanelRemarks.ColumnCount = 1;
            tableLayoutPanelRemarks.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelRemarks.Controls.Add(labelRemarks, 0, 0);
            tableLayoutPanelRemarks.Controls.Add(richTextBoxRemarks, 0, 1);
            tableLayoutPanelRemarks.Dock = DockStyle.Fill;
            tableLayoutPanelRemarks.Location = new Point(3, 19);
            tableLayoutPanelRemarks.Name = "tableLayoutPanelRemarks";
            tableLayoutPanelRemarks.RowCount = 2;
            tableLayoutPanelRemarks.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelRemarks.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelRemarks.Size = new Size(431, 143);
            tableLayoutPanelRemarks.TabIndex = 0;
            // 
            // labelRemarks
            // 
            labelRemarks.AutoSize = true;
            labelRemarks.Dock = DockStyle.Fill;
            labelRemarks.Location = new Point(3, 0);
            labelRemarks.Name = "labelRemarks";
            labelRemarks.Size = new Size(425, 25);
            labelRemarks.TabIndex = 0;
            labelRemarks.Text = "Remarks";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxRemarks
            // 
            richTextBoxRemarks.Dock = DockStyle.Fill;
            richTextBoxRemarks.Location = new Point(3, 28);
            richTextBoxRemarks.Name = "richTextBoxRemarks";
            richTextBoxRemarks.Size = new Size(425, 112);
            richTextBoxRemarks.TabIndex = 1;
            richTextBoxRemarks.Text = "";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonSave);
            panelButtons.Controls.Add(buttonPrint);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(957, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(314, 165);
            panelButtons.TabIndex = 2;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(40, 167, 69);
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.Dock = DockStyle.Top;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(0, 0);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(314, 50);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save Billing";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonPrint
            // 
            buttonPrint.BackColor = Color.FromArgb(23, 162, 184);
            buttonPrint.Cursor = Cursors.Hand;
            buttonPrint.Dock = DockStyle.Top;
            buttonPrint.FlatAppearance.BorderSize = 0;
            buttonPrint.FlatStyle = FlatStyle.Flat;
            buttonPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonPrint.ForeColor = Color.White;
            buttonPrint.Location = new Point(0, 50);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(314, 50);
            buttonPrint.TabIndex = 1;
            buttonPrint.Text = "Print Receipt";
            buttonPrint.UseVisualStyleBackColor = false;
            // 
            // BillingPaymentsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanelMain);
            Font = new Font("Segoe UI", 9F);
            Name = "BillingPaymentsUserControl";
            Size = new Size(1280, 820);
            tableLayoutPanelMain.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            groupBoxBillingInfo.ResumeLayout(false);
            tableLayoutPanelBillingInfo.ResumeLayout(false);
            tableLayoutPanelBillingInfo.PerformLayout();
            panelMiddle.ResumeLayout(false);
            groupBoxBillingItems.ResumeLayout(false);
            tableLayoutPanelItems.ResumeLayout(false);
            panelItemsButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBillingItems).EndInit();
            panelBottom.ResumeLayout(false);
            tableLayoutPanelBottom.ResumeLayout(false);
            groupBoxTotals.ResumeLayout(false);
            tableLayoutPanelTotals.ResumeLayout(false);
            tableLayoutPanelTotals.PerformLayout();
            groupBoxRemarks.ResumeLayout(false);
            tableLayoutPanelRemarks.ResumeLayout(false);
            tableLayoutPanelRemarks.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Panel panelTop;
        private GroupBox groupBoxBillingInfo;
        private TableLayoutPanel tableLayoutPanelBillingInfo;
        private Label labelBillingNo;
        private TextBox textBoxBillingNo;
        private Label labelBillingDate;
        private DateTimePicker dateTimePickerBillingDate;
        private Label labelPaymentMethod;
        private ComboBox comboBoxPaymentMethod;
        private Label labelPaymentStatus;
        private ComboBox comboBoxPaymentStatus;
        private Panel panelMiddle;
        private GroupBox groupBoxBillingItems;
        private TableLayoutPanel tableLayoutPanelItems;
        private Panel panelItemsButtons;
        private Button buttonAddItem;
        private Button buttonRemoveItem;
        private DataGridView dataGridViewBillingItems;
        private DataGridViewTextBoxColumn itemDescriptionColumn;
        private DataGridViewTextBoxColumn itemQuantityColumn;
        private DataGridViewTextBoxColumn itemUnitPriceColumn;
        private DataGridViewTextBoxColumn itemLineTotalColumn;
        private Panel panelBottom;
        private TableLayoutPanel tableLayoutPanelBottom;
        private GroupBox groupBoxTotals;
        private TableLayoutPanel tableLayoutPanelTotals;
        private Label labelSubtotal;
        private TextBox textBoxSubtotal;
        private Label labelDiscount;
        private TextBox textBoxDiscount;
        private Label labelTotal;
        private TextBox textBoxTotal;
        private Label labelAmountPaid;
        private TextBox textBoxAmountPaid;
        private Label labelBalance;
        private TextBox textBoxBalance;
        private GroupBox groupBoxRemarks;
        private TableLayoutPanel tableLayoutPanelRemarks;
        private Label labelRemarks;
        private RichTextBox richTextBoxRemarks;
        private Panel panelButtons;
        private Button buttonSave;
        private Button buttonPrint;
    }
}
