using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Shared.Components;
using ENT_Clinic_System.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    public partial class PatientProfileForm : Form
    {
        private int? _patientId;
        private byte[]? _imageBytes;
        private bool _loadedViaInterface = false;
        private bool _imageChanged = false;

        public PatientProfileForm()
        {
            InitializeComponent();
            _patientId = null;
        }

        public PatientProfileForm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void weightLabel_Click(object sender, EventArgs e)
        {
        }

        private void PatientProfileForm_Load(object sender, EventArgs e)
        {
            CollectionHelper.LoadTextBoxSuggestions(
                addressTextBox,
                "patients",
                "address");

            birthDateDateTimePicker.MaxDate = DateTime.Today;
            birthDateDateTimePicker.ValueChanged += birthDateDateTimePicker_ValueChanged;

            ageTextBox.ReadOnly = true;
            weightNumericUpDown.Maximum = 500;

            // Only load if not already loaded via LoadModuleRecord
            if (!_loadedViaInterface)
            {
                if (_patientId.HasValue)
                {
                    LoadPatient(_patientId.Value);
                }
                else
                {
                    ClearForm();
                }
            }
        }

        private void birthDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ageTextBox.Text = CalculateAge(birthDateDateTimePicker.Value.Date).ToString();
        }

        private void cameraCaptureButton_Click(object sender, EventArgs e)
        {
            // --- Option 1: Capture from camera ---
            using (PatientCamera cameraForm = new PatientCamera())
            {
                if (cameraForm.ShowDialog() == DialogResult.OK)
                {
                    if (cameraForm.CapturedImage is not null)
                    {
                        // Dispose old image
                        patientPictureBox.Image?.Dispose();

                        // Set new image
                        patientPictureBox.Image = cameraForm.CapturedImage;

                        // Convert image to bytes for saving
                        using MemoryStream ms = new MemoryStream();
                        cameraForm.CapturedImage.Save(ms, ImageFormat.Jpeg);
                        _imageBytes = ms.ToArray();
                        _imageChanged = true;
                    }
                    else
                    {
                        MessageBox.Show("No image was captured from the camera.",
                                        "Capture Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void browseImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                byte[] bytes = File.ReadAllBytes(openFileDialog1.FileName);
                using MemoryStream ms = new MemoryStream(bytes);
                using Image tempImage = Image.FromStream(ms);

                _imageBytes = bytes;
                _imageChanged = true;

                if (patientPictureBox.Image != null)
                {
                    Image oldImage = patientPictureBox.Image;
                    patientPictureBox.Image = null;
                    oldImage.Dispose();
                }

                patientPictureBox.Image = new Bitmap(tempImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load image.\n\n" + ex.Message,
                    "Image Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void removeImageButton_Click(object sender, EventArgs e)
        {
            _imageBytes = null;
            _imageChanged = true;

            if (patientPictureBox.Image != null)
            {
                Image oldImage = patientPictureBox.Image;
                patientPictureBox.Image = null;
                oldImage.Dispose();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            if (_patientId.HasValue)
            {
                UpdatePatient();
            }
            else
            {
                InsertPatient();
            }
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void FormatToTitleCase(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return;

            textBox.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBox.Text.ToLowerInvariant());
        }

        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            FormatToTitleCase(lastNameTextBox);
        }

        private void firstNameTextBox_Leave(object sender, EventArgs e)
        {
            FormatToTitleCase(firstNameTextBox);
        }

        private void middleNameTextBox_Leave(object sender, EventArgs e)
        {
            FormatToTitleCase(middleNameTextBox);
        }

        private void addressTextBox_Leave(object sender, EventArgs e)
        {
            FormatToTitleCase(addressTextBox);
        }

        private void ClearForm()
        {
            lastNameTextBox.Clear();
            firstNameTextBox.Clear();
            middleNameTextBox.Clear();
            addressTextBox.Clear();
            contactNoTextBox.Clear();
            ageTextBox.Clear();

            sexComboBox.SelectedIndex = -1;
            civilStatusComboBox.SelectedIndex = -1;

            birthDateDateTimePicker.Value = DateTime.Today.AddYears(-20);
            weightNumericUpDown.Value = 0;

            _imageBytes = null;
            _imageChanged = false;

            if (patientPictureBox.Image != null)
            {
                Image oldImage = patientPictureBox.Image;
                patientPictureBox.Image = null;
                oldImage.Dispose();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lastNameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                MessageBox.Show("First Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firstNameTextBox.Focus();
                return false;
            }

            if (birthDateDateTimePicker.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Birth date cannot be in the future.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                birthDateDateTimePicker.Focus();
                return false;
            }

            if (sexComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Sex is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sexComboBox.Focus();
                return false;
            }

            if (civilStatusComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Civil status is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                civilStatusComboBox.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(contactNoTextBox.Text))
            {
                string contact = contactNoTextBox.Text.Trim();
                foreach (char c in contact)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '-' && c != ' ' && c != '(' && c != ')')
                    {
                        MessageBox.Show("Contact number contains invalid characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        contactNoTextBox.Focus();
                        return false;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(ageTextBox.Text))
            {
                if (!int.TryParse(ageTextBox.Text.Trim(), out int parsedAge) || parsedAge < 0 || parsedAge > 150)
                {
                    MessageBox.Show("Age is invalid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ageTextBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return Math.Max(age, 0);
        }

        private void InsertPatient()
        {
            try
            {
                using MySqlConnection connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                const string sql = @"
INSERT INTO patients
(
    last_name,
    first_name,
    middle_name,
    birth_date,
    age,
    sex,
    civil_status,
    address,
    contact_no,
    weight,
    image
)
VALUES
(
    @last_name,
    @first_name,
    @middle_name,
    @birth_date,
    @age,
    @sex,
    @civil_status,
    @address,
    @contact_no,
    @weight,
    @image
);";

                using MySqlCommand command = new MySqlCommand(sql, connection);
                AddParameters(command);

                command.ExecuteNonQuery();

                MessageBox.Show("Patient saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save patient.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePatient()
        {
            if (!_patientId.HasValue)
            {
                MessageBox.Show("Patient ID is required for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using MySqlConnection connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                string sql;

                if (_imageChanged)
                {
                    sql = @"
UPDATE patients
SET
    last_name = @last_name,
    first_name = @first_name,
    middle_name = @middle_name,
    birth_date = @birth_date,
    age = @age,
    sex = @sex,
    civil_status = @civil_status,
    address = @address,
    contact_no = @contact_no,
    weight = @weight,
    image = @image
WHERE patient_id = @patient_id;";
                }
                else
                {
                    sql = @"
UPDATE patients
SET
    last_name = @last_name,
    first_name = @first_name,
    middle_name = @middle_name,
    birth_date = @birth_date,
    age = @age,
    sex = @sex,
    civil_status = @civil_status,
    address = @address,
    contact_no = @contact_no,
    weight = @weight
WHERE patient_id = @patient_id;";
                }

                using MySqlCommand command = new MySqlCommand(sql, connection);
                AddParameters(command, _imageChanged);
                command.Parameters.AddWithValue("@patient_id", _patientId.Value);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Patient updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _imageChanged = false;
                }
                else
                {
                    MessageBox.Show("No record was updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update patient.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddParameters(MySqlCommand command, bool includeImage = true)
        {
            command.Parameters.AddWithValue("@last_name", lastNameTextBox.Text.Trim());
            command.Parameters.AddWithValue("@first_name", firstNameTextBox.Text.Trim());
            command.Parameters.AddWithValue("@middle_name", string.IsNullOrWhiteSpace(middleNameTextBox.Text) ? DBNull.Value : middleNameTextBox.Text.Trim());
            command.Parameters.AddWithValue("@birth_date", birthDateDateTimePicker.Value.Date);
            command.Parameters.AddWithValue("@age", CalculateAge(birthDateDateTimePicker.Value.Date));
            command.Parameters.AddWithValue("@sex", sexComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@civil_status", civilStatusComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(addressTextBox.Text) ? DBNull.Value : addressTextBox.Text.Trim());
            command.Parameters.AddWithValue("@contact_no", string.IsNullOrWhiteSpace(contactNoTextBox.Text) ? DBNull.Value : contactNoTextBox.Text.Trim());

            if (weightNumericUpDown.Value <= 0)
            {
                command.Parameters.AddWithValue("@weight", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@weight", weightNumericUpDown.Value);
            }

            if (includeImage)
            {
                command.Parameters.AddWithValue("@image", _imageBytes == null ? DBNull.Value : _imageBytes);
            }
        }

        private void LoadPatient(int patientId)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                const string sql = @"
SELECT
    patient_id,
    last_name,
    first_name,
    middle_name,
    birth_date,
    age,
    sex,
    civil_status,
    address,
    contact_no,
    weight,
    image
FROM patients
WHERE patient_id = @patient_id
LIMIT 1;";

                using MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@patient_id", patientId);

                using MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Patient record not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lastNameTextBox.Text = reader["last_name"]?.ToString();
                firstNameTextBox.Text = reader["first_name"]?.ToString();
                middleNameTextBox.Text = reader["middle_name"] == DBNull.Value ? string.Empty : reader["middle_name"].ToString();

                if (reader["birth_date"] != DBNull.Value)
                {
                    DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                    birthDateDateTimePicker.Value = birthDate;
                    ageTextBox.Text = CalculateAge(birthDate).ToString();
                }
                else
                {
                    ageTextBox.Text = reader["age"] == DBNull.Value ? string.Empty : reader["age"].ToString();
                }

                if (reader["sex"] != DBNull.Value)
                {
                    sexComboBox.SelectedItem = reader["sex"].ToString();
                }
                else
                {
                    sexComboBox.SelectedIndex = -1;
                }

                if (reader["civil_status"] != DBNull.Value)
                {
                    civilStatusComboBox.SelectedItem = reader["civil_status"].ToString();
                }
                else
                {
                    civilStatusComboBox.SelectedIndex = -1;
                }

                addressTextBox.Text = reader["address"] == DBNull.Value ? string.Empty : reader["address"].ToString();
                contactNoTextBox.Text = reader["contact_no"] == DBNull.Value ? string.Empty : reader["contact_no"].ToString();

                if (reader["weight"] != DBNull.Value)
                {
                    decimal w = Convert.ToDecimal(reader["weight"]);
                    if (w < weightNumericUpDown.Minimum) w = weightNumericUpDown.Minimum;
                    if (w > weightNumericUpDown.Maximum) w = weightNumericUpDown.Maximum;
                    weightNumericUpDown.Value = w;
                }
                else
                {
                    weightNumericUpDown.Value = 0;
                }

                if (reader["image"] != DBNull.Value)
                {
                    _imageBytes = (byte[])reader["image"];
                    SetPatientImage(_imageBytes);
                }
                else
                {
                    _imageBytes = null;

                    if (patientPictureBox.Image != null)
                    {
                        Image oldImage = patientPictureBox.Image;
                        patientPictureBox.Image = null;
                        oldImage.Dispose();
                    }
                }

                _imageChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load patient.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPatientImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return;
            }

            using MemoryStream ms = new MemoryStream(imageBytes);
            using Image tempImage = Image.FromStream(ms);

            if (patientPictureBox.Image != null)
            {
                Image oldImage = patientPictureBox.Image;
                patientPictureBox.Image = null;
                oldImage.Dispose();
            }

            patientPictureBox.Image = new Bitmap(tempImage);
        }

        public void LoadModuleRecord(ModuleRecordContext context)
        {
            _loadedViaInterface = true;

            if (context.PrimaryKeyValue != null)
            {
                _patientId = Convert.ToInt32(context.PrimaryKeyValue);
                LoadPatient(_patientId.Value);
            }
            else
            {
                ClearForm();
            }
        }
    }
}