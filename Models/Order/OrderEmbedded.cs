using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class OrderEmbedded
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/item")]
        public List<OrderItem> OrderItems { get; set; }
    }
}
