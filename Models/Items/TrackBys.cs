using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class TrackBys
    {
        [JsonProperty("trackLotNumber")]
        public int TrackLotNumber { get; set; }

        [JsonProperty("trackSerialNumber")]
        public int TrackSerialNumber { get; set; }

        [JsonProperty("trackExpirationDate")]
        public int TrackExpirationDate { get; set; }

        [JsonProperty("trackCost")]
        public int TrackCost { get; set; }

        [JsonProperty("outboundMobileSerialization")]
        public int OutboundMobileSerialization { get; set; }

        [JsonProperty("autoHoldExpirationDaysThreshold")]
        public int AutoHoldExpirationDaysThreshold { get; set; }

        [JsonProperty("isPickLotNumberRequired")]
        public bool IsPickLotNumberRequired { get; set; }

        [JsonProperty("isPickSerialNumberRequired")]
        public bool IsPickSerialNumberRequired { get; set; }

        [JsonProperty("isPickExpirationDateRequired")]
        public bool IsPickExpirationDateRequired { get; set; }

        [JsonProperty("movableUnitsUsageLevel")]
        public int MovableUnitsUsageLevel { get; set; }
    }

}
