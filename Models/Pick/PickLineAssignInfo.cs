using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>Marks one pick line as assigned to a picker.</summary>
    public class PickLineAssignInfo
    {
        [JsonProperty("pickerId")]
        public int? PickerId { get; set; }

        [JsonProperty("picker")]
        public Identifier? Picker { get; set; }

        [JsonProperty("pickItemId")]
        public string? PickItemId { get; set; }
    }
}
