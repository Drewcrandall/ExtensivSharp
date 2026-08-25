using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    /// <summary>The manual allocations proposed for one order item within an order-wide request.</summary>
    public class ProposedAllocationsByOrderItemId
    {
        [JsonProperty("orderItemId")]
        public int OrderItemId { get; set; }

        [JsonProperty("proposedAllocations")]
        public List<ProposedAllocation> ProposedAllocations { get; set; } = new();
    }
}
