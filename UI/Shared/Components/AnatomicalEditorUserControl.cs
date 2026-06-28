using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace ABMS_2026.UI.Shared.Components
{
    public partial class AnatomicalEditorUserControl : UserControl
    {
        private readonly List<PointF> _markers = new();

        public AnatomicalEditorUserControl()
        {
            InitializeComponent();

            pictureBoxAnatomical.Cursor = Cursors.Cross;
            pictureBoxAnatomical.MouseClick += PictureBoxAnatomical_MouseClick;
            pictureBoxAnatomical.Paint += PictureBoxAnatomical_Paint;
            pictureBoxAnatomical.Resize += (_, __) => pictureBoxAnatomical.Invalidate();
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
            _markers.Clear();
            pictureBoxAnatomical.Invalidate();
        }

        public void SetMarkers(IEnumerable<PointF> markers)
        {
            _markers.Clear();
            if (markers != null)
                _markers.AddRange(markers);

            pictureBoxAnatomical.Invalidate();
        }

        public void AddMarker(PointF imagePoint)
        {
            _markers.Add(imagePoint);
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

        private void PictureBoxAnatomical_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBoxAnatomical.Image == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                PointF? imagePoint = ControlPointToImagePoint(e.Location);
                if (imagePoint.HasValue)
                {
                    _markers.Add(imagePoint.Value);
                    pictureBoxAnatomical.Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
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

            if (nearest.HasValue && nearestDistance <= 15)
            {
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

                const int radius = 6;
                Rectangle rect = new Rectangle(p.X - radius, p.Y - radius, radius * 2, radius * 2);

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