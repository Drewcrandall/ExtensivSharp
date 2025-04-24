using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class ItemIdentifier
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

}
