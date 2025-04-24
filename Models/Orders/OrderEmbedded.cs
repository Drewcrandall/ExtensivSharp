using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class OrderEmbedded
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/item")]
        public List<OrderItem> OrderItems { get; set; }
    }
}
