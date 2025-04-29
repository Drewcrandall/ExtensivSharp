using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class Billing
    {
        [JsonProperty("chargeType")]
        public int ChargeType { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("details")]
        public List<Detail> Details { get; set; }
    }
}
