using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ChargeDetail
    {
        [JsonProperty("warehouseTransactionPriceCalcId")]
        public int WarehouseTransactionPriceCalcId { get; set; }

        [JsonProperty("numUnits")]
        public decimal NumUnits { get; set; }

        [JsonProperty("chargeLabel")]
        public string ChargeLabel { get; set; }

        [JsonProperty("unitDescription")]
        public string UnitDescription { get; set; }

        [JsonProperty("chargePerUnit")]
        public decimal ChargePerUnit { get; set; }

        [JsonProperty("glAcctNum")]
        public string GlAcctNum { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("ptItem")]
        public string PtItem { get; set; }

        [JsonProperty("ptItemDescription")]
        public string PtItemDescription { get; set; }

        [JsonProperty("ptArAcct")]
        public string PtArAcct { get; set; }

        [JsonProperty("systemGenerated")]
        public bool SystemGenerated { get; set; }

        [JsonProperty("taxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("recurringChargeDetails")]
        public List<RecurringChargeDetail> RecurringChargeDetails { get; set; }
    }
}
