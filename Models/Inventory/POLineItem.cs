using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class POLineItem
    {
        [JsonProperty("purchaseOrderLineItemId")]
        public int PurchaseOrderLineItemId { get; set; }

        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("expectedFacility")]
        public ExpectedFacility ExpectedFacility { get; set; }

        [JsonProperty("expectedDate")]
        public DateTime ExpectedDate { get; set; }

        [JsonProperty("cancelDate")]
        public DateTime CancelDate { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("externalLineId")]
        public string ExternalLineId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
