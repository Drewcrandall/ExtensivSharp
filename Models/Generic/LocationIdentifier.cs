using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
    public class LocationIdentifier
    {
        [JsonProperty("nameKey")]
        public NameKey NameKey { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
