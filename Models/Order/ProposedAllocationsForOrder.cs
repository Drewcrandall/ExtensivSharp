using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    /// <summary>
    /// Manual allocations for a whole order, grouped by order item. This is the bulk path - one
    /// request can allocate every serial on a movable unit, unlike picking which is one call per line.
    /// </summary>
    public class ProposedAllocationsForOrder
    {
        [JsonProperty("proposedAllocations")]
        public List<ProposedAllocationsByOrderItemId> ProposedAllocations { get; set; } = new();
    }
}
