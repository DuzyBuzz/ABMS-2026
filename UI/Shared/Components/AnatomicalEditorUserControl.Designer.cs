namespace ABMS_2026.UI.Shared.Components
{
    partial class AnatomicalEditorUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBoxAnatomical;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnatomicalEditorUserControl));
            pictureBoxAnatomical = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAnatomical).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxAnatomical
            // 
            pictureBoxAnatomical.Dock = DockStyle.Fill;
            pictureBoxAnatomical.Image = (Image)resources.GetObject("pictureBoxAnatomical.Image");
            pictureBoxAnatomical.Location = new Point(0, 0);
            pictureBoxAnatomical.Name = "pictureBoxAnatomical";
            pictureBoxAnatomical.Size = new Size(796, 375);
            pictureBoxAnatomical.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAnatomical.TabIndex = 0;
            pictureBoxAnatomical.TabStop = false;
            // 
            // AnatomicalEditorUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBoxAnatomical);
            Name = "AnatomicalEditorUserControl";
            Size = new Size(796, 375);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAnatomical).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}