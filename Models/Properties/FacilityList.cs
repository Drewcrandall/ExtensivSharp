using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    public class FacilityList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedFacilities Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded facilities.</summary>
        [JsonIgnore]
        public List<Facility> Facilities => Embedded?.Facilities ?? new();
    }
}
