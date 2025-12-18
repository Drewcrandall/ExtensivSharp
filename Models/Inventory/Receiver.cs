using ExtensivSharp.Models.Generic;
using ExtensivSharp.Models.Order;
using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class Receiver
    {
        [JsonProperty("readOnly")]
        public ReceiverReadOnly ReadOnly { get; set; }

        [JsonProperty("referenceNum")]
        public string ReferenceNum { get; set; }

        [JsonProperty("poNum")]
        public string PoNum { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("receiptAdviceNumber")]
        public string ReceiptAdviceNumber { get; set; }

        [JsonProperty("arrivalDate")]
        public DateTime ArrivalDate { get; set; }

        [JsonProperty("scannedArrivalDate")]
        public DateTime ScannedArrivalDate { get; set; }

        [JsonProperty("expectedDate")]
        public DateTime ExpectedDate { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("shipTo")]
        public ShipTo ShipTo { get; set; }

        [JsonProperty("scacCode")]
        public string ScacCode { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("billOfLading")]
        public string BillOfLading { get; set; }

        [JsonProperty("doorNumber")]
        public string DoorNumber { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("trailerNumber")]
        public string TrailerNumber { get; set; }

        [JsonProperty("sealNumber")]
        public string SealNumber { get; set; }

        [JsonProperty("capacityTypeIdentifier")]
        public Identifier CapacityTypeIdentifier { get; set; }

        [JsonProperty("numUnits1")]
        public decimal NumUnits1 { get; set; }

        [JsonProperty("unit1Identifier")]
        public Identifier Unit1Identifier { get; set; }

        [JsonProperty("numUnits2")]
        public decimal NumUnits2 { get; set; }

        [JsonProperty("unit2Identifier")]
        public Identifier Unit2Identifier { get; set; }

        [JsonProperty("totalWeight")]
        public decimal TotalWeight { get; set; }

        [JsonProperty("totalVolume")]
        public decimal TotalVolume { get; set; }

        [JsonProperty("savedElements")]
        public List<SavedElement> SavedElements { get; set; }

        [JsonProperty("_embedded")]
        public ReceiverItemEmbedded Embedded { get; set; }
    }
}
