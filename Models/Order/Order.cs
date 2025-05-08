using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class Order
    {
        [JsonProperty("readOnly")]
        public OrderReadOnly ReadOnly { get; set; }

        [JsonProperty("referenceNum")]
        public string ReferenceNum { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("numUnits1")]
        public double NumUnits1 { get; set; }

        [JsonProperty("totalWeight")]
        public decimal TotalWeight { get; set; }

        [JsonProperty("totalVolume")]
        public decimal TotalVolume { get; set; }

        [JsonProperty("billingCode")]
        public string BillingCode { get; set; }

        [JsonProperty("addFreightToCod")]
        public bool AddFreightToCod { get; set; }

        [JsonProperty("upsIsResidential")]
        public bool UpsIsResidential { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("poNum")]
        public string PoNum { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("earliestShipDate")]
        public DateTime? EarliestShipDate { get; set; }

        [JsonProperty("shipCancelDate")]
        public DateTime? ShipCancelDate { get; set; }

        [JsonProperty("unit1Identifier")]
        public Identifier Unit1Identifier { get; set; }

        [JsonProperty("numUnits2")]
        public int NumUnits2 { get; set; }

        [JsonProperty("unit2Identifier")]
        public Identifier Unit2Identifier { get; set; }

        [JsonProperty("asnNumber")]
        public string AsnNumber { get; set; }

        [JsonProperty("upsServiceOptionCharge")]
        public decimal UpsServiceOptionCharge { get; set; }

        [JsonProperty("upsTransportationCharge")]
        public decimal UpsTransportationCharge { get; set; }

        [JsonProperty("exportChannelIdentifier")]
        public Identifier ExportChannelIdentifier { get; set; }

        [JsonProperty("routePickupDate")]
        public DateTime? RoutePickupDate { get; set; }

        [JsonProperty("shippingNotes")]
        public string ShippingNotes { get; set; }

        [JsonProperty("masterBillOfLadingId")]
        public string MasterBillOfLadingId { get; set; }

        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("fulfillInvInfo")]
        public FulfillInvInfo FulfillInvInfo { get; set; }

        [JsonProperty("routingInfo")]
        public RoutingInfo RoutingInfo { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("shipTo")]
        public ShipTo ShipTo { get; set; }

        [JsonProperty("soldTo")]
        public SoldTo SoldTo { get; set; }

        [JsonProperty("billTo")]
        public BillTo BillTo { get; set; }

        [JsonProperty("savedElements")]
        public List<SavedElement> SavedElements { get; set; }
        [JsonProperty("parcelOption")]
        public ParcelOption ParcelOption { get; set; }

        [JsonProperty("_embedded")]
        public OrderEmbedded Embedded { get; set; }
    }
}
