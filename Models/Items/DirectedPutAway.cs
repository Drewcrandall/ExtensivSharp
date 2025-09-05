using Newtonsoft.Json;
using ExtensivSharp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class DirectedPutAway
    {
        [JsonProperty("locationZones")]
        public string LocationZones { get; set; }

        [JsonProperty("palletLocationZones")]
        public string PalletLocationZones { get; set; }

        [JsonProperty("overAllocLocationZones")]
        public string OverAllocLocationZones { get; set; }

        [JsonProperty("preferredLocationIdentifier")]
        public LocationIdentifier PreferredLocationIdentifier { get; set; }

        [JsonProperty("forceIntoPreferredLocation")]
        public bool ForceIntoPreferredLocation { get; set; }

        [JsonProperty("allowMixedItemStorage")]
        public bool AllowMixedItemStorage { get; set; }

        [JsonProperty("allowMixedLotStorage")]
        public bool AllowMixedLotStorage { get; set; }

        [JsonProperty("mixedExpirationDaysThreshold")]
        public int MixedExpirationDaysThreshold { get; set; }
    }
}
