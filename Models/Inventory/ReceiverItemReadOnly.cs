using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ReceiverItemReadOnly
    {
        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("fullyShippedDate")]
        public DateTime FullyShippedDate { get; set; }

        [JsonProperty("unitIdentifier")]
        public Identifier UnitIdentifier { get; set; }

        [JsonProperty("secondaryUnitIdentifier")]
        public Identifier SecondaryUnitIdentifier { get; set; }

        [JsonProperty("expectedQty")]
        public decimal ExpectedQty { get; set; }

        [JsonProperty("inventoryLevels")]
        public InventoryLevels InventoryLevels { get; set; }

        [JsonProperty("onHoldDate")]
        public DateTime OnHoldDate { get; set; }

        [JsonProperty("onHoldUserIdentifier")]
        public Identifier OnHoldUserIdentifier { get; set; }

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
