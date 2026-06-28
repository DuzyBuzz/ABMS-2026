namespace ABMS_2026.UI.UserControls
{
    partial class ExposureMonitoringUserControl
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
            this.moduleUserControl1 = new ABMS_2026.UI.Shared.Components.ModuleUserControl();
            this.SuspendLayout();
            // 
            // moduleUserControl1
            // 
            this.moduleUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleUserControl1.Location = new System.Drawing.Point(0, 0);
            this.moduleUserControl1.Name = "moduleUserControl1";
            this.moduleUserControl1.Size = new System.Drawing.Size(1140, 800);
            this.moduleUserControl1.TabIndex = 0;
            // 
            // ExposureMonitoringUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moduleUserControl1);
            this.Name = "ExposureMonitoringUserControl";
            this.Size = new System.Drawing.Size(1140, 800);
            this.ResumeLayout(false);

        }

        #endregion

        private ABMS_2026.UI.Shared.Components.ModuleUserControl moduleUserControl1;
    }
}
