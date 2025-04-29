using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class EmbeddedOrders
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/order")]
        public List<Order> Orders { get; set; }
    }
}
