using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>Assigns part of a pick to a bin, for pick-to-bin workflows.</summary>
    public class BinOrder
    {
        [JsonProperty("bin")]
        public string? Bin { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }
    }
}
