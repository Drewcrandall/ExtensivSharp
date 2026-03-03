using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class Alias
    {
        //TODO update these properties to match the API response for Item Aliases, currently they are the same as Item properties

        [JsonProperty("aliasIdentifier")]
        public ItemIdentifier AliasIdentifier { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("details")]
        public List<AliasComponent> AliasComponents { get; set; }
    }
}
