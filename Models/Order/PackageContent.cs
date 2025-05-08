using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class PackageContent
    {
        [JsonProperty("packageContentId")]
        public int PackageContentId { get; set; }

        [JsonProperty("packageId")]
        public int PackageId { get; set; }

        [JsonProperty("orderItemId")]
        public int OrderItemId { get; set; }

        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("qty")]
        public double Qty { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("serialNumbers")]
        public List<string> SerialNumbers { get; set; }

        [JsonProperty("lotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}
