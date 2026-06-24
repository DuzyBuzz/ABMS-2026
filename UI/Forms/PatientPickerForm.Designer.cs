namespace ABMS_2026.UI.Forms
{
    partial class PatientPickerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button refreshButton;

        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView patientDataGridView;

        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button cancelButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            topPanel =
                new System.Windows.Forms.Panel();

            titleLabel =
                new System.Windows.Forms.Label();

            subtitleLabel =
                new System.Windows.Forms.Label();

            searchPanel =
                new System.Windows.Forms.Panel();

            searchTextBox =
                new System.Windows.Forms.TextBox();

            refreshButton =
                new System.Windows.Forms.Button();

            gridPanel =
                new System.Windows.Forms.Panel();

            patientDataGridView =
                new System.Windows.Forms.DataGridView();

            footerPanel =
                new System.Windows.Forms.Panel();

            totalLabel =
                new System.Windows.Forms.Label();

            selectButton =
                new System.Windows.Forms.Button();

            cancelButton =
                new System.Windows.Forms.Button();

            topPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)
                (patientDataGridView)).BeginInit();
            footerPanel.SuspendLayout();

            SuspendLayout();

            //
            // topPanel
            //
            topPanel.BackColor =
                System.Drawing.Color.White;

            topPanel.Controls.Add(
                subtitleLabel);

            topPanel.Controls.Add(
                titleLabel);

            topPanel.Dock =
                System.Windows.Forms.DockStyle.Top;

            topPanel.Location =
                new System.Drawing.Point(
                    0,
                    0);

            topPanel.Name =
                "topPanel";

            topPanel.Padding =
                new System.Windows.Forms.Padding(
                    20,
                    15,
                    20,
                    10);

            topPanel.Size =
                new System.Drawing.Size(
                    1100,
                    85);

            //
            // titleLabel
            //
            titleLabel.AutoSize =
                true;

            titleLabel.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            titleLabel.Location =
                new System.Drawing.Point(
                    20,
                    10);

            titleLabel.Name =
                "titleLabel";

            titleLabel.Size =
                new System.Drawing.Size(
                    194,
                    32);

            titleLabel.Text =
                "Patient Picker";

            //
            // subtitleLabel
            //
            subtitleLabel.AutoSize =
                true;

            subtitleLabel.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            subtitleLabel.ForeColor =
                System.Drawing.Color.DimGray;

            subtitleLabel.Location =
                new System.Drawing.Point(
                    22,
                    50);

            subtitleLabel.Name =
                "subtitleLabel";

            subtitleLabel.Size =
                new System.Drawing.Size(
                    298,
                    15);

            subtitleLabel.Text =
                "Select a patient to add into today's queue";

            //
            // searchPanel
            //
            searchPanel.BackColor =
                System.Drawing.Color.White;

            searchPanel.Controls.Add(
                refreshButton);

            searchPanel.Controls.Add(
                searchTextBox);

            searchPanel.Dock =
                System.Windows.Forms.DockStyle.Top;

            searchPanel.Location =
                new System.Drawing.Point(
                    0,
                    85);

            searchPanel.Name =
                "searchPanel";

            searchPanel.Padding =
                new System.Windows.Forms.Padding(
                    20,
                    10,
                    20,
                    10);

            searchPanel.Size =
                new System.Drawing.Size(
                    1100,
                    60);

            //
            // searchTextBox
            //
            searchTextBox.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            searchTextBox.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            searchTextBox.Location =
                new System.Drawing.Point(
                    20,
                    15);

            searchTextBox.Name =
                "searchTextBox";

            searchTextBox.PlaceholderText =
                "Search patient name, registration number, contact number...";

            searchTextBox.Size =
                new System.Drawing.Size(
                    930,
                    25);

            //
            // refreshButton
            //
            refreshButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Right));

            refreshButton.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            refreshButton.Location =
                new System.Drawing.Point(
                    960,
                    14);

            refreshButton.Name =
                "refreshButton";

            refreshButton.Size =
                new System.Drawing.Size(
                    120,
                    28);

            refreshButton.Text =
                "Refresh";

            refreshButton.UseVisualStyleBackColor =
                true;

            //
            // gridPanel
            //
            gridPanel.Controls.Add(
                patientDataGridView);

            gridPanel.Dock =
                System.Windows.Forms.DockStyle.Fill;

            gridPanel.Location =
                new System.Drawing.Point(
                    0,
                    145);

            gridPanel.Name =
                "gridPanel";

            gridPanel.Padding =
                new System.Windows.Forms.Padding(
                    20,
                    10,
                    20,
                    10);

            //
            // patientDataGridView
            //
            patientDataGridView.AllowUserToAddRows =
                false;

            patientDataGridView.AllowUserToDeleteRows =
                false;

            patientDataGridView.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            patientDataGridView.BackgroundColor =
                System.Drawing.Color.White;

            patientDataGridView.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            patientDataGridView.ColumnHeadersHeight =
                40;

            patientDataGridView.Dock =
                System.Windows.Forms.DockStyle.Fill;

            patientDataGridView.Location =
                new System.Drawing.Point(
                    20,
                    10);

            patientDataGridView.MultiSelect =
                false;

            patientDataGridView.Name =
                "patientDataGridView";

            patientDataGridView.ReadOnly =
                true;

            patientDataGridView.RowHeadersVisible =
                false;

            patientDataGridView.RowTemplate.Height =
                35;

            patientDataGridView.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            patientDataGridView.Size =
                new System.Drawing.Size(
                    1060,
                    445);

            //
            // footerPanel
            //
            footerPanel.BackColor =
                System.Drawing.Color.White;

            footerPanel.Controls.Add(
                totalLabel);

            footerPanel.Controls.Add(
                selectButton);

            footerPanel.Controls.Add(
                cancelButton);

            footerPanel.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            footerPanel.Location =
                new System.Drawing.Point(
                    0,
                    600);

            footerPanel.Name =
                "footerPanel";

            footerPanel.Size =
                new System.Drawing.Size(
                    1100,
                    60);

            //
            // totalLabel
            //
            totalLabel.AutoSize =
                true;

            totalLabel.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            totalLabel.Location =
                new System.Drawing.Point(
                    20,
                    22);

            totalLabel.Name =
                "totalLabel";

            totalLabel.Size =
                new System.Drawing.Size(
                    92,
                    15);

            totalLabel.Text =
                "0 Patients";

            //
            // selectButton
            //
            selectButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Right));

            selectButton.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            selectButton.Location =
                new System.Drawing.Point(
                    850,
                    15);

            selectButton.Name =
                "selectButton";

            selectButton.Size =
                new System.Drawing.Size(
                    110,
                    30);

            selectButton.Text =
                "Select";

            selectButton.UseVisualStyleBackColor =
                true;

            //
            // cancelButton
            //
            cancelButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Right));

            cancelButton.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            cancelButton.Location =
                new System.Drawing.Point(
                    970,
                    15);

            cancelButton.Name =
                "cancelButton";

            cancelButton.Size =
                new System.Drawing.Size(
                    110,
                    30);

            cancelButton.Text =
                "Cancel";

            cancelButton.UseVisualStyleBackColor =
                true;

            //
            // PatientPickerForm
            //
            AutoScaleDimensions =
                new System.Drawing.SizeF(
                    7F,
                    15F);

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            BackColor =
                System.Drawing.Color.White;

            ClientSize =
                new System.Drawing.Size(
                    1100,
                    660);

            Controls.Add(
                gridPanel);

            Controls.Add(
                footerPanel);

            Controls.Add(
                searchPanel);

            Controls.Add(
                topPanel);

            MinimumSize =
                new System.Drawing.Size(
                    1000,
                    600);

            Name =
                "PatientPickerForm";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            Text =
                "Patient Picker";

            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();

            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();

            gridPanel.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (patientDataGridView)).EndInit();

            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();

            ResumeLayout(false);
        }

        #endregion
    }
}