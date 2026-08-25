using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
    /// <summary>Shipping details recorded when an order is confirmed.</summary>
    public class OrderConfirmInfo
    {
        /// <summary>
        /// Must not be in the future, nor before the facility's FreezeDate, unless the calling user
        /// has administrative authority. Violating either is a common cause of a 400 here.
        /// </summary>
        [JsonProperty("confirmDate")]
        public DateTime? ConfirmDate { get; set; }

        [JsonProperty("trackingNumber")]
        public string? TrackingNumber { get; set; }

        [JsonProperty("trailerNumber")]
        public string? TrailerNumber { get; set; }

        [JsonProperty("sealNumber")]
        public string? SealNumber { get; set; }

        [JsonProperty("billOfLading")]
        public string? BillOfLading { get; set; }

        [JsonProperty("loadNumber")]
        public string? LoadNumber { get; set; }

        [JsonProperty("doorNumber")]
        public string? DoorNumber { get; set; }
    }
}
