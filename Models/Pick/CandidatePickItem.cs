using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// A pick line as seen from a single order. Unlike <see cref="PickItem"/> this is not
    /// consolidated across the other orders in a multi-order job, and carries no pick progress.
    /// </summary>
    public class CandidatePickItem
    {
        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("locationIdentifier")]
        public LocationIdentifier LocationIdentifier { get; set; }

        [JsonProperty("locationSort")]
        public LocationSort LocationSort { get; set; }

        [JsonProperty("itemTraits")]
        public ItemTraits ItemTraits { get; set; }

        [JsonProperty("unitIdentifier")]
        public Identifier UnitIdentifier { get; set; }

        [JsonProperty("secondaryUnitIdentifier")]
        public Identifier SecondaryUnitIdentifier { get; set; }

        [JsonProperty("secondaryQty")]
        public decimal? SecondaryQty { get; set; }

        [JsonProperty("isOrderQtySecondary")]
        public bool IsOrderQtySecondary { get; set; }

        [JsonProperty("pickPath")]
        public int? PickPath { get; set; }
    }
}
