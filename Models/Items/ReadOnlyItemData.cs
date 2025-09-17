using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class ReadOnlyItemData
    {
        [JsonProperty("customerIdentifier")]
        public CustomerIdentifier CustomerIdentifier { get; set; }

        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("deactivated")]
        public bool Deactivated { get; set; }

        [JsonProperty("lastPriceChange")]
        public DateTime LastPriceChange { get; set; }

        [JsonProperty("hasStorageRates")]
        public bool HasStorageRates { get; set; }

        [JsonProperty("rowVersion")]
        public string RowVersion { get; set; }
    }
}
