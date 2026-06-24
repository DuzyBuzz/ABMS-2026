using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class PatientQueingUserControl : UserControl
    {
        private readonly MySqlConnectionHelper _connectionHelper;

        private DataTable _queueTable =
            new DataTable();

        private DateTime? _lastDatabaseUpdate;

        public PatientQueingUserControl()
        {
            InitializeComponent();

            _connectionHelper =
                new MySqlConnectionHelper();

            HookEvents();
        }

        private void HookEvents()
        {
            Load +=
                PatientQueingUserControl_Load;

            refreshButton.Click +=
                RefreshButton_Click;

            addQueueButton.Click +=
                AddQueueButton_Click;

            refreshTimer.Tick +=
                RefreshTimer_Tick;

            queueDataGridView.CellEndEdit +=
                QueueDataGridView_CellEndEdit;
        }

        private void PatientQueingUserControl_Load(
            object sender,
            EventArgs e)
        {
            LoadQueues();

            refreshTimer.Start();
        }

        private void RefreshButton_Click(
            object sender,
            EventArgs e)
        {
            LoadQueues();
        }

        private void RefreshTimer_Tick(
            object sender,
            EventArgs e)
        {
            CheckForChanges();
        }

        private void CheckForChanges()
        {
            try
            {
                using (var connection =
                    _connectionHelper.GetConnection())
                {
                    connection.Open();

                    const string sql = @"
SELECT MAX(updated_at)
FROM patient_queues;";

                    using (var command =
                        new MySqlCommand(
                            sql,
                            connection))
                    {
                        object result =
                            command.ExecuteScalar();

                        if (result == null ||
                            result == DBNull.Value)
                        {
                            return;
                        }

                        DateTime latest =
                            Convert.ToDateTime(
                                result);

                        if (!_lastDatabaseUpdate.HasValue)
                        {
                            _lastDatabaseUpdate =
                                latest;

                            return;
                        }

                        if (latest >
                            _lastDatabaseUpdate.Value)
                        {
                            LoadQueues();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void LoadQueues()
        {
            try
            {
                using (var connection =
                    _connectionHelper.GetConnection())
                {
                    connection.Open();

                    const string sql = @"
SELECT
    queue_id,
    queue_number,
    patient_name,
    queue_type,
    priority_level,
    queue_status,
    queue_date,
    updated_at
FROM vw_patient_queues
WHERE queue_date = CURDATE()
ORDER BY CAST(queue_number AS UNSIGNED);";

                    using (var adapter =
                        new MySqlDataAdapter(
                            sql,
                            connection))
                    {
                        _queueTable =
                            new DataTable();

                        adapter.Fill(
                            _queueTable);
                    }
                }

                queueDataGridView.DataSource =
                    _queueTable;

                FormatGrid();

                UpdateActiveQueueCount();

                if (_queueTable.Rows.Count > 0)
                {
                    foreach (DataRow row
                        in _queueTable.Rows)
                    {
                        if (row["updated_at"]
                            != DBNull.Value)
                        {
                            DateTime value =
                                Convert.ToDateTime(
                                    row["updated_at"]);

                            if (!_lastDatabaseUpdate.HasValue ||
                                value >
                                _lastDatabaseUpdate.Value)
                            {
                                _lastDatabaseUpdate =
                                    value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (queueDataGridView.Columns.Count == 0)
            {
                return;
            }

            queueDataGridView.Columns[
                "queue_id"]
                .Visible = false;

            queueDataGridView.Columns[
                "updated_at"]
                .Visible = false;

            queueDataGridView.Columns[
                "queue_number"]
                .HeaderText =
                "Queue No";

            queueDataGridView.Columns[
                "patient_name"]
                .HeaderText =
                "Patient";

            queueDataGridView.Columns[
                "queue_type"]
                .HeaderText =
                "Queue Type";

            queueDataGridView.Columns[
                "priority_level"]
                .HeaderText =
                "Priority";

            queueDataGridView.Columns[
                "queue_status"]
                .HeaderText =
                "Status";

            queueDataGridView.Columns[
                "queue_date"]
                .HeaderText =
                "Date";

            queueDataGridView.Columns[
                "patient_name"]
                .ReadOnly = true;

            queueDataGridView.Columns[
                "queue_status"]
                .ReadOnly = true;

            queueDataGridView.Columns[
                "queue_date"]
                .ReadOnly = true;
        }

        private void UpdateActiveQueueCount()
        {
            int count = 0;

            foreach (DataRow row
                in _queueTable.Rows)
            {
                string status =
                    row["queue_status"]
                    .ToString();

                if (status == "Waiting" ||
                    status == "Serving")
                {
                    count++;
                }
            }

            activeQueueLabel.Text =
                $"Active Queue: {count}";
        }

        private void AddQueueButton_Click(
            object sender,
            EventArgs e)
        {
            using (var picker =
                new PatientPickerForm())
            {
                if (picker.ShowDialog()
                    != DialogResult.OK)
                {
                    return;
                }

                if (PatientAlreadyQueued(
                    picker.SelectedPatientId))
                {
                    MessageBox.Show(
                        "Patient already has an active queue.",
                        "Queue",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                AddQueue(
                    picker.SelectedPatientId);
            }
        }

        private bool PatientAlreadyQueued(
            int patientId)
        {
            using (var connection =
                _connectionHelper.GetConnection())
            {
                connection.Open();

                const string sql = @"
SELECT COUNT(*)
FROM patient_queues
WHERE patient_id = @patient_id
AND queue_date = CURDATE()
AND queue_status IN
(
'Waiting',
'Serving'
);";

                using (var command =
                    new MySqlCommand(
                        sql,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@patient_id",
                        patientId);

                    return Convert.ToInt32(
                        command.ExecuteScalar())
                        > 0;
                }
            }
        }

        private void AddQueue(
            int patientId)
        {
            using (var connection =
                _connectionHelper.GetConnection())
            {
                connection.Open();

                string queueNumber =
                    GetNextQueueNumber(
                        connection);

                const string sql = @"
INSERT INTO patient_queues
(
    queue_number,
    patient_id,
    queue_date
)
VALUES
(
    @queue_number,
    @patient_id,
    CURDATE()
);";

                using (var command =
                    new MySqlCommand(
                        sql,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@queue_number",
                        queueNumber);

                    command.Parameters.AddWithValue(
                        "@patient_id",
                        patientId);

                    command.ExecuteNonQuery();
                }
            }

            LoadQueues();
        }

        private string GetNextQueueNumber(
            MySqlConnection connection)
        {
            const string sql = @"
SELECT IFNULL(
MAX(
CAST(queue_number AS UNSIGNED)
),0) + 1
FROM patient_queues
WHERE queue_date = CURDATE();";

            using (var command =
                new MySqlCommand(
                    sql,
                    connection))
            {
                return command
                    .ExecuteScalar()
                    .ToString();
            }
        }

        private void QueueDataGridView_CellEndEdit(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row =
                    queueDataGridView.Rows[
                        e.RowIndex];

                int queueId =
                    Convert.ToInt32(
                        row.Cells[
                            "queue_id"]
                        .Value);

                string queueNumber =
                    row.Cells[
                        "queue_number"]
                    .Value
                    ?.ToString();

                string queueType =
                    row.Cells[
                        "queue_type"]
                    .Value
                    ?.ToString();

                string priorityLevel =
                    row.Cells[
                        "priority_level"]
                    .Value
                    ?.ToString();

                using (var connection =
                    _connectionHelper.GetConnection())
                {
                    connection.Open();

                    const string sql = @"
UPDATE patient_queues
SET
    queue_number = @queue_number,
    queue_type = @queue_type,
    priority_level = @priority_level
WHERE queue_id = @queue_id;";

                    using (var command =
                        new MySqlCommand(
                            sql,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@queue_number",
                            queueNumber);

                        command.Parameters.AddWithValue(
                            "@queue_type",
                            queueType);

                        command.Parameters.AddWithValue(
                            "@priority_level",
                            priorityLevel);

                        command.Parameters.AddWithValue(
                            "@queue_id",
                            queueId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Queue Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}