using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    #pragma warning disable CS8618
    public class OrderReadOnly
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("asnCandidate")]
        public int AsnCandidate { get; set; }

        [JsonProperty("routeCandidate")]
        public int RouteCandidate { get; set; }

        [JsonProperty("fullyAllocated")]
        public bool FullyAllocated { get; set; }

        [JsonProperty("deferNotification")]
        public bool DeferNotification { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }

        [JsonProperty("processDate")]
        public DateTime ProcessDate { get; set; }

        [JsonProperty("pickStarted")]
        public bool PickStarted { get; set; }

        [JsonProperty("packStarted")]
        public bool PackStarted { get; set; }

        [JsonProperty("loadedState")]
        public int LoadedState { get; set; }

        [JsonProperty("routeSent")]
        public bool RouteSent { get; set; }

        [JsonProperty("asnSent")]
        public bool AsnSent { get; set; }

        [JsonProperty("packages")]
        public List<Package> Packages { get; set; }

        [JsonProperty("shippingPallets")]
        public List<object> ShippingPallets { get; set; }

        [JsonProperty("outboundSerialNumbers")]
        public List<object> OutboundSerialNumbers { get; set; }

        [JsonProperty("parcelLabelType")]
        public int ParcelLabelType { get; set; }

        [JsonProperty("shipDate")]
        public DateTime ShipDate { get; set; }

        [JsonProperty("customerIdentifier")]
        public Identifier CustomerIdentifier { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("warehouseTransactionSourceType")]
        public int WarehouseTransactionSourceType { get; set; }

        [JsonProperty("transactionEntryType")]
        public int TransactionEntryType { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("createdByIdentifier")]
        public Identifier CreatedByIdentifier { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("lastModifiedByIdentifier")]
        public Identifier LastModifiedByIdentifier { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

}
