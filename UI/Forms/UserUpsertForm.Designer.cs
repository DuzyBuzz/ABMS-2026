using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    partial class UserUpsertForm
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
            this.labelUsername = new Label();
            this.textBoxUsername = new TextBox();
            this.labelPassword = new Label();
            this.textBoxPassword = new TextBox();
            this.labelFullName = new Label();
            this.textBoxFullName = new TextBox();
            this.labelRole = new Label();
            this.comboBoxRole = new ComboBox();
            this.labelStatus = new Label();
            this.comboBoxStatus = new ComboBox();
            this.saveButton = new Button();
            this.cancelButton = new Button();
            this.formTitleLabel = new Label();
            this.labelRequired = new Label();
            this.SuspendLayout();
            // 
            // formTitleLabel
            //
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.formTitleLabel.ForeColor = Color.MidnightBlue;
            this.formTitleLabel.Location = new Point(20, 20);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new Size(125, 30);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "USER PROFILE";
            // 
            // labelRequired
            // 
            this.labelRequired.AutoSize = true;
            this.labelRequired.ForeColor = Color.Red;
            this.labelRequired.Location = new Point(20, 55);
            this.labelRequired.Name = "labelRequired";
            this.labelRequired.Size = new Size(129, 15);
            this.labelRequired.TabIndex = 1;
            this.labelRequired.Text = "* Required fields";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new Point(20, 85);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new Size(65, 15);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "* Username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new Point(140, 82);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new Size(300, 23);
            this.textBoxUsername.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new Point(20, 115);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new Size(61, 15);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "* Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new Point(140, 112);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new Size(300, 23);
            this.textBoxPassword.TabIndex = 5;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new Point(20, 145);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new Size(63, 15);
            this.labelFullName.TabIndex = 6;
            this.labelFullName.Text = "Full Name:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new Point(140, 142);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new Size(300, 23);
            this.textBoxFullName.TabIndex = 7;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new Point(20, 175);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new Size(33, 15);
            this.labelRole.TabIndex = 8;
            this.labelRole.Text = "* Role:";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] { "Admin", "Doctor", "Nurse", "Encoder" });
            this.comboBoxRole.Location = new Point(140, 172);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new Size(150, 23);
            this.comboBoxRole.TabIndex = 9;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new Point(20, 205);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new Size(43, 15);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            this.comboBoxStatus.Location = new Point(140, 202);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new Size(150, 23);
            this.comboBoxStatus.TabIndex = 11;
            // 
            // saveButton
            //
            this.saveButton.BackColor = Color.RoyalBlue;
            this.saveButton.FlatStyle = FlatStyle.Flat;
            this.saveButton.ForeColor = Color.White;
            this.saveButton.Location = new Point(140, 250);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new Size(100, 35);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            //
            this.cancelButton.BackColor = Color.Gray;
            this.cancelButton.FlatStyle = FlatStyle.Flat;
            this.cancelButton.ForeColor = Color.White;
            this.cancelButton.Location = new Point(250, 250);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(100, 35);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            //
            // UserUpsertForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(500, 310);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelRequired);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "UserUpsertForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "User Profile";
            this.Load += new EventHandler(this.UserUpsertForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelRole;
        private ComboBox comboBoxRole;
        private Label labelStatus;
        private ComboBox comboBoxStatus;
        private Button saveButton;
        private Button cancelButton;
        private Label formTitleLabel;
        private Label labelRequired;
    }
}
