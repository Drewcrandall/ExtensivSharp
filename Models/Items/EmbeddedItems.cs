using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class EmbeddedItems
    {
        [JsonProperty("http://api.3plCentral.com/rels/customers/item")]
        public List<Item> Items { get; set; }
    }

}
