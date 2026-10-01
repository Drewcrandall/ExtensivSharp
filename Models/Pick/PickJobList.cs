using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class PickJobList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedPickJobs Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded pick jobs.</summary>
        [JsonIgnore]
        public List<PickJob> PickJobs => Embedded?.PickJobs ?? new();
    }
}
