using Newtonsoft.Json;

namespace ExtensivSharp.Models.Receivers
{
#pragma warning disable CS8618
    public class Measurement
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
