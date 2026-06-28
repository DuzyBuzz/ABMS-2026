namespace ABMS_2026.UI.Forms
{
    partial class PatientPickerForm
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
            searchPanel = new Panel();
            searchButton = new Button();
            searchTextBox = new TextBox();
            searchLabel = new Label();
            patientsDataGridView = new DataGridView();
            buttonPanel = new Panel();
            cancelButton = new Button();
            selectButton = new Button();
            formTitleLabel = new Label();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)patientsDataGridView).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(searchButton);
            searchPanel.Controls.Add(searchTextBox);
            searchPanel.Controls.Add(searchLabel);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(20, 10, 20, 10);
            searchPanel.Size = new Size(800, 50);
            searchPanel.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.Dock = DockStyle.Right;
            searchButton.Font = new Font("Segoe UI", 10F);
            searchButton.Location = new Point(672, 10);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(108, 30);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.Font = new Font("Segoe UI", 10F);
            searchTextBox.Location = new Point(72, 10);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Type to search patients...";
            searchTextBox.Size = new Size(708, 25);
            searchTextBox.TabIndex = 1;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Dock = DockStyle.Left;
            searchLabel.Font = new Font("Segoe UI", 10F);
            searchLabel.Location = new Point(20, 10);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(52, 19);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Search:";
            searchLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // patientsDataGridView
            // 
            patientsDataGridView.AllowUserToAddRows = false;
            patientsDataGridView.AllowUserToDeleteRows = false;
            patientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            patientsDataGridView.BackgroundColor = Color.White;
            patientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            patientsDataGridView.Dock = DockStyle.Fill;
            patientsDataGridView.Location = new Point(0, 50);
            patientsDataGridView.Name = "patientsDataGridView";
            patientsDataGridView.ReadOnly = true;
            patientsDataGridView.RowHeadersVisible = false;
            patientsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            patientsDataGridView.Size = new Size(800, 405);
            patientsDataGridView.TabIndex = 2;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(selectButton);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 455);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(20, 10, 20, 10);
            buttonPanel.Size = new Size(800, 55);
            buttonPanel.TabIndex = 3;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Gray;
            cancelButton.Dock = DockStyle.Right;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(580, 10);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 35);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // selectButton
            // 
            selectButton.BackColor = Color.RoyalBlue;
            selectButton.Dock = DockStyle.Right;
            selectButton.FlatStyle = FlatStyle.Flat;
            selectButton.ForeColor = Color.White;
            selectButton.Location = new Point(680, 10);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(100, 35);
            selectButton.TabIndex = 0;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = false;
            // 
            // formTitleLabel
            // 
            formTitleLabel.AutoSize = true;
            formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            formTitleLabel.ForeColor = Color.MidnightBlue;
            formTitleLabel.Location = new Point(20, 20);
            formTitleLabel.Name = "formTitleLabel";
            formTitleLabel.Size = new Size(149, 30);
            formTitleLabel.TabIndex = 0;
            formTitleLabel.Text = "SELECT PATIENT";
            // 
            // PatientPickerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 510);
            Controls.Add(patientsDataGridView);
            Controls.Add(buttonPanel);
            Controls.Add(searchPanel);
            Controls.Add(formTitleLabel);
            Font = new Font("Segoe UI", 9F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PatientPickerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Patient";
            Load += PatientPickerForm_Load;
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)patientsDataGridView).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formTitleLabel;
        private Panel searchPanel;
        private Label searchLabel;
        private TextBox searchTextBox;
        private Button searchButton;
        private DataGridView patientsDataGridView;
        private Panel buttonPanel;
        private Button selectButton;
        private Button cancelButton;
    }
}
