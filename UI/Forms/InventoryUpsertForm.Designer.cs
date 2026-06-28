using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    partial class InventoryUpsertForm
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
            textBoxGenericName = new TextBox();
            labelGenericName = new Label();
            textBoxBrandName = new TextBox();
            labelBrandName = new Label();
            comboBoxCategory = new ComboBox();
            labelCategory = new Label();
            textBoxStrength = new TextBox();
            labelStrength = new Label();
            comboBoxDosageForm = new ComboBox();
            labelDosageForm = new Label();
            comboBoxUnit = new ComboBox();
            labelUnit = new Label();
            numericUpDownReorderLevel = new NumericUpDown();
            labelReorderLevel = new Label();
            dateTimePickerExpirationDate = new DateTimePicker();
            labelExpirationDate = new Label();
            checkBoxIsActive = new CheckBox();
            saveButton = new Button();
            cancelButton = new Button();
            formTitleLabel = new Label();
            labelRequired = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReorderLevel).BeginInit();
            SuspendLayout();
            // 
            // textBoxGenericName
            // 
            textBoxGenericName.Location = new Point(140, 82);
            textBoxGenericName.Name = "textBoxGenericName";
            textBoxGenericName.Size = new Size(300, 23);
            textBoxGenericName.TabIndex = 3;
            // 
            // labelGenericName
            // 
            labelGenericName.AutoSize = true;
            labelGenericName.Location = new Point(20, 85);
            labelGenericName.Name = "labelGenericName";
            labelGenericName.Size = new Size(93, 15);
            labelGenericName.TabIndex = 2;
            labelGenericName.Text = "* Generic Name:";
            // 
            // textBoxBrandName
            // 
            textBoxBrandName.Location = new Point(140, 112);
            textBoxBrandName.Name = "textBoxBrandName";
            textBoxBrandName.Size = new Size(300, 23);
            textBoxBrandName.TabIndex = 5;
            // 
            // labelBrandName
            // 
            labelBrandName.AutoSize = true;
            labelBrandName.Location = new Point(20, 115);
            labelBrandName.Name = "labelBrandName";
            labelBrandName.Size = new Size(76, 15);
            labelBrandName.TabIndex = 4;
            labelBrandName.Text = "Brand Name:";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(140, 142);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(200, 23);
            comboBoxCategory.TabIndex = 7;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(20, 145);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(66, 15);
            labelCategory.TabIndex = 6;
            labelCategory.Text = "* Category:";
            // 
            // textBoxStrength
            // 
            textBoxStrength.Location = new Point(140, 172);
            textBoxStrength.Name = "textBoxStrength";
            textBoxStrength.Size = new Size(150, 23);
            textBoxStrength.TabIndex = 9;
            // 
            // labelStrength
            // 
            labelStrength.AutoSize = true;
            labelStrength.Location = new Point(20, 175);
            labelStrength.Name = "labelStrength";
            labelStrength.Size = new Size(55, 15);
            labelStrength.TabIndex = 8;
            labelStrength.Text = "Strength:";
            // 
            // comboBoxDosageForm
            // 
            comboBoxDosageForm.FormattingEnabled = true;
            comboBoxDosageForm.Location = new Point(140, 202);
            comboBoxDosageForm.Name = "comboBoxDosageForm";
            comboBoxDosageForm.Size = new Size(150, 23);
            comboBoxDosageForm.TabIndex = 11;
            // 
            // labelDosageForm
            // 
            labelDosageForm.AutoSize = true;
            labelDosageForm.Location = new Point(20, 205);
            labelDosageForm.Name = "labelDosageForm";
            labelDosageForm.Size = new Size(80, 15);
            labelDosageForm.TabIndex = 10;
            labelDosageForm.Text = "Dosage Form:";
            // 
            // comboBoxUnit
            // 
            comboBoxUnit.FormattingEnabled = true;
            comboBoxUnit.Location = new Point(140, 232);
            comboBoxUnit.Name = "comboBoxUnit";
            comboBoxUnit.Size = new Size(100, 23);
            comboBoxUnit.TabIndex = 13;
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Location = new Point(20, 235);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(40, 15);
            labelUnit.TabIndex = 12;
            labelUnit.Text = "* Unit:";
            // 
            // numericUpDownReorderLevel
            // 
            numericUpDownReorderLevel.DecimalPlaces = 2;
            numericUpDownReorderLevel.Location = new Point(140, 262);
            numericUpDownReorderLevel.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownReorderLevel.Name = "numericUpDownReorderLevel";
            numericUpDownReorderLevel.Size = new Size(100, 23);
            numericUpDownReorderLevel.TabIndex = 15;
            // 
            // labelReorderLevel
            // 
            labelReorderLevel.AutoSize = true;
            labelReorderLevel.Location = new Point(20, 265);
            labelReorderLevel.Name = "labelReorderLevel";
            labelReorderLevel.Size = new Size(81, 15);
            labelReorderLevel.TabIndex = 14;
            labelReorderLevel.Text = "Reorder Level:";
            // 
            // dateTimePickerExpirationDate
            // 
            dateTimePickerExpirationDate.Format = DateTimePickerFormat.Short;
            dateTimePickerExpirationDate.Location = new Point(140, 292);
            dateTimePickerExpirationDate.Name = "dateTimePickerExpirationDate";
            dateTimePickerExpirationDate.Size = new Size(140, 23);
            dateTimePickerExpirationDate.TabIndex = 17;
            // 
            // labelExpirationDate
            // 
            labelExpirationDate.AutoSize = true;
            labelExpirationDate.Location = new Point(20, 295);
            labelExpirationDate.Name = "labelExpirationDate";
            labelExpirationDate.Size = new Size(90, 15);
            labelExpirationDate.TabIndex = 16;
            labelExpirationDate.Text = "Expiration Date:";
            // 
            // checkBoxIsActive
            // 
            checkBoxIsActive.AutoSize = true;
            checkBoxIsActive.Checked = true;
            checkBoxIsActive.CheckState = CheckState.Checked;
            checkBoxIsActive.Location = new Point(20, 325);
            checkBoxIsActive.Name = "checkBoxIsActive";
            checkBoxIsActive.Size = new Size(70, 19);
            checkBoxIsActive.TabIndex = 18;
            checkBoxIsActive.Text = "Is Active";
            checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.RoyalBlue;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(140, 370);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 35);
            saveButton.TabIndex = 19;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Gray;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(250, 370);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 35);
            cancelButton.TabIndex = 20;
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
            formTitleLabel.Size = new Size(196, 30);
            formTitleLabel.TabIndex = 0;
            formTitleLabel.Text = "INVENTORY ITEM";
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
            // InventoryUpsertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(500, 430);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(checkBoxIsActive);
            Controls.Add(dateTimePickerExpirationDate);
            Controls.Add(labelExpirationDate);
            Controls.Add(numericUpDownReorderLevel);
            Controls.Add(labelReorderLevel);
            Controls.Add(comboBoxUnit);
            Controls.Add(labelUnit);
            Controls.Add(comboBoxDosageForm);
            Controls.Add(labelDosageForm);
            Controls.Add(textBoxStrength);
            Controls.Add(labelStrength);
            Controls.Add(comboBoxCategory);
            Controls.Add(labelCategory);
            Controls.Add(textBoxBrandName);
            Controls.Add(labelBrandName);
            Controls.Add(textBoxGenericName);
            Controls.Add(labelGenericName);
            Controls.Add(labelRequired);
            Controls.Add(formTitleLabel);
            Font = new Font("Segoe UI", 9F);
            Name = "InventoryUpsertForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inventory Item";
            Load += InventoryUpsertForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownReorderLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxGenericName;
        private Label labelGenericName;
        private TextBox textBoxBrandName;
        private Label labelBrandName;
        private ComboBox comboBoxCategory;
        private Label labelCategory;
        private TextBox textBoxStrength;
        private Label labelStrength;
        private ComboBox comboBoxDosageForm;
        private Label labelDosageForm;
        private ComboBox comboBoxUnit;
        private Label labelUnit;
        private NumericUpDown numericUpDownReorderLevel;
        private Label labelReorderLevel;
        private DateTimePicker dateTimePickerExpirationDate;
        private Label labelExpirationDate;
        private CheckBox checkBoxIsActive;
        private Button saveButton;
        private Button cancelButton;
        private Label formTitleLabel;
        private Label labelRequired;
    }
}