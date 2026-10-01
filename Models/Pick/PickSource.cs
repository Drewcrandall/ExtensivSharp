using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>Which receive item, and how much of it, backs a consolidated pick line.</summary>
    public class PickSource
    {
        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }
    }
}
