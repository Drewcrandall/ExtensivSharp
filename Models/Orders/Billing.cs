using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
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
