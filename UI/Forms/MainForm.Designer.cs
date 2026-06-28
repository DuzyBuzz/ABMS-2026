namespace ABMS_2026.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar controls
        private Panel sidebarPanel;
        private Button dashboardButton;
        private Button patientsButton;
        private Button biteCasesButton;
        private Button vaccinationButton;
        private Button inventoryButton;
        private Button reportsButton;
        private Button adminButton;
        private Button logoutButton;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sidebarPanel = new Panel();
            settingsButton = new Button();
            userButton = new Button();
            transactionButton = new Button();
            inventoryButton = new Button();
            calendarButton = new Button();
            biteCaseButton = new Button();
            patientButton = new Button();
            dashboardsButton = new Button();
            pictureBox1 = new PictureBox();
            logoutButton = new Button();
            toolTip1 = new ToolTip(components);
            headerTilePanel = new Panel();
            userNameLabel = new Label();
            pageTitleLabel = new Label();
            mainContentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            headerTilePanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(7, 102, 255);
            sidebarPanel.Controls.Add(settingsButton);
            sidebarPanel.Controls.Add(userButton);
            sidebarPanel.Controls.Add(transactionButton);
            sidebarPanel.Controls.Add(inventoryButton);
            sidebarPanel.Controls.Add(calendarButton);
            sidebarPanel.Controls.Add(biteCaseButton);
            sidebarPanel.Controls.Add(patientButton);
            sidebarPanel.Controls.Add(dashboardsButton);
            sidebarPanel.Controls.Add(pictureBox1);
            sidebarPanel.Controls.Add(logoutButton);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(60, 800);
            sidebarPanel.TabIndex = 0;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Transparent;
            settingsButton.Cursor = Cursors.Hand;
            settingsButton.Dock = DockStyle.Bottom;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Font = new Font("Segoe UI Emoji", 16F);
            settingsButton.ForeColor = Color.White;
            settingsButton.Location = new Point(0, 720);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(60, 40);
            settingsButton.TabIndex = 43;
            settingsButton.Text = "⚙️";
            toolTip1.SetToolTip(settingsButton, "User Logs");
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // userButton
            // 
            userButton.BackColor = Color.Transparent;
            userButton.Cursor = Cursors.Hand;
            userButton.Dock = DockStyle.Top;
            userButton.FlatAppearance.BorderSize = 0;
            userButton.FlatStyle = FlatStyle.Flat;
            userButton.Font = new Font("Segoe UI Emoji", 16F);
            userButton.ForeColor = Color.White;
            userButton.Location = new Point(0, 290);
            userButton.Margin = new Padding(10);
            userButton.Name = "userButton";
            userButton.Size = new Size(60, 40);
            userButton.TabIndex = 40;
            userButton.Text = "🔐";
            toolTip1.SetToolTip(userButton, "Users");
            userButton.UseVisualStyleBackColor = true;
            userButton.Click += userButton_Click;
            // 
            // transactionButton
            // 
            transactionButton.BackColor = Color.Transparent;
            transactionButton.Cursor = Cursors.Hand;
            transactionButton.Dock = DockStyle.Top;
            transactionButton.FlatAppearance.BorderSize = 0;
            transactionButton.FlatStyle = FlatStyle.Flat;
            transactionButton.Font = new Font("Segoe UI Emoji", 16F);
            transactionButton.ForeColor = Color.White;
            transactionButton.Location = new Point(0, 250);
            transactionButton.Margin = new Padding(10);
            transactionButton.Name = "transactionButton";
            transactionButton.Size = new Size(60, 40);
            transactionButton.TabIndex = 39;
            transactionButton.Text = "⇄";
            toolTip1.SetToolTip(transactionButton, "Inventory Transactions");
            transactionButton.UseVisualStyleBackColor = true;
            transactionButton.Click += transactionButton_Click;
            // 
            // inventoryButton
            // 
            inventoryButton.BackColor = Color.Transparent;
            inventoryButton.Cursor = Cursors.Hand;
            inventoryButton.Dock = DockStyle.Top;
            inventoryButton.FlatAppearance.BorderSize = 0;
            inventoryButton.FlatStyle = FlatStyle.Flat;
            inventoryButton.Font = new Font("Segoe UI Emoji", 16F);
            inventoryButton.ForeColor = Color.White;
            inventoryButton.Location = new Point(0, 210);
            inventoryButton.Margin = new Padding(10);
            inventoryButton.Name = "inventoryButton";
            inventoryButton.Size = new Size(60, 40);
            inventoryButton.TabIndex = 38;
            inventoryButton.Text = "📦";
            toolTip1.SetToolTip(inventoryButton, "Inventory");
            inventoryButton.UseVisualStyleBackColor = true;
            inventoryButton.Click += inventoryButton_Click;
            // 
            // calendarButton
            // 
            calendarButton.BackColor = Color.Transparent;
            calendarButton.Cursor = Cursors.Hand;
            calendarButton.Dock = DockStyle.Top;
            calendarButton.FlatAppearance.BorderSize = 0;
            calendarButton.FlatStyle = FlatStyle.Flat;
            calendarButton.Font = new Font("Segoe UI Emoji", 16F);
            calendarButton.ForeColor = Color.White;
            calendarButton.Location = new Point(0, 170);
            calendarButton.Margin = new Padding(10);
            calendarButton.Name = "calendarButton";
            calendarButton.Size = new Size(60, 40);
            calendarButton.TabIndex = 34;
            calendarButton.Text = "📅";
            toolTip1.SetToolTip(calendarButton, "Calendar");
            calendarButton.UseVisualStyleBackColor = true;
            calendarButton.Click += calendarButton_Click;
            // 
            // biteCaseButton
            // 
            biteCaseButton.BackColor = Color.Transparent;
            biteCaseButton.Cursor = Cursors.Hand;
            biteCaseButton.Dock = DockStyle.Top;
            biteCaseButton.FlatAppearance.BorderSize = 0;
            biteCaseButton.FlatStyle = FlatStyle.Flat;
            biteCaseButton.Font = new Font("Segoe UI Emoji", 16F);
            biteCaseButton.ForeColor = Color.White;
            biteCaseButton.Location = new Point(0, 130);
            biteCaseButton.Margin = new Padding(10);
            biteCaseButton.Name = "biteCaseButton";
            biteCaseButton.Size = new Size(60, 40);
            biteCaseButton.TabIndex = 32;
            biteCaseButton.Text = "🗃️";
            toolTip1.SetToolTip(biteCaseButton, "Case Records");
            biteCaseButton.UseVisualStyleBackColor = true;
            biteCaseButton.Click += biteCaseButton_Click;
            // 
            // patientButton
            // 
            patientButton.BackColor = Color.Transparent;
            patientButton.Cursor = Cursors.Hand;
            patientButton.Dock = DockStyle.Top;
            patientButton.FlatAppearance.BorderSize = 0;
            patientButton.FlatStyle = FlatStyle.Flat;
            patientButton.Font = new Font("Segoe UI Emoji", 16F);
            patientButton.ForeColor = Color.White;
            patientButton.Location = new Point(0, 90);
            patientButton.Margin = new Padding(10);
            patientButton.Name = "patientButton";
            patientButton.Size = new Size(60, 40);
            patientButton.TabIndex = 27;
            patientButton.Text = "🤕";
            toolTip1.SetToolTip(patientButton, "Patients");
            patientButton.UseVisualStyleBackColor = true;
            patientButton.Click += patientButton_Click;
            // 
            // dashboardsButton
            // 
            dashboardsButton.BackColor = Color.Transparent;
            dashboardsButton.Cursor = Cursors.Hand;
            dashboardsButton.Dock = DockStyle.Top;
            dashboardsButton.FlatAppearance.BorderSize = 0;
            dashboardsButton.FlatStyle = FlatStyle.Flat;
            dashboardsButton.Font = new Font("Segoe UI Emoji", 16F);
            dashboardsButton.ForeColor = Color.White;
            dashboardsButton.Location = new Point(0, 50);
            dashboardsButton.Margin = new Padding(10);
            dashboardsButton.Name = "dashboardsButton";
            dashboardsButton.Size = new Size(60, 40);
            dashboardsButton.TabIndex = 26;
            dashboardsButton.Text = "📊";
            toolTip1.SetToolTip(dashboardsButton, "Dashboard");
            dashboardsButton.UseVisualStyleBackColor = true;
            dashboardsButton.Click += dashboardsButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Shot Animal Bite Center");
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.Transparent;
            logoutButton.Cursor = Cursors.Hand;
            logoutButton.Dock = DockStyle.Bottom;
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Font = new Font("Segoe UI Emoji", 16F);
            logoutButton.ForeColor = Color.FromArgb(254, 0, 2);
            logoutButton.Location = new Point(0, 760);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(60, 40);
            logoutButton.TabIndex = 8;
            logoutButton.Text = "🚪";
            toolTip1.SetToolTip(logoutButton, "Logout");
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += OnLogoutButtonClick;
            // 
            // headerTilePanel
            // 
            headerTilePanel.BackColor = Color.FromArgb(22, 54, 105);
            headerTilePanel.Controls.Add(userNameLabel);
            headerTilePanel.Controls.Add(pageTitleLabel);
            headerTilePanel.Dock = DockStyle.Top;
            headerTilePanel.Location = new Point(60, 0);
            headerTilePanel.Name = "headerTilePanel";
            headerTilePanel.Padding = new Padding(10);
            headerTilePanel.Size = new Size(1140, 50);
            headerTilePanel.TabIndex = 1;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Dock = DockStyle.Right;
            userNameLabel.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            userNameLabel.ForeColor = Color.White;
            userNameLabel.Location = new Point(1016, 10);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(114, 25);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "User Name";
            userNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pageTitleLabel
            // 
            pageTitleLabel.AutoSize = true;
            pageTitleLabel.Dock = DockStyle.Left;
            pageTitleLabel.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            pageTitleLabel.ForeColor = Color.White;
            pageTitleLabel.Location = new Point(10, 10);
            pageTitleLabel.Name = "pageTitleLabel";
            pageTitleLabel.Size = new Size(67, 25);
            pageTitleLabel.TabIndex = 0;
            pageTitleLabel.Text = "label1";
            pageTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackgroundImage = (Image)resources.GetObject("mainContentPanel.BackgroundImage");
            mainContentPanel.BackgroundImageLayout = ImageLayout.Zoom;
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(60, 50);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1140, 750);
            mainContentPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(mainContentPanel);
            Controls.Add(headerTilePanel);
            Controls.Add(sidebarPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Animal Bite Center Management System";
            WindowState = FormWindowState.Maximized;
            FormClosing += OnFormClosing;
            Load += OnFormLoad;
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            headerTilePanel.ResumeLayout(false);
            headerTilePanel.PerformLayout();
            ResumeLayout(false);
        }

        private Panel CreatePanel(string title)
        {
            Panel panel = new Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(0, 0);
            panel.Size = new System.Drawing.Size(1140, 750);
            panel.Visible = false;
            panel.BackColor = System.Drawing.Color.White;

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(20, 20);
            titleLabel.Size = new System.Drawing.Size(500, 40);
            panel.Controls.Add(titleLabel);

            return panel;
        }
        private PictureBox pictureBox1;
        private Button calendarButton;
        private Button biteCaseButton;
        private Button patientButton;
        private Button dashboardsButton;
        private Button userButton;
        private Button transactionButton;
        private ToolTip toolTip1;
        private Panel headerTilePanel;
        private Panel mainContentPanel;
        private Button settingsButton;
        private Label pageTitleLabel;
        private Label userNameLabel;
    }
}