using ExtensivSharp.Models.Generic;
using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ReceiverItem
    {
        [JsonProperty("readOnly")]
        public ReceiverItemReadOnly ReadOnly { get; set; }

        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("secondaryQty")]
        public decimal SecondaryQty { get; set; }

        [JsonProperty("lotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("supplierIdentifier")]
        public Identifier SupplierIdentifier { get; set; }

        [JsonProperty("locationInfo")]
        public LocationInfo LocationInfo { get; set; }

        [JsonProperty("palletInfo")]
        public PalletInfo PalletInfo { get; set; }

        [JsonProperty("weightImperial")]
        public decimal WeightImperial { get; set; }

        [JsonProperty("weightMetric")]
        public decimal WeightMetric { get; set; }

        [JsonProperty("onHold")]
        public bool OnHold { get; set; }

        [JsonProperty("onHoldReason")]
        public string OnHoldReason { get; set; }

        [JsonProperty("savedElements")]
        public List<SavedElement> SavedElements { get; set; }

        [JsonProperty("condensedSEs")]
        public string CondensedSEs { get; set; }
    }
}
