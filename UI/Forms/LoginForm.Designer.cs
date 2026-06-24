namespace ABMS_2026.UI.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            titleLabel = new Label();
            subtitleLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(50, 240);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(325, 30);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Animal Bite Center";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            subtitleLabel.Font = new Font("Microsoft Sans Serif", 14F);
            subtitleLabel.Location = new Point(50, 275);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(325, 25);
            subtitleLabel.TabIndex = 2;
            subtitleLabel.Text = "Management System";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(50, 325);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(100, 23);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(50, 385);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(100, 23);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(50, 355);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(325, 23);
            usernameTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(50, 415);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.Size = new Size(325, 23);
            passwordTextBox.TabIndex = 6;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Microsoft Sans Serif", 10F);
            loginButton.Location = new Point(145, 460);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(100, 35);
            loginButton.TabIndex = 7;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += OnLoginButtonClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(112, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // LoginForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 550);
            Controls.Add(pictureBox1);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Animal Bite Center Management System - Login";
            Load += OnFormLoad;
            KeyDown += LoginForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private PictureBox pictureBox1;
    }
}