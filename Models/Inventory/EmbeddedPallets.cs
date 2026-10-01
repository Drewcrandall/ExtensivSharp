using Newtonsoft.Json;

namespace ExtensivSharp.Models.Inventory
{
#pragma warning disable CS8618
    public class EmbeddedPallets
    {
        [JsonProperty("http://api.3plCentral.com/rels/inventory/pallet")]
        public List<Pallet> Pallets { get; set; }
    }
}
