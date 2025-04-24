using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class OrderItem
    {
        [JsonProperty("readOnly")]
        public ReadOnlyOrderItem ReadOnly { get; set; }

        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("qty")]
        public double Qty { get; set; }

        [JsonProperty("weightImperial")]
        public double WeightImperial { get; set; }

        [JsonProperty("weightMetric")]
        public double WeightMetric { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("savedElements")]
        public List<SavedElement> SavedElements { get; set; }

        [JsonProperty("isInsert")]
        public bool IsInsert { get; set; }
    }
}
