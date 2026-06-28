using ABMS_2026.Common.Session;
using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class ProfileEditForm : Form
    {
        private readonly MySqlConnectionHelper _connectionHelper;

        public ProfileEditForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            WireUpEvents();
            LoadCurrentUser();
        }

        private void WireUpEvents()
        {
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, args) => Close();
        }

        private void LoadCurrentUser()
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("You are not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            textBoxCurrentUsername.Text = SessionManager.Username;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxCurrentPassword.Text))
            {
                MessageBox.Show("Current password is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCurrentPassword.Focus();
                return false;
            }

            // Verify current password
            if (!VerifyCurrentPassword())
            {
                MessageBox.Show("Current password is incorrect.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCurrentPassword.Clear();
                textBoxCurrentPassword.Focus();
                return false;
            }

            // If changing username, validate it
            if (!string.IsNullOrWhiteSpace(textBoxNewUsername.Text))
            {
                if (textBoxNewUsername.Text == SessionManager.Username)
                {
                    MessageBox.Show("New username cannot be the same as current username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNewUsername.Focus();
                    return false;
                }
            }

            // If changing password, validate it
            if (!string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                if (textBoxNewPassword.Text.Length < 4)
                {
                    MessageBox.Show("New password must be at least 4 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNewPassword.Focus();
                    return false;
                }

                if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
                {
                    MessageBox.Show("New password and confirm password do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxConfirmPassword.Focus();
                    return false;
                }
            }

            // At least one field must be changed
            if (string.IsNullOrWhiteSpace(textBoxNewUsername.Text) && string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBox.Show("Please enter a new username or new password to update your profile.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNewUsername.Focus();
                return false;
            }

            return true;
        }

        private bool VerifyCurrentPassword()
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                const string sql = @"
SELECT COUNT(*)
FROM users
WHERE user_id = @user_id
AND BINARY password = @password
LIMIT 1;";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@user_id", SessionManager.UserId);
                command.Parameters.AddWithValue("@password", textBoxCurrentPassword.Text.Trim());

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error verifying password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                using var transaction = connection.BeginTransaction();

                try
                {
                    string sql = "UPDATE users SET ";
                    var updates = new System.Collections.Generic.List<string>();

                    // Add username update if provided
                    if (!string.IsNullOrWhiteSpace(textBoxNewUsername.Text))
                    {
                        updates.Add("username = @username");
                    }

                    // Add password update if provided
                    if (!string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
                    {
                        updates.Add("password = @password");
                    }

                    sql += string.Join(", ", updates);
                    sql += " WHERE user_id = @user_id;";

                    using var command = new MySqlCommand(sql, connection, transaction);
                    command.Parameters.AddWithValue("@user_id", SessionManager.UserId);

                    if (!string.IsNullOrWhiteSpace(textBoxNewUsername.Text))
                    {
                        command.Parameters.AddWithValue("@username", textBoxNewUsername.Text.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
                    {
                        command.Parameters.AddWithValue("@password", textBoxNewPassword.Text.Trim());
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        transaction.Commit();

                        // Update session
                        if (!string.IsNullOrWhiteSpace(textBoxNewUsername.Text))
                        {
                            SessionManager.Username = textBoxNewUsername.Text.Trim();
                        }

                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("No record was updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update profile.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
