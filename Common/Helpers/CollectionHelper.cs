using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace ABMS_2026.Common.Helpers
{
    public static class CollectionHelper
    {
        public static void LoadComboBoxDistinct(
            ComboBox comboBox,
            string tableName,
            string columnName,
            bool addEmptyItem = true)
        {
            try
            {
                comboBox.BeginUpdate();

                comboBox.Items.Clear();

                if (addEmptyItem)
                {
                    comboBox.Items.Add(string.Empty);
                }

                using var connection =
                    new MySqlConnectionHelper().GetConnection();

                connection.Open();

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
WHERE {columnName} IS NOT NULL
AND {columnName} <> ''
ORDER BY {columnName};";

                using var command =
                    new MySqlCommand(query, connection);

                using var reader =
                    command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(
                        reader[columnName].ToString());
                }

                comboBox.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load ComboBox",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void LoadTextBoxSuggestions(
            TextBox textBox,
            string tableName,
            string columnName)
        {
            try
            {
                AutoCompleteStringCollection collection =
                    new AutoCompleteStringCollection();

                using var connection =
                    new MySqlConnectionHelper().GetConnection();

                connection.Open();

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
WHERE {columnName} IS NOT NULL
AND {columnName} <> ''
ORDER BY {columnName};";

                using var command =
                    new MySqlCommand(query, connection);

                using var reader =
                    command.ExecuteReader();

                while (reader.Read())
                {
                    collection.Add(
                        reader[columnName].ToString());
                }

                textBox.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;

                textBox.AutoCompleteSource =
                    AutoCompleteSource.CustomSource;

                textBox.AutoCompleteCustomSource =
                    collection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load Suggestions",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void LoadDataGridViewComboBoxDistinct(
            DataGridViewComboBoxColumn comboBoxColumn,
            string tableName,
            string columnName,
            bool addEmptyItem = true)
        {
            try
            {
                comboBoxColumn.Items.Clear();

                if (addEmptyItem)
                {
                    comboBoxColumn.Items.Add(string.Empty);
                }

                using var connection =
                    new MySqlConnectionHelper().GetConnection();

                connection.Open();

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
WHERE {columnName} IS NOT NULL
AND {columnName} <> ''
ORDER BY {columnName};";

                using var command =
                    new MySqlCommand(query, connection);

                using var reader =
                    command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxColumn.Items.Add(
                        reader[columnName].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load DataGridView ComboBox",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void LoadDataGridViewComboBoxDistinct(
            DataGridView dataGridView,
            string columnName,
            string tableName,
            string sourceColumnName,
            bool addEmptyItem = true)
        {
            try
            {
                // Find the column by name
                DataGridViewColumn? column = dataGridView.Columns[columnName];
                if (column == null)
                {
                    MessageBox.Show(
                        $"Column '{columnName}' not found in DataGridView.",
                        "Column Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (column is DataGridViewComboBoxColumn comboBoxColumn)
                {
                    LoadDataGridViewComboBoxDistinct(
                        comboBoxColumn,
                        tableName,
                        sourceColumnName,
                        addEmptyItem);
                }
                else
                {
                    MessageBox.Show(
                        $"Column '{columnName}' is not a DataGridViewComboBoxColumn.",
                        "Invalid Column Type",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load DataGridView ComboBox",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void SetupDataGridViewTextBoxSuggestions(
            DataGridView dataGridView,
            string columnName,
            string tableName,
            string sourceColumnName)
        {
            try
            {
                // Find the column by name
                DataGridViewColumn? column = dataGridView.Columns[columnName];
                if (column == null)
                {
                    MessageBox.Show(
                        $"Column '{columnName}' not found in DataGridView.",
                        "Column Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (column is DataGridViewTextBoxColumn textBoxColumn)
                {
                    // Load suggestions from database
                    AutoCompleteStringCollection collection =
                        new AutoCompleteStringCollection();

                    using var connection =
                        new MySqlConnectionHelper().GetConnection();

                    connection.Open();

                    string query = $@"
SELECT DISTINCT {sourceColumnName}
FROM {tableName}
WHERE {sourceColumnName} IS NOT NULL
AND {sourceColumnName} <> ''
ORDER BY {sourceColumnName};";

                    using var command =
                        new MySqlCommand(query, connection);

                    using var reader =
                        command.ExecuteReader();

                    while (reader.Read())
                    {
                        collection.Add(
                            reader[sourceColumnName].ToString());
                    }

                    // Subscribe to the EditingControlShowing event
                    dataGridView.EditingControlShowing -= DataGridView_EditingControlShowing;
                    dataGridView.EditingControlShowing += (sender, e) =>
                    {
                        if (dataGridView.CurrentCell?.OwningColumn.Name == columnName &&
                            e.Control is TextBox textBox)
                        {
                            textBox.AutoCompleteMode =
                                AutoCompleteMode.SuggestAppend;

                            textBox.AutoCompleteSource =
                                AutoCompleteSource.CustomSource;

                            textBox.AutoCompleteCustomSource =
                                collection;
                        }
                    };
                }
                else
                {
                    MessageBox.Show(
                        $"Column '{columnName}' is not a DataGridViewTextBoxColumn.",
                        "Invalid Column Type",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Setup DataGridView TextBox Suggestions",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void DataGridView_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // This method is a placeholder - the actual logic is handled in the lambda above
            // This is to prevent memory leaks by removing the event handler
        }

        public static void LoadDataGridViewTextBoxSuggestions(
            DataGridView dataGridView,
            string columnName,
            string tableName,
            string sourceColumnName)
        {
            SetupDataGridViewTextBoxSuggestions(
                dataGridView,
                columnName,
                tableName,
                sourceColumnName);
        }
    }
}