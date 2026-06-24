using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ABMS_2026.UI.Shared.Components
{
    public partial class PanAndZoomPictureBox : UserControl
    {
        private Bitmap? _originalBitmap;
        private Bitmap? _displayBitmap;
        private float _zoomFactor = 1.0f;
        private const float MIN_ZOOM = 0.1f;
        private const float MAX_ZOOM = 5.0f;
        private const float ZOOM_STEP = 0.1f;
        
        // Editing state
        private List<Point> _clickedPoints = new List<Point>();
        private bool _isFocused = false;
        
        // Undo/Redo stacks
        private Stack<List<Point>> _undoStack = new Stack<List<Point>>();
        private Stack<List<Point>> _redoStack = new Stack<List<Point>>();
        
        // Drawing settings
        private static readonly Color MARKER_COLOR = Color.Red;
        private const int MARKER_SIZE = 10;

        public PanAndZoomPictureBox()
        {
            InitializeComponent();
            SetControlProperties();
            HookupEvents();
        }

        private void SetControlProperties()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.BackColor = Color.White;
        }

        private void HookupEvents()
        {
            pictureBoxEditor.MouseDown += PictureBoxEditor_MouseDown;
            pictureBoxEditor.MouseWheel += PictureBoxEditor_MouseWheel;
            pictureBoxEditor.Enter += PictureBoxEditor_Enter;
            pictureBoxEditor.Leave += PictureBoxEditor_Leave;
            pictureBoxEditor.KeyDown += PictureBoxEditor_KeyDown;
            pictureBoxEditor.Click += PictureBoxEditor_Click;
            this.Load += PanAndZoomPictureBox_Load;
        }

        private void PictureBoxEditor_Click(object? sender, EventArgs e)
        {
            pictureBoxEditor.Focus();
        }

        private void PictureBoxEditor_Enter(object? sender, EventArgs e)
        {
            _isFocused = true;
            pictureBoxEditor.BackColor = Color.LightBlue;
        }

        private void PictureBoxEditor_Leave(object? sender, EventArgs e)
        {
            _isFocused = false;
            pictureBoxEditor.BackColor = Color.White;
        }

        private void PanAndZoomPictureBox_Load(object? sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                pictureBoxEditor.Focus();
            }
        }

        public void SetImage(Image image)
        {
            if (_originalBitmap != null)
            {
                _originalBitmap.Dispose();
            }
            
            _originalBitmap = new Bitmap(image);
            pictureBoxEditor.Image = _originalBitmap;
            _clickedPoints.Clear();
            _undoStack.Clear();
            _redoStack.Clear();
            SaveStateForUndo();
            RedrawCanvas();
        }

        private void PictureBoxEditor_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!_isFocused)
            {
                return;
            }

            if (e.Button == MouseButtons.Left && _originalBitmap != null)
            {
                Point clickImagePoint = ScreenToImageCoordinates(e.Location);
                
                // Only add point if it's within image bounds
                if (clickImagePoint.X >= 0 && clickImagePoint.X < _originalBitmap.Width &&
                    clickImagePoint.Y >= 0 && clickImagePoint.Y < _originalBitmap.Height)
                {
                    _clickedPoints.Add(clickImagePoint);
                    SaveStateForUndo();
                    _redoStack.Clear();
                    RedrawCanvas();
                }
            }
        }

        private void PictureBoxEditor_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (!_isFocused)
            {
                return;
            }

            // Only zoom if Ctrl key is pressed
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
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
            // Don't scroll when wheel is used without Ctrl
        }

        private void PictureBoxEditor_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!_isFocused)
            {
                return;
            }

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
                
                // Draw all clicked points scaled
                foreach (var point in _clickedPoints)
                {
                    Point scaledPoint = ScalePoint(point);
                    DrawMarker(g, scaledPoint);
                }
            }

            pictureBoxEditor.Image = _displayBitmap;
            pictureBoxEditor.Invalidate();
        }

        private void DrawMarker(Graphics graphics, Point point)
        {
            using (Brush brush = new SolidBrush(MARKER_COLOR))
            {
                graphics.FillEllipse(brush, 
                    point.X - MARKER_SIZE, 
                    point.Y - MARKER_SIZE, 
                    MARKER_SIZE * 2, 
                    MARKER_SIZE * 2);
            }
        }

        private Point ScalePoint(Point originalPoint)
        {
            return new Point(
                (int)(originalPoint.X * _zoomFactor),
                (int)(originalPoint.Y * _zoomFactor)
            );
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
            List<Point> state = new List<Point>(_clickedPoints);
            _undoStack.Push(state);
            
            // Limit undo stack size to prevent memory issues
            if (_undoStack.Count > 50)
            {
                List<Point>[] array = _undoStack.ToArray();
                _undoStack.Clear();
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
                List<Point> currentState = new List<Point>(_clickedPoints);
                _redoStack.Push(currentState);
                
                _undoStack.Pop();
                List<Point> previousState = _undoStack.Peek();
                _clickedPoints = new List<Point>(previousState);
                RedrawCanvas();
            }
        }

        private void Redo()
        {
            if (_redoStack.Count > 0)
            {
                List<Point> nextState = _redoStack.Pop();
                _undoStack.Push(nextState);
                _clickedPoints = new List<Point>(nextState);
                RedrawCanvas();
            }
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point[] ClickedPoints
        {
            get
            {
                return _clickedPoints.ToArray();
            }
            set
            {
                if (value == null)
                {
                    _clickedPoints.Clear();
                }
                else
                {
                    _clickedPoints = new List<Point>(value);
                }
                SaveStateForUndo();
                RedrawCanvas();
            }
        }

        public void ClearPoints()
        {
            _clickedPoints.Clear();
            SaveStateForUndo();
            RedrawCanvas();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_displayBitmap != null)
                {
                    _displayBitmap.Dispose();
                    _displayBitmap = null;
                }
                if (_originalBitmap != null)
                {
                    _originalBitmap.Dispose();
                    _originalBitmap = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}