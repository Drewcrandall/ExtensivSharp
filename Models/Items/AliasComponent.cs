using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class AliasComponent
    {
        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qty")]
        public decimal Quantity { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("itemDeactivated")]
        public bool ItemDeactivated { get; set; }
    }
}