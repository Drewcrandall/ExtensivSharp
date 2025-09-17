using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class EmbeddedItem
    {
        [JsonProperty("item")]
        public List<ItemQualifier> Items { get; set; }
    }
}
