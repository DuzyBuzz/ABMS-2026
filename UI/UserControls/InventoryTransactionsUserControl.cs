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

                PrimaryKeyColumn = "transaction_id",

                DisplayColumns = new()
                {
                    "generic_name",
                    "brand_name",
                    "item_name",
                    "category",
                    "strength",
                    "dosage_form",
                    "unit",
                    "transaction_type",
                    "quantity",
                    "remarks",
                    "reference_no",
                    "created_by",
                    "transaction_date",
                    "treatment_schedule_id",
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
