using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
    public class CustomerIdentifier
    {
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
