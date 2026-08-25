using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// One order that is a candidate for picking. Extensiv already filters out shipped and
    /// under-allocated orders, so anything returned here is pickable.
    /// </summary>
    public class PickCandidate
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }

        /// <summary>Stored and displayed in warehouse time, not UTC.</summary>
        [JsonProperty("pickDoneDate")]
        public DateTime? PickDoneDate { get; set; }

        [JsonProperty("loadOutDoneDate")]
        public DateTime? LoadOutDoneDate { get; set; }

        [JsonProperty("fullyAllocated")]
        public bool FullyAllocated { get; set; }

        [JsonProperty("pickJobId")]
        public int? PickJobId { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        /// <summary>Pick information for this order alone, not consolidated across a multi-order job.</summary>
        [JsonProperty("pickList")]
        public List<CandidatePickItem> PickList { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("customerDeactivated")]
        public bool CustomerDeactivated { get; set; }

        [JsonProperty("onHoldDate")]
        public DateTime? OnHoldDate { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedPickCandidatePickJob Embedded { get; set; }

        /// <summary>The pick job this order belongs to, or null if it has not been assigned to one.</summary>
        [JsonIgnore]
        public PickJob? PickJob => Embedded?.PickJob;
    }
}
