using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
    public class NameKey
    {
        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
