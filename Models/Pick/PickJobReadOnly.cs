using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    public class PickJobReadOnly
    {
        [JsonProperty("pickJobId")]
        public int PickJobId { get; set; }

        [JsonProperty("customerIdentifier")]
        public CustomerIdentifier CustomerIdentifier { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        /// <summary>Number of orders in this pick job; a convenience count of OrderIdentifiers.</summary>
        [JsonProperty("nOrders")]
        public int NOrders { get; set; }

        [JsonProperty("createdBy")]
        public Identifier CreatedBy { get; set; }

        [JsonProperty("creationDateUtc")]
        public DateTime CreationDateUtc { get; set; }

        [JsonProperty("lastUpdatedBy")]
        public Identifier LastUpdatedBy { get; set; }

        [JsonProperty("lastUpdateDateUtc")]
        public DateTime LastUpdateDateUtc { get; set; }

        [JsonProperty("assignedDateUtc")]
        public DateTime? AssignedDateUtc { get; set; }

        [JsonProperty("doneDateUtc")]
        public DateTime? DoneDateUtc { get; set; }

        /// <summary>True if the operator closed the job with items still left to pick.</summary>
        [JsonProperty("doneIncomplete")]
        public bool DoneIncomplete { get; set; }

        [JsonProperty("reasonForIncomplete")]
        public string ReasonForIncomplete { get; set; }

        /// <summary>Maintained automatically when a mispick is recorded.</summary>
        [JsonProperty("mispickExplanations")]
        public string MispickExplanations { get; set; }

        [JsonProperty("onHoldDate")]
        public DateTime? OnHoldDate { get; set; }

        /// <summary>
        /// When non-null, the PickJobId of the first pick job in the batch this job belongs to.
        /// </summary>
        [JsonProperty("batchId")]
        public int? BatchId { get; set; }
    }
}
