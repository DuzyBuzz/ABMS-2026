using ABMS_2026.Common.Helpers;
using ABMS_2026.Common.Printing;
using ABMS_2026.UI.Forms;
using ABMS_2026.UI.Shared.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class BiteCaseUserControl : UserControl
    {
        public BiteCaseUserControl()
        {
            InitializeComponent();
        }

        private void BiteCaseUserControl_Load(object sender, EventArgs e)
        {
            moduleUserControl.Configure(new ModuleUserControlOptions
            {
                SourceName = "v_bite_cases",
                TargetTableName = "bite_cases",

                PrimaryKeyColumn = "bite_case_id",

                DisplayColumns = new()
                {
                    "created_at",

                    "patient_name",
                    "address",
                    "sex",
                    "age",
                    "exposure_date",

                    "incident_place",
                    "animal_type",
                    "animal_classification",
                    "animal_status",
                    "wound_type",
                    "wound_count",
                    "wound_classification",
                },

                SearchableColumns = new()
                {
                    "patient_name",
                    "animal_type",
                    "incident_place"
                },

                DateColumn = "exposure_date",

                IsPaginated = true,

                PageSize = 1000,

                UpsertFormType = typeof(EditBiteCaseForm),

                HideAddButton = true, // Hide add button - no new bite cases from this control
                RefreshButtonText = "Refresh",
                SearchButtonText = "Search",

                // Configure the form to handle edit only

                // Enable context menu with Print ITR option
                EnableContextMenu = true,
                HideActionButtonsWhenContextMenuEnabled = false,
                ContextMenuItems = new List<ModuleContextMenuItem>
                {
                    new ModuleContextMenuItem
                    {
                        Text = "Print ITR",
                        Name = "print_itr",
                        Action = PrintITRAction,
                        ReloadGridAfterAction = false
                    }
                }
            });
        }

        private void ConfigureBiteCaseForm(Form form, ModuleRecordContext context)
        {
            // Close the auto-created form since we'll create our own
            form.DialogResult = DialogResult.Cancel;
            form.Close();

            if (context.IsEditMode && context.PrimaryKeyValue != null)
            {
                // Editing existing bite case - only need biteCaseId
                int biteCaseId = Convert.ToInt32(context.PrimaryKeyValue);

                // Create EditBiteCaseForm with only biteCaseId (it will query for patientId)
                using var editForm = new EditBiteCaseForm(biteCaseId);
                editForm.StartPosition = FormStartPosition.CenterParent;
                editForm.ShowDialog(FindForm());
            }
            // Add functionality removed - no new bite cases from this control
        }

        private void PrintITRAction(ModuleRecordContext context)
        {
            if (context.PrimaryKeyValue == null) return;

            int biteCaseId = Convert.ToInt32(context.PrimaryKeyValue);

            try
            {
                var itrPrint = new ITRPrint(biteCaseId);
                itrPrint.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing ITR: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
