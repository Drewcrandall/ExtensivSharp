using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class PalletInfo
    {
        [JsonProperty("palletId")]
        public int PalletId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("splitOverCapacityOnCreate")]
        public bool SplitOverCapacityOnCreate { get; set; }

        [JsonProperty("qtyOverrideOnSplit")]
        public decimal QtyOverrideOnSplit { get; set; }

        [JsonProperty("palletTypeIdentifier")]
        public Identifier PalletTypeIdentifier { get; set; }

        [JsonProperty("metric")]
        public Dimensions Metric { get; set; }

        [JsonProperty("imperial")]
        public Dimensions Imperial { get; set; }
    }
}
