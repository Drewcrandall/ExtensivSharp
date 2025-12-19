using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{

    public class InventoryLevels
    {
        [JsonProperty("onHand")]
        public decimal OnHand { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("secondaryAvailable")]
        public decimal SecondaryAvailable { get; set; }
    }
}
