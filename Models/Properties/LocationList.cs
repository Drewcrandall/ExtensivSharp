using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    public class LocationList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedLocations Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded locations.</summary>
        [JsonIgnore]
        public List<Location> Locations => Embedded?.Locations ?? new();
    }
}
