using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABMS_2026.UI.UserControls
{
    public partial class ExposureMonitoringUserControl : UserControl
    {
        public ExposureMonitoringUserControl()
        {
            InitializeComponent();
            ConfigureModule();
        }

        private void ConfigureModule()
        {
            var options = new ABMS_2026.UI.Shared.Components.ModuleUserControlOptions
            {
                SourceName = "v_post_exposure_monitoring",
                ModuleName = "Post Exposure Monitoring",
                PrimaryKeyColumn = "bite_case_id",
                DisplayColumns = new List<string>
                {
                    "category_of_exposure",
                    "washing_of_bite",
                    "rig_date_given",
                    "generic_name",
                    "brand_name",
                    "route",
                    "d0",
                    "d3",
                    "d7",
                    "d14_im",
                    "d28",
                    "status_of_biting_animal_after_14_days_of_observation",
                    "remarks"
                },
                SearchableColumns = new List<string>
                {
                    "patient_id",
                    "category_of_exposure",
                    "generic_name",
                    "brand_name",
                    "status_of_biting_animal_after_14_days_of_observation"
                },
                DateColumn = "d0",
                IsPaginated = true,
                PageSize = 1000,
                AddButtonText = "Add New",
                RefreshButtonText = "Refresh",
                SearchButtonText = "Search",
                HideAddButton = true,
                HideActionButtons = true
            };

            moduleUserControl1.Configure(options);
        }
    }
}
