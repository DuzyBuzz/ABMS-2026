using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    partial class TreatmentScheduleUserControl
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
            this.headerPanel = new Panel();
            this.monthYearLabel = new Label();
            this.todayButton = new Button();
            this.nextMonthButton = new Button();
            this.prevMonthButton = new Button();
            this.calendarLayoutPanel = new TableLayoutPanel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = Color.FromArgb(22, 54, 105);
            this.headerPanel.Controls.Add(this.monthYearLabel);
            this.headerPanel.Controls.Add(this.todayButton);
            this.headerPanel.Controls.Add(this.nextMonthButton);
            this.headerPanel.Controls.Add(this.prevMonthButton);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Location = new Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new Size(800, 50);
            this.headerPanel.TabIndex = 0;
            // 
            // monthYearLabel
            // 
            this.monthYearLabel.AutoSize = true;
            this.monthYearLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.monthYearLabel.ForeColor = Color.White;
            this.monthYearLabel.Location = new Point(20, 12);
            this.monthYearLabel.Name = "monthYearLabel";
            this.monthYearLabel.Size = new Size(120, 25);
            this.monthYearLabel.TabIndex = 0;
            this.monthYearLabel.Text = "MMMM yyyy";
            // 
            // todayButton
            // 
            this.todayButton.BackColor = Color.White;
            this.todayButton.FlatStyle = FlatStyle.Flat;
            this.todayButton.Font = new Font("Segoe UI", 9F);
            this.todayButton.ForeColor = Color.FromArgb(22, 54, 105);
            this.todayButton.Location = new Point(450, 10);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new Size(80, 30);
            this.todayButton.TabIndex = 3;
            this.todayButton.Text = "Today";
            this.todayButton.UseVisualStyleBackColor = false;
            this.todayButton.Click += new EventHandler(this.todayButton_Click);
            // 
            // nextMonthButton
            // 
            this.nextMonthButton.BackColor = Color.White;
            this.nextMonthButton.FlatStyle = FlatStyle.Flat;
            this.nextMonthButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.nextMonthButton.ForeColor = Color.FromArgb(22, 54, 105);
            this.nextMonthButton.Location = new Point(540, 10);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new Size(40, 30);
            this.nextMonthButton.TabIndex = 2;
            this.nextMonthButton.Text = ">";
            this.nextMonthButton.UseVisualStyleBackColor = false;
            this.nextMonthButton.Click += new EventHandler(this.nextMonthButton_Click);
            // 
            // prevMonthButton
            // 
            this.prevMonthButton.BackColor = Color.White;
            this.prevMonthButton.FlatStyle = FlatStyle.Flat;
            this.prevMonthButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.prevMonthButton.ForeColor = Color.FromArgb(22, 54, 105);
            this.prevMonthButton.Location = new Point(400, 10);
            this.prevMonthButton.Name = "prevMonthButton";
            this.prevMonthButton.Size = new Size(40, 30);
            this.prevMonthButton.TabIndex = 1;
            this.prevMonthButton.Text = "<";
            this.prevMonthButton.UseVisualStyleBackColor = false;
            this.prevMonthButton.Click += new EventHandler(this.prevMonthButton_Click);
            // 
            // calendarLayoutPanel
            // 
            this.calendarLayoutPanel.BackColor = Color.White;
            this.calendarLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.calendarLayoutPanel.ColumnCount = 7;
            this.calendarLayoutPanel.Dock = DockStyle.Fill;
            this.calendarLayoutPanel.Location = new Point(0, 50);
            this.calendarLayoutPanel.Name = "calendarLayoutPanel";
            this.calendarLayoutPanel.RowCount = 7;
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.calendarLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.calendarLayoutPanel.Size = new Size(800, 550);
            this.calendarLayoutPanel.TabIndex = 1;
            // 
            // TreatmentScheduleUserControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.calendarLayoutPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "TreatmentScheduleUserControl";
            this.Size = new Size(800, 600);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel headerPanel;
        private Label monthYearLabel;
        private Button todayButton;
        private Button nextMonthButton;
        private Button prevMonthButton;
        private TableLayoutPanel calendarLayoutPanel;
    }
}