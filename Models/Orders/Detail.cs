using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class Detail
    {
        [JsonProperty("warehouseTransactionPriceCalcId")]
        public int WarehouseTransactionPriceCalcId { get; set; }

        [JsonProperty("numUnits")]
        public int NumUnits { get; set; }

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
    }
}
