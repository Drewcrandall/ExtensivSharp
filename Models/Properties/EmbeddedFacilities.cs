using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    public class EmbeddedFacilities
    {
        [JsonProperty("http://api.3plCentral.com/rels/properties/facility")]
        public List<Facility> Facilities { get; set; }
    }
}
