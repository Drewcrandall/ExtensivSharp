using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Receivers
{
#pragma warning disable CS8618
    public class ReceiveItemReadOnly
    {
        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("fullyShippedDate")]
        public DateTime FullyShippedDate { get; set; }

        [JsonProperty("unitIdentifier")]
        public Identifier UnitIdentifier { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("transactionID")]
        public int TransactionID { get; set; }

        [JsonProperty("rowVersion")]
        public string RowVersion { get; set; }
    }
}
