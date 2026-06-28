using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class BiteCaseDetailsUserControl : UserControl
    {
        private int? _biteCaseId;
        private int _patientId;
        private bool _isLoading;

        public event Action<int>? BiteCaseSaved;

        public BiteCaseDetailsUserControl()
        {
            InitializeComponent();

            Load += BiteCaseDetailsUserControl_Load;

            ConfigureEditablePanels();
        }

        public BiteCaseDetailsUserControl(int patientId, int? biteCaseId = null) : this()
        {
            _patientId = patientId;
            _biteCaseId = biteCaseId;
        }

        private void ConfigureEditablePanels()
        {
            flowLayoutPanelCategoryI.Enabled = true;
            flowLayoutPanelCategoryII.Enabled = true;
            flowLayoutPanelCategoryIII.Enabled = true;

            flowLayoutPanelCategoryI.AutoScroll = true;
            flowLayoutPanelCategoryII.AutoScroll = true;
            flowLayoutPanelCategoryIII.AutoScroll = true;

            PEDGV.AllowUserToAddRows = true;
            chronicDGV.AllowUserToAddRows = true;
        }

        private void BiteCaseDetailsUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                _isLoading = true;

                LoadComboBoxOptions();
                LoadCategoryBasisMaster();

                if (_biteCaseId.HasValue)
                {
                    LoadBiteCaseData(_biteCaseId.Value);
                    LoadBiteCategoryDetails(_biteCaseId.Value);
                }
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void LoadComboBoxOptions()
        {
            CollectionHelper.LoadComboBoxDistinct(comboBoxAnimalType, "bite_cases", "animal_type");
            CollectionHelper.LoadComboBoxDistinct(comboBoxWoundType, "bite_cases", "wound_type");
            CollectionHelper.LoadComboBoxDistinct(comboBoxWoundCount, "bite_cases", "wound_count");
            CollectionHelper.LoadComboBoxDistinct(comboBoxWoundClasification, "bite_cases", "wound_classification");
            CollectionHelper.LoadComboBoxDistinct(comboBoxBrand, "prophylaxis_history", "vaccine_brand");
            CollectionHelper.LoadRichTextBoxSuggestions(richTextBoxRemarks, "bite_cases", "remarks");
            CollectionHelper.LoadRichTextBoxSuggestions(richTextBoxProphylaxisHistoryRemarks, "prophylaxis_history", "consent_notes");

            CollectionHelper.LoadTextBoxSuggestions(
                textBoxIncidentPlace,
                "bite_cases",
                "incident_place");

            CollectionHelper.LoadDataGridViewTextBoxSuggestions(
                chronicDGV,
                "ChronicIllnessColumn",
                "chronic_illnesses",
                "illness_name");

            CollectionHelper.LoadDataGridViewTextBoxSuggestions(
                PEDGV,
                "peColumn",
                "patient_symptoms",
                "symptom_name");

            if (comboBoxAnimalClassification.Items.Count == 0)
                comboBoxAnimalClassification.Items.AddRange(new object[] { "Pet", "Stray", "Unknown" });

            if (comboBoxAnimalStatus.Items.Count == 0)
                comboBoxAnimalStatus.Items.AddRange(new object[] { "Alive", "Sick", "Dead", "Unknown" });

            if (comboBoxRoute.Items.Count == 0)
                comboBoxRoute.Items.AddRange(new object[] { "Intradermal", "Intramuscular" });
        }

        private void LoadCategoryBasisMaster()
        {
            flowLayoutPanelCategoryI.Controls.Clear();
            flowLayoutPanelCategoryII.Controls.Clear();
            flowLayoutPanelCategoryIII.Controls.Clear();

            try
            {
                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                const string query = @"
SELECT
    basis_id,
    exposure_category,
    basis_description
FROM category_basis_master
ORDER BY exposure_category, basis_id;";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int basisId = Convert.ToInt32(reader["basis_id"]);
                    string category = reader["exposure_category"]?.ToString()?.Trim().ToUpperInvariant() ?? string.Empty;
                    string description = reader["basis_description"]?.ToString() ?? string.Empty;

                    CheckBox checkBox = CreateBasisCheckBox(basisId, description);

                    switch (category)
                    {
                        case "I":
                        case "CATEGORY I":
                            flowLayoutPanelCategoryI.Controls.Add(checkBox);
                            break;

                        case "II":
                        case "CATEGORY II":
                            flowLayoutPanelCategoryII.Controls.Add(checkBox);
                            break;

                        case "III":
                        case "CATEGORY III":
                            flowLayoutPanelCategoryIII.Controls.Add(checkBox);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Category Basis Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CheckBox CreateBasisCheckBox(int basisId, string description)
        {
            var checkBox = new CheckBox
            {
                AutoSize = false,
                Width = 185,
                Height = 32,
                Text = description,
                Tag = basisId,
                Checked = false,
                Enabled = true,
                Margin = new Padding(6, 4, 6, 4)
            };

            Size textSize = TextRenderer.MeasureText(
                checkBox.Text,
                checkBox.Font,
                new Size(checkBox.Width - 20, int.MaxValue),
                TextFormatFlags.WordBreak);

            checkBox.Height = Math.Max(28, textSize.Height + 8);

            return checkBox;
        }

        private void LoadBiteCategoryDetails(int biteCaseId)
        {
            var selectedBasisIds = new HashSet<int>();

            const string sql = @"
SELECT exposure_category_id
FROM bite_case_category_basis
WHERE bite_case_id = @bite_case_id;";

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", biteCaseId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["exposure_category_id"] != DBNull.Value)
                    selectedBasisIds.Add(Convert.ToInt32(reader["exposure_category_id"]));
            }

            MarkSelectedBasis(flowLayoutPanelCategoryI, selectedBasisIds);
            MarkSelectedBasis(flowLayoutPanelCategoryII, selectedBasisIds);
            MarkSelectedBasis(flowLayoutPanelCategoryIII, selectedBasisIds);
        }

        private void MarkSelectedBasis(FlowLayoutPanel panel, HashSet<int> selectedBasisIds)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is CheckBox checkBox &&
                    checkBox.Tag != null &&
                    int.TryParse(checkBox.Tag.ToString(), out int basisId))
                {
                    checkBox.Checked = selectedBasisIds.Contains(basisId);
                }
            }
        }

        private void LoadBiteCaseData(int biteCaseId)
        {
            const string sql = @"
SELECT
    bite_case_id,
    patient_id,
    exposure_date,
    incident_place,
    animal_type,
    animal_classification,
    animal_status,
    is_wound_washed,
    wound_type,
    wound_count,
    wound_classification,
    bite_locations,
    created_at,
    bite_chart_path,
    remarks
FROM bite_cases
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", biteCaseId);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return;

            if (reader["exposure_date"] != DBNull.Value)
                dateTimePickerExposureDate.Value = Convert.ToDateTime(reader["exposure_date"]);

            textBoxIncidentPlace.Text = reader["incident_place"]?.ToString() ?? string.Empty;
            comboBoxAnimalType.Text = reader["animal_type"]?.ToString() ?? string.Empty;
            comboBoxAnimalClassification.Text = reader["animal_classification"]?.ToString() ?? string.Empty;
            comboBoxAnimalStatus.Text = reader["animal_status"]?.ToString() ?? string.Empty;
            checkBoxWoundWashed.Checked = reader["is_wound_washed"] != DBNull.Value && Convert.ToBoolean(reader["is_wound_washed"]);
            comboBoxWoundType.Text = reader["wound_type"]?.ToString() ?? string.Empty;
            comboBoxWoundCount.Text = reader["wound_count"]?.ToString() ?? string.Empty;
            comboBoxWoundClasification.Text = reader["wound_classification"]?.ToString() ?? string.Empty;
            richTextBoxRemarks.Text = reader["remarks"]?.ToString() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(reader["bite_chart_path"]?.ToString()))
            {
                string path = reader["bite_chart_path"].ToString();

                try
                {
                    if (File.Exists(path))
                    {
                        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        using var tempImage = Image.FromStream(fs);
                        anatomicalEditorUserControl1.AnatomicalImage = new Bitmap(tempImage);
                    }
                }
                catch
                {
                    // keep the default image if loading fails
                }
            }

            LoadSymptoms();
            LoadChronicIllnesses();
            LoadProphylaxisHistory();
        }

        private void LoadSymptoms()
        {
            PEDGV.Rows.Clear();

            if (!_biteCaseId.HasValue)
                return;

            const string sql = @"
SELECT symptom_name
FROM patient_symptoms
WHERE bite_case_id = @bite_case_id
ORDER BY symptom_id;";

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId.Value);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string value = reader["symptom_name"]?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                    PEDGV.Rows.Add(value);
            }
        }

        private void LoadChronicIllnesses()
        {
            chronicDGV.Rows.Clear();

            if (!_biteCaseId.HasValue)
                return;

            const string sql = @"
SELECT illness_name
FROM chronic_illnesses
WHERE bite_case_id = @bite_case_id
ORDER BY illness_id;";

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId.Value);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string value = reader["illness_name"]?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                    chronicDGV.Rows.Add(value);
            }
        }

        private void LoadProphylaxisHistory()
        {
            if (!_biteCaseId.HasValue)
                return;

            const string sql = @"
SELECT
    date_given,
    vaccine_brand,
    route,
    is_hrig_given,
    is_booster,
    pep_completed_date,
    consent_notes
FROM prophylaxis_history
WHERE bite_case_id = @bite_case_id
ORDER BY prophylaxis_history_id DESC
LIMIT 1;";

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId.Value);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return;

            if (reader["date_given"] != DBNull.Value)
                dateTimePickerDateGiven.Value = Convert.ToDateTime(reader["date_given"]);

            comboBoxBrand.Text = reader["vaccine_brand"]?.ToString() ?? string.Empty;
            comboBoxRoute.Text = reader["route"]?.ToString() ?? string.Empty;
            checkBoxIsHRIG.Checked = reader["is_hrig_given"] != DBNull.Value && Convert.ToBoolean(reader["is_hrig_given"]);
            checkBoxIsBooster.Checked = reader["is_booster"] != DBNull.Value && Convert.ToBoolean(reader["is_booster"]);

            if (reader["pep_completed_date"] != DBNull.Value)
                dateTimePickerDateCompleted.Value = Convert.ToDateTime(reader["pep_completed_date"]);

            richTextBoxProphylaxisHistoryRemarks.Text = reader["consent_notes"]?.ToString() ?? string.Empty;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UpsertBiteCase();
        }

        private void UpsertBiteCase()
        {
            if (_patientId <= 0)
            {
                MessageBox.Show("PatientId is required before saving a bite case.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                string biteChartPath = SaveAnnotatedChartImage();

                int biteCaseId = _biteCaseId.HasValue
                    ? UpdateBiteCase(connection, transaction, _biteCaseId.Value, biteChartPath)
                    : InsertBiteCase(connection, transaction, biteChartPath);

                UpsertCategoryBasis(connection, transaction, biteCaseId);
                UpsertSymptoms(connection, transaction, biteCaseId);
                UpsertChronicIllnesses(connection, transaction, biteCaseId);
                UpsertProphylaxisHistory(connection, transaction, biteCaseId);

                transaction.Commit();

                _biteCaseId = biteCaseId;
                MessageBox.Show("Bite case saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify parent form that bite case is saved
                BiteCaseSaved?.Invoke(biteCaseId);
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    // ignore rollback errors
                }

                MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int InsertBiteCase(MySqlConnection connection, MySqlTransaction transaction, string biteChartPath)
        {
            const string sql = @"
INSERT INTO bite_cases
(
    patient_id,
    exposure_date,
    incident_place,
    animal_type,
    animal_classification,
    animal_status,
    is_wound_washed,
    wound_type,
    wound_count,
    wound_classification,
    bite_locations,
    created_at,
    bite_chart_path,
    remarks
)
VALUES
(
    @patient_id,
    @exposure_date,
    @incident_place,
    @animal_type,
    @animal_classification,
    @animal_status,
    @is_wound_washed,
    @wound_type,
    @wound_count,
    @wound_classification,
    @bite_locations,
    NOW(),
    @bite_chart_path,
    @remarks
);
SELECT LAST_INSERT_ID();";

            using var command = new MySqlCommand(sql, connection, transaction);
            AddBiteCaseParameters(command, biteChartPath);

            object result = command.ExecuteScalar();
            int newBiteCaseId = Convert.ToInt32(result);

            // If image was saved to temp folder (0), move it to the correct folder
            if (!string.IsNullOrWhiteSpace(biteChartPath) && biteChartPath.Contains("bitecharts\\0\\"))
            {
                string newPath = MoveImageToCorrectFolder(biteChartPath, newBiteCaseId);
                if (!string.IsNullOrWhiteSpace(newPath))
                {
                    // Update the path in the database
                    string updateSql = "UPDATE bite_cases SET bite_chart_path = @bite_chart_path WHERE bite_case_id = @bite_case_id;";
                    using var updateCmd = new MySqlCommand(updateSql, connection, transaction);
                    updateCmd.Parameters.AddWithValue("@bite_chart_path", newPath);
                    updateCmd.Parameters.AddWithValue("@bite_case_id", newBiteCaseId);
                    updateCmd.ExecuteNonQuery();
                    return newBiteCaseId;
                }
            }

            return newBiteCaseId;
        }

        private string MoveImageToCorrectFolder(string oldPath, int biteCaseId)
        {
            try
            {
                string fileName = Path.GetFileName(oldPath);
                string newFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bitecharts", biteCaseId.ToString());
                Directory.CreateDirectory(newFolder);

                string newPath = Path.Combine(newFolder, fileName);

                if (File.Exists(oldPath))
                {
                    File.Move(oldPath, newPath);
                    return newPath;
                }
            }
            catch
            {
                // Return old path if move fails
            }
            return oldPath;
        }

        private int UpdateBiteCase(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId, string biteChartPath)
        {
            const string sql = @"
UPDATE bite_cases
SET
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
    bite_chart_path = @bite_chart_path,
    remarks = @remarks
WHERE bite_case_id = @bite_case_id;";

            using var command = new MySqlCommand(sql, connection, transaction);
            AddBiteCaseParameters(command, biteChartPath);
            command.Parameters.AddWithValue("@bite_case_id", biteCaseId);

            command.ExecuteNonQuery();
            return biteCaseId;
        }

        private void AddBiteCaseParameters(MySqlCommand command, string biteChartPath)
        {
            command.Parameters.AddWithValue("@patient_id", _patientId);
            command.Parameters.AddWithValue("@exposure_date", dateTimePickerExposureDate.Value.Date);
            command.Parameters.AddWithValue("@incident_place", FormatToTitleCase(textBoxIncidentPlace.Text.Trim()));
            command.Parameters.AddWithValue("@animal_type", FormatToTitleCase(GetComboText(comboBoxAnimalType)));
            command.Parameters.AddWithValue("@animal_classification", FormatToTitleCase(GetComboText(comboBoxAnimalClassification)));
            command.Parameters.AddWithValue("@animal_status", FormatToTitleCase(GetComboText(comboBoxAnimalStatus)));
            command.Parameters.AddWithValue("@is_wound_washed", checkBoxWoundWashed.Checked);
            command.Parameters.AddWithValue("@wound_type", FormatToTitleCase(GetComboText(comboBoxWoundType)));
            command.Parameters.AddWithValue("@wound_count", FormatToTitleCase(GetComboText(comboBoxWoundCount)));
            command.Parameters.AddWithValue("@wound_classification", FormatToTitleCase(GetComboText(comboBoxWoundClasification)));
            command.Parameters.AddWithValue("@bite_locations", SerializeBiteLocations());
            command.Parameters.AddWithValue("@bite_chart_path", string.IsNullOrWhiteSpace(biteChartPath) ? (object)DBNull.Value : biteChartPath);
            command.Parameters.AddWithValue("@remarks", richTextBoxRemarks.Text.Trim());
        }

        private void UpsertCategoryBasis(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            const string deleteSql = @"DELETE FROM bite_case_category_basis WHERE bite_case_id = @bite_case_id;";
            using (var deleteCommand = new MySqlCommand(deleteSql, connection, transaction))
            {
                deleteCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                deleteCommand.ExecuteNonQuery();
            }

            const string insertSql = @"
INSERT INTO bite_case_category_basis (bite_case_id, exposure_category_id)
VALUES (@bite_case_id, @exposure_category_id);";

            var selectedBasisIds = GetSelectedBasisIds();

            foreach (int basisId in selectedBasisIds)
            {
                using var insertCommand = new MySqlCommand(insertSql, connection, transaction);
                insertCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                insertCommand.Parameters.AddWithValue("@exposure_category_id", basisId);
                insertCommand.ExecuteNonQuery();
            }
        }

        private void UpsertSymptoms(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            const string deleteSql = @"DELETE FROM patient_symptoms WHERE bite_case_id = @bite_case_id;";
            using (var deleteCommand = new MySqlCommand(deleteSql, connection, transaction))
            {
                deleteCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                deleteCommand.ExecuteNonQuery();
            }

            const string insertSql = @"
INSERT INTO patient_symptoms (bite_case_id, symptom_name)
VALUES (@bite_case_id, @symptom_name);";

            foreach (string symptom in GetGridValues(PEDGV, "peColumn"))
            {
                using var insertCommand = new MySqlCommand(insertSql, connection, transaction);
                insertCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                insertCommand.Parameters.AddWithValue("@symptom_name", symptom);
                insertCommand.ExecuteNonQuery();
            }
        }

        private void UpsertChronicIllnesses(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            const string deleteSql = @"DELETE FROM chronic_illnesses WHERE bite_case_id = @bite_case_id;";
            using (var deleteCommand = new MySqlCommand(deleteSql, connection, transaction))
            {
                deleteCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                deleteCommand.ExecuteNonQuery();
            }

            const string insertSql = @"
INSERT INTO chronic_illnesses (bite_case_id, illness_name)
VALUES (@bite_case_id, @illness_name);";

            foreach (string illness in GetGridValues(chronicDGV, "ChronicIllnessColumn"))
            {
                using var insertCommand = new MySqlCommand(insertSql, connection, transaction);
                insertCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                insertCommand.Parameters.AddWithValue("@illness_name", illness);
                insertCommand.ExecuteNonQuery();
            }
        }

        private void UpsertProphylaxisHistory(MySqlConnection connection, MySqlTransaction transaction, int biteCaseId)
        {
            const string deleteSql = @"DELETE FROM prophylaxis_history WHERE bite_case_id = @bite_case_id;";
            using (var deleteCommand = new MySqlCommand(deleteSql, connection, transaction))
            {
                deleteCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
                deleteCommand.ExecuteNonQuery();
            }

            const string insertSql = @"
INSERT INTO prophylaxis_history
(
    bite_case_id,
    date_given,
    vaccine_brand,
    route,
    is_hrig_given,
    is_booster,
    pep_completed_date,
    consent_notes
)
VALUES
(
    @bite_case_id,
    @date_given,
    @vaccine_brand,
    @route,
    @is_hrig_given,
    @is_booster,
    @pep_completed_date,
    @consent_notes
);";

            using var insertCommand = new MySqlCommand(insertSql, connection, transaction);
            insertCommand.Parameters.AddWithValue("@bite_case_id", biteCaseId);
            insertCommand.Parameters.AddWithValue("@date_given", dateTimePickerDateGiven.Value.Date);
            insertCommand.Parameters.AddWithValue("@vaccine_brand", comboBoxBrand.Text.Trim());
            insertCommand.Parameters.AddWithValue("@route", string.IsNullOrWhiteSpace(comboBoxRoute.Text.Trim()) ? (object)DBNull.Value : comboBoxRoute.Text.Trim());
            insertCommand.Parameters.AddWithValue("@is_hrig_given", checkBoxIsHRIG.Checked);
            insertCommand.Parameters.AddWithValue("@is_booster", checkBoxIsBooster.Checked);
            insertCommand.Parameters.AddWithValue("@pep_completed_date", dateTimePickerDateCompleted.Value.Date);
            insertCommand.Parameters.AddWithValue("@consent_notes", richTextBoxProphylaxisHistoryRemarks.Text.Trim());

            insertCommand.ExecuteNonQuery();
        }

        private IEnumerable<int> GetSelectedBasisIds()
        {
            return flowLayoutPanelCategoryI.Controls
                .OfType<CheckBox>()
                .Concat(flowLayoutPanelCategoryII.Controls.OfType<CheckBox>())
                .Concat(flowLayoutPanelCategoryIII.Controls.OfType<CheckBox>())
                .Where(cb => cb.Checked && cb.Tag != null && int.TryParse(cb.Tag.ToString(), out _))
                .Select(cb => Convert.ToInt32(cb.Tag))
                .Distinct()
                .ToList();
        }

        private IEnumerable<string> GetGridValues(DataGridView dgv, string columnName)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object rawValue = row.Cells[columnName].Value;
                string value = rawValue?.ToString()?.Trim();

                if (!string.IsNullOrWhiteSpace(value))
                    yield return value;
            }
        }

        private string GetComboText(ComboBox comboBox)
        {
            return comboBox.Text?.Trim() ?? string.Empty;
        }

        private string FormatToTitleCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLowerInvariant());
        }

        private string SerializeBiteLocations()
        {
            try
            {
                var markers = anatomicalEditorUserControl1.Markers;
                if (markers == null || markers.Count == 0)
                    return string.Empty;

                return string.Join(";", markers.Select(m => $"{m.X:0.##},{m.Y:0.##}"));
            }
            catch
            {
                return string.Empty;
            }
        }

        private string SaveAnnotatedChartImage()
        {
            try
            {
                using var bitmap = anatomicalEditorUserControl1.ExportAnnotatedImage();
                if (bitmap == null)
                    return null;

                // Use bite case ID if available, otherwise use temp
                int biteCaseId = _biteCaseId ?? 0;
                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bitecharts", biteCaseId.ToString());
                Directory.CreateDirectory(folder);

                string fileName = $"bite_chart_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
                string fullPath = Path.Combine(folder, fileName);

                bitmap.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                return fullPath;
            }
            catch
            {
                return null;
            }
        }
    }
}