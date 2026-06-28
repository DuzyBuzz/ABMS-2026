using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace ABMS_2026.UI.Shared.Components
{
    public partial class AnatomicalLocationPickerUserControl : UserControl
    {
        private Bitmap? _originalBitmap;
        private Bitmap? _displayBitmap;
        private bool _isDrawing = false;
        private Point _lastPoint;

        // Coordinate storage
        private List<Point> _coordinates = new List<Point>();
        private List<List<Point>> _strokeHistory = new List<List<Point>>();
        private List<Point> _currentStroke = new List<Point>();

        // Undo/Redo stacks
        private Stack<List<List<Point>>> _undoStack = new Stack<List<List<Point>>>();
        private Stack<List<List<Point>>> _redoStack = new Stack<List<List<Point>>>();

        // Zoom
        private float _zoomFactor = 1.0f;
        private const float MIN_ZOOM = 0.1f;
        private const float MAX_ZOOM = 5.0f;
        private const float ZOOM_STEP = 0.1f;

        // Drawing settings
        private static readonly Color DRAW_COLOR = Color.Red;
        private const int LINE_WIDTH = 3;
        private const DashStyle DASH_STYLE = DashStyle.Dot;

        // Body part regions and highlighting
        private Dictionary<string, BodyPartRegion> _bodyPartRegions = new Dictionary<string, BodyPartRegion>();
        private HashSet<string> _highlightedBodyParts = new HashSet<string>();
        private bool _bodyPartSelectionMode = true; // When true, clicks select body parts; when false, clicks draw
        private static readonly Color HIGHLIGHT_COLOR = Color.FromArgb(128, 255, 255, 0); // Semi-transparent yellow
        private static readonly Color SELECTED_COLOR = Color.FromArgb(128, 0, 255, 0); // Semi-transparent green

        public AnatomicalLocationPickerUserControl()
        {
            InitializeComponent();
            SetControlProperties();
            HookupEvents();
            LoadImageFromPictureBox();
            InitializeBodyPartRegions();
        }

        private void SetControlProperties()
        {
            this.SetStyle(ControlStyles.Selectable, true);
        }

        private void HookupEvents()
        {
            pictureBoxEditor.MouseDown += PictureBoxEditor_MouseDown;
            pictureBoxEditor.MouseMove += PictureBoxEditor_MouseMove;
            pictureBoxEditor.MouseUp += PictureBoxEditor_MouseUp;
            pictureBoxEditor.MouseWheel += PictureBoxEditor_MouseWheel;
            pictureBoxEditor.Enter += PictureBoxEditor_Enter;
            pictureBoxEditor.Leave += PictureBoxEditor_Leave;
            pictureBoxEditor.KeyDown += PictureBoxEditor_KeyDown;
            pictureBoxEditor.Click += PictureBoxEditor_Click;
            this.Load += AnatomicalLocationPickerUserControl_Load;
        }

        private void PictureBoxEditor_Click(object? sender, EventArgs e)
        {
            pictureBoxEditor.Focus();
        }

        private void PictureBoxEditor_Enter(object? sender, EventArgs e)
        {
            pictureBoxEditor.BackColor = Color.LightBlue;
        }

        private void PictureBoxEditor_Leave(object? sender, EventArgs e)
        {
            pictureBoxEditor.BackColor = Color.White;
        }

        private void AnatomicalLocationPickerUserControl_Load(object? sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                pictureBoxEditor.Focus();
            }
        }

        private void LoadImageFromPictureBox()
        {
            if (pictureBoxEditor.Image != null)
            {
                _originalBitmap = new Bitmap(pictureBoxEditor.Image);
                pictureBoxEditor.Image = _originalBitmap;
                SaveStateForUndo();
            }
        }

        public void SetImage(Image image)
        {
            if (image == null)
            {
                return;
            }

            // Dispose previous bitmaps
            if (_originalBitmap != null)
            {
                _originalBitmap.Dispose();
            }
            if (_displayBitmap != null)
            {
                _displayBitmap.Dispose();
            }

            _originalBitmap = new Bitmap(image);
            _displayBitmap = null;
            _zoomFactor = 1.0f;
            _strokeHistory.Clear();
            _currentStroke.Clear();
            _coordinates.Clear();
            _undoStack.Clear();
            _redoStack.Clear();
            _highlightedBodyParts.Clear();

            InitializeBodyPartRegions();
            RedrawCanvas();
            SaveStateForUndo();
        }

        private void InitializeBodyPartRegions()
        {
            // These coordinates are based on the anatomy image - you may need to adjust them
            // based on the actual image dimensions. Coordinates are in original image space.

            if (_originalBitmap == null) return;

            int imgWidth = _originalBitmap.Width;
            int imgHeight = _originalBitmap.Height;

            // Head region
            _bodyPartRegions["Head"] = new BodyPartRegion
            {
                Name = "Head",
                Bounds = new Rectangle(imgWidth / 2 - 30, 20, 60, 70),
                Description = "Head area including face and skull"
            };

            // Neck region
            _bodyPartRegions["Neck"] = new BodyPartRegion
            {
                Name = "Neck",
                Bounds = new Rectangle(imgWidth / 2 - 15, 90, 30, 25),
                Description = "Neck area"
            };

            // Chest/Thorax region
            _bodyPartRegions["Chest"] = new BodyPartRegion
            {
                Name = "Chest",
                Bounds = new Rectangle(imgWidth / 2 - 40, 115, 80, 60),
                Description = "Chest and thorax area"
            };

            // Abdomen region
            _bodyPartRegions["Abdomen"] = new BodyPartRegion
            {
                Name = "Abdomen",
                Bounds = new Rectangle(imgWidth / 2 - 35, 175, 70, 50),
                Description = "Abdominal area"
            };

            // Left Arm
            _bodyPartRegions["LeftArm"] = new BodyPartRegion
            {
                Name = "LeftArm",
                Bounds = new Rectangle(imgWidth / 2 - 80, 120, 35, 100),
                Description = "Left arm (upper arm, forearm, hand)"
            };

            // Right Arm
            _bodyPartRegions["RightArm"] = new BodyPartRegion
            {
                Name = "RightArm",
                Bounds = new Rectangle(imgWidth / 2 + 45, 120, 35, 100),
                Description = "Right arm (upper arm, forearm, hand)"
            };

            // Left Leg
            _bodyPartRegions["LeftLeg"] = new BodyPartRegion
            {
                Name = "LeftLeg",
                Bounds = new Rectangle(imgWidth / 2 - 45, 225, 35, 120),
                Description = "Left leg (thigh, lower leg, foot)"
            };

            // Right Leg
            _bodyPartRegions["RightLeg"] = new BodyPartRegion
            {
                Name = "RightLeg",
                Bounds = new Rectangle(imgWidth / 2 + 10, 225, 35, 120),
                Description = "Right leg (thigh, lower leg, foot)"
            };

            // Left Hand
            _bodyPartRegions["LeftHand"] = new BodyPartRegion
            {
                Name = "LeftHand",
                Bounds = new Rectangle(imgWidth / 2 - 75, 220, 25, 25),
                Description = "Left hand"
            };

            // Right Hand
            _bodyPartRegions["RightHand"] = new BodyPartRegion
            {
                Name = "RightHand",
                Bounds = new Rectangle(imgWidth / 2 + 50, 220, 25, 25),
                Description = "Right hand"
            };

            // Left Foot
            _bodyPartRegions["LeftFoot"] = new BodyPartRegion
            {
                Name = "LeftFoot",
                Bounds = new Rectangle(imgWidth / 2 - 45, 345, 30, 20),
                Description = "Left foot"
            };

            // Right Foot
            _bodyPartRegions["RightFoot"] = new BodyPartRegion
            {
                Name = "RightFoot",
                Bounds = new Rectangle(imgWidth / 2 + 15, 345, 30, 20),
                Description = "Right foot"
            };
        }

        private string? GetBodyPartAtPoint(Point imagePoint)
        {
            foreach (var kvp in _bodyPartRegions)
            {
                if (kvp.Value.Bounds.Contains(imagePoint))
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        private void ToggleBodyPartHighlight(string bodyPartName)
        {
            // Show message box with the clicked region name
            if (_bodyPartRegions.TryGetValue(bodyPartName, out BodyPartRegion region))
            {
                MessageBox.Show($"Selected: {region.Name}", "Anatomical Location",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Selected: {bodyPartName}", "Anatomical Location",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Trigger event for programmatic handling
            OnBodyPartSelected(bodyPartName, true);
        }

        private void PictureBoxEditor_MouseDown(object? sender, MouseEventArgs e)
        {
            if (_originalBitmap == null)
            {
                return;
            }

            // Check if clicking on a body part region (in selection mode)
            if (_bodyPartSelectionMode && e.Button == MouseButtons.Left)
            {
                Point clickImagePoint = ScreenToImageCoordinates(e.Location);
                string? clickedBodyPart = GetBodyPartAtPoint(clickImagePoint);

                if (clickedBodyPart != null)
                {
                    ToggleBodyPartHighlight(clickedBodyPart);
                    return;
                }
            }

            // Original drawing logic (when not in selection mode or click didn't hit a body part)
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _isDrawing = true;
            _lastPoint = e.Location;
            _currentStroke = new List<Point>();
            Point drawImagePoint = ScreenToImageCoordinates(e.Location);
            _currentStroke.Add(drawImagePoint);
        }

        private void PictureBoxEditor_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_isDrawing || _originalBitmap == null)
            {
                return;
            }

            Point currentImagePoint = ScreenToImageCoordinates(e.Location);
            _currentStroke.Add(currentImagePoint);
            RedrawCanvas();
            _lastPoint = e.Location;
        }

        private void PictureBoxEditor_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                if (_currentStroke.Count > 0)
                {
                    _strokeHistory.Add(new List<Point>(_currentStroke));
                    UpdateCoordinates();
                    SaveStateForUndo();
                    _redoStack.Clear();
                }
                _currentStroke.Clear();
            }
        }

        private void PictureBoxEditor_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (!Control.ModifierKeys.HasFlag(Keys.Control))
            {
                return;
            }

            if (e.Delta > 0)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }

            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void PictureBoxEditor_KeyDown(object? sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.Z)
                {
                    Undo();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Y)
                {
                    Redo();
                    e.Handled = true;
                }
            }
        }

        private void DrawLine(Graphics graphics, Point startPoint, Point endPoint)
        {
            using (Pen pen = new Pen(DRAW_COLOR, LINE_WIDTH))
            {
                pen.DashStyle = DASH_STYLE;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;
                graphics.DrawLine(pen, startPoint, endPoint);
            }
        }

        private void RedrawCanvas()
        {
            if (_originalBitmap == null)
            {
                return;
            }

            // Dispose previous display bitmap
            if (_displayBitmap != null)
            {
                _displayBitmap.Dispose();
            }

            // Create zoomed bitmap
            int newWidth = (int)(_originalBitmap.Width * _zoomFactor);
            int newHeight = (int)(_originalBitmap.Height * _zoomFactor);

            if (newWidth <= 0 || newHeight <= 0)
            {
                return;
            }

            _displayBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(_displayBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw original image scaled
                g.DrawImage(_originalBitmap, 0, 0, newWidth, newHeight);

                // Draw highlighted body parts
                DrawHighlightedBodyParts(g);

                // Draw all completed strokes scaled
                foreach (var stroke in _strokeHistory)
                {
                    DrawScaledStroke(g, stroke);
                }

                // Draw current stroke scaled
                if (_currentStroke.Count > 0)
                {
                    DrawScaledStroke(g, _currentStroke);
                }
            }

            pictureBoxEditor.Image = _displayBitmap;
            pictureBoxEditor.Invalidate();
        }

        private void DrawHighlightedBodyParts(Graphics graphics)
        {
            foreach (var bodyPartName in _highlightedBodyParts)
            {
                if (_bodyPartRegions.TryGetValue(bodyPartName, out BodyPartRegion region))
                {
                    Rectangle scaledBounds = ScaleRectangle(region.Bounds);
                    using (Brush brush = new SolidBrush(HIGHLIGHT_COLOR))
                    {
                        graphics.FillRectangle(brush, scaledBounds);
                    }
                    using (Pen pen = new Pen(Color.Yellow, 2))
                    {
                        graphics.DrawRectangle(pen, scaledBounds);
                    }
                }
            }
        }

        private Rectangle ScaleRectangle(Rectangle originalRect)
        {
            return new Rectangle(
                (int)(originalRect.X * _zoomFactor),
                (int)(originalRect.Y * _zoomFactor),
                (int)(originalRect.Width * _zoomFactor),
                (int)(originalRect.Height * _zoomFactor)
            );
        }



        private void UpdateCoordinates()
        {
            _coordinates.Clear();
            foreach (var stroke in _strokeHistory)
            {
                _coordinates.AddRange(stroke);
            }
        }

        private Point ScreenToImageCoordinates(Point screenPoint)
        {
            if (_originalBitmap == null || pictureBoxEditor.Image == null)
            {
                return screenPoint;
            }

            Rectangle imageRect = GetImageDisplayRectangle();

            if (imageRect.Width == 0 || imageRect.Height == 0)
            {
                return screenPoint;
            }

            // Calculate position within the displayed image rectangle
            float relativeX = screenPoint.X - imageRect.X;
            float relativeY = screenPoint.Y - imageRect.Y;

            // Get the actual displayed bitmap dimensions (with zoom applied)
            float displayedWidth = _originalBitmap.Width * _zoomFactor;
            float displayedHeight = _originalBitmap.Height * _zoomFactor;

            // Convert to scaled coordinates
            float scaledX = (relativeX / imageRect.Width) * displayedWidth;
            float scaledY = (relativeY / imageRect.Height) * displayedHeight;

            // Convert back to original image coordinates
            int imageX = (int)(scaledX / _zoomFactor);
            int imageY = (int)(scaledY / _zoomFactor);

            imageX = Math.Max(0, Math.Min(_originalBitmap.Width - 1, imageX));
            imageY = Math.Max(0, Math.Min(_originalBitmap.Height - 1, imageY));

            return new Point(imageX, imageY);
        }

        private Rectangle GetImageDisplayRectangle()
        {
            if (_originalBitmap == null)
            {
                return pictureBoxEditor.ClientRectangle;
            }

            // Use zoomed dimensions for display calculation
            float zoomedWidth = _originalBitmap.Width * _zoomFactor;
            float zoomedHeight = _originalBitmap.Height * _zoomFactor;

            float pictureBoxRatio = (float)pictureBoxEditor.Width / pictureBoxEditor.Height;
            float imageRatio = zoomedWidth / zoomedHeight;

            int displayWidth, displayHeight;
            int displayX, displayY;

            if (pictureBoxRatio > imageRatio)
            {
                displayHeight = pictureBoxEditor.Height;
                displayWidth = (int)(displayHeight * imageRatio);
                displayX = (pictureBoxEditor.Width - displayWidth) / 2;
                displayY = 0;
            }
            else
            {
                displayWidth = pictureBoxEditor.Width;
                displayHeight = (int)(displayWidth / imageRatio);
                displayX = 0;
                displayY = (pictureBoxEditor.Height - displayHeight) / 2;
            }

            return new Rectangle(displayX, displayY, displayWidth, displayHeight);
        }

        private void SaveStateForUndo()
        {
            List<List<Point>> state = new List<List<Point>>();
            foreach (var stroke in _strokeHistory)
            {
                state.Add(new List<Point>(stroke));
            }
            _undoStack.Push(state);

            // Limit undo stack size to prevent memory issues
            if (_undoStack.Count > 50)
            {
                // Remove oldest item (bottom of stack)
                List<List<Point>>[] array = _undoStack.ToArray();

                _undoStack.Clear();
                // Push back from newest to oldest (excluding the oldest one)
                for (int i = array.Length - 1; i >= 1; i--)
                {
                    _undoStack.Push(array[i]);
                }
            }
        }

        private void Undo()
        {
            if (_undoStack.Count > 1)
            {
                List<List<Point>> currentState = new List<List<Point>>();
                foreach (var stroke in _strokeHistory)
                {
                    currentState.Add(new List<Point>(stroke));
                }
                _redoStack.Push(currentState);

                _undoStack.Pop(); // Remove current state
                List<List<Point>> previousState = _undoStack.Peek();
                RestoreState(previousState);
            }
        }

        private void Redo()
        {
            if (_redoStack.Count > 0)
            {
                List<List<Point>> nextState = _redoStack.Pop();
                _undoStack.Push(nextState);
                RestoreState(nextState);
            }
        }

        private void RestoreState(List<List<Point>> state)
        {
            _strokeHistory.Clear();
            foreach (var stroke in state)
            {
                _strokeHistory.Add(new List<Point>(stroke));
            }
            UpdateCoordinates();
            RedrawCanvas();
        }

        private void ZoomIn()
        {
            if (_zoomFactor < MAX_ZOOM)
            {
                _zoomFactor = Math.Min(MAX_ZOOM, _zoomFactor + ZOOM_STEP);
                RedrawCanvas();
            }
        }

        private void ZoomOut()
        {
            if (_zoomFactor > MIN_ZOOM)
            {
                _zoomFactor = Math.Max(MIN_ZOOM, _zoomFactor - ZOOM_STEP);
                RedrawCanvas();
            }
        }

        private void DrawScaledStroke(Graphics graphics, List<Point> stroke)
        {
            if (stroke.Count < 2)
            {
                return;
            }

            for (int i = 0; i < stroke.Count - 1; i++)
            {
                Point scaledStart = ScalePoint(stroke[i]);
                Point scaledEnd = ScalePoint(stroke[i + 1]);
                DrawLine(graphics, scaledStart, scaledEnd);
            }
        }

        private Point ScalePoint(Point originalPoint)
        {
            return new Point(
                (int)(originalPoint.X * _zoomFactor),
                (int)(originalPoint.Y * _zoomFactor)
            );
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point[] Coordinates
        {
            get
            {
                return _coordinates.ToArray();
            }
            set
            {
                if (value == null)
                {
                    _coordinates.Clear();
                    _strokeHistory.Clear();
                }
                else
                {
                    _coordinates = new List<Point>(value);
                    // For simplicity, treat all coordinates as one continuous stroke
                    // You can modify this if you need stroke separation
                    _strokeHistory.Clear();
                    if (_coordinates.Count > 0)
                    {
                        _strokeHistory.Add(new List<Point>(_coordinates));
                    }
                }
                RedrawCanvas();
                SaveStateForUndo();
            }
        }

        // Body part properties and methods
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BodyPartSelectionMode
        {
            get
            {
                return _bodyPartSelectionMode;
            }
            set
            {
                _bodyPartSelectionMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] HighlightedBodyParts
        {
            get
            {
                return _highlightedBodyParts.ToArray();
            }
            set
            {
                _highlightedBodyParts.Clear();
                if (value != null)
                {
                    foreach (var part in value)
                    {
                        if (_bodyPartRegions.ContainsKey(part))
                        {
                            _highlightedBodyParts.Add(part);
                        }
                    }
                }
                RedrawCanvas();
            }
        }

        public void HighlightBodyPart(string bodyPartName)
        {
            if (_bodyPartRegions.ContainsKey(bodyPartName))
            {
                _highlightedBodyParts.Add(bodyPartName);
                RedrawCanvas();
            }
        }

        public void UnhighlightBodyPart(string bodyPartName)
        {
            _highlightedBodyParts.Remove(bodyPartName);
            RedrawCanvas();
        }

        public void ClearAllHighlights()
        {
            _highlightedBodyParts.Clear();
            RedrawCanvas();
        }

        public bool IsBodyPartHighlighted(string bodyPartName)
        {
            return _highlightedBodyParts.Contains(bodyPartName);
        }

        public BodyPartRegion? GetBodyPartRegion(string bodyPartName)
        {
            _bodyPartRegions.TryGetValue(bodyPartName, out BodyPartRegion region);
            return region;
        }

        public Dictionary<string, BodyPartRegion> GetAllBodyPartRegions()
        {
            return new Dictionary<string, BodyPartRegion>(_bodyPartRegions);
        }

        public void SetBodyPartRegion(string bodyPartName, BodyPartRegion region)
        {
            _bodyPartRegions[bodyPartName] = region;
            RedrawCanvas();
        }

        public void AddBodyPartRegion(string bodyPartName, BodyPartRegion region)
        {
            _bodyPartRegions[bodyPartName] = region;
            RedrawCanvas();
        }

        public void RemoveBodyPartRegion(string bodyPartName)
        {
            _bodyPartRegions.Remove(bodyPartName);
            _highlightedBodyParts.Remove(bodyPartName);
            RedrawCanvas();
        }

        // CSV Export/Import methods
        public string GetHighlightedBodyPartsAsCSV()
        {
            return string.Join(",", _highlightedBodyParts);
        }

        public void SetHighlightedBodyPartsFromCSV(string csv)
        {
            if (string.IsNullOrWhiteSpace(csv))
            {
                _highlightedBodyParts.Clear();
            }
            else
            {
                string[] parts = csv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                _highlightedBodyParts.Clear();
                foreach (var part in parts)
                {
                    string trimmedPart = part.Trim();
                    if (_bodyPartRegions.ContainsKey(trimmedPart))
                    {
                        _highlightedBodyParts.Add(trimmedPart);
                    }
                }
            }
            RedrawCanvas();
        }

        public string GetAllBodyPartsAsCSV()
        {
            return string.Join(",", _bodyPartRegions.Keys);
        }

        public void SetBodyPartsSelectionFromCSV(string csv)
        {
            if (string.IsNullOrWhiteSpace(csv))
            {
                _highlightedBodyParts.Clear();
            }
            else
            {
                string[] parts = csv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                _highlightedBodyParts.Clear();
                foreach (var part in parts)
                {
                    string trimmedPart = part.Trim();
                    if (_bodyPartRegions.ContainsKey(trimmedPart))
                    {
                        _highlightedBodyParts.Add(trimmedPart);
                    }
                }
            }
            RedrawCanvas();
        }

        // File-based CSV export/import
        public void ExportHighlightedBodyPartsToCSV(string filePath)
        {
            try
            {
                string csv = GetHighlightedBodyPartsAsCSV();
                File.WriteAllText(filePath, csv);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export CSV: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImportHighlightedBodyPartsFromCSV(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string csv = File.ReadAllText(filePath);
                    SetHighlightedBodyPartsFromCSV(csv);
                }
                else
                {
                    MessageBox.Show($"File not found: {filePath}", "Import Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to import CSV: {ex.Message}", "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CSV with selection status (BodyPartName,true/false format)
        public string GetBodyPartsWithSelectionStatusAsCSV()
        {
            var lines = new List<string>();
            foreach (var kvp in _bodyPartRegions.OrderBy(x => x.Key))
            {
                bool isSelected = _highlightedBodyParts.Contains(kvp.Key);
                lines.Add($"{kvp.Key},{isSelected.ToString().ToLower()}");
            }
            return string.Join(Environment.NewLine, lines);
        }

        public void SetBodyPartsFromSelectionStatusCSV(string csv)
        {
            if (string.IsNullOrWhiteSpace(csv))
            {
                _highlightedBodyParts.Clear();
            }
            else
            {
                _highlightedBodyParts.Clear();
                string[] lines = csv.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2)
                    {
                        string bodyPartName = parts[0].Trim();
                        bool isSelected = parts[1].Trim().Equals("true", StringComparison.OrdinalIgnoreCase);

                        if (_bodyPartRegions.ContainsKey(bodyPartName) && isSelected)
                        {
                            _highlightedBodyParts.Add(bodyPartName);
                        }
                    }
                }
            }
            RedrawCanvas();
        }

        public void ExportBodyPartsWithSelectionStatusToCSV(string filePath)
        {
            try
            {
                string csv = GetBodyPartsWithSelectionStatusAsCSV();
                File.WriteAllText(filePath, csv);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export CSV: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImportBodyPartsWithSelectionStatusFromCSV(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string csv = File.ReadAllText(filePath);
                    SetBodyPartsFromSelectionStatusCSV(csv);
                }
                else
                {
                    MessageBox.Show($"File not found: {filePath}", "Import Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to import CSV: {ex.Message}", "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public event EventHandler<BodyPartSelectedEventArgs>? BodyPartSelected;

        protected virtual void OnBodyPartSelected(string bodyPartName, bool isSelected)
        {
            BodyPartSelected?.Invoke(this, new BodyPartSelectedEventArgs(bodyPartName, isSelected));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_displayBitmap != null)
                {
                    _displayBitmap.Dispose();
                }
                if (_originalBitmap != null)
                {
                    _originalBitmap.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void AnatomicalLocationPickerUserControl_Load_1(object sender, EventArgs e)
        {

        }
    }

    // Supporting classes for body part functionality
    public class BodyPartRegion
    {
        public string Name { get; set; } = string.Empty;
        public Rectangle Bounds { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class BodyPartSelectedEventArgs : EventArgs
    {
        public string BodyPartName { get; }
        public bool IsSelected { get; }

        public BodyPartSelectedEventArgs(string bodyPartName, bool isSelected)
        {
            BodyPartName = bodyPartName;
            IsSelected = isSelected;
        }
    }
}
