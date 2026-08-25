using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Inventory
{
#pragma warning disable CS8618
    /// <summary>
    /// Inventory at receive-item granularity, including track-bys. This is how the contents of a
    /// movable unit are read: filter with RQL on <c>palletidentifier.namekey.name</c> and each row
    /// gives you a serial and the <see cref="ReceiveItemId"/> needed to allocate it.
    /// </summary>
    public class StockDetail
    {
        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("itemIdentifier")]
        public ItemIdentifier ItemIdentifier { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description2")]
        public string Description2 { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("received")]
        public decimal Received { get; set; }

        /// <summary>Unallocated quantity. See <see cref="IsOnHold"/> for whether it is allocatable.</summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }

        /// <summary>True if the receive item is explicitly held.</summary>
        [JsonProperty("isOnHold")]
        public bool IsOnHold { get; set; }

        /// <summary>True if implicitly held by virtue of sitting in a quarantine location.</summary>
        [JsonProperty("quarantined")]
        public bool Quarantined { get; set; }

        [JsonProperty("onHand")]
        public decimal OnHand { get; set; }

        [JsonProperty("secondaryReceived")]
        public decimal? SecondaryReceived { get; set; }

        [JsonProperty("secondaryAvailable")]
        public decimal? SecondaryAvailable { get; set; }

        [JsonProperty("lotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("cost")]
        public decimal? Cost { get; set; }

        [JsonProperty("supplierIdentifier")]
        public Identifier SupplierIdentifier { get; set; }

        [JsonProperty("locationIdentifier")]
        public LocationIdentifier LocationIdentifier { get; set; }

        /// <summary>The movable unit this inventory sits on, if any.</summary>
        [JsonProperty("palletIdentifier")]
        public PalletIdentifier PalletIdentifier { get; set; }

        [JsonProperty("palletTypeIdentifier")]
        public Identifier PalletTypeIdentifier { get; set; }

        [JsonProperty("inventoryUnitOfMeasureIdentifier")]
        public Identifier InventoryUnitOfMeasureIdentifier { get; set; }

        [JsonProperty("secondaryUnitOfMeasureIdentifier")]
        public Identifier SecondaryUnitOfMeasureIdentifier { get; set; }

        [JsonProperty("inventoryUnitsPerSecondaryUnit")]
        public decimal? InventoryUnitsPerSecondaryUnit { get; set; }

        [JsonProperty("receiverId")]
        public int ReceiverId { get; set; }

        [JsonProperty("receivedDate")]
        public DateTime ReceivedDate { get; set; }

        [JsonProperty("referenceNum")]
        public string ReferenceNum { get; set; }

        [JsonProperty("poNum")]
        public string PoNum { get; set; }

        [JsonProperty("trailerNumber")]
        public string TrailerNumber { get; set; }

        [JsonProperty("savedElements")]
        public List<SavedElement> SavedElements { get; set; }

        [JsonProperty("weightImperial")]
        public decimal? WeightImperial { get; set; }

        [JsonProperty("weightMetric")]
        public decimal? WeightMetric { get; set; }
    }
}
