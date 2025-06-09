using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Receivers
{
    public class ReceiveItemPutRequest
    {
        [JsonProperty("receiveItemIds")]
        public List<int> ReceiveItemIds { get; set; }

        [JsonProperty("lotNumber")]
        public string? LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string? SerialNumber { get; set; }

        [JsonProperty("setExpirationDateToNull")]
        public bool? SetExpirationDateToNull { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("setCostToNull")]
        public bool? SetCostToNull { get; set; }

        [JsonProperty("cost")]
        public double? Cost { get; set; }

        [JsonProperty("supplierIdentifier")]
        public SupplierIdentifier? SupplierIdentifier { get; set; }

        [JsonProperty("savedElementsToAddOrUpdate")]
        public List<SavedElement>? SavedElementsToAddOrUpdate { get; set; }

        [JsonProperty("savedElementNamesToDelete")]
        public List<SavedElement>? SavedElementNamesToDelete { get; set; }
    }
}
