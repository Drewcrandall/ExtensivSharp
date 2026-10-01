using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class EmbeddedConsolidatedPickList
    {
        /// <summary>A single pick job, not a collection, on this rel.</summary>
        [JsonProperty("http://api.3plCentral.com/rels/orders/pickjob")]
        public PickJob PickJob { get; set; }

        [JsonProperty("item")]
        public List<ConsolidatedPickItem> Items { get; set; }
    }
}
