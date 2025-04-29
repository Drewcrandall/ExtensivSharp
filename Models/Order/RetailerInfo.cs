using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class RetailerInfo
    {
        [JsonProperty("nameKey")]
        public NameKey NameKey { get; set; }
    }
}
