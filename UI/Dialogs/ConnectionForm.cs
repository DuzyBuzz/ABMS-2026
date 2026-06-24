using System;
using System.Drawing;
using System.Windows.Forms;
using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;

namespace ABMS_2026.UI.Dialogs
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
            LoadCurrentConnection();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            connectionStringTextBox.Focus();
        }

        private void OnTestButtonClick(object sender, EventArgs e)
        {
            try
            {
                string connectionString = connectionStringTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    MessageBox.Show(
                        "Please enter a connection string.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                ShowStatus("Testing connection...", Color.Blue);

                var helper = new MySqlConnectionHelper(connectionString);

                if (helper.TestConnection())
                {
                    ShowStatus(
                        "Connection successful! Database is accessible.",
                        Color.Green);
                }
                else
                {
                    ShowStatus(
                        "Connection failed. Please verify the server, database, username, and password.",
                        Color.Red);
                }
            }
            catch (Exception ex)
            {
                ShowStatus(
                    $"Connection test failed: {ex.Message}",
                    Color.Red);
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                string connectionString = connectionStringTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    MessageBox.Show(
                        "Please enter a connection string.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var helper = new MySqlConnectionHelper(connectionString);

                if (!helper.TestConnection())
                {
                    MessageBox.Show(
                        "Unable to connect to the database using the provided connection string.",
                        "Connection Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                ConfigManager.SaveConnectionString(connectionString);

                ShowStatus(
                    "Connection string saved successfully.",
                    Color.Green);

                MessageBox.Show(
                    "Connection string saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowStatus(
                    $"Error saving connection string: {ex.Message}",
                    Color.Red);
            }
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadCurrentConnection()
        {
            try
            {
                connectionStringTextBox.Text =
                    ConfigManager.GetConnectionString();

                statusLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ShowStatus(
                    $"Error loading configuration: {ex.Message}",
                    Color.Red);
            }
        }

        private void ShowStatus(string message, Color color)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = color;
        }
    }
}