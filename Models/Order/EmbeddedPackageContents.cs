using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class EmbeddedPackageContents
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/packagecontent")]
        public List<PackageContent> PackageContents { get; set; }
    }
}
