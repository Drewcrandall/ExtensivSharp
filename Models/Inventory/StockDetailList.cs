using Newtonsoft.Json;

namespace ExtensivSharp.Models.Inventory
{
#pragma warning disable CS8618
    public class StockDetailList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedStockDetails Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded stock details.</summary>
        [JsonIgnore]
        public List<StockDetail> StockDetails => Embedded?.StockDetails ?? new();
    }
}
