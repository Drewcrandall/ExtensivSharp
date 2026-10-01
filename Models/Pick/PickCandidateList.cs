using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class PickCandidateList
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedPickCandidates Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded candidates.</summary>
        [JsonIgnore]
        public List<PickCandidate> PickCandidates => Embedded?.PickCandidates ?? new();
    }
}
