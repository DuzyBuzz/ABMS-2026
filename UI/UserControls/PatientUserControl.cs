using ABMS_2026.Common.Helpers;
using ABMS_2026.UI.Forms;
using ABMS_2026.UI.Shared.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class PatientUserControl : UserControl
    {

        public PatientUserControl()
        {
            InitializeComponent();
        }


        private void PatientUserControl_Load(object sender, EventArgs e)
        {

            moduleUserControl.Configure(new ModuleUserControlOptions
            {
                SourceName = "v_patients",
                TargetTableName = "patients",

                PrimaryKeyColumn = "patient_id",

                DisplayColumns = new()
        {
            "last_name",
            "first_name",
            "middle_name",
            "birth_date",
            "age",
            "sex",
            "civil_status",
            "address",
            "contact_no",
        },

                SearchableColumns = new()
        {
            "last_name",
            "first_name",
            "middle_name",
"registration_no"
        },

                DateColumn = "created_at",

                IsPaginated = true,

                PageSize = 1000,

                UpsertFormType = typeof(PatientProfileForm),

                // Enable context menu with custom actions
                EnableContextMenu = true,
                HideActionButtonsWhenContextMenuEnabled = false,
                ContextMenuItems = new List<ModuleContextMenuItem>
                {
                    new ModuleContextMenuItem
                    {
                        Text = "New Bite Case",
                        Name = "new_bite_case",
                        Action = NewBiteCaseAction,
                        ReloadGridAfterAction = false
                    },
                    new ModuleContextMenuItem
                    {
                        Text = "Bite Case History",
                        Name = "bite_case_history",
                        Action = BiteCaseHistoryAction,
                        ReloadGridAfterAction = false
                    }
                }
            });
        }

        private void NewBiteCaseAction(ModuleRecordContext context)
        {
            if (context.PrimaryKeyValue == null) return;

            int patientId = Convert.ToInt32(context.PrimaryKeyValue);

            using (var biteCaseForm = new BiteCaseForm(patientId))
            {
                biteCaseForm.StartPosition = FormStartPosition.CenterParent;
                if (biteCaseForm.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    // Optionally refresh or notify of success
                }
            }
        }

        private void BiteCaseHistoryAction(ModuleRecordContext context)
        {
            if (context.PrimaryKeyValue == null) return;

            int patientId = Convert.ToInt32(context.PrimaryKeyValue);

            // Show bite case history for this patient
            using (var historyForm = new Form())
            {

            }
        }
    }
}
