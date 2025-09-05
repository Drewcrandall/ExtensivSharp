using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class ItemOptions
    {
        [JsonProperty("inventoryUnit")]
        public InventoryUnit InventoryUnit { get; set; }

        [JsonProperty("secondaryUnit")]
        public SecondaryUnit SecondaryUnit { get; set; }

        [JsonProperty("packageUnit")]
        public PackageUnit PackageUnit { get; set; }

        [JsonProperty("trackBys")]
        public TrackBys TrackBys { get; set; }

        [JsonProperty("pallets")]
        public Pallets Pallets { get; set; }

        [JsonProperty("hazMat")]
        public HazMat HazMat { get; set; }

        [JsonProperty("directedPutAway")]
        public DirectedPutAway DirectedPutAway { get; set; }

        [JsonProperty("daysBetweenCounts")]
        public int DaysBetweenCounts { get; set; }

        [JsonProperty("autoHoldOnReceive")]
        public bool AutoHoldOnReceive { get; set; }
    }
}
