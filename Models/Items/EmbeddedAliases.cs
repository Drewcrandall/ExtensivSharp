using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class EmbeddedAliases
    {
        [JsonProperty("http://api.3plCentral.com/rels/customers/itemalias")]
        public List<Alias> Aliases { get; set; }
    }

}
