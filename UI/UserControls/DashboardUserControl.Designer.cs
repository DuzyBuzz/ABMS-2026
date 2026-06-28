namespace ABMS_2026.UI.UserControls
{
    partial class DashboardUserControl
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
            titleNavPanel = new Panel();
            formTitleLabel = new Label();
            titleNavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleNavPanel
            // 
            titleNavPanel.Controls.Add(formTitleLabel);
            titleNavPanel.Dock = DockStyle.Top;
            titleNavPanel.Location = new Point(0, 0);
            titleNavPanel.Name = "titleNavPanel";
            titleNavPanel.Size = new Size(1140, 50);
            titleNavPanel.TabIndex = 0;
            // 
            // formTitleLabel
            // 
            formTitleLabel.AutoSize = true;
            formTitleLabel.Dock = DockStyle.Left;
            formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            formTitleLabel.ForeColor = Color.FromArgb(22, 54, 105);
            formTitleLabel.Location = new Point(0, 0);
            formTitleLabel.Margin = new Padding(10);
            formTitleLabel.Name = "formTitleLabel";
            formTitleLabel.Padding = new Padding(10);
            formTitleLabel.Size = new Size(355, 50);
            formTitleLabel.TabIndex = 1;
            formTitleLabel.Text = "DAILY TREATMENT SCHEDULES";
            // 
            // DashboardUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleNavPanel);
            Name = "DashboardUserControl";
            Size = new Size(1140, 750);
            titleNavPanel.ResumeLayout(false);
            titleNavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel titleNavPanel;
        private Label formTitleLabel;
    }
}
