using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    public class EmbeddedLocations
    {
        [JsonProperty("http://api.3plCentral.com/rels/properties/location")]
        public List<Location> Locations { get; set; }
    }
}
