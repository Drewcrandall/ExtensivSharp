using ExtensivSharp.Models.Generic;
using ExtensivSharp.Models.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class StockSummary
    {
        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }
        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }
        [JsonProperty("totalReceived")]
        public decimal TotalReceived { get; set;  }
        [JsonProperty("allocated")]
        public decimal Allocated { get; set; }
        [JsonProperty("available")]
        public decimal Available { get; set; }
        [JsonProperty("onHold")]
        public decimal OnHold { get; set; }
        [JsonProperty("onHand")]
        public decimal OnHand { get; set; }
        [JsonProperty("orderedNotAllocated")]
        public decimal? OrderedNotAllocated { get; set; }
        [JsonProperty("facilityId")]
        public int FacilityId { get; set; }
    }
}
