using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    partial class InventoryTransactionsUserControl
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
            moduleUserControl = new ABMS_2026.UI.Shared.Components.ModuleUserControl();
            SuspendLayout();
            // 
            // moduleUserControl
            // 
            moduleUserControl.BackColor = Color.White;
            moduleUserControl.Dock = DockStyle.Fill;
            moduleUserControl.Font = new Font("Segoe UI", 9F);
            moduleUserControl.Location = new Point(0, 0);
            moduleUserControl.Name = "moduleUserControl";
            moduleUserControl.Size = new Size(1140, 750);
            moduleUserControl.TabIndex = 0;
            // 
            // InventoryTransactionsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(moduleUserControl);
            Name = "InventoryTransactionsUserControl";
            Size = new Size(1140, 750);
            Load += InventoryTransactionsUserControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Shared.Components.ModuleUserControl moduleUserControl;
    }
}
