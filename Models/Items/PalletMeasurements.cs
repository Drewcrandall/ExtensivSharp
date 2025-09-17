using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class PalletMeasurements
    {
        [JsonProperty("length")]
        public decimal Length { get; set; }

        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }
    }
}
