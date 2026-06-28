using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace ABMS_2026.Common.Helpers
{
    public static class CollectionHelper
    {
        private sealed class RichTextBoxSuggestionState
        {
            public RichTextBox RichTextBox { get; init; }
            public ListBox SuggestionListBox { get; init; }
            public AutoCompleteStringCollection Suggestions { get; init; }
            public bool IsUpdating { get; set; }
        }

        private static readonly Dictionary<RichTextBox, RichTextBoxSuggestionState> _richTextBoxStates = new();

        public static void LoadComboBoxItems(
            ComboBox comboBox,
            IEnumerable<string> items,
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

                foreach (string item in items)
                {
                    comboBox.Items.Add(item);
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

        public static void LoadComboBoxDistinct(
            ComboBox comboBox,
            string tableName,
            string columnName,
            bool addEmptyItem = true)
        {
            LoadComboBoxDistinct(comboBox, tableName, columnName, null, addEmptyItem);
        }

        public static void LoadComboBoxDistinct(
            ComboBox comboBox,
            string tableName,
            string columnName,
            string? whereClause,
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

                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                string whereSql = string.IsNullOrWhiteSpace(whereClause)
                    ? $"WHERE {columnName} IS NOT NULL AND {columnName} <> ''"
                    : $"WHERE {whereClause} AND {columnName} IS NOT NULL AND {columnName} <> ''";

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
{whereSql}
ORDER BY {columnName};";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader[columnName].ToString());
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
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
WHERE {columnName} IS NOT NULL
AND {columnName} <> ''
ORDER BY {columnName};";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    collection.Add(reader[columnName].ToString());
                }

                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox.AutoCompleteCustomSource = collection;
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

        public static void LoadRichTextBoxSuggestions(
            RichTextBox richTextBox,
            string tableName,
            string columnName)
        {
            try
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
WHERE {columnName} IS NOT NULL
AND {columnName} <> ''
ORDER BY {columnName};";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string value = reader[columnName]?.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                        collection.Add(value);
                }

                AttachRichTextBoxSuggestions(richTextBox, collection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load RichTextBox Suggestions",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void AttachRichTextBoxSuggestions(
            RichTextBox richTextBox,
            AutoCompleteStringCollection suggestions)
        {
            if (_richTextBoxStates.TryGetValue(richTextBox, out var existing))
            {
                DetachRichTextBoxSuggestions(existing);
                _richTextBoxStates.Remove(richTextBox);
            }

            if (richTextBox.Parent == null)
                return;

            var listBox = new ListBox
            {
                Visible = false,
                IntegralHeight = false,
                Height = 120,
                Width = richTextBox.Width,
                Font = richTextBox.Font,
                BorderStyle = BorderStyle.FixedSingle
            };

            richTextBox.Parent.Controls.Add(listBox);
            listBox.BringToFront();

            var state = new RichTextBoxSuggestionState
            {
                RichTextBox = richTextBox,
                SuggestionListBox = listBox,
                Suggestions = suggestions
            };

            richTextBox.TextChanged += RichTextBox_TextChanged;
            richTextBox.KeyDown += RichTextBox_KeyDown;
            richTextBox.LostFocus += RichTextBox_LostFocus;
            listBox.DoubleClick += SuggestionListBox_DoubleClick;
            listBox.Click += SuggestionListBox_Click;

            _richTextBoxStates[richTextBox] = state;
        }

        private static void DetachRichTextBoxSuggestions(RichTextBoxSuggestionState state)
        {
            state.RichTextBox.TextChanged -= RichTextBox_TextChanged;
            state.RichTextBox.KeyDown -= RichTextBox_KeyDown;
            state.RichTextBox.LostFocus -= RichTextBox_LostFocus;

            state.SuggestionListBox.DoubleClick -= SuggestionListBox_DoubleClick;
            state.SuggestionListBox.Click -= SuggestionListBox_Click;

            if (state.SuggestionListBox.Parent != null)
            {
                state.SuggestionListBox.Parent.Controls.Remove(state.SuggestionListBox);
            }

            state.SuggestionListBox.Dispose();
        }

        private static void RichTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (sender is not RichTextBox richTextBox)
                return;

            if (!_richTextBoxStates.TryGetValue(richTextBox, out var state))
                return;

            if (state.IsUpdating)
                return;

            ShowRichTextBoxSuggestions(state);
        }

        private static void RichTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not RichTextBox richTextBox)
                return;

            if (!_richTextBoxStates.TryGetValue(richTextBox, out var state))
                return;

            if (!state.SuggestionListBox.Visible)
                return;

            if (e.KeyCode == Keys.Down)
            {
                if (state.SuggestionListBox.Items.Count > 0)
                {
                    int index = state.SuggestionListBox.SelectedIndex;
                    if (index < state.SuggestionListBox.Items.Count - 1)
                        state.SuggestionListBox.SelectedIndex = index + 1;
                    else
                        state.SuggestionListBox.SelectedIndex = 0;
                }

                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (state.SuggestionListBox.Items.Count > 0)
                {
                    int index = state.SuggestionListBox.SelectedIndex;
                    if (index > 0)
                        state.SuggestionListBox.SelectedIndex = index - 1;
                    else
                        state.SuggestionListBox.SelectedIndex = state.SuggestionListBox.Items.Count - 1;
                }

                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InsertSelectedSuggestion(state);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideSuggestionList(state);
                e.SuppressKeyPress = true;
            }
        }

        private static void RichTextBox_LostFocus(object? sender, EventArgs e)
        {
            if (sender is RichTextBox richTextBox &&
                _richTextBoxStates.TryGetValue(richTextBox, out var state))
            {
                HideSuggestionList(state);
            }
        }

        private static void SuggestionListBox_Click(object? sender, EventArgs e)
        {
            if (sender is ListBox listBox)
            {
                var state = _richTextBoxStates.Values.FirstOrDefault(s => s.SuggestionListBox == listBox);
                if (state != null)
                    InsertSelectedSuggestion(state);
            }
        }

        private static void SuggestionListBox_DoubleClick(object? sender, EventArgs e)
        {
            SuggestionListBox_Click(sender, e);
        }

        private static void ShowRichTextBoxSuggestions(RichTextBoxSuggestionState state)
        {
            string prefix = GetCurrentWordPrefix(state.RichTextBox);

            if (string.IsNullOrWhiteSpace(prefix))
            {
                HideSuggestionList(state);
                return;
            }

            var matches = state.Suggestions
                .Cast<string>()
                .Where(x => x.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x)
                .Take(10)
                .ToList();

            if (matches.Count == 0)
            {
                HideSuggestionList(state);
                return;
            }

            state.SuggestionListBox.BeginUpdate();
            state.SuggestionListBox.Items.Clear();
            foreach (var match in matches)
                state.SuggestionListBox.Items.Add(match);
            state.SuggestionListBox.SelectedIndex = 0;
            state.SuggestionListBox.EndUpdate();

            var parent = state.RichTextBox.Parent;
            if (parent == null)
                return;

            Point location = new Point(
                state.RichTextBox.Left,
                state.RichTextBox.Bottom);

            state.SuggestionListBox.Location = location;
            state.SuggestionListBox.Width = state.RichTextBox.Width;
            state.SuggestionListBox.Height = Math.Min(120, 20 * matches.Count + 4);
            state.SuggestionListBox.Visible = true;
            state.SuggestionListBox.BringToFront();
        }

        private static void HideSuggestionList(RichTextBoxSuggestionState state)
        {
            state.SuggestionListBox.Visible = false;
            state.SuggestionListBox.Items.Clear();
        }

        private static void InsertSelectedSuggestion(RichTextBoxSuggestionState state)
        {
            if (!state.SuggestionListBox.Visible || state.SuggestionListBox.SelectedItem == null)
                return;

            string selected = state.SuggestionListBox.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selected))
                return;

            var rtb = state.RichTextBox;
            int selectionStart = rtb.SelectionStart;
            string textBeforeCaret = rtb.Text.Substring(0, selectionStart);
            int wordStart = GetWordStartIndex(textBeforeCaret);

            state.IsUpdating = true;
            try
            {
                rtb.Select(wordStart, selectionStart - wordStart);
                rtb.SelectedText = selected;
                rtb.SelectionStart = wordStart + selected.Length;
                rtb.SelectionLength = 0;
            }
            finally
            {
                state.IsUpdating = false;
            }

            HideSuggestionList(state);
            rtb.Focus();
        }

        private static int GetWordStartIndex(string textBeforeCaret)
        {
            if (string.IsNullOrEmpty(textBeforeCaret))
                return 0;

            char[] separators = new[]
            {
                ' ', '\r', '\n', '\t', ',', ';', '.', ':', '(', ')', '[', ']', '{', '}', '-', '/'
            };

            int lastSeparator = textBeforeCaret.LastIndexOfAny(separators);
            return lastSeparator >= 0 ? lastSeparator + 1 : 0;
        }

        private static string GetCurrentWordPrefix(RichTextBox richTextBox)
        {
            int selectionStart = richTextBox.SelectionStart;
            if (selectionStart <= 0)
                return string.Empty;

            string textBeforeCaret = richTextBox.Text.Substring(0, selectionStart);
            int wordStart = GetWordStartIndex(textBeforeCaret);

            if (wordStart < 0 || wordStart > textBeforeCaret.Length)
                return string.Empty;

            return textBeforeCaret.Substring(wordStart);
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

                using var connection = new MySqlConnectionHelper().GetConnection();
                connection.Open();

                string query = $@"
SELECT DISTINCT {columnName}
FROM {tableName}
WHERE {columnName} IS NOT NULL
AND {columnName} <> ''
ORDER BY {columnName};";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxColumn.Items.Add(reader[columnName].ToString());
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

                if (column is DataGridViewTextBoxColumn)
                {
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                    using var connection = new MySqlConnectionHelper().GetConnection();
                    connection.Open();

                    string query = $@"
SELECT DISTINCT {sourceColumnName}
FROM {tableName}
WHERE {sourceColumnName} IS NOT NULL
AND {sourceColumnName} <> ''
ORDER BY {sourceColumnName};";

                    using var command = new MySqlCommand(query, connection);
                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        collection.Add(reader[sourceColumnName].ToString());
                    }

                    dataGridView.EditingControlShowing -= DataGridView_EditingControlShowing;
                    dataGridView.EditingControlShowing += (sender, e) =>
                    {
                        if (dataGridView.CurrentCell?.OwningColumn.Name == columnName &&
                            e.Control is TextBox textBox)
                        {
                            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBox.AutoCompleteCustomSource = collection;
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