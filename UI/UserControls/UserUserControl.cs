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
    public partial class UserUserControl : UserControl
    {
        public UserUserControl()
        {
            InitializeComponent();
        }

        private void UserUserControl_Load(object sender, EventArgs e)
        {
            moduleUserControl.Configure(new ModuleUserControlOptions
            {
                SourceName = "users",
                TargetTableName = "users",

                PrimaryKeyColumn = "user_id",

                DisplayColumns = new()
                {
                    "username",
                    "full_name",
                    "role",
                    "status",
                    "created_at"
                },

                SearchableColumns = new()
                {
                    "username",
                    "full_name",
                    "role"
                },

                DateColumn = "created_at",

                IsPaginated = true,

                PageSize = 1000,

                UpsertFormType = typeof(UserUpsertForm),

                EnableContextMenu = false,
                HideActionButtonsWhenContextMenuEnabled = false,

                AddButtonText = "Add New",
                RefreshButtonText = "Refresh",
                SearchButtonText = "Search"
            });
        }
    }
}
