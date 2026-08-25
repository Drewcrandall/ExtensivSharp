using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
#pragma warning disable CS8618
    /// <summary>
    /// The unique identifying characteristics of an item in a location. Extensiv consolidates pick
    /// lists by Location + ItemTraits, so for serialized inventory every distinct
    /// <see cref="SerialNumber"/> produces its own pick line at quantity 1.
    /// <see cref="PalletIdentifier"/> is what ties a pick line back to the movable unit it sits on.
    /// </summary>
    public class ItemTraits
    {
        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("lotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("cost")]
        public decimal? Cost { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("palletIdentifier")]
        public PalletIdentifier PalletIdentifier { get; set; }
    }
}
