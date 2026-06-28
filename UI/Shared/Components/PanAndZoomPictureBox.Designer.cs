namespace ABMS_2026.UI.Shared.Components
{
    partial class PanAndZoomPictureBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanAndZoomPictureBox));
            pictureBoxEditor = new PictureBox();
            contextMenuStrip = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditor).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxEditor
            // 
            pictureBoxEditor.BackColor = Color.White;
            pictureBoxEditor.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEditor.Dock = DockStyle.Fill;
            pictureBoxEditor.Image = (Image)resources.GetObject("pictureBoxEditor.Image");
            pictureBoxEditor.Location = new Point(0, 0);
            pictureBoxEditor.Margin = new Padding(4, 3, 4, 3);
            pictureBoxEditor.Name = "pictureBoxEditor";
            pictureBoxEditor.Size = new Size(700, 577);
            pictureBoxEditor.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEditor.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(61, 4);
            // 
            // PanAndZoomPictureBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBoxEditor);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PanAndZoomPictureBox";
            Size = new Size(700, 577);
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditor).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBoxEditor;
        private ContextMenuStrip contextMenuStrip;
    }
}