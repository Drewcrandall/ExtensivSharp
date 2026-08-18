using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class EmbeddedPackages
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/package")]
        public List<Package> Packages { get; set; }
    }
}
