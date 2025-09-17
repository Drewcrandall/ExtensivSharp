using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class Items
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedItems Embedded { get; set; }
    }
}
