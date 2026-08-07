using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    /// <summary>
    /// Response envelope for POST /orders/{id}/items. The API returns a list rather than a single
    /// item because an alias SKU can expand into more than one order item.
    /// </summary>
    public class OrderItemList
    {
        [JsonProperty("_embedded")]
        public OrderEmbedded Embedded { get; set; }

        /// <summary>
        /// The created order items, or an empty list if the response carried none.
        /// </summary>
        [JsonIgnore]
        public List<OrderItem> OrderItems => Embedded?.OrderItems ?? new List<OrderItem>();
    }
}
