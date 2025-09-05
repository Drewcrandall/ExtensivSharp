using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class ReadOnlyOrderItem
    {
        [JsonProperty("orderItemId")]
        public int OrderItemId { get; set; }

        [JsonProperty("fullyAllocated")]
        public bool FullyAllocated { get; set; }

        [JsonProperty("unitIdentifier")]
        public UnitIdentifier UnitIdentifier { get; set; }

        [JsonProperty("originalPrimaryQty")]
        public double OriginalPrimaryQty { get; set; }

        [JsonProperty("isOrderQtySecondary")]
        public bool IsOrderQtySecondary { get; set; }

        [JsonProperty("allocations")]
        public List<Allocation> Allocations { get; set; }

        [JsonProperty("isInsert")]
        public bool IsInsert { get; set; }

        [JsonProperty("maxToAllocateFromPickLine")]
        public double MaxToAllocateFromPickLine { get; set; }

        [JsonProperty("rowVersion")]
        public string RowVersion { get; set; }
    }

}
