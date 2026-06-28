using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    partial class ProfileEditForm
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
            this.labelCurrentUsername = new Label();
            this.textBoxCurrentUsername = new TextBox();
            this.labelNewUsername = new Label();
            this.textBoxNewUsername = new TextBox();
            this.labelCurrentPassword = new Label();
            this.textBoxCurrentPassword = new TextBox();
            this.labelNewPassword = new Label();
            this.textBoxNewPassword = new TextBox();
            this.labelConfirmPassword = new Label();
            this.textBoxConfirmPassword = new TextBox();
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
            this.formTitleLabel.Size = new Size(143, 30);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "EDIT PROFILE";
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
            // labelCurrentUsername
            // 
            this.labelCurrentUsername.AutoSize = true;
            this.labelCurrentUsername.Location = new Point(20, 85);
            this.labelCurrentUsername.Name = "labelCurrentUsername";
            this.labelCurrentUsername.Size = new Size(113, 15);
            this.labelCurrentUsername.TabIndex = 2;
            this.labelCurrentUsername.Text = "Current Username:";
            // 
            // textBoxCurrentUsername
            // 
            this.textBoxCurrentUsername.Location = new Point(140, 82);
            this.textBoxCurrentUsername.Name = "textBoxCurrentUsername";
            this.textBoxCurrentUsername.ReadOnly = true;
            this.textBoxCurrentUsername.Size = new Size(300, 23);
            this.textBoxCurrentUsername.TabIndex = 3;
            // 
            // labelNewUsername
            // 
            this.labelNewUsername.AutoSize = true;
            this.labelNewUsername.Location = new Point(20, 115);
            this.labelNewUsername.Name = "labelNewUsername";
            this.labelNewUsername.Size = new Size(89, 15);
            this.labelNewUsername.TabIndex = 4;
            this.labelNewUsername.Text = "New Username:";
            // 
            // textBoxNewUsername
            // 
            this.textBoxNewUsername.Location = new Point(140, 112);
            this.textBoxNewUsername.Name = "textBoxNewUsername";
            this.textBoxNewUsername.Size = new Size(300, 23);
            this.textBoxNewUsername.TabIndex = 5;
            // 
            // labelCurrentPassword
            // 
            this.labelCurrentPassword.AutoSize = true;
            this.labelCurrentPassword.Location = new Point(20, 145);
            this.labelCurrentPassword.Name = "labelCurrentPassword";
            this.labelCurrentPassword.Size = new Size(107, 15);
            this.labelCurrentPassword.TabIndex = 6;
            this.labelCurrentPassword.Text = "* Current Password:";
            // 
            // textBoxCurrentPassword
            // 
            this.textBoxCurrentPassword.Location = new Point(140, 142);
            this.textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            this.textBoxCurrentPassword.PasswordChar = '•';
            this.textBoxCurrentPassword.Size = new Size(300, 23);
            this.textBoxCurrentPassword.TabIndex = 7;
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new Point(20, 175);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new Size(83, 15);
            this.labelNewPassword.TabIndex = 8;
            this.labelNewPassword.Text = "New Password:";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new Point(140, 172);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '•';
            this.textBoxNewPassword.Size = new Size(300, 23);
            this.textBoxNewPassword.TabIndex = 9;
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new Point(20, 205);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new Size(109, 15);
            this.labelConfirmPassword.TabIndex = 10;
            this.labelConfirmPassword.Text = "Confirm Password:";
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new Point(140, 202);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '•';
            this.textBoxConfirmPassword.Size = new Size(300, 23);
            this.textBoxConfirmPassword.TabIndex = 11;
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
            // ProfileEditForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(500, 310);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.textBoxCurrentPassword);
            this.Controls.Add(this.labelCurrentPassword);
            this.Controls.Add(this.textBoxNewUsername);
            this.Controls.Add(this.labelNewUsername);
            this.Controls.Add(this.textBoxCurrentUsername);
            this.Controls.Add(this.labelCurrentUsername);
            this.Controls.Add(this.labelRequired);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "ProfileEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Profile";
            this.Load += new EventHandler(this.ProfileEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label labelCurrentUsername;
        private TextBox textBoxCurrentUsername;
        private Label labelNewUsername;
        private TextBox textBoxNewUsername;
        private Label labelCurrentPassword;
        private TextBox textBoxCurrentPassword;
        private Label labelNewPassword;
        private TextBox textBoxNewPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button saveButton;
        private Button cancelButton;
        private Label formTitleLabel;
        private Label labelRequired;
    }
}
