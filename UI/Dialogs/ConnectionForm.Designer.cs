namespace ABMS_2026.UI.Dialogs
{
    partial class ConnectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label connectionStringLabel;
        private TextBox connectionStringTextBox;
        private Button testButton;
        private Button saveButton;
        private Button cancelButton;
        private Label statusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.connectionStringLabel = new Label();
            this.connectionStringTextBox = new TextBox();
            this.testButton = new Button();
            this.saveButton = new Button();
            this.cancelButton = new Button();
            this.statusLabel = new Label();
            this.SuspendLayout();

            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.connectionStringTextBox);
            this.Controls.Add(this.connectionStringLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Connection Settings";

            // 
            // connectionStringLabel
            // 
            this.connectionStringLabel.Location = new System.Drawing.Point(20, 20);
            this.connectionStringLabel.Name = "connectionStringLabel";
            this.connectionStringLabel.Size = new System.Drawing.Size(200, 23);
            this.connectionStringLabel.TabIndex = 0;
            this.connectionStringLabel.Text = "Connection String:";

            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Location = new System.Drawing.Point(20, 50);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(540, 23);
            this.connectionStringTextBox.TabIndex = 1;

            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(20, 90);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(150, 30);
            this.testButton.TabIndex = 2;
            this.testButton.Text = "Test Connection";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.OnTestButtonClick);

            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(180, 90);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);

            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(290, 90);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);

            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(20, 140);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(540, 100);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Click 'Test Connection' to verify your connection string.";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}