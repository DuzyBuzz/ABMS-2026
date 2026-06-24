namespace ENT_Clinic_System.Helpers
{
    partial class PatientCamera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            comboBoxCameras = new ComboBox();
            pictureBoxCaptured = new PictureBox();
            btnCapture = new Button();
            btnConfirm = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBoxLive = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptured).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLive).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCameras
            // 
            comboBoxCameras.Dock = DockStyle.Top;
            comboBoxCameras.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCameras.FormattingEnabled = true;
            comboBoxCameras.Location = new Point(0, 0);
            comboBoxCameras.Margin = new Padding(2);
            comboBoxCameras.Name = "comboBoxCameras";
            comboBoxCameras.Size = new Size(586, 23);
            comboBoxCameras.TabIndex = 0;
            comboBoxCameras.SelectedIndexChanged += comboBoxCameras_SelectedIndexChanged;
            // 
            // pictureBoxCaptured
            // 
            pictureBoxCaptured.BackColor = Color.Gray;
            pictureBoxCaptured.Dock = DockStyle.Fill;
            pictureBoxCaptured.Location = new Point(0, 0);
            pictureBoxCaptured.Margin = new Padding(2);
            pictureBoxCaptured.Name = "pictureBoxCaptured";
            pictureBoxCaptured.Size = new Size(586, 655);
            pictureBoxCaptured.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCaptured.TabIndex = 2;
            pictureBoxCaptured.TabStop = false;
            // 
            // btnCapture
            // 
            btnCapture.Dock = DockStyle.Fill;
            btnCapture.Location = new Point(2, 2);
            btnCapture.Margin = new Padding(2);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(289, 46);
            btnCapture.TabIndex = 3;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Dock = DockStyle.Fill;
            btnConfirm.Location = new Point(295, 2);
            btnConfirm.Margin = new Padding(2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(289, 46);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1184, 661);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBoxLive);
            panel1.Controls.Add(comboBoxCameras);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(586, 655);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Controls.Add(pictureBoxCaptured);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(595, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(586, 655);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnCapture, 0, 0);
            tableLayoutPanel2.Controls.Add(btnConfirm, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 605);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(586, 50);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBoxLive
            // 
            pictureBoxLive.BackColor = Color.Black;
            pictureBoxLive.Dock = DockStyle.Fill;
            pictureBoxLive.Location = new Point(0, 23);
            pictureBoxLive.Margin = new Padding(2);
            pictureBoxLive.Name = "pictureBoxLive";
            pictureBoxLive.Size = new Size(586, 632);
            pictureBoxLive.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLive.TabIndex = 2;
            pictureBoxLive.TabStop = false;
            // 
            // PatientCamera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PatientCamera";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Patient Camera";
            FormClosing += PatientCamera_FormClosing;
            Load += PatientCamera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptured).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLive).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.PictureBox pictureBoxCaptured;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnConfirm;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox pictureBoxLive;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
