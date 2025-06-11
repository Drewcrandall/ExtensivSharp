using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Receivers
{
#pragma warning disable CS8618
    public class PalletInfo
    {
        [JsonProperty("palletId")]
        public int PalletId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("palletTypeIdentifier")]
        public Identifier PalletTypeIdentifier { get; set; }

        [JsonProperty("metric")]
        public Receivers.Measurement Metric { get; set; }

        [JsonProperty("imperial")]
        public Receivers.Measurement Imperial { get; set; }
    }
}
