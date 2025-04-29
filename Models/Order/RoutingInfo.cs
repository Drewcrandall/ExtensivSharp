using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class RoutingInfo
    {
        [JsonProperty("isCod")]
        public bool IsCod { get; set; }

        [JsonProperty("isInsurance")]
        public bool IsInsurance { get; set; }

        [JsonProperty("requiresDeliveryConf")]
        public bool RequiresDeliveryConf { get; set; }

        [JsonProperty("requiresReturnReceipt")]
        public bool RequiresReturnReceipt { get; set; }

        [JsonProperty("scacCode")]
        public string ScacCode { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("shipPointZip")]
        public string ShipPointZip { get; set; }

        [JsonProperty("capacityTypeIdentifier")]
        public Identifier CapacityTypeIdentifier { get; set; }

        [JsonProperty("loadNumber")]
        public string LoadNumber { get; set; }

        [JsonProperty("billOfLading")]
        public string BillOfLading { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("trailerNumber")]
        public string TrailerNumber { get; set; }

        [JsonProperty("sealNumber")]
        public string SealNumber { get; set; }

        [JsonProperty("doorNumber")]
        public string DoorNumber { get; set; }

        [JsonProperty("pickupDate")]
        public DateTime PickupDate { get; set; }
    }
}
