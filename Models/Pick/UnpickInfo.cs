using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>Backs out a quantity previously picked from one pick line.</summary>
    public class UnpickInfo
    {
        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("weightImperial")]
        public decimal? WeightImperial { get; set; }

        [JsonProperty("weightMetric")]
        public decimal? WeightMetric { get; set; }

        [JsonProperty("pickItemId")]
        public string? PickItemId { get; set; }
    }
}
