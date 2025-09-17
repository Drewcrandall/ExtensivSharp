using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class ItemQualifier
    {
        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }
    }
}
