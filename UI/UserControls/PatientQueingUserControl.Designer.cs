namespace ABMS_2026.UI.UserControls
{
    partial class PatientQueingUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Panel contentPanel;

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label activeQueueLabel;

        private System.Windows.Forms.Button addQueueButton;
        private System.Windows.Forms.Button refreshButton;

        private System.Windows.Forms.DataGridView queueDataGridView;

        private System.Windows.Forms.Timer refreshTimer;

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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            subtitleLabel = new Label();
            titleLabel = new Label();
            toolbarPanel = new Panel();
            activeQueueLabel = new Label();
            refreshButton = new Button();
            addQueueButton = new Button();
            contentPanel = new Panel();
            queueDataGridView = new DataGridView();
            refreshTimer = new System.Windows.Forms.Timer(components);
            headerPanel.SuspendLayout();
            toolbarPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)queueDataGridView).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1200, 80);
            headerPanel.TabIndex = 2;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.ForeColor = Color.DimGray;
            subtitleLabel.Location = new Point(22, 50);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(167, 15);
            subtitleLabel.TabIndex = 0;
            subtitleLabel.Text = "Manage today's patient queue";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(20, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(175, 32);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Patient Queue";
            // 
            // toolbarPanel
            // 
            toolbarPanel.BackColor = Color.White;
            toolbarPanel.Controls.Add(activeQueueLabel);
            toolbarPanel.Controls.Add(refreshButton);
            toolbarPanel.Controls.Add(addQueueButton);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Location = new Point(0, 80);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new Size(1200, 60);
            toolbarPanel.TabIndex = 1;
            // 
            // activeQueueLabel
            // 
            activeQueueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            activeQueueLabel.Location = new Point(950, 18);
            activeQueueLabel.Name = "activeQueueLabel";
            activeQueueLabel.Size = new Size(230, 20);
            activeQueueLabel.TabIndex = 0;
            activeQueueLabel.Text = "Active Queue: 0";
            activeQueueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(150, 14);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(120, 30);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // addQueueButton
            // 
            addQueueButton.Location = new Point(20, 14);
            addQueueButton.Name = "addQueueButton";
            addQueueButton.Size = new Size(120, 30);
            addQueueButton.TabIndex = 2;
            addQueueButton.Text = "Add Queue";
            addQueueButton.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(queueDataGridView);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 140);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(15);
            contentPanel.Size = new Size(1200, 560);
            contentPanel.TabIndex = 0;
            // 
            // queueDataGridView
            // 
            queueDataGridView.AllowUserToAddRows = false;
            queueDataGridView.AllowUserToDeleteRows = false;
            queueDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            queueDataGridView.BackgroundColor = Color.White;
            queueDataGridView.ColumnHeadersHeight = 40;
            queueDataGridView.Dock = DockStyle.Fill;
            queueDataGridView.Location = new Point(15, 15);
            queueDataGridView.MultiSelect = false;
            queueDataGridView.Name = "queueDataGridView";
            queueDataGridView.RowHeadersVisible = false;
            queueDataGridView.RowTemplate.Height = 35;
            queueDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            queueDataGridView.Size = new Size(1170, 530);
            queueDataGridView.TabIndex = 0;
            // 
            // refreshTimer
            // 
            refreshTimer.Interval = 3000;
            // 
            // PatientQueingUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentPanel);
            Controls.Add(toolbarPanel);
            Controls.Add(headerPanel);
            Name = "PatientQueingUserControl";
            Size = new Size(1200, 700);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            toolbarPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)queueDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}