using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class POReadOnly
    {
        [JsonProperty("purchaseOrderId")]
        public int PurchaseOrderId { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }
    }
}
