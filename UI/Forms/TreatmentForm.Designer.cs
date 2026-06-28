using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    partial class TreatmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            scheduleDayComboBox = new ComboBox();
            scheduleDayLabel = new Label();
            biologicTypeComboBox = new ComboBox();
            biologicTypeLabel = new Label();
            routeComboBox = new ComboBox();
            routeLabel = new Label();
            scheduledDateDateTimePicker = new DateTimePicker();
            scheduledDateLabel = new Label();
            administeredDateDateTimePicker = new DateTimePicker();
            administeredDateLabel = new Label();
            statusComboBox = new ComboBox();
            statusLabel = new Label();
            administeredByTextBox = new TextBox();
            administeredByLabel = new Label();
            remarksTextBox = new TextBox();
            remarksLabel = new Label();
            itemPickerButton = new Button();
            selectedItemLabel = new Label();
            selectedItemLabelLabel = new Label();
            quantityUsedNumericUpDown = new NumericUpDown();
            quantityUsedLabel = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            formTitleLabel = new Label();
            labelRequired = new Label();
            ((System.ComponentModel.ISupportInitialize)quantityUsedNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // scheduleDayComboBox
            // 
            scheduleDayComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            scheduleDayComboBox.FormattingEnabled = true;
            scheduleDayComboBox.Location = new Point(140, 82);
            scheduleDayComboBox.Name = "scheduleDayComboBox";
            scheduleDayComboBox.Size = new Size(200, 23);
            scheduleDayComboBox.TabIndex = 3;
            // 
            // scheduleDayLabel
            // 
            scheduleDayLabel.AutoSize = true;
            scheduleDayLabel.Location = new Point(20, 85);
            scheduleDayLabel.Name = "scheduleDayLabel";
            scheduleDayLabel.Size = new Size(89, 15);
            scheduleDayLabel.TabIndex = 2;
            scheduleDayLabel.Text = "* Schedule Day:";
            // 
            // biologicTypeComboBox
            // 
            biologicTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            biologicTypeComboBox.FormattingEnabled = true;
            biologicTypeComboBox.Location = new Point(140, 112);
            biologicTypeComboBox.Name = "biologicTypeComboBox";
            biologicTypeComboBox.Size = new Size(200, 23);
            biologicTypeComboBox.TabIndex = 5;
            // 
            // biologicTypeLabel
            // 
            biologicTypeLabel.AutoSize = true;
            biologicTypeLabel.Location = new Point(20, 115);
            biologicTypeLabel.Name = "biologicTypeLabel";
            biologicTypeLabel.Size = new Size(88, 15);
            biologicTypeLabel.TabIndex = 4;
            biologicTypeLabel.Text = "* Biologic Type:";
            // 
            // routeComboBox
            // 
            routeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            routeComboBox.FormattingEnabled = true;
            routeComboBox.Location = new Point(140, 142);
            routeComboBox.Name = "routeComboBox";
            routeComboBox.Size = new Size(200, 23);
            routeComboBox.TabIndex = 7;
            // 
            // routeLabel
            // 
            routeLabel.AutoSize = true;
            routeLabel.Location = new Point(20, 145);
            routeLabel.Name = "routeLabel";
            routeLabel.Size = new Size(51, 15);
            routeLabel.TabIndex = 6;
            routeLabel.Text = "* Route:";
            // 
            // scheduledDateDateTimePicker
            // 
            scheduledDateDateTimePicker.Format = DateTimePickerFormat.Short;
            scheduledDateDateTimePicker.Location = new Point(140, 172);
            scheduledDateDateTimePicker.Name = "scheduledDateDateTimePicker";
            scheduledDateDateTimePicker.Size = new Size(140, 23);
            scheduledDateDateTimePicker.TabIndex = 9;
            // 
            // scheduledDateLabel
            // 
            scheduledDateLabel.AutoSize = true;
            scheduledDateLabel.Location = new Point(20, 175);
            scheduledDateLabel.Name = "scheduledDateLabel";
            scheduledDateLabel.Size = new Size(100, 15);
            scheduledDateLabel.TabIndex = 8;
            scheduledDateLabel.Text = "* Scheduled Date:";
            // 
            // administeredDateDateTimePicker
            // 
            administeredDateDateTimePicker.Checked = false;
            administeredDateDateTimePicker.Format = DateTimePickerFormat.Short;
            administeredDateDateTimePicker.Location = new Point(140, 202);
            administeredDateDateTimePicker.Name = "administeredDateDateTimePicker";
            administeredDateDateTimePicker.ShowCheckBox = true;
            administeredDateDateTimePicker.Size = new Size(140, 23);
            administeredDateDateTimePicker.TabIndex = 11;
            // 
            // administeredDateLabel
            // 
            administeredDateLabel.AutoSize = true;
            administeredDateLabel.Location = new Point(20, 205);
            administeredDateLabel.Name = "administeredDateLabel";
            administeredDateLabel.Size = new Size(108, 15);
            administeredDateLabel.TabIndex = 10;
            administeredDateLabel.Text = "Administered Date:";
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(140, 232);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(200, 23);
            statusComboBox.TabIndex = 13;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(20, 235);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 15);
            statusLabel.TabIndex = 12;
            statusLabel.Text = "* Status:";
            // 
            // administeredByTextBox
            // 
            administeredByTextBox.Location = new Point(140, 262);
            administeredByTextBox.Name = "administeredByTextBox";
            administeredByTextBox.Size = new Size(300, 23);
            administeredByTextBox.TabIndex = 15;
            // 
            // administeredByLabel
            // 
            administeredByLabel.AutoSize = true;
            administeredByLabel.Location = new Point(20, 265);
            administeredByLabel.Name = "administeredByLabel";
            administeredByLabel.Size = new Size(97, 15);
            administeredByLabel.TabIndex = 14;
            administeredByLabel.Text = "Administered By:";
            // 
            // remarksTextBox
            // 
            remarksTextBox.Location = new Point(140, 292);
            remarksTextBox.Multiline = true;
            remarksTextBox.Name = "remarksTextBox";
            remarksTextBox.Size = new Size(300, 60);
            remarksTextBox.TabIndex = 17;
            // 
            // remarksLabel
            // 
            remarksLabel.AutoSize = true;
            remarksLabel.Location = new Point(20, 295);
            remarksLabel.Name = "remarksLabel";
            remarksLabel.Size = new Size(55, 15);
            remarksLabel.TabIndex = 16;
            remarksLabel.Text = "Remarks:";
            // 
            // itemPickerButton
            // 
            itemPickerButton.BackColor = Color.RoyalBlue;
            itemPickerButton.FlatStyle = FlatStyle.Flat;
            itemPickerButton.ForeColor = Color.White;
            itemPickerButton.Location = new Point(413, 358);
            itemPickerButton.Name = "itemPickerButton";
            itemPickerButton.Size = new Size(100, 30);
            itemPickerButton.TabIndex = 20;
            itemPickerButton.Text = "Select Item";
            itemPickerButton.UseVisualStyleBackColor = false;
            itemPickerButton.Click += ItemPickerButton_Click;
            // 
            // selectedItemLabel
            // 
            selectedItemLabel.AutoSize = true;
            selectedItemLabel.Location = new Point(140, 362);
            selectedItemLabel.Name = "selectedItemLabel";
            selectedItemLabel.Size = new Size(70, 15);
            selectedItemLabel.TabIndex = 19;
            selectedItemLabel.Text = "ITEM NAME";
            // 
            // selectedItemLabelLabel
            // 
            selectedItemLabelLabel.AutoSize = true;
            selectedItemLabelLabel.Location = new Point(20, 366);
            selectedItemLabelLabel.Name = "selectedItemLabelLabel";
            selectedItemLabelLabel.Size = new Size(34, 15);
            selectedItemLabelLabel.TabIndex = 16;
            selectedItemLabelLabel.Text = "Item (req if administered):";
            // 
            // quantityUsedNumericUpDown
            // 
            quantityUsedNumericUpDown.DecimalPlaces = 2;
            quantityUsedNumericUpDown.Location = new Point(140, 391);
            quantityUsedNumericUpDown.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            quantityUsedNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantityUsedNumericUpDown.Name = "quantityUsedNumericUpDown";
            quantityUsedNumericUpDown.Size = new Size(120, 23);
            quantityUsedNumericUpDown.TabIndex = 21;
            quantityUsedNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // quantityUsedLabel
            // 
            quantityUsedLabel.AutoSize = true;
            quantityUsedLabel.Location = new Point(20, 393);
            quantityUsedLabel.Name = "quantityUsedLabel";
            quantityUsedLabel.Size = new Size(85, 15);
            quantityUsedLabel.TabIndex = 22;
            quantityUsedLabel.Text = "Quantity Used:";
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.RoyalBlue;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(140, 430);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 35);
            saveButton.TabIndex = 23;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Gray;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(250, 430);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 35);
            cancelButton.TabIndex = 24;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // formTitleLabel
            // 
            formTitleLabel.AutoSize = true;
            formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            formTitleLabel.ForeColor = Color.MidnightBlue;
            formTitleLabel.Location = new Point(20, 20);
            formTitleLabel.Name = "formTitleLabel";
            formTitleLabel.Size = new Size(141, 30);
            formTitleLabel.TabIndex = 0;
            formTitleLabel.Text = "TREATMENT";
            // 
            // labelRequired
            // 
            labelRequired.AutoSize = true;
            labelRequired.ForeColor = Color.Red;
            labelRequired.Location = new Point(20, 55);
            labelRequired.Name = "labelRequired";
            labelRequired.Size = new Size(93, 15);
            labelRequired.TabIndex = 1;
            labelRequired.Text = "* Required fields";
            // 
            // TreatmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(550, 490);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(quantityUsedLabel);
            Controls.Add(quantityUsedNumericUpDown);
            Controls.Add(itemPickerButton);
            Controls.Add(selectedItemLabel);
            Controls.Add(selectedItemLabelLabel);
            Controls.Add(remarksTextBox);
            Controls.Add(remarksLabel);
            Controls.Add(administeredByTextBox);
            Controls.Add(administeredByLabel);
            Controls.Add(statusComboBox);
            Controls.Add(statusLabel);
            Controls.Add(administeredDateDateTimePicker);
            Controls.Add(administeredDateLabel);
            Controls.Add(scheduledDateDateTimePicker);
            Controls.Add(scheduledDateLabel);
            Controls.Add(routeComboBox);
            Controls.Add(routeLabel);
            Controls.Add(biologicTypeComboBox);
            Controls.Add(biologicTypeLabel);
            Controls.Add(scheduleDayComboBox);
            Controls.Add(scheduleDayLabel);
            Controls.Add(labelRequired);
            Controls.Add(formTitleLabel);
            Font = new Font("Segoe UI", 9F);
            Name = "TreatmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Treatment Schedule";
            Load += TreatmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)quantityUsedNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formTitleLabel;
        private Label labelRequired;
        private Label scheduleDayLabel;
        private ComboBox scheduleDayComboBox;
        private Label biologicTypeLabel;
        private ComboBox biologicTypeComboBox;
        private Label routeLabel;
        private ComboBox routeComboBox;
        private Label scheduledDateLabel;
        private DateTimePicker scheduledDateDateTimePicker;
        private Label administeredDateLabel;
        private DateTimePicker administeredDateDateTimePicker;
        private Label statusLabel;
        private ComboBox statusComboBox;
        private Label administeredByLabel;
        private TextBox administeredByTextBox;
        private Label remarksLabel;
        private TextBox remarksTextBox;
        private Label selectedItemLabelLabel;
        private Label selectedItemLabel;
        private Button itemPickerButton;
        private Label quantityUsedLabel;
        private NumericUpDown quantityUsedNumericUpDown;
        private Button saveButton;
        private Button cancelButton;
    }
}
