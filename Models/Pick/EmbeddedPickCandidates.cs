using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class EmbeddedPickCandidates
    {
        [JsonProperty("item")]
        public List<PickCandidate> PickCandidates { get; set; }
    }
}
