using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>
    /// Records a pick of one pick line. There is no bulk form - Extensiv accepts exactly one
    /// <see cref="PickItemId"/> per request, so picking a whole movable unit means issuing one of
    /// these per serial, chaining the ETag returned by each response into the next request.
    /// </summary>
    public class PickInfo
    {
        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        /// <summary>Actual imperial weight picked. Specify this or <see cref="WeightMetric"/>, not both.</summary>
        [JsonProperty("weightImperial")]
        public decimal? WeightImperial { get; set; }

        /// <summary>Actual metric weight picked. Specify this or <see cref="WeightImperial"/>, not both.</summary>
        [JsonProperty("weightMetric")]
        public decimal? WeightMetric { get; set; }

        /// <summary>Optional; only needed for pick-to-bin.</summary>
        [JsonProperty("binOrderList")]
        public List<BinOrder>? BinOrderList { get; set; }

        [JsonProperty("pickItemId")]
        public string? PickItemId { get; set; }
    }
}
