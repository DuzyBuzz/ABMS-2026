using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    partial class TreatmentScheduleDayForm
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

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.schedulesDataGridView = new DataGridView();
            this.dateLabel = new Label();
            this.countLabel = new Label();
            this.closeButton = new Button();
            this.formTitleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.formTitleLabel.ForeColor = Color.FromArgb(22, 54, 105);
            this.formTitleLabel.Location = new Point(20, 20);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new Size(230, 30);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "DAILY TREATMENT SCHEDULES";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dateLabel.ForeColor = Color.FromArgb(22, 54, 105);
            this.dateLabel.Location = new Point(20, 60);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new Size(136, 20);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Schedules for date";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new Point(20, 85);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new Size(42, 15);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "Total: 0";
            // 
            // schedulesDataGridView
            // 
            this.schedulesDataGridView.AllowUserToAddRows = false;
            this.schedulesDataGridView.AllowUserToDeleteRows = false;
            this.schedulesDataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.schedulesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.schedulesDataGridView.BackgroundColor = Color.White;
            this.schedulesDataGridView.BorderStyle = BorderStyle.FixedSingle;
            this.schedulesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schedulesDataGridView.Location = new Point(20, 110);
            this.schedulesDataGridView.Name = "schedulesDataGridView";
            this.schedulesDataGridView.ReadOnly = true;
            this.schedulesDataGridView.RowHeadersVisible = false;
            this.schedulesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.schedulesDataGridView.Size = new Size(1160, 350);
            this.schedulesDataGridView.TabIndex = 3;
            this.schedulesDataGridView.CellClick += new DataGridViewCellEventHandler(this.schedulesDataGridView_CellClick);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.closeButton.BackColor = Color.FromArgb(22, 54, 105);
            this.closeButton.FlatStyle = FlatStyle.Flat;
            this.closeButton.ForeColor = Color.White;
            this.closeButton.Location = new Point(1000, 480);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new Size(100, 35);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new EventHandler(this.closeButton_Click);
            // 
            // TreatmentScheduleDayForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1200, 530);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.schedulesDataGridView);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreatmentScheduleDayForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Daily Treatment Schedules";
            this.Load += new EventHandler(this.TreatmentScheduleDayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DataGridView schedulesDataGridView;
        private Label dateLabel;
        private Label countLabel;
        private Button closeButton;
        private Label formTitleLabel;
    }
}