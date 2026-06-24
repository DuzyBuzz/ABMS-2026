using ABMS_2026.Common.Session;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Dialogs;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            KeyPreview = true;
        }

        private async void OnLoginButtonClick(
            object sender,
            EventArgs e)
        {
            try
            {
                string username =
                    usernameTextBox.Text.Trim();

                string password =
                    passwordTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show(
                        "Username is required.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    usernameTextBox.Focus();

                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(
                        "Password is required.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    passwordTextBox.Focus();

                    return;
                }

                bool success = false;

                using (var connection =
                    new MySqlConnectionHelper()
                    .GetConnection())
                {
                    await connection.OpenAsync();

                    const string sql = @"
SELECT
    user_id,
    username,
    full_name
FROM users
WHERE BINARY username = @username
AND BINARY password = @password
AND is_active = 1
LIMIT 1;";

                    using (var command =
                        new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@username",
                            username);

                        command.Parameters.AddWithValue(
                            "@password",
                            password);

                        using (var reader =
                            (MySqlDataReader)
                            await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                success = true;

                                SessionManager.UserId =
                                    Convert.ToInt32(
                                        reader["user_id"]);

                                SessionManager.Username =
                                    reader["username"]
                                    .ToString() ?? string.Empty;

                                SessionManager.FullName =
                                    reader["full_name"]
                                    .ToString() ?? string.Empty;
                            }
                        }
                    }
                }

                if (!success)
                {
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    passwordTextBox.Clear();

                    passwordTextBox.Focus();

                    return;
                }

                Hide();

                using (var mainForm =
                    new MainForm())
                {
                    mainForm.ShowDialog();
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OnFormLoad(
            object sender,
            EventArgs e)
        {
            usernameTextBox.Focus();
        }

        private void OpenConnectionForm()
        {
            try
            {
                using (var connectionForm =
                    new ConnectionForm())
                {
                    connectionForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoginForm_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.Control &&
                e.Shift &&
                e.KeyCode == Keys.C)
            {
                OpenConnectionForm();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void pictureBox1_Click(
            object sender,
            EventArgs e)
        {
            OpenConnectionForm();
        }

        private void OnExitButtonClick(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }
    }
}