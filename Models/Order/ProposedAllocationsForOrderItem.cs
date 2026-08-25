using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    /// <summary>A list of manual allocations for one order item.</summary>
    public class ProposedAllocationsForOrderItem
    {
        [JsonProperty("proposedAllocations")]
        public List<ProposedAllocation> ProposedAllocations { get; set; } = new();
    }
}
