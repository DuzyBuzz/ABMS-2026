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
            pictureBoxEditor = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditor).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxEditor
            // 
            pictureBoxEditor.BackColor = System.Drawing.Color.White;
            pictureBoxEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBoxEditor.Location = new System.Drawing.Point(0, 0);
            pictureBoxEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBoxEditor.Name = "pictureBoxEditor";
            pictureBoxEditor.Size = new System.Drawing.Size(700, 577);
            pictureBoxEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxEditor.TabIndex = 0;
            pictureBoxEditor.TabStop = true;
            // 
            // PanAndZoomPictureBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pictureBoxEditor);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "PanAndZoomPictureBox";
            Size = new System.Drawing.Size(700, 577);
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditor).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBoxEditor;
    }
}