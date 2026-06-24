using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashCap;

namespace ENT_Clinic_System.Helpers
{
    public partial class PatientCamera : Form
    {
        private CaptureDevice? videoSource;
        private CaptureDeviceDescriptor[]? videoDevices;
        private Bitmap? currentFrame;
        private Image? capturedImage;

        public Image? CapturedImage => capturedImage;

        public PatientCamera()
        {
            InitializeComponent();

            // Keep preview sharp on screen
            pictureBoxLive.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCaptured.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void PatientCamera_Load(object sender, EventArgs e)
        {
            try
            {
                var devices = new CaptureDevices();
                videoDevices = devices.EnumerateDescriptors().ToArray();

                comboBoxCameras.Items.Clear();

                if (videoDevices.Length == 0)
                {
                    MessageBox.Show("No webcam detected.", "Camera Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                foreach (var device in videoDevices)
                {
                    comboBoxCameras.Items.Add(device.Name);
                }

                // This will trigger SelectedIndexChanged once and start the camera
                comboBoxCameras.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cameras: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCameras.SelectedIndex >= 0)
            {
                await StartCameraAsync(comboBoxCameras.SelectedIndex);
            }
        }

        private async Task StartCameraAsync(int index)
        {
            try
            {
                await StopCameraAsync();

                if (videoDevices is null || index < 0 || index >= videoDevices.Length)
                    return;

                var device = videoDevices[index];
                var characteristics = device.Characteristics;

                if (characteristics == null || characteristics.Length == 0)
                {
                    MessageBox.Show("No video formats available.", "Camera Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pick the highest resolution format available
                var bestFormat = characteristics
                    .OrderByDescending(GetFormatScore)
                    .First();

                videoSource = await device.OpenAsync(bestFormat, bufferScope =>
                {
                    try
                    {
                        byte[] imageData = bufferScope.Buffer.ExtractImage();

                        using var ms = new MemoryStream(imageData);
                        using var bitmap = new Bitmap(ms);

                        // Keep a full-size copy for capture
                        var fullFrame = new Bitmap(bitmap);

                        // Create a smaller preview image for the live picture box
                        Bitmap previewFrame = CreatePreviewImage(fullFrame, pictureBoxLive.Width, pictureBoxLive.Height);

                        BeginInvoke(new Action(() =>
                        {
                            if (IsDisposed)
                            {
                                previewFrame.Dispose();
                                fullFrame.Dispose();
                                return;
                            }

                            var oldPreview = pictureBoxLive.Image;
                            pictureBoxLive.Image = previewFrame;
                            oldPreview?.Dispose();

                            currentFrame?.Dispose();
                            currentFrame = fullFrame;
                        }));
                    }
                    catch
                    {
                        // Ignore bad frames
                    }
                });

                await videoSource.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to start camera: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFrame is null)
                {
                    MessageBox.Show("No live image available to capture.", "Capture Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Store the full-resolution image for return to the parent form
                capturedImage?.Dispose();
                capturedImage = new Bitmap(currentFrame);

                // Show a preview without reducing the actual captured quality
                var preview = CreatePreviewImage(capturedImage, pictureBoxCaptured.Width, pictureBoxCaptured.Height);
                var oldCaptured = pictureBoxCaptured.Image;
                pictureBoxCaptured.Image = preview;
                oldCaptured?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Capture failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (capturedImage is not null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please capture an image before confirming.", "No Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task StopCameraAsync()
        {
            try
            {
                if (videoSource != null)
                {
                    await videoSource.StopAsync();
                    videoSource.Dispose();
                    videoSource = null;
                }
            }
            catch
            {
                // Ignore stop errors
            }
        }

        private async void PatientCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            await StopCameraAsync();

            var live = pictureBoxLive.Image;
            pictureBoxLive.Image = null;
            live?.Dispose();

            var captured = pictureBoxCaptured.Image;
            pictureBoxCaptured.Image = null;
            captured?.Dispose();

            currentFrame?.Dispose();
            currentFrame = null;

            // Do not dispose capturedImage here.
            // It is returned to the parent form through DialogResult.OK.
        }

        private static Bitmap CreatePreviewImage(Image source, int width, int height)
        {
            if (width <= 0) width = 1;
            if (height <= 0) height = 1;

            var preview = new Bitmap(width, height);
            using (var g = Graphics.FromImage(preview))
            {
                g.Clear(Color.Black);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(source, 0, 0, width, height);
            }

            return preview;
        }

        private static int GetFormatScore(object format)
        {
            // Tries several possible property names so this survives FlashCap version differences.
            int width = GetIntProperty(format, "Width", "width");
            int height = GetIntProperty(format, "Height", "height");

            if (width <= 0 || height <= 0)
            {
                var frameSize = GetObjectProperty(format, "FrameSize", "Size", "Resolution");
                if (frameSize != null)
                {
                    width = GetIntProperty(frameSize, "Width", "width");
                    height = GetIntProperty(frameSize, "Height", "height");
                }
            }

            if (width <= 0 || height <= 0)
                return 0;

            return width * height;
        }

        private static int GetIntProperty(object obj, params string[] names)
        {
            var type = obj.GetType();

            foreach (var name in names)
            {
                var prop = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null)
                {
                    var value = prop.GetValue(obj);
                    if (value is int i)
                        return i;

                    if (value != null && int.TryParse(value.ToString(), out int parsed))
                        return parsed;
                }
            }

            return 0;
        }

        private static object? GetObjectProperty(object obj, params string[] names)
        {
            var type = obj.GetType();

            foreach (var name in names)
            {
                var prop = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null)
                    return prop.GetValue(obj);
            }

            return null;
        }
    }
}