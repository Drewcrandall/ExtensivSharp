using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class Pallets
    {
        [JsonProperty("typeIdentifier")]
        public Identifier TypeIdentifier { get; set; }

        [JsonProperty("tie")]
        public decimal Tie { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("imperial")]
        public PalletMeasurements Imperial { get; set; }

        [JsonProperty("metric")]
        public PalletMeasurements Metric { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }
    }
}
