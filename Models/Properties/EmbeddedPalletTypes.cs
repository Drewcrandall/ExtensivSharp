using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    public class EmbeddedPalletTypes
    {
        [JsonProperty("http://api.3plCentral.com/rels/properties/pallettype")]
        public List<PalletType> PalletTypes { get; set; }
    }
}
