using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class PurchaseOrderEmbedded
    {
        [JsonProperty("http://api.3plCentral.com/rels/inventory/purchaseorder")]
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
