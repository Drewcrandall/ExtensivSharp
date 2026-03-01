using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class Aliases
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedAliases Embedded { get; set; }
    }
}
