using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// A pick job's full pick list, consolidated by Location + ItemTraits across every order in the
    /// job. This is returned by every pick-affecting call, each time with a fresh ETag - so the
    /// response of one pick supplies the If-Match value for the next.
    /// </summary>
    public class ConsolidatedPickList
    {
        [JsonProperty("_embedded")]
        public EmbeddedConsolidatedPickList Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded pick job.</summary>
        [JsonIgnore]
        public PickJob? PickJob => Embedded?.PickJob;

        /// <summary>Convenience accessor for the embedded pick lines.</summary>
        [JsonIgnore]
        public List<ConsolidatedPickItem> Items => Embedded?.Items ?? new();
    }
}
