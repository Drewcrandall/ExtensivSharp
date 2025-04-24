using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class SavedElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
