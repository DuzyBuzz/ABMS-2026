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
                SourceName = "v_bite_case_details",
                TargetTableName = "bite_cases",

                PrimaryKeyColumn = "bite_case_id",

                DisplayColumns = new()
    {
        "patient_id",
        "exposure_date",
        "animal_type",
        "animal_classification",
        "animal_status",
        "wound_type",
        "wound_classification",
        "prophylaxis_type",
        "category_basis_details",
        "chronic_illnesses",
        "patient_symptoms"
    },

                SearchableColumns = new()
    {
        "animal_type",
        "animal_classification",
        "wound_type",
        "prophylaxis_type",
        "category_basis_details",
        "chronic_illnesses",
        "patient_symptoms"
    },

                DateColumn = "exposure_date",

                IsPaginated = true,

                PageSize = 1000,

                UpsertFormType = typeof(BiteCaseForm)
            });
        }
    }
}
