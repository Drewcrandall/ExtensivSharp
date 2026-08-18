using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class ConsolidatedPickItem
    {
        [JsonProperty("pickItem")]
        public PickItem PickItem { get; set; }

        [JsonProperty("picker")]
        public Identifier Picker { get; set; }

        [JsonProperty("orderPickQtys")]
        public List<OrderPickQty> OrderPickQtys { get; set; }

        [JsonProperty("sourceData")]
        public List<PickSource> SourceData { get; set; }

        /// <summary>
        /// Opaque handle for this line, and the only way to address it when picking, unpicking,
        /// mispicking or loading. Extensiv states it must not be constructed or parsed.
        /// </summary>
        [JsonProperty("pickItemId")]
        public string PickItemId { get; set; }
    }
}
