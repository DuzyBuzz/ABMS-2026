using ABMS_2026.Common.Helpers;
using ABMS_2026.Common.Session;
using ABMS_2026.UI.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class MainForm : Form
    {
        private ToolTip sidebarTooltip;
        private Label? _currentUserInfoLabel;
        private Label? _userRoleLabel;
        private Button? _currentHighlightedButton;

        public MainForm()
        {
            InitializeComponent();

            // Set the icon
            try
            {
                this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("Resources\\Icons\\shoot-animalbitelogo.ico");
            }
            catch
            {
                // If icon loading fails, use default
            }

            SetupUserSpecificFeatures();
            StartDateTimeTimer();
        }


        private void SetupUserSpecificFeatures()
        {



        }





        private void OnLogoutButtonClick(object sender, EventArgs e)
        {
            if (ConfirmLogout())
            {

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }



        private bool ConfirmLogout()
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void ShowFeatureComingSoonMessage(string featureName)
        {
            MessageBox.Show(
                $"{featureName} will be implemented soon.",
                "Feature Coming Soon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Dashboard";
            userNameLabel.Text = SessionManager.FullName;

            // Highlight dashboard button by default
            HighlightButton(dashboardsButton);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (ConfirmExit())
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private bool ConfirmExit()
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void SetupSidebarTooltips()
        {
            sidebarTooltip.AutoPopDelay = 5000;
            sidebarTooltip.InitialDelay = 1000;
            sidebarTooltip.ReshowDelay = 500;

            if (dashboardButton != null) sidebarTooltip.SetToolTip(dashboardButton, "Dashboard");
            if (patientsButton != null) sidebarTooltip.SetToolTip(patientsButton, "Patients");
            if (biteCasesButton != null) sidebarTooltip.SetToolTip(biteCasesButton, "Bite Cases");
            if (vaccinationButton != null) sidebarTooltip.SetToolTip(vaccinationButton, "Vaccination");
            if (inventoryButton != null) sidebarTooltip.SetToolTip(inventoryButton, "Inventory");
            if (reportsButton != null) sidebarTooltip.SetToolTip(reportsButton, "Reports");
            if (adminButton != null) sidebarTooltip.SetToolTip(adminButton, "Admin");
            if (logoutButton != null) sidebarTooltip.SetToolTip(logoutButton, "Logout");
        }

        private void StartDateTimeTimer()
        {
            //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            //timer.Interval = 1000;
            //timer.Tick += (s, e) => {
            //    if (dateTimeLabel != null)
            //        dateTimeLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss");
            //};
            //timer.Start();
        }

        private void HighlightButton(Button? button)
        {
            // Reset previous highlighted button
            if (_currentHighlightedButton != null)
            {
                _currentHighlightedButton.ForeColor = Color.White;
                _currentHighlightedButton.BackColor = Color.Transparent;
            }

            // Highlight new button
            if (button != null)
            {
                button.ForeColor = Color.FromArgb(22, 54, 105);
                button.BackColor = Color.White;

                _currentHighlightedButton = button;
            }
        }




        private void patientButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Patients";
            UserControlLoaderHelper.Load(mainContentPanel, new PatientUserControl());
            HighlightButton(patientButton);
        }

        private void adminPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dashboardsButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Dashboard";
            HighlightButton(dashboardsButton);
            UserControlLoaderHelper.Load(mainContentPanel, new DashboardUserControl());
        }

        private void biteCaseButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Bite Cases";
            HighlightButton(biteCaseButton);
            UserControlLoaderHelper.Load(mainContentPanel, new BiteCaseUserControl());
        }

        private void queingButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Queing";
        }

        private void calendarButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Schedule";
            HighlightButton(calendarButton);
            UserControlLoaderHelper.Load(mainContentPanel, new TreatmentScheduleUserControl());
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Inventory";
            HighlightButton(inventoryButton);
            UserControlLoaderHelper.Load(mainContentPanel, new InventoryItemsUserControl());
        }

        private void transactionButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "Transactions";
            HighlightButton(transactionButton);
            UserControlLoaderHelper.Load(mainContentPanel, new InventoryTransactionsUserControl());

        }

        private void userButton_Click(object sender, EventArgs e)
        {
            pageTitleLabel.Text = "User Management";
            HighlightButton(userButton);
            UserControlLoaderHelper.Load(mainContentPanel, new UserUserControl());
        }

        private void userLogsButton_Click(object sender, EventArgs e)
        {
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ProfileEditForm profileEditForm = new ProfileEditForm();
            profileEditForm.ShowDialog();
        }
    }
} 