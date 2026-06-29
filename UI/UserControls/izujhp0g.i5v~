using ABMS_2026.Common.Helpers;
using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class DoctorsOrdersUserControl : UserControl
    {
        private int? _doctorOrderId;
        private int _biteCaseId;
        private bool _isLoading;

        public DoctorsOrdersUserControl()
        {
            InitializeComponent();

            saveButton.Click += saveButton_Click;
            Load += DoctorsOrdersUserControl_Load;
        }

        public DoctorsOrdersUserControl(int biteCaseId, int? doctorOrderId = null) : this()
        {
            _biteCaseId = biteCaseId;
            _doctorOrderId = doctorOrderId;
        }

        private void DoctorsOrdersUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                _isLoading = true;

                LoadComboBoxOptions();

                if (_doctorOrderId.HasValue)
                {
                    LoadDoctorOrderData(_doctorOrderId.Value);
                }
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void LoadComboBoxOptions()
        {
            CollectionHelper.LoadComboBoxDistinct(
                comboBoxMedicationAntibiotic,
                "doctor_orders",
                "medication_antibiotic");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxMedicationNsaid,
                "doctor_orders",
                "medication_nsaid");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxMedicationOthers,
                "doctor_orders",
                "medication_others");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxDoctorName,
                "doctor_orders",
                "doctor_name");

            // Load ComboBox options for treatment details
            CollectionHelper.LoadComboBoxDistinct(
                comboBoxPrepDetails,
                "doctor_orders",
                "prep_details");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxErigDetails,
                "doctor_orders",
                "erig_details");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxHrigDetails,
                "doctor_orders",
                "hrig_details");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxTetanusToxoidDetails,
                "doctor_orders",
                "tetanus_toxoid_details");

            CollectionHelper.LoadComboBoxDistinct(
                comboBoxAntiTetanusSerumDetails,
                "doctor_orders",
                "anti_tetanus_serum_details");

            // Load RichTextBox suggestions for clinical assessment fields
            CollectionHelper.LoadRichTextBoxSuggestions(
                richTextBoxHistoryPresentIllness,
                "doctor_orders",
                "history_present_illness");

            CollectionHelper.LoadRichTextBoxSuggestions(
                richTextBoxPhysicalExamination,
                "doctor_orders",
                "physical_examination");

            CollectionHelper.LoadRichTextBoxSuggestions(
                richTextBoxDiagnosis,
                "doctor_orders",
                "diagnosis");

            CollectionHelper.LoadRichTextBoxSuggestions(
                richTextBoxManagement,
                "doctor_orders",
                "management");

            CollectionHelper.LoadRichTextBoxSuggestions(
                richTextBoxOtherManagement,
                "doctor_orders",
                "other_management");
        }

        private void LoadDoctorOrderData(int doctorOrderId)
        {
            const string sql = @"
SELECT
    doctor_order_id,
    bite_case_id,
    history_present_illness,
    physical_examination,
    diagnosis,
    management,
    other_management,
    medication_antibiotic,
    medication_nsaid,
    medication_others,
    is_pep,
    is_prep,
    prep_details,
    `is_erig`,
    erig_details,
    `is_hrig`,
    hrig_details,
    is_tetanus_diphtheria,
    is_tetanus_toxoid,
    tetanus_toxoid_details,
    is_anti_tetanus_serum,
    anti_tetanus_serum_details,
    doctor_name
FROM doctor_orders
WHERE doctor_order_id = @doctor_order_id
LIMIT 1;";

            try
            {
                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@doctor_order_id", doctorOrderId);

                using var reader = command.ExecuteReader();
                if (!reader.Read())
                    return;

                LoadDoctorOrderFields(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor order data: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctorOrderFields(MySqlDataReader reader)
        {
            richTextBoxHistoryPresentIllness.Text = reader["history_present_illness"]?.ToString() ?? string.Empty;
            richTextBoxPhysicalExamination.Text = reader["physical_examination"]?.ToString() ?? string.Empty;
            richTextBoxDiagnosis.Text = reader["diagnosis"]?.ToString() ?? string.Empty;
            richTextBoxManagement.Text = reader["management"]?.ToString() ?? string.Empty;
            richTextBoxOtherManagement.Text = reader["other_management"]?.ToString() ?? string.Empty;

            comboBoxMedicationAntibiotic.Text = reader["medication_antibiotic"]?.ToString() ?? string.Empty;
            comboBoxMedicationNsaid.Text = reader["medication_nsaid"]?.ToString() ?? string.Empty;
            comboBoxMedicationOthers.Text = reader["medication_others"]?.ToString() ?? string.Empty;

            checkBoxIsPep.Checked = reader["is_pep"] != DBNull.Value && Convert.ToBoolean(reader["is_pep"]);
            checkBoxIsPrep.Checked = reader["is_prep"] != DBNull.Value && Convert.ToBoolean(reader["is_prep"]);
            checkBoxIsErig.Checked = reader["is_erig"] != DBNull.Value && Convert.ToBoolean(reader["is_erig"]);
            checkBoxIsHrig.Checked = reader["is_hrig"] != DBNull.Value && Convert.ToBoolean(reader["is_hrig"]);
            checkBoxIsTetanusDiphtheria.Checked = reader["is_tetanus_diphtheria"] != DBNull.Value && Convert.ToBoolean(reader["is_tetanus_diphtheria"]);
            checkBoxIsTetanusToxoid.Checked = reader["is_tetanus_toxoid"] != DBNull.Value && Convert.ToBoolean(reader["is_tetanus_toxoid"]);
            checkBoxIsAntiTetanusSerum.Checked = reader["is_anti_tetanus_serum"] != DBNull.Value && Convert.ToBoolean(reader["is_anti_tetanus_serum"]);

            comboBoxPrepDetails.Text = reader["prep_details"]?.ToString() ?? string.Empty;
            comboBoxErigDetails.Text = reader["erig_details"]?.ToString() ?? string.Empty;
            comboBoxHrigDetails.Text = reader["hrig_details"]?.ToString() ?? string.Empty;
            comboBoxTetanusToxoidDetails.Text = reader["tetanus_toxoid_details"]?.ToString() ?? string.Empty;
            comboBoxAntiTetanusSerumDetails.Text = reader["anti_tetanus_serum_details"]?.ToString() ?? string.Empty;

            comboBoxDoctorName.Text = reader["doctor_name"]?.ToString() ?? string.Empty;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UpsertDoctorOrder();
        }

        private void UpsertDoctorOrder()
        {
            if (_biteCaseId <= 0)
            {
                MessageBox.Show("Bite Case ID is required before saving doctor orders.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var connection = new MySqlConnectionHelper().GetConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                int doctorOrderId = _doctorOrderId.HasValue
                    ? UpdateDoctorOrder(connection, transaction, _doctorOrderId.Value)
                    : InsertDoctorOrder(connection, transaction);

                transaction.Commit();

                _doctorOrderId = doctorOrderId;
                MessageBox.Show("Doctor orders saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private int InsertDoctorOrder(MySqlConnection connection, MySqlTransaction transaction)
        {
            const string sql = @"
INSERT INTO doctor_orders
(
    bite_case_id,
    history_present_illness,
    physical_examination,
    diagnosis,
    management,
    other_management,
    medication_antibiotic,
    medication_nsaid,
    medication_others,
    is_pep,
    is_prep,
    prep_details,
    `is_erig`,
    erig_details,
    `is_hrig`,
    hrig_details,
    is_tetanus_diphtheria,
    is_tetanus_toxoid,
    tetanus_toxoid_details,
    is_anti_tetanus_serum,
    anti_tetanus_serum_details,
    doctor_name
)
VALUES
(
    @bite_case_id,
    @history_present_illness,
    @physical_examination,
    @diagnosis,
    @management,
    @other_management,
    @medication_antibiotic,
    @medication_nsaid,
    @medication_others,
    @is_pep,
    @is_prep,
    @prep_details,
    @is_erig,
    @erig_details,
    @is_hrig,
    @hrig_details,
    @is_tetanus_diphtheria,
    @is_tetanus_toxoid,
    @tetanus_toxoid_details,
    @is_anti_tetanus_serum,
    @anti_tetanus_serum_details,
    @doctor_name
);
SELECT LAST_INSERT_ID();";

            using var command = new MySqlCommand(sql, connection, transaction);
            AddDoctorOrderParameters(command);
            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        private int UpdateDoctorOrder(MySqlConnection connection, MySqlTransaction transaction, int doctorOrderId)
        {
            const string sql = @"
UPDATE doctor_orders
SET
    history_present_illness = @history_present_illness,
    physical_examination = @physical_examination,
    diagnosis = @diagnosis,
    management = @management,
    other_management = @other_management,
    medication_antibiotic = @medication_antibiotic,
    medication_nsaid = @medication_nsaid,
    medication_others = @medication_others,
    is_pep = @is_pep,
    is_prep = @is_prep,
    prep_details = @prep_details,
    `is_erig` = @is_erig,
    erig_details = @erig_details,
    `is_hrig` = @is_hrig,
    hrig_details = @hrig_details,
    is_tetanus_diphtheria = @is_tetanus_diphtheria,
    is_tetanus_toxoid = @is_tetanus_toxoid,
    tetanus_toxoid_details = @tetanus_toxoid_details,
    is_anti_tetanus_serum = @is_anti_tetanus_serum,
    anti_tetanus_serum_details = @anti_tetanus_serum_details,
    doctor_name = @doctor_name
WHERE doctor_order_id = @doctor_order_id;";

            using var command = new MySqlCommand(sql, connection, transaction);
            AddDoctorOrderParameters(command);
            command.Parameters.AddWithValue("@doctor_order_id", doctorOrderId);
            command.ExecuteNonQuery();
            return doctorOrderId;
        }

        private void AddDoctorOrderParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);
            command.Parameters.AddWithValue("@history_present_illness", richTextBoxHistoryPresentIllness.Text.Trim());
            command.Parameters.AddWithValue("@physical_examination", richTextBoxPhysicalExamination.Text.Trim());
            command.Parameters.AddWithValue("@diagnosis", richTextBoxDiagnosis.Text.Trim());
            command.Parameters.AddWithValue("@management", richTextBoxManagement.Text.Trim());
            command.Parameters.AddWithValue("@other_management", richTextBoxOtherManagement.Text.Trim());
            command.Parameters.AddWithValue("@medication_antibiotic", GetComboText(comboBoxMedicationAntibiotic));
            command.Parameters.AddWithValue("@medication_nsaid", GetComboText(comboBoxMedicationNsaid));
            command.Parameters.AddWithValue("@medication_others", GetComboText(comboBoxMedicationOthers));
            command.Parameters.AddWithValue("@is_pep", checkBoxIsPep.Checked);
            command.Parameters.AddWithValue("@is_prep", checkBoxIsPrep.Checked);
            command.Parameters.AddWithValue("@prep_details", GetComboText(comboBoxPrepDetails));
            command.Parameters.AddWithValue("@is_erig", checkBoxIsErig.Checked);
            command.Parameters.AddWithValue("@erig_details", GetComboText(comboBoxErigDetails));
            command.Parameters.AddWithValue("@is_hrig", checkBoxIsHrig.Checked);
            command.Parameters.AddWithValue("@hrig_details", GetComboText(comboBoxHrigDetails));
            command.Parameters.AddWithValue("@is_tetanus_diphtheria", checkBoxIsTetanusDiphtheria.Checked);
            command.Parameters.AddWithValue("@is_tetanus_toxoid", checkBoxIsTetanusToxoid.Checked);
            command.Parameters.AddWithValue("@tetanus_toxoid_details", GetComboText(comboBoxTetanusToxoidDetails));
            command.Parameters.AddWithValue("@is_anti_tetanus_serum", checkBoxIsAntiTetanusSerum.Checked);
            command.Parameters.AddWithValue("@anti_tetanus_serum_details", GetComboText(comboBoxAntiTetanusSerumDetails));
            command.Parameters.AddWithValue("@doctor_name", GetComboText(comboBoxDoctorName));
        }

        private string GetComboText(ComboBox comboBox)
        {
            return comboBox.Text?.Trim() ?? string.Empty;
        }

        private string FormatToTitleCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var titleCasedWords = words.Select(word =>
            {
                if (string.IsNullOrEmpty(word))
                    return word;

                return char.ToUpper(word[0]) + word.Substring(1).ToLower();
            });

            return string.Join(" ", titleCasedWords);
        }
    }
}
