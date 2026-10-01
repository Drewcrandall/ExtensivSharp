using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// A consolidated pick line's breakdown by order. Only needed for pick-to-bin; otherwise it can
    /// safely be ignored.
    /// </summary>
    public class OrderPickQty
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("orderItemIds")]
        public List<int> OrderItemIds { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("pickedQty")]
        public decimal PickedQty { get; set; }

        [JsonProperty("bin")]
        public string Bin { get; set; }

        [JsonProperty("loaded")]
        public bool Loaded { get; set; }
    }
}
