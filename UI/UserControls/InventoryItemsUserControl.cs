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
    public partial class InventoryItemsUserControl : UserControl
    {
        public InventoryItemsUserControl()
        {
            InitializeComponent();
        }

        private void InventoryItemsUserControl_Load(object sender, EventArgs e)
        {
            moduleUserControl.Configure(new ModuleUserControlOptions
            {
                SourceName = "inventory_items",
                TargetTableName = "inventory_items",

                PrimaryKeyColumn = "item_id",

                DisplayColumns = new()
                {
                    "generic_name",
                    "brand_name",
                    "category",
                    "strength",
                    "dosage_form",
                    "unit",
                    "quantity_on_hand",
                    "reorder_level",
                    "expiration_date",
                    "is_active"
                },

                SearchableColumns = new()
                {
                    "generic_name",
                    "brand_name",
                    "category"
                },

                IsPaginated = false, // No pagination as requested

                PageSize = 1000,

                UpsertFormType = typeof(InventoryUpsertForm),

                AddButtonText = "Add Item",
                RefreshButtonText = "Refresh",
                SearchButtonText = "Search"
            });
        }
    }
}
