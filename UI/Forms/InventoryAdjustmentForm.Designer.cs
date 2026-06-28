using System.Drawing;
using System.Windows.Forms;

namespace ABMS_2026.UI.Forms
{
    partial class InventoryAdjustmentForm
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
            this.labelItem = new Label();
            this.textBoxSelectedItem = new TextBox();
            this.selectItemButton = new Button();
            this.labelTransactionType = new Label();
            this.comboBoxTransactionType = new ComboBox();
            this.labelQuantity = new Label();
            this.numericUpDownQuantity = new NumericUpDown();
            this.labelCurrentStock = new Label();
            this.textBoxCurrentStock = new TextBox();
            this.textBoxRemarks = new TextBox();
            this.labelRemarks = new Label();
            this.textBoxReferenceNo = new TextBox();
            this.labelReferenceNo = new Label();
            this.labelTransactionDate = new Label();
            this.dateTimePickerTransactionDate = new DateTimePicker();
            this.saveButton = new Button();
            this.cancelButton = new Button();
            this.formTitleLabel = new Label();
            this.labelRequired = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // formTitleLabel
            //
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.formTitleLabel.ForeColor = Color.MidnightBlue;
            this.formTitleLabel.Location = new Point(20, 20);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new Size(244, 30);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "INVENTORY ADJUSTMENT";
            // 
            // labelRequired
            // 
            this.labelRequired.AutoSize = true;
            this.labelRequired.ForeColor = Color.Red;
            this.labelRequired.Location = new Point(20, 55);
            this.labelRequired.Name = "labelRequired";
            this.labelRequired.Size = new Size(129, 15);
            this.labelRequired.TabIndex = 1;
            this.labelRequired.Text = "* Required fields";
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new Point(20, 85);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new Size(31, 15);
            this.labelItem.TabIndex = 2;
            this.labelItem.Text = "* Item:";
            // 
            // textBoxSelectedItem
            // 
            this.textBoxSelectedItem.Location = new Point(140, 82);
            this.textBoxSelectedItem.Name = "textBoxSelectedItem";
            this.textBoxSelectedItem.ReadOnly = true;
            this.textBoxSelectedItem.Size = new Size(300, 23);
            this.textBoxSelectedItem.TabIndex = 3;
            // 
            // selectItemButton
            // 
            this.selectItemButton.Location = new Point(450, 80);
            this.selectItemButton.Name = "selectItemButton";
            this.selectItemButton.Size = new Size(100, 28);
            this.selectItemButton.TabIndex = 4;
            this.selectItemButton.Text = "Select...";
            this.selectItemButton.UseVisualStyleBackColor = true;
            // 
            // labelTransactionType
            // 
            this.labelTransactionType.AutoSize = true;
            this.labelTransactionType.Location = new Point(20, 115);
            this.labelTransactionType.Name = "labelTransactionType";
            this.labelTransactionType.Size = new Size(104, 15);
            this.labelTransactionType.TabIndex = 5;
            this.labelTransactionType.Text = "Transaction Type:";
            // 
            // comboBoxTransactionType
            // 
            this.comboBoxTransactionType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxTransactionType.FormattingEnabled = true;
            this.comboBoxTransactionType.Location = new Point(140, 112);
            this.comboBoxTransactionType.Name = "comboBoxTransactionType";
            this.comboBoxTransactionType.Size = new Size(150, 23);
            this.comboBoxTransactionType.TabIndex = 6;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new Point(20, 145);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new Size(56, 15);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "* Quantity:";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.DecimalPlaces = 2;
            this.numericUpDownQuantity.Location = new Point(140, 142);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new Size(120, 23);
            this.numericUpDownQuantity.TabIndex = 8;
            this.numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelCurrentStock
            // 
            this.labelCurrentStock.AutoSize = true;
            this.labelCurrentStock.Location = new Point(270, 145);
            this.labelCurrentStock.Name = "labelCurrentStock";
            this.labelCurrentStock.Size = new Size(79, 15);
            this.labelCurrentStock.TabIndex = 9;
            this.labelCurrentStock.Text = "Current Stock:";
            // 
            // textBoxCurrentStock
            // 
            this.textBoxCurrentStock.Location = new Point(355, 142);
            this.textBoxCurrentStock.Name = "textBoxCurrentStock";
            this.textBoxCurrentStock.ReadOnly = true;
            this.textBoxCurrentStock.Size = new Size(100, 23);
            this.textBoxCurrentStock.TabIndex = 10;
            this.textBoxCurrentStock.Text = "0.00";
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Location = new Point(20, 175);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new Size(53, 15);
            this.labelRemarks.TabIndex = 11;
            this.labelRemarks.Text = "Remarks:";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Location = new Point(140, 172);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new Size(350, 60);
            this.textBoxRemarks.TabIndex = 12;
            // 
            // labelReferenceNo
            // 
            this.labelReferenceNo.AutoSize = true;
            this.labelReferenceNo.Location = new Point(20, 245);
            this.labelReferenceNo.Name = "labelReferenceNo";
            this.labelReferenceNo.Size = new Size(79, 15);
            this.labelReferenceNo.TabIndex = 13;
            this.labelReferenceNo.Text = "Reference No:";
            // 
            // textBoxReferenceNo
            // 
            this.textBoxReferenceNo.Location = new Point(140, 242);
            this.textBoxReferenceNo.Name = "textBoxReferenceNo";
            this.textBoxReferenceNo.Size = new Size(200, 23);
            this.textBoxReferenceNo.TabIndex = 14;
            // 
            // labelTransactionDate
            // 
            this.labelTransactionDate.AutoSize = true;
            this.labelTransactionDate.Location = new Point(20, 275);
            this.labelTransactionDate.Name = "labelTransactionDate";
            this.labelTransactionDate.Size = new Size(95, 15);
            this.labelTransactionDate.TabIndex = 15;
            this.labelTransactionDate.Text = "Transaction Date:";
            // 
            // dateTimePickerTransactionDate
            //
            this.dateTimePickerTransactionDate.Format = DateTimePickerFormat.Short;
            this.dateTimePickerTransactionDate.Location = new Point(140, 272);
            this.dateTimePickerTransactionDate.Name = "dateTimePickerTransactionDate";
            this.dateTimePickerTransactionDate.Size = new Size(140, 23);
            this.dateTimePickerTransactionDate.TabIndex = 16;
            //
            // saveButton
            //
            this.saveButton.BackColor = Color.RoyalBlue;
            this.saveButton.FlatStyle = FlatStyle.Flat;
            this.saveButton.ForeColor = Color.White;
            this.saveButton.Location = new Point(140, 320);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new Size(100, 35);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            //
            this.cancelButton.BackColor = Color.Gray;
            this.cancelButton.FlatStyle = FlatStyle.Flat;
            this.cancelButton.ForeColor = Color.White;
            this.cancelButton.Location = new Point(250, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(100, 35);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            //
            // InventoryAdjustmentForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(600, 380);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dateTimePickerTransactionDate);
            this.Controls.Add(this.labelTransactionDate);
            this.Controls.Add(this.textBoxReferenceNo);
            this.Controls.Add(this.labelReferenceNo);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.textBoxCurrentStock);
            this.Controls.Add(this.labelCurrentStock);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.comboBoxTransactionType);
            this.Controls.Add(this.labelTransactionType);
            this.Controls.Add(this.selectItemButton);
            this.Controls.Add(this.textBoxSelectedItem);
            this.Controls.Add(this.labelItem);
            this.Controls.Add(this.labelRequired);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "InventoryAdjustmentForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Inventory Adjustment";
            this.Load += new EventHandler(this.InventoryAdjustmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label labelItem;
        private TextBox textBoxSelectedItem;
        private Button selectItemButton;
        private Label labelTransactionType;
        private ComboBox comboBoxTransactionType;
        private Label labelQuantity;
        private NumericUpDown numericUpDownQuantity;
        private Label labelCurrentStock;
        private TextBox textBoxCurrentStock;
        private TextBox textBoxRemarks;
        private Label labelRemarks;
        private TextBox textBoxReferenceNo;
        private Label labelReferenceNo;
        private Label labelTransactionDate;
        private DateTimePicker dateTimePickerTransactionDate;
        private Button saveButton;
        private Button cancelButton;
        private Label formTitleLabel;
        private Label labelRequired;
    }
}