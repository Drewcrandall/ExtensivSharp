using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// One consolidated line of a pick list: a quantity of one item, with one set of track-bys, in
    /// one location. For serialized inventory this is a single serial at quantity 1, and
    /// <c>ItemTraits.PalletIdentifier</c> names the movable unit it is on.
    /// </summary>
    public class PickItem
    {
        [JsonProperty("pickedQty")]
        public decimal PickedQty { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("weightImperial")]
        public decimal WeightImperial { get; set; }

        [JsonProperty("weightMetric")]
        public decimal WeightMetric { get; set; }

        /// <summary>Whether the movable unit this line sits on is loadable.</summary>
        [JsonProperty("isOnLoadableMu")]
        public bool IsOnLoadableMu { get; set; }

        [JsonProperty("supplier")]
        public string Supplier { get; set; }

        /// <summary>Reference numbers of the orders this pick line contributes to.</summary>
        [JsonProperty("refNums")]
        public List<string> RefNums { get; set; }

        [JsonProperty("isInsert")]
        public bool IsInsert { get; set; }

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
