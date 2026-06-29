using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace ABMS_2026.UI.Shared.Components
{
    public partial class AnatomicalEditorUserControl : UserControl
    {
        private readonly List<PointF> _markers = new();
        private readonly List<List<PointF>> _undoStack = new();
        private readonly List<List<PointF>> _redoStack = new();

        private const int MaxHistorySize = 50;
        private const int MarkerRadius = 6;
        private const int RemoveDistanceThreshold = 15;

        private bool _keyboardArmed;

        public AnatomicalEditorUserControl()
        {
            InitializeComponent();

            // Make the user control focusable so it can receive Ctrl+Z / Ctrl+Y.
            SetStyle(ControlStyles.Selectable, true);
            TabStop = true;

            Cursor = Cursors.Cross;
            pictureBoxAnatomical.Cursor = Cursors.Cross;

            pictureBoxAnatomical.MouseDown += PictureBoxAnatomical_MouseDown;
            pictureBoxAnatomical.MouseClick += PictureBoxAnatomical_MouseClick;
            pictureBoxAnatomical.Paint += PictureBoxAnatomical_Paint;
            pictureBoxAnatomical.Resize += (_, __) => pictureBoxAnatomical.Invalidate();

            Enter += (_, __) => ArmKeyboard();
            Leave += (_, __) => DisarmKeyboard();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image AnatomicalImage
        {
            get => pictureBoxAnatomical.Image;
            set
            {
                pictureBoxAnatomical.Image = value;
                pictureBoxAnatomical.Invalidate();
            }
        }

        public IReadOnlyList<PointF> Markers => _markers.AsReadOnly();

        public void ClearMarkers()
        {
            if (_markers.Count == 0)
                return;

            SaveState();
            _markers.Clear();
            pictureBoxAnatomical.Invalidate();
        }

        public void SetMarkers(IEnumerable<PointF> markers)
        {
            SaveState();
            _markers.Clear();

            if (markers != null)
                _markers.AddRange(markers);

            pictureBoxAnatomical.Invalidate();
        }

        public void AddMarker(PointF imagePoint)
        {
            SaveState();
            _markers.Add(imagePoint);
            pictureBoxAnatomical.Invalidate();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0)
                return;

            _redoStack.Add(new List<PointF>(_markers));

            var previous = _undoStack[^1];
            _undoStack.RemoveAt(_undoStack.Count - 1);

            _markers.Clear();
            _markers.AddRange(previous);

            pictureBoxAnatomical.Invalidate();
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
                return;

            _undoStack.Add(new List<PointF>(_markers));

            var next = _redoStack[^1];
            _redoStack.RemoveAt(_redoStack.Count - 1);

            _markers.Clear();
            _markers.AddRange(next);

            pictureBoxAnatomical.Invalidate();
        }

        public Bitmap ExportAnnotatedImage()
        {
            if (pictureBoxAnatomical.Image == null)
                return null;

            Bitmap bmp = new Bitmap(pictureBoxAnatomical.Width, pictureBoxAnatomical.Height);
            pictureBoxAnatomical.DrawToBitmap(bmp, pictureBoxAnatomical.ClientRectangle);
            return bmp;
        }

        private void ArmKeyboard()
        {
            _keyboardArmed = true;
        }

        private void DisarmKeyboard()
        {
            _keyboardArmed = false;
        }

        private void PictureBoxAnatomical_MouseDown(object sender, MouseEventArgs e)
        {
            // This is the important part: make the control active when the image is clicked.
            ArmKeyboard();
            Focus();
        }

        private void SaveState()
        {
            _undoStack.Add(new List<PointF>(_markers));
            _redoStack.Clear();

            if (_undoStack.Count > MaxHistorySize)
                _undoStack.RemoveAt(0);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Only handle shortcuts when this control is the active editor.
            if (_keyboardArmed)
            {
                if (keyData == (Keys.Control | Keys.Z))
                {
                    Undo();
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Y))
                {
                    Redo();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PictureBoxAnatomical_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBoxAnatomical.Image == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                PointF? imagePoint = ControlPointToImagePoint(e.Location);
                if (imagePoint.HasValue)
                {
                    ArmKeyboard();
                    AddMarker(imagePoint.Value);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ArmKeyboard();
                RemoveNearestMarker(e.Location);
            }
        }

        private void RemoveNearestMarker(Point clickPoint)
        {
            if (pictureBoxAnatomical.Image == null || _markers.Count == 0)
                return;

            PointF? nearest = null;
            double nearestDistance = double.MaxValue;

            foreach (var marker in _markers)
            {
                Point markerControlPoint = ImagePointToControlPoint(marker);
                double distance = Distance(clickPoint, markerControlPoint);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearest = marker;
                }
            }

            if (nearest.HasValue && nearestDistance <= RemoveDistanceThreshold)
            {
                SaveState();
                _markers.Remove(nearest.Value);
                pictureBoxAnatomical.Invalidate();
            }
        }

        private void PictureBoxAnatomical_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBoxAnatomical.Image == null || _markers.Count == 0)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var fillBrush = new SolidBrush(Color.FromArgb(180, Color.Red));
            using var borderPen = new Pen(Color.Red, 1.5f);

            foreach (var marker in _markers)
            {
                Point p = ImagePointToControlPoint(marker);

                Rectangle rect = new Rectangle(
                    p.X - MarkerRadius,
                    p.Y - MarkerRadius,
                    MarkerRadius * 2,
                    MarkerRadius * 2);

                e.Graphics.FillEllipse(fillBrush, rect);
                e.Graphics.DrawEllipse(borderPen, rect);
            }
        }

        private PointF? ControlPointToImagePoint(Point controlPoint)
        {
            Rectangle imageRect = GetImageDisplayRectangle();
            if (imageRect.Width <= 0 || imageRect.Height <= 0)
                return null;

            if (!imageRect.Contains(controlPoint))
                return null;

            Image img = pictureBoxAnatomical.Image;

            float x = (controlPoint.X - imageRect.X) * img.Width / (float)imageRect.Width;
            float y = (controlPoint.Y - imageRect.Y) * img.Height / (float)imageRect.Height;

            return new PointF(x, y);
        }

        private Point ImagePointToControlPoint(PointF imagePoint)
        {
            Rectangle imageRect = GetImageDisplayRectangle();
            if (imageRect.Width <= 0 || imageRect.Height <= 0 || pictureBoxAnatomical.Image == null)
                return Point.Empty;

            Image img = pictureBoxAnatomical.Image;

            float x = imageRect.X + (imagePoint.X * imageRect.Width / img.Width);
            float y = imageRect.Y + (imagePoint.Y * imageRect.Height / img.Height);

            return new Point((int)Math.Round(x), (int)Math.Round(y));
        }

        private Rectangle GetImageDisplayRectangle()
        {
            if (pictureBoxAnatomical.Image == null)
                return Rectangle.Empty;

            if (pictureBoxAnatomical.SizeMode != PictureBoxSizeMode.Zoom &&
                pictureBoxAnatomical.SizeMode != PictureBoxSizeMode.Normal)
            {
                return pictureBoxAnatomical.ClientRectangle;
            }

            Image img = pictureBoxAnatomical.Image;
            Rectangle client = pictureBoxAnatomical.ClientRectangle;

            if (img.Width == 0 || img.Height == 0 || client.Width == 0 || client.Height == 0)
                return Rectangle.Empty;

            float imageAspect = img.Width / (float)img.Height;
            float clientAspect = client.Width / (float)client.Height;

            int drawWidth;
            int drawHeight;
            int offsetX;
            int offsetY;

            if (imageAspect > clientAspect)
            {
                drawWidth = client.Width;
                drawHeight = (int)(client.Width / imageAspect);
                offsetX = 0;
                offsetY = (client.Height - drawHeight) / 2;
            }
            else
            {
                drawHeight = client.Height;
                drawWidth = (int)(client.Height * imageAspect);
                offsetX = (client.Width - drawWidth) / 2;
                offsetY = 0;
            }

            return new Rectangle(offsetX, offsetY, drawWidth, drawHeight);
        }

        private static double Distance(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}