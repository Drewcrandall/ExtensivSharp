using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
    /// <summary>
    /// One manual allocation: take <see cref="Qty"/> from a specific receive item. Unlike picking,
    /// allocation accepts these in bulk, so an entire movable unit can be allocated in one request.
    /// </summary>
    public class ProposedAllocation
    {
        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }
    }
}
