namespace ABMS_2026.UI.Shared.Components
{
    partial class AnatomicalEditorUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnatomicalEditorUserControl));
            panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panAndZoomPictureBox1
            // 
            panAndZoomPictureBox1.Dock = DockStyle.Fill;
            panAndZoomPictureBox1.Image = (Image)resources.GetObject("panAndZoomPictureBox1.Image");
            panAndZoomPictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            panAndZoomPictureBox1.Location = new Point(0, 0);
            panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            panAndZoomPictureBox1.Size = new Size(796, 375);
            panAndZoomPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            panAndZoomPictureBox1.TabIndex = 0;
            panAndZoomPictureBox1.TabStop = false;
            // 
            // AnatomicalEditorUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panAndZoomPictureBox1);
            Name = "AnatomicalEditorUserControl";
            Size = new Size(796, 375);
            ((System.ComponentModel.ISupportInitialize)panAndZoomPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
    }
}
