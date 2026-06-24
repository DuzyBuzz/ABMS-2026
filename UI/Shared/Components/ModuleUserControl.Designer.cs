namespace ABMS_2026.UI.Shared.Components
{
    partial class ModuleUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            topLayout = new TableLayoutPanel();
            labelSearch = new Label();
            moduleSearchTextBox = new TextBox();
            moduleSearchButton = new Button();
            moduleRefreshButton = new Button();
            moduleAddButton = new Button();
            moduleDataGridView = new DataGridView();
            panelBottom = new Panel();
            bottomLayout = new TableLayoutPanel();
            summaryLabel = new Label();
            labelFrom = new Label();
            moduleDateFromDateTimePicker = new DateTimePicker();
            labelTo = new Label();
            moduleDateToDateTimePicker = new DateTimePicker();
            prevButton = new Button();
            nextButton = new Button();
            panelTop.SuspendLayout();
            topLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)moduleDataGridView).BeginInit();
            panelBottom.SuspendLayout();
            bottomLayout.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(topLayout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(20, 16, 20, 16);
            panelTop.Size = new Size(1140, 80);
            panelTop.TabIndex = 0;
            // 
            // topLayout
            // 
            topLayout.ColumnCount = 5;
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            topLayout.Controls.Add(labelSearch, 0, 0);
            topLayout.Controls.Add(moduleSearchTextBox, 1, 0);
            topLayout.Controls.Add(moduleSearchButton, 2, 0);
            topLayout.Controls.Add(moduleRefreshButton, 3, 0);
            topLayout.Controls.Add(moduleAddButton, 4, 0);
            topLayout.Dock = DockStyle.Fill;
            topLayout.Location = new Point(20, 16);
            topLayout.Name = "topLayout";
            topLayout.RowCount = 1;
            topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topLayout.Size = new Size(1100, 48);
            topLayout.TabIndex = 0;
            // 
            // labelSearch
            // 
            labelSearch.Dock = DockStyle.Fill;
            labelSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSearch.ForeColor = Color.FromArgb(73, 80, 87);
            labelSearch.Location = new Point(3, 0);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(64, 48);
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Search";
            labelSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // moduleSearchTextBox
            // 
            moduleSearchTextBox.BackColor = Color.FromArgb(248, 249, 250);
            moduleSearchTextBox.BorderStyle = BorderStyle.None;
            moduleSearchTextBox.Dock = DockStyle.Fill;
            moduleSearchTextBox.Font = new Font("Segoe UI", 10F);
            moduleSearchTextBox.ForeColor = Color.FromArgb(33, 37, 41);
            moduleSearchTextBox.Location = new Point(73, 10);
            moduleSearchTextBox.Margin = new Padding(3, 10, 8, 10);
            moduleSearchTextBox.Name = "moduleSearchTextBox";
            moduleSearchTextBox.PlaceholderText = "Type to search...";
            moduleSearchTextBox.Size = new Size(729, 18);
            moduleSearchTextBox.TabIndex = 1;
            // 
            // moduleSearchButton
            // 
            moduleSearchButton.BackColor = Color.FromArgb(59, 130, 246);
            moduleSearchButton.Cursor = Cursors.Hand;
            moduleSearchButton.Dock = DockStyle.Fill;
            moduleSearchButton.FlatAppearance.BorderColor = Color.FromArgb(49, 108, 222);
            moduleSearchButton.FlatAppearance.BorderSize = 0;
            moduleSearchButton.FlatStyle = FlatStyle.Flat;
            moduleSearchButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moduleSearchButton.ForeColor = Color.White;
            moduleSearchButton.Location = new Point(813, 10);
            moduleSearchButton.Margin = new Padding(3, 10, 8, 10);
            moduleSearchButton.Name = "moduleSearchButton";
            moduleSearchButton.Size = new Size(79, 28);
            moduleSearchButton.TabIndex = 2;
            moduleSearchButton.Text = "Search";
            moduleSearchButton.UseVisualStyleBackColor = false;
            // 
            // moduleRefreshButton
            // 
            moduleRefreshButton.BackColor = Color.FromArgb(108, 117, 125);
            moduleRefreshButton.Cursor = Cursors.Hand;
            moduleRefreshButton.Dock = DockStyle.Fill;
            moduleRefreshButton.FlatAppearance.BorderColor = Color.FromArgb(82, 88, 94);
            moduleRefreshButton.FlatAppearance.BorderSize = 0;
            moduleRefreshButton.FlatStyle = FlatStyle.Flat;
            moduleRefreshButton.Font = new Font("Segoe UI", 10F);
            moduleRefreshButton.ForeColor = Color.White;
            moduleRefreshButton.Location = new Point(903, 8);
            moduleRefreshButton.Margin = new Padding(3, 8, 8, 8);
            moduleRefreshButton.Name = "moduleRefreshButton";
            moduleRefreshButton.Size = new Size(79, 32);
            moduleRefreshButton.TabIndex = 3;
            moduleRefreshButton.Text = "Refresh";
            moduleRefreshButton.UseVisualStyleBackColor = false;
            // 
            // moduleAddButton
            // 
            moduleAddButton.BackColor = Color.FromArgb(40, 167, 69);
            moduleAddButton.Cursor = Cursors.Hand;
            moduleAddButton.Dock = DockStyle.Fill;
            moduleAddButton.FlatAppearance.BorderColor = Color.FromArgb(30, 126, 52);
            moduleAddButton.FlatAppearance.BorderSize = 0;
            moduleAddButton.FlatStyle = FlatStyle.Flat;
            moduleAddButton.Font = new Font("Segoe UI", 10F);
            moduleAddButton.ForeColor = Color.White;
            moduleAddButton.Location = new Point(993, 8);
            moduleAddButton.Margin = new Padding(3, 8, 3, 8);
            moduleAddButton.Name = "moduleAddButton";
            moduleAddButton.Size = new Size(104, 32);
            moduleAddButton.TabIndex = 4;
            moduleAddButton.Text = "Add New";
            moduleAddButton.UseVisualStyleBackColor = false;
            // 
            // moduleDataGridView
            // 
            moduleDataGridView.BackgroundColor = Color.White;
            moduleDataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            moduleDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            moduleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            moduleDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            moduleDataGridView.Dock = DockStyle.Fill;
            moduleDataGridView.GridColor = Color.FromArgb(222, 226, 230);
            moduleDataGridView.Location = new Point(0, 80);
            moduleDataGridView.Name = "moduleDataGridView";
            moduleDataGridView.Size = new Size(1140, 660);
            moduleDataGridView.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(245, 247, 250);
            panelBottom.Controls.Add(bottomLayout);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 740);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(16, 12, 16, 12);
            panelBottom.Size = new Size(1140, 60);
            panelBottom.TabIndex = 2;
            // 
            // bottomLayout
            // 
            bottomLayout.ColumnCount = 7;
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            bottomLayout.Controls.Add(summaryLabel, 0, 0);
            bottomLayout.Controls.Add(labelFrom, 1, 0);
            bottomLayout.Controls.Add(moduleDateFromDateTimePicker, 2, 0);
            bottomLayout.Controls.Add(labelTo, 3, 0);
            bottomLayout.Controls.Add(moduleDateToDateTimePicker, 4, 0);
            bottomLayout.Controls.Add(prevButton, 5, 0);
            bottomLayout.Controls.Add(nextButton, 6, 0);
            bottomLayout.Dock = DockStyle.Fill;
            bottomLayout.Location = new Point(16, 12);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.RowCount = 1;
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomLayout.Size = new Size(1108, 36);
            bottomLayout.TabIndex = 0;
            // 
            // summaryLabel
            // 
            summaryLabel.Dock = DockStyle.Fill;
            summaryLabel.Font = new Font("Segoe UI", 9F);
            summaryLabel.ForeColor = Color.FromArgb(73, 80, 87);
            summaryLabel.Location = new Point(3, 0);
            summaryLabel.Name = "summaryLabel";
            summaryLabel.Size = new Size(557, 36);
            summaryLabel.TabIndex = 0;
            summaryLabel.Text = "Showing 1–100 of 10,000 records | Page 1 of 100";
            summaryLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelFrom
            // 
            labelFrom.Dock = DockStyle.Fill;
            labelFrom.Font = new Font("Segoe UI", 9F);
            labelFrom.ForeColor = Color.FromArgb(73, 80, 87);
            labelFrom.Location = new Point(566, 0);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(44, 36);
            labelFrom.TabIndex = 1;
            labelFrom.Text = "from";
            labelFrom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // moduleDateFromDateTimePicker
            // 
            moduleDateFromDateTimePicker.CalendarForeColor = Color.FromArgb(33, 37, 41);
            moduleDateFromDateTimePicker.Dock = DockStyle.Fill;
            moduleDateFromDateTimePicker.Font = new Font("Segoe UI", 9F);
            moduleDateFromDateTimePicker.Format = DateTimePickerFormat.Short;
            moduleDateFromDateTimePicker.Location = new Point(616, 6);
            moduleDateFromDateTimePicker.Margin = new Padding(3, 6, 3, 6);
            moduleDateFromDateTimePicker.Name = "moduleDateFromDateTimePicker";
            moduleDateFromDateTimePicker.Size = new Size(134, 23);
            moduleDateFromDateTimePicker.TabIndex = 2;
            // 
            // labelTo
            // 
            labelTo.Dock = DockStyle.Fill;
            labelTo.Font = new Font("Segoe UI", 9F);
            labelTo.ForeColor = Color.FromArgb(73, 80, 87);
            labelTo.Location = new Point(756, 0);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(29, 36);
            labelTo.TabIndex = 3;
            labelTo.Text = "to";
            labelTo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // moduleDateToDateTimePicker
            // 
            moduleDateToDateTimePicker.CalendarForeColor = Color.FromArgb(33, 37, 41);
            moduleDateToDateTimePicker.Dock = DockStyle.Fill;
            moduleDateToDateTimePicker.Font = new Font("Segoe UI", 9F);
            moduleDateToDateTimePicker.Format = DateTimePickerFormat.Short;
            moduleDateToDateTimePicker.Location = new Point(791, 6);
            moduleDateToDateTimePicker.Margin = new Padding(3, 6, 3, 6);
            moduleDateToDateTimePicker.Name = "moduleDateToDateTimePicker";
            moduleDateToDateTimePicker.Size = new Size(134, 23);
            moduleDateToDateTimePicker.TabIndex = 4;
            // 
            // prevButton
            // 
            prevButton.BackColor = Color.FromArgb(233, 236, 239);
            prevButton.Cursor = Cursors.Hand;
            prevButton.Dock = DockStyle.Fill;
            prevButton.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            prevButton.FlatStyle = FlatStyle.Flat;
            prevButton.Font = new Font("Segoe UI", 10F);
            prevButton.ForeColor = Color.FromArgb(33, 37, 41);
            prevButton.Location = new Point(931, 6);
            prevButton.Margin = new Padding(3, 6, 3, 6);
            prevButton.Name = "prevButton";
            prevButton.Size = new Size(84, 24);
            prevButton.TabIndex = 5;
            prevButton.Text = "←";
            prevButton.UseVisualStyleBackColor = false;
            // 
            // nextButton
            // 
            nextButton.BackColor = Color.FromArgb(233, 236, 239);
            nextButton.Cursor = Cursors.Hand;
            nextButton.Dock = DockStyle.Fill;
            nextButton.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.Font = new Font("Segoe UI", 10F);
            nextButton.ForeColor = Color.FromArgb(33, 37, 41);
            nextButton.Location = new Point(1021, 6);
            nextButton.Margin = new Padding(3, 6, 3, 6);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(84, 24);
            nextButton.TabIndex = 6;
            nextButton.Text = "→";
            nextButton.UseVisualStyleBackColor = false;
            // 
            // ModuleUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(moduleDataGridView);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9F);
            Name = "ModuleUserControl";
            Size = new Size(1140, 800);
            panelTop.ResumeLayout(false);
            topLayout.ResumeLayout(false);
            topLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)moduleDataGridView).EndInit();
            panelBottom.ResumeLayout(false);
            bottomLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private TableLayoutPanel topLayout;
        private Label labelSearch;
        private TextBox moduleSearchTextBox;
        private Button moduleSearchButton;
        private Button moduleRefreshButton;
        private Button moduleAddButton;
        private DataGridView moduleDataGridView;
        private Panel panelBottom;
        private TableLayoutPanel bottomLayout;
        private Label summaryLabel;
        private Label labelFrom;
        private DateTimePicker moduleDateFromDateTimePicker;
        private Label labelTo;
        private DateTimePicker moduleDateToDateTimePicker;
        private Button prevButton;
        private Button nextButton;
    }
}