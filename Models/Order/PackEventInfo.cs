using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    public class PackEventInfo
    {
        [JsonProperty("eventType")]
        public string? EventType { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }
    }
}
