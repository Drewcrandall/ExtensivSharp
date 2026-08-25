using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class EmbeddedPickCandidatePickJob
    {
        [JsonProperty("http://api.3plCentral.com/rels/orders/pickjob")]
        public PickJob PickJob { get; set; }
    }
}
