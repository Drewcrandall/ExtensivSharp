using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class Kit
    {
        [JsonProperty("materialNotes")]
        public string MaterialNotes { get; set; }

        [JsonProperty("components")]
        public List<KitComponent> Components { get; set; }
    }
}
