using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class Package
    {
        [JsonProperty("packageId")]
        public int PackageId { get; set; }

        [JsonProperty("packageDefIdentifier")]
        public Identifier PackageDefIdentifier { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("packageContents")]
        public List<PackageContent> PackageContents { get; set; }
    }
}
