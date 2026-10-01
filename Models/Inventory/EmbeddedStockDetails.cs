using Newtonsoft.Json;

namespace ExtensivSharp.Models.Inventory
{
#pragma warning disable CS8618
    public class EmbeddedStockDetails
    {
        [JsonProperty("item")]
        public List<StockDetail> StockDetails { get; set; }
    }
}
