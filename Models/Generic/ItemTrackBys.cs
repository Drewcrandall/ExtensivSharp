using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
#pragma warning disable CS8618
    /// <summary>
    /// The track-by values actually observed at the shelf. Sent on a mispick to describe what was
    /// picked instead of what the pick line asked for. Unlike <see cref="ItemTraits"/> this carries
    /// no item identifier or qualifier - the SKU is not in question, only its track-bys.
    /// </summary>
    public class ItemTrackBys
    {
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
