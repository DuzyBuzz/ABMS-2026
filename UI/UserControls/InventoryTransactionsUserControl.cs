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
    public partial class InventoryTransactionsUserControl : UserControl
    {
        public InventoryTransactionsUserControl()
        {
            InitializeComponent();
        }

        private void InventoryTransactionsUserControl_Load(object sender, EventArgs e)
        {
            moduleUserControl.Configure(new ModuleUserControlOptions
            {
                SourceName = "v_transactions",
                TargetTableName = "inventory_transactions",
                ModuleName = "Inventory Transactions",
                PrimaryKeyColumn = "transaction_id",

                DisplayColumns = new()
                {
                    "transaction_date",
                    "generic_name",
                    "brand_name",
                    "category",
                    "strength",
                    "unit",
                    "transaction_type",
                    "quantity",
                    "remarks",
                    "expiration_date"
                },

                SearchableColumns = new()
                {
                    "reference_no",
                    "remarks",
                    "item_name",
                    "generic_name",
                    "brand_name"
                },

                DateColumn = "transaction_date",

                IsPaginated = true,

                PageSize = 1000,

                // Transactions can be added via InventoryAdjustmentForm (IN and ADJUSTMENT only)
                // OUT transactions are created automatically via TreatmentForm
                UpsertFormType = typeof(InventoryAdjustmentForm),
                EnableContextMenu = false,
                HideActionButtonsWhenContextMenuEnabled = false,

                AddButtonText = "Add New",
                RefreshButtonText = "Refresh",
                SearchButtonText = "Search"
            });
        }
    }
}
