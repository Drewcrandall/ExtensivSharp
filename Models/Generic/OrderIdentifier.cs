using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
    public class OrderIdentifier
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
