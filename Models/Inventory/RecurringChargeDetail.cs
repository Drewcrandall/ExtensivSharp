using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class RecurringChargeDetail
    {
        [JsonProperty("recurringBillingDetailId")]
        public int RecurringBillingDetailId { get; set; }

        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("onHandAtBillTime")]
        public decimal OnHandAtBillTime { get; set; }

        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

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

        [JsonProperty("locationIdentifier")]
        public LocationIdentifier LocationIdentifier { get; set; }

        [JsonProperty("palletIdentifier")]
        public PalletIdentifier PalletIdentifier { get; set; }
    }
}
