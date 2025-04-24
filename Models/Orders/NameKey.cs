using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class NameKey
    {
        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
