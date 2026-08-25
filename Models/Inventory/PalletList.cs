using Newtonsoft.Json;

namespace ExtensivSharp.Models.Inventory
{
#pragma warning disable CS8618
    public class PalletList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedPallets Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded pallets.</summary>
        [JsonIgnore]
        public List<Pallet> Pallets => Embedded?.Pallets ?? new();
    }
}
