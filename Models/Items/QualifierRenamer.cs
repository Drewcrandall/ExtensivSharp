using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class QualifierRenamer
    {
        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("renames")]
        public string Renames { get; set; }
    }

}
