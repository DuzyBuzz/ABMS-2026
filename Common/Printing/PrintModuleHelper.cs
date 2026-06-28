using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABMS_2026.Common.Printing
{
    public class PrintModuleHelper
    {
        private readonly DataGridView _dataGridView;
        private readonly string _moduleName;
        private readonly string _logoPath;
        
        private PrintDocument? _printDocument;
        private Image? _logoImage;
        private int _currentPage;
        private int _totalPages;
        
        private List<DataGridViewRow> _rowsToPrint = new();
        private List<DataGridViewColumn> _columnsToPrint = new();
        private List<float> _columnWidths = new();
        private float _tableHeaderHeight;
        
        private readonly Font _headerFont = new Font("Arial", 14, FontStyle.Bold);
        private readonly Font _subHeaderFont = new Font("Arial", 11, FontStyle.Bold);
        private readonly Font _tableHeaderFont = new Font("Arial", 9, FontStyle.Bold);
        private readonly Font _normalFont = new Font("Arial", 8);
        private readonly Font _footerFont = new Font("Arial", 8);
        
        private readonly Color _headerBackColor = Color.FromArgb(91, 155, 213);
        private readonly Color _headerBorderColor = Color.FromArgb(255, 230, 0);
        private readonly Color _tableHeaderBackColor = Color.FromArgb(22, 54, 105);
        
        private const float HeaderHeight = 60;
        private const float FooterHeight = 30;
        private const float Margin = 20;
        private const float MinColumnWidth = 60;
        private const float CellPadding = 5;
        
        // Track row heights for pagination
        private List<float> _rowHeights = new();
        private int _currentRowIndex;
        
        public PrintModuleHelper(DataGridView dataGridView, string moduleName, string logoPath = "")
        {
            _dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));
            _moduleName = moduleName ?? throw new ArgumentNullException(nameof(moduleName));
            _logoPath = logoPath;
        }
        
        public void Print()
        {
            LoadLogoImage();
            ConfigurePrintDocument();
            PrepareData();
            CalculateColumnWidths();
            CalculateTableHeaderHeight();
            CalculateRowHeights();
            CalculateTotalPages();
            ShowPrintPreviewWithPrinterSelection();
        }
        
        private void LoadLogoImage()
        {
            if (string.IsNullOrWhiteSpace(_logoPath) || !File.Exists(_logoPath))
            {
                _logoImage = null;
                return;
            }
            
            try
            {
                using var fs = new FileStream(_logoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var img = Image.FromStream(fs);
                _logoImage = new Bitmap(img);
            }
            catch
            {
                _logoImage = null;
            }
        }
        
        private void PrepareData()
        {
            // Get only visible rows (filtered/visible in grid)
            _rowsToPrint = _dataGridView.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Visible && !r.IsNewRow)
                .ToList();
            
            // Get columns to print (exclude action columns and hidden columns)
            _columnsToPrint = _dataGridView.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible && 
                           c.Name != "__action_edit" && 
                           c.Name != "__action_delete")
                .ToList();
        }
        
        private void CalculateColumnWidths()
        {
            if (_printDocument == null || _columnsToPrint.Count == 0)
                return;
            
            float availableWidth = _printDocument.DefaultPageSettings.Bounds.Width - (Margin * 2);
            float totalWidth = availableWidth;
            
            // Start with equal distribution
            float baseWidth = totalWidth / _columnsToPrint.Count;
            
            _columnWidths = _columnsToPrint.Select(c => Math.Max(baseWidth, MinColumnWidth)).ToList();
        }
        
        private void CalculateTableHeaderHeight()
        {
            if (_printDocument == null || _columnsToPrint.Count == 0)
            {
                _tableHeaderHeight = 30;
                return;
            }
            
            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);
            
            float maxHeight = 30; // Minimum header height
            
            for (int i = 0; i < _columnsToPrint.Count; i++)
            {
                string headerText = _columnsToPrint[i].HeaderText;
                float width = _columnWidths[i] - (CellPadding * 2);
                
                float height = MeasureWrappedTextHeight(g, headerText, _tableHeaderFont, width);
                maxHeight = Math.Max(maxHeight, height + (CellPadding * 2));
            }
            
            _tableHeaderHeight = maxHeight;
        }
        
        private void CalculateRowHeights()
        {
            if (_printDocument == null || _rowsToPrint.Count == 0)
            {
                _rowHeights = new List<float>();
                return;
            }
            
            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);
            
            _rowHeights = new List<float>();
            
            foreach (var row in _rowsToPrint)
            {
                float maxHeight = 25; // Minimum row height
                
                for (int i = 0; i < _columnsToPrint.Count; i++)
                {
                    var column = _columnsToPrint[i];
                    string cellValue = GetFormattedCellValue(row, column);
                    float width = _columnWidths[i] - (CellPadding * 2);
                    
                    float height = MeasureWrappedTextHeight(g, cellValue, _normalFont, width);
                    maxHeight = Math.Max(maxHeight, height + (CellPadding * 2));
                }
                
                _rowHeights.Add(maxHeight);
            }
        }
        
        private void CalculateTotalPages()
        {
            if (_printDocument == null)
            {
                _totalPages = 1;
                return;
            }
            
            float availableHeight = _printDocument.DefaultPageSettings.Bounds.Height - (Margin * 2);
            float contentHeight = HeaderHeight + _tableHeaderHeight + FooterHeight;
            float availableForRows = availableHeight - contentHeight;
            
            _totalPages = 1;
            float currentPageHeight = 0;
            
            foreach (float rowHeight in _rowHeights)
            {
                if (currentPageHeight + rowHeight > availableForRows)
                {
                    _totalPages++;
                    currentPageHeight = rowHeight;
                }
                else
                {
                    currentPageHeight += rowHeight;
                }
            }
        }
        
        private void ConfigurePrintDocument()
        {
            if (_printDocument != null)
            {
                _printDocument.BeginPrint -= PrintDocument_BeginPrint;
                _printDocument.PrintPage -= PrintDocument_PrintPage;
                _printDocument.Dispose();
            }
            
            _printDocument = new PrintDocument
            {
                DefaultPageSettings =
                {
                    Landscape = true,
                    Margins = new Margins((int)Margin - 5, (int)Margin, (int)Margin, (int)Margin)
                },
                OriginAtMargins = true
            };
            
            _printDocument.BeginPrint += PrintDocument_BeginPrint;
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }
        
        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            _currentPage = 0;
            _currentRowIndex = 0;
        }
        
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;
            
            float currentY = y;
            
            // Print header
            currentY = PrintHeader(e.Graphics, x, currentY, width);
            
            // Print table header
            currentY = PrintTableHeader(e.Graphics, x, currentY, width);
            
            // Calculate available height for rows
            float availableHeight = e.MarginBounds.Height - (HeaderHeight + FooterHeight + _tableHeaderHeight);
            float usedHeight = 0;
            
            // Print rows that fit on this page
            while (_currentRowIndex < _rowsToPrint.Count)
            {
                float rowHeight = _rowHeights[_currentRowIndex];
                
                // Check if row fits on current page
                if (usedHeight + rowHeight > availableHeight && usedHeight > 0)
                {
                    // Row doesn't fit, move to next page
                    break;
                }
                
                // Print the row
                PrintRow(e.Graphics, x, currentY, width, _rowsToPrint[_currentRowIndex], rowHeight);
                currentY += rowHeight;
                usedHeight += rowHeight;
                _currentRowIndex++;
            }
            
            // Print footer
            PrintFooter(e.Graphics, x, e.MarginBounds.Bottom - FooterHeight + 10, width);
            
            _currentPage++;
            e.HasMorePages = _currentRowIndex < _rowsToPrint.Count;
        }
        
        private float PrintHeader(Graphics g, float x, float y, float width)
        {
            DrawFilledRect(g, _headerBackColor, _headerBorderColor, x, y, width, HeaderHeight);
            
            string title = "SHOT ANIMAL BITE CENTER";
            string subtitle = _moduleName.ToUpperInvariant();
            
            // Draw logo on the left side
            if (_logoImage != null)
            {
                int logoWidth = 80;
                int logoHeight = 50;
                Rectangle logoRect = new Rectangle((int)x + 10, (int)y + 5, logoWidth, logoHeight);
                
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                
                g.DrawImage(_logoImage, logoRect);
            }
            
            // Calculate text position (centered in remaining space after logo)
            float logoOffset = _logoImage != null ? 100 : 0;
            float textWidth = width - logoOffset;
            
            SizeF titleSize = g.MeasureString(title, _headerFont);
            SizeF subtitleSize = g.MeasureString(subtitle, _subHeaderFont);
            
            float titleX = x + logoOffset + (textWidth - titleSize.Width) / 2;
            float subtitleX = x + logoOffset + (textWidth - subtitleSize.Width) / 2;
            
            using var white = new SolidBrush(Color.White);
            g.DrawString(title, _headerFont, white, titleX, y + 8);
            g.DrawString(subtitle, _subHeaderFont, white, subtitleX, y + 31);
            
            return y + HeaderHeight + 8;
        }
        
        private float PrintTableHeader(Graphics g, float x, float y, float width)
        {
            DrawFilledRect(g, _tableHeaderBackColor, Color.Black, x, y, width, _tableHeaderHeight);
            
            float columnX = x;
            
            using var white = new SolidBrush(Color.White);
            using var pen = new Pen(Color.Black, 0.5f);
            
            for (int i = 0; i < _columnsToPrint.Count; i++)
            {
                var column = _columnsToPrint[i];
                string headerText = column.HeaderText;
                float columnWidth = _columnWidths[i];
                
                // Create rectangle for wrapped text
                RectangleF textRect = new RectangleF(
                    columnX + CellPadding,
                    y + CellPadding,
                    columnWidth - (CellPadding * 2),
                    _tableHeaderHeight - (CellPadding * 2)
                );
                
                // Draw wrapped text
                DrawWrappedText(g, headerText, _tableHeaderFont, white, textRect, StringAlignment.Center);
                
                // Draw vertical line
                if (i < _columnsToPrint.Count - 1)
                {
                    g.DrawLine(pen, columnX + columnWidth, y, columnX + columnWidth, y + _tableHeaderHeight);
                }
                
                columnX += columnWidth;
            }
            
            return y + _tableHeaderHeight;
        }
        
        private void PrintRow(Graphics g, float x, float y, float width, DataGridViewRow row, float rowHeight)
        {
            float columnX = x;
            
            using var brush = new SolidBrush(Color.Black);
            using var pen = new Pen(Color.LightGray, 0.5f);
            
            for (int i = 0; i < _columnsToPrint.Count; i++)
            {
                var column = _columnsToPrint[i];
                string cellValue = GetFormattedCellValue(row, column);
                float columnWidth = _columnWidths[i];
                
                // Create rectangle for wrapped text
                RectangleF textRect = new RectangleF(
                    columnX + CellPadding,
                    y + CellPadding,
                    columnWidth - (CellPadding * 2),
                    rowHeight - (CellPadding * 2)
                );
                
                // Draw wrapped text
                DrawWrappedText(g, cellValue, _normalFont, brush, textRect, StringAlignment.Near);
                
                // Draw vertical line
                if (i < _columnsToPrint.Count - 1)
                {
                    g.DrawLine(pen, columnX + columnWidth, y, columnX + columnWidth, y + rowHeight);
                }
                
                columnX += columnWidth;
            }
            
            // Draw bottom line
            g.DrawLine(pen, x, y + rowHeight, x + width, y + rowHeight);
        }
        
        private string GetFormattedCellValue(DataGridViewRow row, DataGridViewColumn column)
        {
            if (row.Cells[column.Index].Value == null || row.Cells[column.Index].Value == DBNull.Value)
                return string.Empty;
            
            object value = row.Cells[column.Index].Value;
            
            // Format based on column type
            if (column is DataGridViewCheckBoxColumn)
            {
                return Convert.ToBoolean(value) ? "✓" : "✗";
            }
            
            if (value is DateTime dt)
            {
                return dt.ToString("yyyy-MM-dd");
            }
            
            if (value is decimal dec)
            {
                return dec.ToString("N2");
            }
            
            if (value is int || value is long)
            {
                return Convert.ToInt64(value).ToString("N0");
            }
            
            return value.ToString() ?? string.Empty;
        }
        
        private void PrintFooter(Graphics g, float x, float y, float width)
        {
            string pageText = $"Page {_currentPage + 1} of {_totalPages}";
            
            SizeF textSize = g.MeasureString(pageText, _footerFont);
            float textX = x + (width - textSize.Width) / 2;
            
            using var brush = new SolidBrush(Color.Black);
            g.DrawString(pageText, _footerFont, brush, textX, y);
        }
        
        private void DrawFilledRect(Graphics g, Color backColor, Color borderColor, float x, float y, float width, float height)
        {
            using var brush = new SolidBrush(backColor);
            using var pen = new Pen(borderColor, 1);
            
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(pen, x, y, width, height);
        }
        
        /// <summary>
        /// Measures the height required to draw text with word wrapping within a specified width.
        /// </summary>
        private float MeasureWrappedTextHeight(Graphics g, string text, Font font, float width)
        {
            if (string.IsNullOrWhiteSpace(text))
                return font.Height;
            
            using var format = new StringFormat
            {
                FormatFlags = StringFormatFlags.LineLimit,
                Trimming = StringTrimming.EllipsisWord
            };
            
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            
            SizeF size = g.MeasureString(text, font, new SizeF(width, float.MaxValue), format);
            return size.Height;
        }
        
        /// <summary>
        /// Draws text with word wrapping within the specified bounds.
        /// </summary>
        private void DrawWrappedText(Graphics g, string text, Font font, Brush brush, RectangleF bounds, StringAlignment alignment)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            
            using var format = new StringFormat
            {
                FormatFlags = StringFormatFlags.LineLimit,
                Trimming = StringTrimming.EllipsisWord
            };
            
            format.Alignment = alignment;
            format.LineAlignment = StringAlignment.Near;
            
            g.DrawString(text, font, brush, bounds, format);
        }
        
        private void ShowPrintPreviewWithPrinterSelection()
        {
            using var previewDialog = new PrintPreviewDialog
            {
                Document = _printDocument,
                UseAntiAlias = true,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                ShowIcon = false,
                MinimizeBox = false,
                MaximizeBox = true
            };
            
            previewDialog.PrintPreviewControl.Zoom = 1.0;
            previewDialog.PrintPreviewControl.AutoZoom = false;
            
            // Subscribe to the print button click event
            var toolbar = previewDialog.Controls[0] as ToolStrip;
            if (toolbar != null)
            {
                foreach (ToolStripItem item in toolbar.Items)
                {
                    if (item is ToolStripButton button && button.ToolTipText.Contains("Print"))
                    {
                        button.Click -= PrintButton_Click;
                        button.Click += PrintButton_Click;
                        break;
                    }
                }
            }
            
            previewDialog.ShowDialog();
        }
        
        private void PrintButton_Click(object? sender, EventArgs e)
        {
            using var printDialog = new PrintDialog
            {
                Document = _printDocument,
                AllowSomePages = false,
                AllowSelection = false,
                UseEXDialog = true
            };
            
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument?.Print();
            }
        }
    }
}
