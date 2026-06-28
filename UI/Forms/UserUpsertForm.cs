using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Shared.Components;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class UserUpsertForm : Form, IModuleUpsertForm
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private ModuleRecordContext? _context;
        private int? _userId;
        private bool _loadedViaInterface = false;

        public UserUpsertForm()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        public UserUpsertForm(int userId) : this()
        {
            _userId = userId;
        }

        private void UserUpsertForm_Load(object sender, EventArgs e)
        {
            WireUpEvents();

            // Only load if not already loaded via LoadModuleRecord
            if (!_loadedViaInterface)
            {
                if (_userId.HasValue)
                {
                    LoadUser(_userId.Value);
                }
                else
                {
                    ClearForm();
                }
            }
        }

        private void WireUpEvents()
        {
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, args) => Close();
        }

        public void LoadModuleRecord(ModuleRecordContext context)
        {
            _loadedViaInterface = true;
            _context = context;
            _userId = context.PrimaryKeyValue as int?;

            if (_userId.HasValue)
            {
                LoadUser(_userId.Value);
            }
            else
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxFullName.Clear();
            comboBoxRole.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = 0; // Default to Active
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Password is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            if (comboBoxRole.SelectedIndex < 0)
            {
                MessageBox.Show("Role is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRole.Focus();
                return false;
            }

            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            if (_userId.HasValue)
            {
                UpdateUser();
            }
            else
            {
                InsertUser();
            }
        }

        private void InsertUser()
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                const string sql = @"
INSERT INTO users
(
    username,
    password,
    full_name,
    role,
    status,
    is_active
)
VALUES
(
    @username,
    @password,
    @full_name,
    @role,
    @status,
    @is_active
);

SELECT LAST_INSERT_ID();";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", textBoxUsername.Text.Trim());
                command.Parameters.AddWithValue("@password", textBoxPassword.Text.Trim());
                command.Parameters.AddWithValue("@full_name", string.IsNullOrWhiteSpace(textBoxFullName.Text) ? DBNull.Value : textBoxFullName.Text.Trim());
                command.Parameters.AddWithValue("@role", comboBoxRole.SelectedItem?.ToString() ?? "Encoder");
                command.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem?.ToString() ?? "Active");
                command.Parameters.AddWithValue("@is_active", comboBoxStatus.SelectedItem?.ToString() == "Active" ? 1 : 0);

                _userId = Convert.ToInt32(command.ExecuteScalar());

                MessageBox.Show("User saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save user.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUser()
        {
            if (!_userId.HasValue)
            {
                MessageBox.Show("User ID is required for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                const string sql = @"
UPDATE users
SET
    username = @username,
    password = @password,
    full_name = @full_name,
    role = @role,
    status = @status,
    is_active = @is_active
WHERE user_id = @user_id;";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", textBoxUsername.Text.Trim());
                command.Parameters.AddWithValue("@password", textBoxPassword.Text.Trim());
                command.Parameters.AddWithValue("@full_name", string.IsNullOrWhiteSpace(textBoxFullName.Text) ? DBNull.Value : textBoxFullName.Text.Trim());
                command.Parameters.AddWithValue("@role", comboBoxRole.SelectedItem?.ToString() ?? "Encoder");
                command.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem?.ToString() ?? "Active");
                command.Parameters.AddWithValue("@is_active", comboBoxStatus.SelectedItem?.ToString() == "Active" ? 1 : 0);
                command.Parameters.AddWithValue("@user_id", _userId.Value);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No record was updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update user.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUser(int userId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                const string sql = @"
SELECT
    user_id,
    username,
    password,
    full_name,
    role,
    status,
    is_active
FROM users
WHERE user_id = @user_id
LIMIT 1;";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@user_id", userId);

                using var reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("User record not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                textBoxUsername.Text = reader["username"]?.ToString() ?? string.Empty;
                textBoxPassword.Text = reader["password"]?.ToString() ?? string.Empty;
                textBoxFullName.Text = reader["full_name"] == DBNull.Value ? string.Empty : reader["full_name"].ToString();

                if (reader["role"] != DBNull.Value)
                {
                    comboBoxRole.SelectedItem = reader["role"].ToString();
                }
                else
                {
                    comboBoxRole.SelectedIndex = -1;
                }

                if (reader["status"] != DBNull.Value)
                {
                    comboBoxStatus.SelectedItem = reader["status"].ToString();
                }
                else
                {
                    comboBoxStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load user.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
