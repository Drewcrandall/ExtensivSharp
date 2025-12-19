using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class PurchaseOrder
    {
        [JsonProperty("readOnly")]
        public POReadOnly ReadOnly { get; set; }

        [JsonProperty("purchaseOrderNumber")]
        public string PurchaseOrderNumber { get; set; }

        [JsonProperty("customerIdentifier")]
        public CustomerIdentifier CustomerIdentifier { get; set; }

        [JsonProperty("issueDate")]
        public DateTime IssueDate { get; set; }

        [JsonProperty("supplier")]
        public Supplier Supplier { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("lineItems")]
        public List<POLineItem> LineItems { get; set; }
    }

}
