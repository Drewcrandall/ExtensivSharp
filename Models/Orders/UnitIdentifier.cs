using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class UnitIdentifier
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

}
