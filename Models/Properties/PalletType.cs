using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    /// <summary>A movable unit type: pallet, carton, skid, cart, trailer and so on.</summary>
    public class PalletType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lengthImperial")]
        public decimal LengthImperial { get; set; }

        [JsonProperty("widthImperial")]
        public decimal WidthImperial { get; set; }

        [JsonProperty("heightImperial")]
        public decimal HeightImperial { get; set; }

        [JsonProperty("weightImperial")]
        public decimal WeightImperial { get; set; }

        [JsonProperty("lengthMetric")]
        public decimal LengthMetric { get; set; }

        [JsonProperty("widthMetric")]
        public decimal WidthMetric { get; set; }

        [JsonProperty("heightMetric")]
        public decimal HeightMetric { get; set; }

        [JsonProperty("weightMetric")]
        public decimal WeightMetric { get; set; }

        [JsonProperty("materialType")]
        public int MaterialType { get; set; }

        [JsonProperty("loadType")]
        public int LoadType { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("defaultRate")]
        public decimal DefaultRate { get; set; }
    }
}
