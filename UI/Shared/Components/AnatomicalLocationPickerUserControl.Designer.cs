namespace ABMS_2026.UI.Shared.Components
{
    partial class AnatomicalLocationPickerUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnatomicalLocationPickerUserControl));
            pictureBoxEditor = new Emgu.CV.UI.PanAndZoomPictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditor).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxEditor
            // 
            pictureBoxEditor.Dock = DockStyle.Fill;
            pictureBoxEditor.Image = (Image)resources.GetObject("pictureBoxEditor.Image");
            pictureBoxEditor.Location = new Point(0, 0);
            pictureBoxEditor.Name = "pictureBoxEditor";
            pictureBoxEditor.Size = new Size(700, 577);
            pictureBoxEditor.TabIndex = 1;
            pictureBoxEditor.TabStop = false;
            // 
            // AnatomicalLocationPickerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBoxEditor);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AnatomicalLocationPickerUserControl";
            Size = new Size(700, 577);
            Load += AnatomicalLocationPickerUserControl_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditor).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.PanAndZoomPictureBox pictureBoxEditor;
    }
}
