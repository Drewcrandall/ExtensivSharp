using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class KitComponent
    {
        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("nonSkuMaterial")]
        public string NonSkuMaterial { get; set; }
    }
}
