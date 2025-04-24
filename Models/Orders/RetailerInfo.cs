using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class RetailerInfo
    {
        [JsonProperty("nameKey")]
        public NameKey NameKey { get; set; }
    }
}
