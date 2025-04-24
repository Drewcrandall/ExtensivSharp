using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class EmbeddedOrders
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/order")]
        public List<Order> Orders { get; set; }
    }
}
