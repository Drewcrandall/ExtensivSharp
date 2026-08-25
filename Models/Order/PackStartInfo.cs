using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    public class PackStartInfo
    {
        [JsonProperty("source")]
        public string? Source { get; set; }
    }
}
