using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>Associates a picker with one pick line.</summary>
    public class PickLineInfo
    {
        [JsonProperty("pickerId")]
        public int? PickerId { get; set; }

        [JsonProperty("picker")]
        public Identifier? Picker { get; set; }

        [JsonProperty("pickItemId")]
        public string? PickItemId { get; set; }
    }
}
