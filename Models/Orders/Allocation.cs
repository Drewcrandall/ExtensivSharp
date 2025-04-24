using Newtonsoft.Json;

namespace ExtensivSharp.Models.Orders
{
    public class Allocation
    {
        [JsonProperty("receiveItemId")]
        public int ReceiveItemId { get; set; }

        [JsonProperty("qty")]
        public double Qty { get; set; }

        [JsonProperty("properlyPickedPrimary")]
        public double ProperlyPickedPrimary { get; set; }

        [JsonProperty("properlyPickedSecondary")]
        public double ProperlyPickedSecondary { get; set; }

        [JsonProperty("loadedOut")]
        public bool LoadedOut { get; set; }

        [JsonProperty("rowVersion")]
        public string RowVersion { get; set; }
    }

}
