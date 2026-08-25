using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    /// <summary>
    /// A quantity of one SKU inside a package. Unlike picking, this accepts many serials at once via
    /// <see cref="SerialNumbers"/>, so an entire movable unit's worth can go up in a single request.
    /// </summary>
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

        [JsonProperty("orderItemPickExceptionId")]
        public int? OrderItemPickExceptionId { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("lotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("serialNumbers")]
        public List<string> SerialNumbers { get; set; }

        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }
    }
}
