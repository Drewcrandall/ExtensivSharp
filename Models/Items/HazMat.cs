using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class HazMat
    {
        [JsonProperty("isHazMat")]
        public bool IsHazMat { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("shippingName")]
        public string ShippingName { get; set; }

        [JsonProperty("hazardClass")]
        public string HazardClass { get; set; }

        [JsonProperty("packingGroup")]
        public string PackingGroup { get; set; }

        [JsonProperty("flashPoint")]
        public string FlashPoint { get; set; }

        [JsonProperty("labelCode")]
        public string LabelCode { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
