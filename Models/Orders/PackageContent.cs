using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class PackageContent
    {
        [JsonProperty("packageContentId")]
        public int PackageContentId { get; set; }

        [JsonProperty("packageId")]
        public int PackageId { get; set; }

        [JsonProperty("orderItemId")]
        public int OrderItemId { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("serialNumbers")]
        public List<string> SerialNumbers { get; set; }
    }
}
