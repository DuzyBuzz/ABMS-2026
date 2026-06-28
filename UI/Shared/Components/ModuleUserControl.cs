using ABMS_2026.Common.Helpers;
using ABMS_2026.Common.Printing;
using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ABMS_2026.UI.Shared.Components
{

    public partial class ModuleUserControl : UserControl
    {
        private static readonly Regex SafeIdentifierRegex =
            new(@"^[A-Za-z_][A-Za-z0-9_]*$", RegexOptions.Compiled);

        private const string ActionEditColumnName = "__action_edit";
        private const string ActionDeleteColumnName = "__action_delete";

        private readonly MySqlConnectionHelper _connectionHelper;
        private ModuleUserControlOptions? _options;

        private int _currentPage = 1;
        private int _totalRecords = 0;
        private int _totalPages = 0;

        private bool _suppressReload;
        private bool _hidePrimaryKeyColumn;

        public ModuleUserControl()
        {
            InitializeComponent();

            _connectionHelper = new MySqlConnectionHelper();

            moduleSearchButton.Click += moduleSearchButton_Click;
            moduleRefreshButton.Click += moduleRefreshButton_Click;
            modulePrintButton.Click += modulePrintButton_Click;
            moduleAddButton.Click += moduleAddButton_Click;
            prevButton.Click += prevButton_Click;
            nextButton.Click += nextButton_Click;
            moduleSearchTextBox.KeyDown += moduleSearchTextBox_KeyDown;

            moduleDateFromDateTimePicker.ValueChanged += DateFilterChanged;
            moduleDateToDateTimePicker.ValueChanged += DateFilterChanged;
            moduleDataGridView.CellContentClick += moduleDataGridView_CellContentClick;
            moduleDataGridView.CellMouseClick += moduleDataGridView_CellMouseClick;
            rowContextMenuStrip.Opening += rowContextMenuStrip_Opening;
            rowContextMenuStrip.ItemClicked += rowContextMenuStrip_ItemClicked;

            ApplyDefaultVisualState();
        }

        public void Configure(ModuleUserControlOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            ValidateOptions(options);

            _options = options;

            moduleAddButton.Text = options.AddButtonText;
            moduleRefreshButton.Text = options.RefreshButtonText;
            moduleSearchButton.Text = options.SearchButtonText;
            moduleAddButton.Visible = !options.HideAddButton;

            _hidePrimaryKeyColumn = !options.DisplayColumns.Any(c =>
                string.Equals(c, options.PrimaryKeyColumn, StringComparison.OrdinalIgnoreCase));

            _suppressReload = true;
            ApplyVisualMode();
            LoadSearchSuggestions();
            _suppressReload = false;

            _currentPage = 1;
            LoadGrid();
        }

        private void ApplyDefaultVisualState()
        {
            panelBottom.Visible = true;
            panelTop.Visible = true;
            summaryLabel.Text = string.Empty;

            moduleDateFromDateTimePicker.Visible = false;
            moduleDateToDateTimePicker.Visible = false;
            labelTo.Visible = false;
            labelFrom.Visible = false;
            prevButton.Visible = false;
            nextButton.Visible = false;
        }

        private void ApplyVisualMode()
        {
            if (_options == null) return;

            bool paginated = _options.IsPaginated;

            moduleDateFromDateTimePicker.Visible = paginated;
            moduleDateToDateTimePicker.Visible = paginated;
            labelTo.Visible = paginated;
            labelFrom.Visible = paginated;
            prevButton.Visible = paginated;
            nextButton.Visible = paginated;

            if (paginated)
            {
                // Set default date range from last month to next month
                moduleDateFromDateTimePicker.Value = DateTime.Today.AddMonths(-1);
                moduleDateToDateTimePicker.Value = DateTime.Today.AddMonths(1);
            }
        }

        private void LoadSearchSuggestions()
        {
            if (_options == null) return;
            if (_options.SearchableColumns == null || _options.SearchableColumns.Count == 0) return;

            try
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                foreach (string column in _options.SearchableColumns)
                {
                    string source = Quote(_options.SourceName);
                    string col = Quote(column);

                    string query = $@"
SELECT DISTINCT {col}
FROM {source}
WHERE {col} IS NOT NULL
AND {col} <> ''
ORDER BY {col}
LIMIT 100;";

                    using var command = new MySqlCommand(query, connection);
                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string value = reader[column].ToString();
                        if (!string.IsNullOrWhiteSpace(value) && !collection.Contains(value))
                        {
                            collection.Add(value);
                        }
                    }
                }

                moduleSearchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                moduleSearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                moduleSearchTextBox.AutoCompleteCustomSource = collection;
            }
            catch (Exception ex)
            {
                // Silently fail - suggestions are optional
                System.Diagnostics.Debug.WriteLine($"Failed to load search suggestions: {ex.Message}");
            }
        }

        private void ValidateOptions(ModuleUserControlOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.SourceName))
                throw new ArgumentException("SourceName is required.");

            if (string.IsNullOrWhiteSpace(options.PrimaryKeyColumn))
                throw new ArgumentException("PrimaryKeyColumn is required.");

            if (options.DisplayColumns == null || options.DisplayColumns.Count == 0)
                throw new ArgumentException("DisplayColumns must contain at least one column.");

            if (options.SearchableColumns == null)
                options.SearchableColumns = new List<string>();

            if (!IsSafeIdentifier(options.SourceName))
                throw new ArgumentException($"Invalid source name: {options.SourceName}");

            if (!IsSafeIdentifier(options.PrimaryKeyColumn))
                throw new ArgumentException($"Invalid primary key column: {options.PrimaryKeyColumn}");

            if (!string.IsNullOrWhiteSpace(options.TargetTableName) && !IsSafeIdentifier(options.TargetTableName))
                throw new ArgumentException($"Invalid target table name: {options.TargetTableName}");

            foreach (string col in options.DisplayColumns)
                if (!IsSafeIdentifier(col))
                    throw new ArgumentException($"Invalid display column: {col}");

            foreach (string col in options.SearchableColumns)
                if (!IsSafeIdentifier(col))
                    throw new ArgumentException($"Invalid searchable column: {col}");

            if (!string.IsNullOrWhiteSpace(options.DateColumn) && !IsSafeIdentifier(options.DateColumn))
                throw new ArgumentException($"Invalid date column: {options.DateColumn}");
        }

        private static bool IsSafeIdentifier(string value)
        {
            return SafeIdentifierRegex.IsMatch(value);
        }

        private static string Quote(string identifier)
        {
            return $"`{identifier.Replace("`", "``")}`";
        }

        private string ResolveTargetTableName()
        {
            if (_options == null) return string.Empty;
            return string.IsNullOrWhiteSpace(_options.TargetTableName)
                ? _options.SourceName
                : _options.TargetTableName;
        }

        private void LoadGrid()
        {
            if (_options == null) return;
            if (_suppressReload) return;

            string search = moduleSearchTextBox.Text.Trim();

            DateTime? fromDate = null;
            DateTime? toDate = null;

            // Only apply date filter if paginated and search is NOT active
            bool isSearchActive = !string.IsNullOrWhiteSpace(search);
            if (_options.IsPaginated && !isSearchActive)
            {
                fromDate = moduleDateFromDateTimePicker.Value.Date;
                toDate = moduleDateToDateTimePicker.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("From date cannot be greater than To date.", "Invalid Date Range",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                _totalRecords = GetTotalRecords(connection, search, fromDate, toDate);

                DataTable table = GetPageData(connection, search, fromDate, toDate);

                moduleDataGridView.DataSource = null;
                moduleDataGridView.AutoGenerateColumns = true;
                moduleDataGridView.DataSource = table;

                FormatHeaders();
                HidePrimaryKeyIfNeeded();
                AddActionColumns();
                ApplyGridSettings();
                AutoFormatColumns();

                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetTotalRecords(
            MySqlConnection connection,
            string search,
            DateTime? fromDate,
            DateTime? toDate)
        {
            if (_options == null) return 0;

            string source = Quote(_options.SourceName);
            string whereSql = BuildWhereClause(search, fromDate, toDate);

            string sql = $@"
SELECT COUNT(*)
FROM {source}
{whereSql};";

            using var cmd = new MySqlCommand(sql, connection);
            AddParameters(cmd, search, fromDate, toDate);

            object? result = cmd.ExecuteScalar();
            return Convert.ToInt32(result ?? 0, CultureInfo.InvariantCulture);
        }

        private DataTable GetPageData(
            MySqlConnection connection,
            string search,
            DateTime? fromDate,
            DateTime? toDate)
        {
            if (_options == null) return new DataTable();

            string source = Quote(_options.SourceName);

            List<string> selectColumns = _options.DisplayColumns
                .Select(c => c.Trim())
                .ToList();

            if (!selectColumns.Any(c => string.Equals(c, _options.PrimaryKeyColumn, StringComparison.OrdinalIgnoreCase)))
            {
                selectColumns.Add(_options.PrimaryKeyColumn);
            }

            selectColumns = selectColumns
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            string cols = string.Join(", ", selectColumns.Select(Quote));

            // Order by date column when paginated with date filtering, otherwise by primary key
            string orderBy;
            if (_options.IsPaginated && !string.IsNullOrWhiteSpace(_options.DateColumn))
            {
                orderBy = Quote(_options.DateColumn) + " DESC, " + Quote(_options.PrimaryKeyColumn) + " DESC";
            }
            else
            {
                orderBy = Quote(_options.PrimaryKeyColumn) + " DESC";
            }

            string whereSql = BuildWhereClause(search, fromDate, toDate);

            // Disable pagination when search is active to show all matching results
            bool isSearchActive = !string.IsNullOrWhiteSpace(search);
            bool applyPagination = _options.IsPaginated && !isSearchActive;

            string limitSql = string.Empty;
            if (applyPagination)
            {
                limitSql = "LIMIT @limit OFFSET @offset";
            }

            string sql = $@"
SELECT {cols}
FROM {source}
{whereSql}
ORDER BY {orderBy}
{limitSql};";

            using var cmd = new MySqlCommand(sql, connection);
            AddParameters(cmd, search, fromDate, toDate);

            if (applyPagination)
            {
                cmd.Parameters.AddWithValue("@limit", _options.PageSize);
                cmd.Parameters.AddWithValue("@offset", Math.Max(_currentPage - 1, 0) * _options.PageSize);
            }

            using var adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private string BuildWhereClause(string search, DateTime? fromDate, DateTime? toDate)
        {
            if (_options == null) return string.Empty;

            List<string> parts = new();

            if (!string.IsNullOrWhiteSpace(search) && _options.SearchableColumns.Count > 0)
            {
                List<string> searchParts = _options.SearchableColumns
                    .Select(col => $"{Quote(col)} LIKE @search")
                    .ToList();

                parts.Add("(" + string.Join(" OR ", searchParts) + ")");
            }

            // Only apply date filter if search is NOT active
            bool isSearchActive = !string.IsNullOrWhiteSpace(search);
            if (_options.IsPaginated && !isSearchActive &&
                !string.IsNullOrWhiteSpace(_options.DateColumn) &&
                fromDate.HasValue &&
                toDate.HasValue)
            {
                parts.Add($"DATE({Quote(_options.DateColumn)}) BETWEEN @fromDate AND @toDate");
            }

            if (parts.Count == 0)
                return string.Empty;

            return "WHERE " + string.Join(" AND ", parts);
        }

        private void AddParameters(MySqlCommand cmd, string search, DateTime? fromDate, DateTime? toDate)
        {
            if (_options == null) return;

            if (!string.IsNullOrWhiteSpace(search) && _options.SearchableColumns.Count > 0)
            {
                cmd.Parameters.AddWithValue("@search", $"%{search.Trim()}%");
            }

            // Only add date parameters if search is NOT active
            bool isSearchActive = !string.IsNullOrWhiteSpace(search);
            if (_options.IsPaginated && !isSearchActive &&
                !string.IsNullOrWhiteSpace(_options.DateColumn) &&
                fromDate.HasValue &&
                toDate.HasValue)
            {
                cmd.Parameters.AddWithValue("@fromDate", fromDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@toDate", toDate.Value.ToString("yyyy-MM-dd"));
            }
        }

        private void FormatHeaders()
        {
            if (moduleDataGridView.Columns.Count == 0) return;

            foreach (DataGridViewColumn column in moduleDataGridView.Columns)
            {
                if (column.Name == ActionEditColumnName || column.Name == ActionDeleteColumnName)
                    continue;

                column.HeaderText = ToTitleCaseFromSnakeCase(column.Name);
            }
        }

        private void HidePrimaryKeyIfNeeded()
        {
            if (_options == null) return;
            if (!_hidePrimaryKeyColumn) return;

            if (moduleDataGridView.Columns.Contains(_options.PrimaryKeyColumn))
            {
                moduleDataGridView.Columns[_options.PrimaryKeyColumn].Visible = false;
            }
        }

        private void AddActionColumns()
        {
            RemoveActionColumns();

            // Skip action columns if context menu is enabled and configured to hide them
            if (_options != null && _options.EnableContextMenu && _options.HideActionButtonsWhenContextMenuEnabled)
            {
                return;
            }

            // Skip action columns if HideActionButtons is set (for read-only views)
            if (_options != null && _options.HideActionButtons)
            {
                return;
            }

            var editColumn = new DataGridViewButtonColumn
            {
                Name = ActionEditColumnName,
                HeaderText = string.Empty,
                Text = "View",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Flat
            };

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = ActionDeleteColumnName,
                HeaderText = string.Empty,
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Flat
            };

            moduleDataGridView.Columns.Add(editColumn);
            moduleDataGridView.Columns.Add(deleteColumn);

            editColumn.DisplayIndex = moduleDataGridView.Columns.Count - 2;
            deleteColumn.DisplayIndex = moduleDataGridView.Columns.Count - 1;
        }

        private void RemoveActionColumns()
        {
            if (moduleDataGridView.Columns.Contains(ActionEditColumnName))
                moduleDataGridView.Columns.Remove(ActionEditColumnName);

            if (moduleDataGridView.Columns.Contains(ActionDeleteColumnName))
                moduleDataGridView.Columns.Remove(ActionDeleteColumnName);
        }

        private void ApplyGridSettings()
        {
            moduleDataGridView.ReadOnly = true;
            moduleDataGridView.AllowUserToAddRows = false;
            moduleDataGridView.AllowUserToDeleteRows = false;
            moduleDataGridView.AllowUserToResizeRows = false;
            moduleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            moduleDataGridView.MultiSelect = false;
            moduleDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            moduleDataGridView.RowHeadersVisible = false;
            moduleDataGridView.EnableHeadersVisualStyles = false;

            // Apply header styling
            moduleDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 54, 105);
            moduleDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            moduleDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(moduleDataGridView.Font, FontStyle.Bold);
            moduleDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void AutoFormatColumns()
        {
            if (moduleDataGridView.DataSource is not DataTable table)
                return;

            var columnsToProcess = moduleDataGridView.Columns.Cast<DataGridViewColumn>().ToList();

            foreach (DataGridViewColumn column in columnsToProcess)
            {
                if (column.Name == ActionEditColumnName || column.Name == ActionDeleteColumnName)
                    continue;

                // Skip if column doesn't exist in data table
                if (!table.Columns.Contains(column.Name))
                    continue;

                DataColumn dataColumn = table.Columns[column.Name];

                // Format date columns
                if (dataColumn.DataType == typeof(DateTime) || dataColumn.DataType == typeof(DateTime?))
                {
                    column.DefaultCellStyle.Format = "yyyy-MM-dd";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                // Format numeric columns
                else if (dataColumn.DataType == typeof(decimal) || dataColumn.DataType == typeof(decimal?))
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(int?) ||
                         dataColumn.DataType == typeof(long) || dataColumn.DataType == typeof(long?))
                {
                    column.DefaultCellStyle.Format = "N0";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (dataColumn.DataType == typeof(float) || dataColumn.DataType == typeof(float?) ||
                         dataColumn.DataType == typeof(double) || dataColumn.DataType == typeof(double?))
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                // Format boolean columns as checkboxes
                else if (dataColumn.DataType == typeof(bool) || dataColumn.DataType == typeof(bool?))
                {
                    // Change to checkbox column
                    int index = column.Index;
                    var checkBoxColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = column.Name,
                        HeaderText = column.HeaderText,
                        DataPropertyName = column.DataPropertyName,
                        AutoSizeMode = column.AutoSizeMode,
                        FillWeight = column.FillWeight,
                        ThreeState = dataColumn.DataType == typeof(bool?)
                    };

                    moduleDataGridView.Columns.Remove(column);
                    moduleDataGridView.Columns.Insert(index, checkBoxColumn);
                }
                // Text columns - left align
                else
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void UpdateSummary()
        {
            if (_options == null) return;

            if (!_options.IsPaginated)
            {
                summaryLabel.Text = $"Showing {_totalRecords:N0} rows out of {_totalRecords:N0}";
                prevButton.Enabled = false;
                nextButton.Enabled = false;
                return;
            }

            // Check if search is active - if so, disable pagination controls
            bool isSearchActive = !string.IsNullOrWhiteSpace(moduleSearchTextBox.Text.Trim());

            if (isSearchActive)
            {
                summaryLabel.Text = $"Showing all {_totalRecords:N0} matching records (search active)";
                prevButton.Enabled = false;
                nextButton.Enabled = false;
                return;
            }

            _totalPages = Math.Max((int)Math.Ceiling(_totalRecords / (double)_options.PageSize), 1);

            int startRow = _totalRecords == 0 ? 0 : ((_currentPage - 1) * _options.PageSize) + 1;
            int endRow = Math.Min(_currentPage * _options.PageSize, _totalRecords);

            summaryLabel.Text =
                $"Showing {startRow:N0}–{endRow:N0} of {_totalRecords:N0} records | Page {_currentPage:N0} of {_totalPages:N0}";

            prevButton.Enabled = _currentPage > 1;
            nextButton.Enabled = _currentPage < _totalPages;
        }

        private static string ToTitleCaseFromSnakeCase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            string spaced = value.Replace("_", " ").Trim();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(spaced.ToLowerInvariant());
        }

        private void moduleSearchButton_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            LoadGrid();
        }

        private void moduleRefreshButton_Click(object? sender, EventArgs e)
        {
            _suppressReload = true;

            moduleSearchTextBox.Clear();

            if (_options != null && _options.IsPaginated)
            {
                // Reset to default date range (last month to next month)
                moduleDateFromDateTimePicker.Value = DateTime.Today.AddMonths(-1);
                moduleDateToDateTimePicker.Value = DateTime.Today.AddMonths(1);
            }

            _suppressReload = false;

            _currentPage = 1;
            LoadGrid();
        }

        private void modulePrintButton_Click(object? sender, EventArgs e)
        {
            if (_options == null) return;

            string moduleName = _options.ModuleName ?? _options.SourceName;
            string logoPath = @"C:\Users\wenwe\source\repos\ABMS-2026\Resources\Images\shoot-animalbitelogo.png";

            try
            {
                var printHelper = new PrintModuleHelper(moduleDataGridView, moduleName, logoPath);
                printHelper.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void moduleAddButton_Click(object? sender, EventArgs e)
        {
            if (_options == null) return;

            Form? upsertForm = ResolveUpsertForm(isEditMode: false, primaryKeyValue: null);
            if (upsertForm == null)
            {
                MessageBox.Show("Upsert form could not be resolved. Set UpsertFormType or UpsertFormName.",
                    "Missing Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var context = CreateContext(isEditMode: false, row: null);
            TryPassContext(upsertForm, context, isEditMode: false);

            // Invoke custom callback if provided
            _options.FormConfigureCallback?.Invoke(upsertForm, context);

            using (upsertForm)
            {
                upsertForm.StartPosition = FormStartPosition.CenterParent;
                upsertForm.ShowDialog(FindForm());
            }

            LoadGrid();
        }

        private void moduleDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_options == null) return;
            if (e.RowIndex < 0) return;

            if (moduleDataGridView.Columns[e.ColumnIndex].Name == ActionEditColumnName)
            {
                OpenEditForm(moduleDataGridView.Rows[e.RowIndex]);
            }
            else if (moduleDataGridView.Columns[e.ColumnIndex].Name == ActionDeleteColumnName)
            {
                DeleteRow(moduleDataGridView.Rows[e.RowIndex]);
            }
        }

        private void moduleDataGridView_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (_options == null) return;
            if (!_options.EnableContextMenu) return;
            if (e.Button != MouseButtons.Right) return;
            if (e.RowIndex < 0) return;

            // Select the row that was right-clicked
            moduleDataGridView.ClearSelection();
            moduleDataGridView.Rows[e.RowIndex].Selected = true;

            // Show context menu beside the actual mouse cursor position
            Point cursorPosition = Cursor.Position;
            Point menuPosition = new Point(cursorPosition.X + 10, cursorPosition.Y + 10);
            rowContextMenuStrip.Show(menuPosition);
        }

        private void rowContextMenuStrip_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_options == null || !_options.EnableContextMenu)
            {
                e.Cancel = true;
                return;
            }

            // Build context menu from configuration
            rowContextMenuStrip.Items.Clear();

            foreach (var menuItem in _options.ContextMenuItems)
            {
                if (menuItem.IsSeparator)
                {
                    rowContextMenuStrip.Items.Add(new ToolStripSeparator());
                }
                else
                {
                    var toolStripItem = new ToolStripMenuItem(menuItem.Text)
                    {
                        Name = menuItem.Name,
                        Tag = menuItem
                    };
                    rowContextMenuStrip.Items.Add(toolStripItem);
                }
            }

            // If no items, cancel the menu
            if (rowContextMenuStrip.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void rowContextMenuStrip_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (_options == null) return;
            if (moduleDataGridView.SelectedRows.Count == 0) return;

            var clickedItem = e.ClickedItem;
            if (clickedItem.Tag is not ModuleContextMenuItem menuItem) return;

            var selectedRow = moduleDataGridView.SelectedRows[0];
            var context = CreateContext(isEditMode: true, row: selectedRow);

            // Execute the custom action
            menuItem.Action?.Invoke(context);

            // Reload grid if configured to do so
            if (menuItem.ReloadGridAfterAction)
            {
                LoadGrid();
            }
        }

        private void OpenEditForm(DataGridViewRow row)
        {
            if (_options == null) return;

            object? pkValue = GetCellValue(row, _options.PrimaryKeyColumn);

            Form? upsertForm = ResolveUpsertForm(isEditMode: true, primaryKeyValue: pkValue);
            if (upsertForm == null)
            {
                MessageBox.Show("Upsert form could not be resolved. Set UpsertFormType or UpsertFormName.",
                    "Missing Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var context = CreateContext(isEditMode: true, row: row);
            TryPassContext(upsertForm, context, isEditMode: true);

            // Invoke custom callback if provided
            _options.FormConfigureCallback?.Invoke(upsertForm, context);

            using (upsertForm)
            {
                upsertForm.StartPosition = FormStartPosition.CenterParent;
                upsertForm.ShowDialog(FindForm());
            }

            LoadGrid();
        }

        private void DeleteRow(DataGridViewRow row)
        {
            if (_options == null) return;

            object? pkValue = GetCellValue(row, _options.PrimaryKeyColumn);

            if (pkValue == null || pkValue == DBNull.Value)
            {
                MessageBox.Show("Primary key value not found for delete.", "Delete Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Delete this record permanently?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using var connection = _connectionHelper.GetConnection();
                connection.Open();

                string targetTable = Quote(ResolveTargetTableName());
                string primaryKey = Quote(_options.PrimaryKeyColumn);

                string sql = $@"
DELETE FROM {targetTable}
WHERE {primaryKey} = @pkValue
LIMIT 1;";

                using var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@pkValue", pkValue);

                int affected = cmd.ExecuteNonQuery();

                if (affected > 0)
                {
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("No record was deleted.", "Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object? GetCellValue(DataGridViewRow row, string columnName)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (string.Equals(cell.OwningColumn?.Name, columnName, StringComparison.OrdinalIgnoreCase))
                    return cell.Value;
            }

            return null;
        }

        private Form? ResolveUpsertForm(bool isEditMode, object? primaryKeyValue)
        {
            if (_options == null) return null;

            Type? formType = null;

            if (_options.UpsertFormType != null)
            {
                if (!typeof(Form).IsAssignableFrom(_options.UpsertFormType))
                    throw new InvalidOperationException("UpsertFormType must inherit from Form.");

                formType = _options.UpsertFormType;
            }
            else if (!string.IsNullOrWhiteSpace(_options.UpsertFormName))
            {
                formType = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(a =>
                    {
                        try { return a.GetTypes(); }
                        catch { return Array.Empty<Type>(); }
                    })
                    .FirstOrDefault(t =>
                        typeof(Form).IsAssignableFrom(t) &&
                        (string.Equals(t.FullName, _options.UpsertFormName, StringComparison.Ordinal) ||
                         string.Equals(t.Name, _options.UpsertFormName, StringComparison.Ordinal)));
            }

            if (formType == null)
                return null;

            // Try to use constructor with primary key parameter if in edit mode
            if (isEditMode && primaryKeyValue != null)
            {
                ConstructorInfo? constructor = formType.GetConstructor(
                    BindingFlags.Public | BindingFlags.Instance,
                    binder: null,
                    types: new[] { primaryKeyValue.GetType() },
                    modifiers: null);

                if (constructor != null)
                {
                    return (Form?)constructor.Invoke(new object[] { primaryKeyValue });
                }

                // Try constructor with int parameter
                if (primaryKeyValue is int || primaryKeyValue is long)
                {
                    ConstructorInfo? intConstructor = formType.GetConstructor(
                        BindingFlags.Public | BindingFlags.Instance,
                        binder: null,
                        types: new[] { typeof(int) },
                        modifiers: null);

                    if (intConstructor != null)
                    {
                        return (Form?)intConstructor.Invoke(new object[] { Convert.ToInt32(primaryKeyValue) });
                    }
                }
            }

            // Fallback to parameterless constructor
            return (Form?)Activator.CreateInstance(formType);
        }

        private ModuleRecordContext CreateContext(bool isEditMode, DataGridViewRow? row)
        {
            if (_options == null)
                throw new InvalidOperationException("Control is not configured.");

            var values = new Dictionary<string, object?>();

            if (row != null)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = cell.OwningColumn?.Name ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(columnName))
                        values[columnName] = cell.Value is DBNull ? null : cell.Value;
                }
            }

            object? pkValue = row == null ? null : GetCellValue(row, _options.PrimaryKeyColumn);

            return new ModuleRecordContext
            {
                IsEditMode = isEditMode,
                SourceName = _options.SourceName,
                TargetTableName = ResolveTargetTableName(),
                PrimaryKeyColumn = _options.PrimaryKeyColumn,
                PrimaryKeyValue = pkValue is DBNull ? null : pkValue,
                Values = values
            };
        }

        private static void TryPassContext(Form form, ModuleRecordContext context, bool isEditMode)
        {
            if (form is IModuleUpsertForm upsertForm)
            {
                upsertForm.LoadModuleRecord(context);
                return;
            }

            // Fallback: invoke a compatible public method if the form has one.
            MethodInfo? loadMethod = form.GetType().GetMethod(
                "LoadModuleRecord",
                BindingFlags.Public | BindingFlags.Instance,
                binder: null,
                types: new[] { typeof(ModuleRecordContext) },
                modifiers: null);

            if (loadMethod != null)
            {
                loadMethod.Invoke(form, new object[] { context });
                return;
            }

            // Fallback: set common properties by reflection.
            TrySetProperty(form, "IsEditMode", isEditMode);
            TrySetProperty(form, "IsEdit", isEditMode);
            TrySetProperty(form, "RecordId", context.PrimaryKeyValue);
            TrySetProperty(form, "PrimaryKeyValue", context.PrimaryKeyValue);
            TrySetProperty(form, "SelectedId", context.PrimaryKeyValue);
            TrySetProperty(form, "Id", context.PrimaryKeyValue);
            TrySetProperty(form, "TableName", context.TargetTableName);
            TrySetProperty(form, "SourceName", context.SourceName);

            // Additional entity-specific property fallbacks
            TrySetProperty(form, context.PrimaryKeyColumn + "Id", context.PrimaryKeyValue);
            TrySetProperty(form, context.PrimaryKeyColumn + "_ID", context.PrimaryKeyValue);
            TrySetProperty(form, context.PrimaryKeyColumn + "ID", context.PrimaryKeyValue);
        }

        private static void TrySetProperty(object target, string propertyName, object? value)
        {
            PropertyInfo? prop = target.GetType().GetProperty(
                propertyName,
                BindingFlags.Public | BindingFlags.Instance);

            if (prop == null || !prop.CanWrite)
                return;

            object? convertedValue = value;

            if (value != null && prop.PropertyType != value.GetType())
            {
                try
                {
                    if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                    {
                        Type underlying = Nullable.GetUnderlyingType(prop.PropertyType)!;
                        convertedValue = Convert.ChangeType(value, underlying, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        convertedValue = Convert.ChangeType(value, prop.PropertyType, CultureInfo.InvariantCulture);
                    }
                }
                catch
                {
                    convertedValue = value;
                }
            }

            try
            {
                prop.SetValue(target, convertedValue);
            }
            catch
            {
                // ignore fallback failures
            }
        }

        private void prevButton_Click(object? sender, EventArgs e)
        {
            if (_options == null || !_options.IsPaginated) return;
            if (_currentPage <= 1) return;

            _currentPage--;
            LoadGrid();
        }

        private void nextButton_Click(object? sender, EventArgs e)
        {
            if (_options == null || !_options.IsPaginated) return;
            if (_currentPage >= _totalPages) return;

            _currentPage++;
            LoadGrid();
        }

        private void moduleSearchTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _currentPage = 1;
                LoadGrid();
            }
        }

        private void DateFilterChanged(object? sender, EventArgs e)
        {
            if (_suppressReload) return;
            if (_options == null || !_options.IsPaginated) return;

            // Don't reload if search is active (date filter is disabled during search)
            bool isSearchActive = !string.IsNullOrWhiteSpace(moduleSearchTextBox.Text.Trim());
            if (isSearchActive) return;

            _currentPage = 1;
            LoadGrid();
        }
    }
    public sealed class ModuleContextMenuItem
    {
        public string Text { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Action<ModuleRecordContext>? Action { get; set; }
        public bool IsSeparator { get; set; }
        public bool ReloadGridAfterAction { get; set; } = true;
    }

    public sealed class ModuleUserControlOptions
    {
        public string SourceName { get; set; } = string.Empty;          // table or view name for SELECT
        public string TargetTableName { get; set; } = string.Empty;     // table name for UPDATE/DELETE; defaults to SourceName
        public string? ModuleName { get; set; }                        // display name for the module (used in printing)

        public string PrimaryKeyColumn { get; set; } = string.Empty;

        public List<string> DisplayColumns { get; set; } = new();
        public List<string> SearchableColumns { get; set; } = new();

        public bool IsPaginated { get; set; } = true;
        public int PageSize { get; set; } = 1000;

        public string? DateColumn { get; set; }

        public Type? UpsertFormType { get; set; }
        public string? UpsertFormName { get; set; }

        public string AddButtonText { get; set; } = "Add New";
        public string RefreshButtonText { get; set; } = "Refresh";
        public string SearchButtonText { get; set; } = "Search";
        public bool HideAddButton { get; set; } = false;
        public bool HideActionButtons { get; set; } = false;          // Hide Edit/Delete buttons for read-only views

        public Action<Form, ModuleRecordContext>? FormConfigureCallback { get; set; }

        // Context menu configuration
        public bool EnableContextMenu { get; set; } = false;
        public List<ModuleContextMenuItem> ContextMenuItems { get; set; } = new();
        public bool HideActionButtonsWhenContextMenuEnabled { get; set; } = true;
    }

    public sealed class ModuleRecordContext
    {
        public bool IsEditMode { get; init; }
        public string SourceName { get; init; } = string.Empty;
        public string TargetTableName { get; init; } = string.Empty;
        public string PrimaryKeyColumn { get; init; } = string.Empty;
        public object? PrimaryKeyValue { get; init; }
        public IReadOnlyDictionary<string, object?> Values { get; init; } = new Dictionary<string, object?>();
    }

    public interface IModuleUpsertForm
    {
        void LoadModuleRecord(ModuleRecordContext context);
    }

}