using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Shared.Components;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class UpsertBiteCaseUserControl : UserControl, IModuleUpsertForm
    {
        private readonly MySqlConnectionHelper _connectionHelper;
        private ModuleRecordContext? _context;
        private int? _biteCaseId;
        private int? _patientId;
        private Image? _currentBiteChartImage;
        private string? _currentBiteChartPath;

        public UpsertBiteCaseUserControl()
        {
            InitializeComponent();
            _connectionHelper = new MySqlConnectionHelper();
        }

        public UpsertBiteCaseUserControl(int biteCaseId) : this()
        {
            _biteCaseId = biteCaseId;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UpsertBiteCaseUserControl_Load(object sender, EventArgs e)
        {
            LoadCategoryBasisMaster();
            InitializePanAndZoomPictureBox();
            LoadCollectionHelper();
            LoadComboBoxOptions();

            // Wire up save button
            saveButton.Click += SaveButton_Click;
            
            // Wire up browse button
        }

        public void LoadModuleRecord(ModuleRecordContext context)
        {
            _context = context;
            _biteCaseId = context.PrimaryKeyValue as int?;
            _patientId = context.Values.ContainsKey("patient_id") ? context.Values["patient_id"] as int? : null;
            
            if (_biteCaseId.HasValue)
            {
                LoadBiteCaseData(_biteCaseId.Value);
            }
        }

        private void LoadComboBoxOptions()
        {
            // Load animal types from database
            CollectionHelper.LoadComboBoxDistinct(comboBoxAnimalType, "bite_cases", "animal_type");
            CollectionHelper.LoadComboBoxDistinct(comboBoxWoundType, "bite_cases", "wound_type");
            CollectionHelper.LoadComboBoxDistinct(comboBoxWoundCount, "bite_cases", "wound_count");
            CollectionHelper.LoadComboBoxDistinct(comboBoxWoundClasification, "bite_cases", "wound_classification");
            CollectionHelper.LoadComboBoxDistinct(comboBoxProphylaxisType, "bite_cases", "prophylaxis_type");
            //CollectionHelper.LoadComboBoxDistinct(comboBoxBrand, "bite_cases", "prophylaxis_type"); // Re-use for brand
            CollectionHelper.LoadTextBoxSuggestions(
textBoxIncidentPlace,
"bite_cases",
"incident_place");
            CollectionHelper.LoadDataGridViewTextBoxSuggestions(
    chronicDGV,
    "ChronicIllnessColumn",     // DataGridView column name
    "chronic_illnesses",      // database table
    "illness_name"      // database column
);
            CollectionHelper.LoadDataGridViewTextBoxSuggestions(
    PEDGV,
    "peColumn",     // DataGridView column name
    "patient_symptoms",      // database table
    "symptom_name"      // database column
);
        }

        private void LoadCollectionHelper()
        {

        }

        private void InitializePanAndZoomPictureBox()
        {
            try
            {
                // Load a default anatomy image for the pan and zoom picture box
                // You can change this path to your actual anatomy image
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "anatomy_diagram.png");

                if (File.Exists(imagePath))
                {
                    Image anatomyImage = Image.FromFile(imagePath);
                    panAndZoomPictureBoxBiteChart.SetImage(anatomyImage);
                }
                else
                {
                    // If the image doesn't exist, create a simple placeholder
                    Bitmap placeholder = new Bitmap(700, 577);
                    using (Graphics g = Graphics.FromImage(placeholder))
                    {
                        g.Clear(Color.White);
                        g.DrawString("Anatomy Diagram Image Not Found",
                            new Font("Arial", 12), Brushes.Gray, 10, 10);
                        g.DrawString("Place your anatomy image at: " + imagePath,
                            new Font("Arial", 10), Brushes.Gray, 10, 30);
                    }
                    panAndZoomPictureBoxBiteChart.SetImage(placeholder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading anatomy image: {ex.Message}",
                    "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadCategoryBasisMaster()
        {
            flowLayoutPanelCategoryI.Controls.Clear();
            flowLayoutPanelCategoryIII.Controls.Clear();
            flowLayoutPanelCategoryII.Controls.Clear();

            try
            {
                using var connection =
                    new ABMS_2026.Data.MySql.MySqlConnectionHelper()
                    .GetConnection();

                connection.Open();

                string query = @"
            SELECT
                basis_id,
                exposure_category,
                basis_description
            FROM category_basis_master
            ORDER BY exposure_category, basis_id";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CheckBox checkBox = new CheckBox
                    {
                        AutoSize = false,
                        Width = flowLayoutPanelCategoryI.ClientSize.Width - 20,
                        Text = reader["basis_description"].ToString(),
                        Tag = Convert.ToInt32(reader["basis_id"]),
                        Margin = new Padding(5)
                    };

                    Size textSize = TextRenderer.MeasureText(
                        checkBox.Text,
                        checkBox.Font,
                        new Size(checkBox.Width - 20, int.MaxValue),
                        TextFormatFlags.WordBreak);

                    checkBox.Height = textSize.Height + 5;

                    string category =
                        reader["exposure_category"].ToString() ?? "";

                    switch (category)
                    {
                        case "I":
                            flowLayoutPanelCategoryI.Controls.Add(checkBox);
                            break;

                        case "II":
                            flowLayoutPanelCategoryIII.Controls.Add(checkBox);
                            break;

                        case "III":
                            flowLayoutPanelCategoryII.Controls.Add(checkBox);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void checkBoxCategoryI3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UpdateExposure(string _selectedExposure)
        {
            if (_selectedExposure == "I")
            {
                flowLayoutPanelCategoryI.Enabled = true;
                flowLayoutPanelCategoryII.Enabled = false;
                flowLayoutPanelCategoryIII.Enabled = false;

            }
            else if (_selectedExposure == "II")
            {
                flowLayoutPanelCategoryI.Enabled = false;
                flowLayoutPanelCategoryII.Enabled = true;
                flowLayoutPanelCategoryIII.Enabled = false;
            }
            else if (_selectedExposure == "III")
            {
                flowLayoutPanelCategoryI.Enabled = false;
                flowLayoutPanelCategoryII.Enabled = false;
                flowLayoutPanelCategoryIII.Enabled = true;
            }

        }

        private void tableLayoutPanelExposureAnimal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelCategoryI_Click(object sender, EventArgs e)
        {
                        UpdateExposure("I");
        }

        private void labelCategoryII_Click(object sender, EventArgs e)
        {
            UpdateExposure("II");
        }

        private void labelCategoryIII_Click(object sender, EventArgs e)
        {
            UpdateExposure("III");
        }

        private void ButtonBrowseBiteChart_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Bite Chart Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _currentBiteChartImage = Image.FromFile(openFileDialog.FileName);
                    panAndZoomPictureBoxBiteChart.SetImage(_currentBiteChartImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Image Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string SaveBiteChartImage(int biteCaseId)
        {
            try
            {
                // Get the current image from the picture box (edited state)
                Image? currentImage = panAndZoomPictureBoxBiteChart.GetImage();
                
                if (currentImage == null)
                {
                    // If no image in picture box and we're updating, keep the existing path
                    return _currentBiteChartPath ?? string.Empty;
                }

                // Create directory structure: upload/bite_case_id/
                string baseDirectory = Application.StartupPath;
                string uploadDirectory = Path.Combine(baseDirectory, "upload");
                string biteCaseDirectory = Path.Combine(uploadDirectory, biteCaseId.ToString());

                // Create all directories if they don't exist
                Directory.CreateDirectory(uploadDirectory);
                Directory.CreateDirectory(biteCaseDirectory);

                // Generate filename with datetime
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"bite_chart_{timestamp}.png";
                string filePath = Path.Combine(biteCaseDirectory, fileName);

                // Save the image
                currentImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                // Return relative path from base directory
                string relativePath = Path.Combine("upload", biteCaseId.ToString(), fileName);
                
                // Update current path
                _currentBiteChartPath = relativePath;
                
                return relativePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving bite chart image: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                using var transaction = connection.BeginTransaction();

                try
                {
                    int biteCaseId = SaveBiteCase(connection, transaction);
                    
                    // Save bite chart image after getting the bite case ID
                    string biteChartPath = SaveBiteChartImage(biteCaseId);
                    
                    // Update the bite case with the bite chart path
                    UpdateBiteCaseChartPath(connection, transaction, biteCaseId, biteChartPath);
                    
                    SaveCategoryBasis(connection, transaction, biteCaseId);
                    SaveChronicIllnesses(connection, transaction, biteCaseId);
                    SavePatientSymptoms(connection, transaction, biteCaseId);

                    transaction.Commit();

                    _biteCaseId = biteCaseId;
                    MessageBox.Show("Bite case saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optionally close the parent form
                    var parentForm = this.FindForm();
                    parentForm?.DialogResult = DialogResult.OK;
                    parentForm?.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving bite case: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (_patientId == null)
            {
                MessageBox.Show("Patient ID is required. Please select a patient first.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxAnimalType.Text))
            {
                MessageBox.Show("Animal type is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateTimePickerExposureDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Exposure date is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private int SaveBiteCase(MySqlConnection connection, MySqlTransaction transaction)
        {
            string sql;

            if (_biteCaseId.HasValue)
            {
                // Update existing record
                sql = @"
UPDATE bite_cases SET
    patient_id = @patient_id,
    exposure_date = @exposure_date,
    incident_place = @incident_place,
    animal_type = @animal_type,
    animal_classification = @animal_classification,
    animal_status = @animal_status,
    is_wound_washed = @is_wound_washed,
    wound_type = @wound_type,
    wound_count = @wound_count,
    wound_classification = @wound_classification,
    bite_locations = @bite_locations,
    prophylaxis_type = @prophylaxis_type,
    history_present_illness = @history_present_illness,
    physical_examination = @physical_examination,
    diagnosis = @diagnosis,
    management = @management,
    doctor_name = @doctor_name
WHERE bite_case_id = @bite_case_id;";
            }
            else
            {
                // Insert new record
                sql = @"
INSERT INTO bite_cases (
    patient_id, exposure_date, incident_place, animal_type, animal_classification,
    animal_status, is_wound_washed, wound_type, wound_count, wound_classification,
    bite_locations, prophylaxis_type, history_present_illness, physical_examination,
    diagnosis, management, doctor_name
) VALUES (
    @patient_id, @exposure_date, @incident_place, @animal_type, @animal_classification,
    @animal_status, @is_wound_washed, @wound_type, @wound_count, @wound_classification,
    @bite_locations, @prophylaxis_type, @history_present_illness, @physical_examination,
    @diagnosis, @management, @doctor_name
);

SELECT LAST_INSERT_ID();";
            }

            using var cmd = new MySqlCommand(sql, connection, transaction);
            cmd.Parameters.AddWithValue("@patient_id", _patientId.Value);
            cmd.Parameters.AddWithValue("@exposure_date", dateTimePickerExposureDate.Value);
            cmd.Parameters.AddWithValue("@incident_place", textBoxIncidentPlace.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@animal_type", comboBoxAnimalType.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@animal_classification", comboBoxAnimalClassification.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@animal_status", comboBoxAnimalStatus.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@is_wound_washed", checkBoxWoundWashed.Checked);
            cmd.Parameters.AddWithValue("@wound_type", comboBoxWoundType.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@wound_count", comboBoxWoundCount.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@wound_classification", comboBoxWoundClasification.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@bite_locations", richTextBoxRemarks.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@prophylaxis_type", comboBoxProphylaxisType.Text?.Trim() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@history_present_illness", (object)DBNull.Value); // Will need corresponding UI field
            cmd.Parameters.AddWithValue("@physical_examination", (object)DBNull.Value); // Will need corresponding UI field
            cmd.Parameters.AddWithValue("@diagnosis", (object)DBNull.Value); // Will need corresponding UI field
            cmd.Parameters.AddWithValue("@management", (object)DBNull.Value); // Will need corresponding UI field
            cmd.Parameters.AddWithValue("@doctor_name", (object)DBNull.Value); // Will need corresponding UI field

            if (_biteCaseId.HasValue)
            {
                cmd.Parameters.AddWithValue("@bite_case_id", _biteCaseId.Value);
                cmd.ExecuteNonQuery();
                return _biteCaseId.Value;
            }
            else
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void UpdateBiteCaseChartPath(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId, string biteChartPath)
        {
            string sql = @"
UPDATE bite_cases 
SET bite_chart_path = @bite_chart_path 
WHERE bite_case_id = @bite_case_id;";

            using var cmd = new MySqlCommand(sql, connection, transaction);
            cmd.Parameters.AddWithValue("@bite_chart_path", string.IsNullOrWhiteSpace(biteChartPath) ? (object)DBNull.Value : biteChartPath);
            cmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
            cmd.ExecuteNonQuery();
        }

        private void SaveCategoryBasis(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            // Delete existing category basis for this bite case
            string deleteSql = "DELETE FROM bite_case_category_basis WHERE bite_case_id = @bite_case_id";
            using var deleteCmd = new MySqlCommand(deleteSql, connection, transaction);
            deleteCmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
            deleteCmd.ExecuteNonQuery();

            // Insert selected category basis
            var selectedCategories = new List<CheckBox>();
            selectedCategories.AddRange(flowLayoutPanelCategoryI.Controls.OfType<CheckBox>().Where(cb => cb.Checked));
            selectedCategories.AddRange(flowLayoutPanelCategoryII.Controls.OfType<CheckBox>().Where(cb => cb.Checked));
            selectedCategories.AddRange(flowLayoutPanelCategoryIII.Controls.OfType<CheckBox>().Where(cb => cb.Checked));

            foreach (var checkBox in selectedCategories)
            {
                if (checkBox.Tag is int basisId)
                {
                    string insertSql = @"
INSERT INTO bite_case_category_basis (bite_case_id, exposure_category_id)
VALUES (@bite_case_id, @exposure_category_id);";

                    using var insertCmd = new MySqlCommand(insertSql, connection, transaction);
                    insertCmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                    insertCmd.Parameters.AddWithValue("@exposure_category_id", basisId);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveChronicIllnesses(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            // Delete existing chronic illnesses for this bite case
            string deleteSql = "DELETE FROM chronic_illnesses WHERE bite_case_id = @bite_case_id";
            using var deleteCmd = new MySqlCommand(deleteSql, connection, transaction);
            deleteCmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
            deleteCmd.ExecuteNonQuery();

            // Insert chronic illnesses from DataGridView
            foreach (DataGridViewRow row in chronicDGV.Rows)
            {
                if (!row.IsNewRow && row.Cells["ChronicIllnessColumn"].Value != null)
                {
                    string illnessName = row.Cells["ChronicIllnessColumn"].Value.ToString()?.Trim();
                    if (!string.IsNullOrWhiteSpace(illnessName))
                    {
                        string insertSql = @"
INSERT INTO chronic_illnesses (bite_case_id, illness_name)
VALUES (@bite_case_id, @illness_name);";

                        using var insertCmd = new MySqlCommand(insertSql, connection, transaction);
                        insertCmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                        insertCmd.Parameters.AddWithValue("@illness_name", illnessName);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void SavePatientSymptoms(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            // Delete existing symptoms for this bite case
            string deleteSql = "DELETE FROM patient_symptoms WHERE bite_case_id = @bite_case_id";
            using var deleteCmd = new MySqlCommand(deleteSql, connection, transaction);
            deleteCmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
            deleteCmd.ExecuteNonQuery();

            // Insert symptoms from DataGridView
            foreach (DataGridViewRow row in PEDGV.Rows)
            {
                if (!row.IsNewRow && row.Cells["peColumn"].Value != null)
                {
                    string symptomName = row.Cells["peColumn"].Value.ToString()?.Trim();
                    if (!string.IsNullOrWhiteSpace(symptomName))
                    {
                        string insertSql = @"
INSERT INTO patient_symptoms (bite_case_id, symptom_name)
VALUES (@bite_case_id, @symptom_name);";

                        using var insertCmd = new MySqlCommand(insertSql, connection, transaction);
                        insertCmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                        insertCmd.Parameters.AddWithValue("@symptom_name", symptomName);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void LoadBiteCaseData(int biteCaseId)
        {
            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                // Load main bite case data using the view
                string sql = @"
SELECT
    bite_case_id, patient_id, exposure_date, incident_place, animal_type,
    animal_classification, animal_status, is_wound_washed, wound_type,
    wound_count, wound_classification, bite_locations, prophylaxis_type,
    history_present_illness, physical_examination, diagnosis, management,
    doctor_name, bite_chart_path, category_basis_ids, chronic_illness_ids, patient_symptom_ids
FROM v_bite_case_details
WHERE bite_case_id = @bite_case_id;";

                using var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _patientId = reader["patient_id"] as int?;
                    dateTimePickerExposureDate.Value = reader["exposure_date"] as DateTime? ?? DateTime.Now;
                    textBoxIncidentPlace.Text = reader["incident_place"]?.ToString() ?? string.Empty;
                    comboBoxAnimalType.Text = reader["animal_type"]?.ToString() ?? string.Empty;
                    comboBoxAnimalClassification.Text = reader["animal_classification"]?.ToString() ?? string.Empty;
                    comboBoxAnimalStatus.Text = reader["animal_status"]?.ToString() ?? string.Empty;
                    checkBoxWoundWashed.Checked = reader["is_wound_washed"] as bool? ?? false;
                    comboBoxWoundType.Text = reader["wound_type"]?.ToString() ?? string.Empty;
                    comboBoxWoundCount.Text = reader["wound_count"]?.ToString() ?? string.Empty;
                    comboBoxWoundClasification.Text = reader["wound_classification"]?.ToString() ?? string.Empty;
                    richTextBoxRemarks.Text = reader["bite_locations"]?.ToString() ?? string.Empty;
                    comboBoxProphylaxisType.Text = reader["prophylaxis_type"]?.ToString() ?? string.Empty;
                    
                    // Load bite chart if exists
                    string? biteChartPath = reader["bite_chart_path"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(biteChartPath))
                    {
                        LoadBiteChartImage(biteChartPath);
                    }
                }

                reader.Close();

                // Load category basis (still using the specific method for checkbox handling)
                LoadCategoryBasisData(connection, biteCaseId);

                // Load chronic illnesses (still using the specific method for DataGridView)
                LoadChronicIllnessesData(connection, biteCaseId);

                // Load patient symptoms (still using the specific method for DataGridView)
                LoadPatientSymptomsData(connection, biteCaseId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bite case data: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategoryBasisData(MySqlConnection connection, int biteCaseId)
        {
            string sql = @"
SELECT exposure_category_id
FROM bite_case_category_basis
WHERE bite_case_id = @bite_case_id;";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);

            using var reader = cmd.ExecuteReader();
            var selectedBasisIds = new List<int>();

            while (reader.Read())
            {
                selectedBasisIds.Add(Convert.ToInt32(reader["exposure_category_id"]));
            }

            reader.Close();

            // Check the corresponding checkboxes
            foreach (Control control in flowLayoutPanelCategoryI.Controls)
            {
                if (control is CheckBox cb && cb.Tag is int basisId)
                {
                    cb.Checked = selectedBasisIds.Contains(basisId);
                }
            }

            foreach (Control control in flowLayoutPanelCategoryII.Controls)
            {
                if (control is CheckBox cb && cb.Tag is int basisId)
                {
                    cb.Checked = selectedBasisIds.Contains(basisId);
                }
            }

            foreach (Control control in flowLayoutPanelCategoryIII.Controls)
            {
                if (control is CheckBox cb && cb.Tag is int basisId)
                {
                    cb.Checked = selectedBasisIds.Contains(basisId);
                }
            }
        }

        private void LoadChronicIllnessesData(MySqlConnection connection, int biteCaseId)
        {
            string sql = @"
SELECT illness_name
FROM chronic_illnesses
WHERE bite_case_id = @bite_case_id;";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);

            using var adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            chronicDGV.DataSource = table;
            chronicDGV.Columns.Clear();
            chronicDGV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ChronicIllnessColumn",
                HeaderText = "Chronic Illness",
            });

            foreach (DataRow row in table.Rows)
            {
                chronicDGV.Rows.Add(row["illness_name"]);
            }
        }

        private void LoadPatientSymptomsData(MySqlConnection connection, int biteCaseId)
        {
            string sql = @"
SELECT symptom_name
FROM patient_symptoms
WHERE bite_case_id = @bite_case_id;";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@bite_case_id", biteCaseId);

            using var adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            PEDGV.DataSource = table;
            PEDGV.Columns.Clear();
            PEDGV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "peColumn",
                HeaderText = "PE S/S/Sx",
            });

            foreach (DataRow row in table.Rows)
            {
                PEDGV.Rows.Add(row["symptom_name"]);
            }
        }

        private void LoadBiteChartImage(string biteChartPath)
        {
            try
            {
                // Construct full path from application base directory
                string fullPath = Path.Combine(Application.StartupPath, biteChartPath);
                
                if (File.Exists(fullPath))
                {
                    _currentBiteChartImage = Image.FromFile(fullPath);
                    _currentBiteChartPath = biteChartPath;
                    panAndZoomPictureBoxBiteChart.SetImage(_currentBiteChartImage);
                }
                else
                {
                    MessageBox.Show($"Bite chart image not found at: {fullPath}", "Image Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bite chart image: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
