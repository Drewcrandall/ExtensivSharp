using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Receivers
{
#pragma warning disable CS8618
    public class ReceiveItem
    {
        [JsonProperty("readOnly")]
        public ReceiveItemReadOnly ReadOnly { get; set; }

        [JsonProperty("itemIdentifier")]
        public Identifier ItemIdentifier { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("lotNumber")]
        public string LotNumber { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("palletInfo")]
        public PalletInfo PalletInfo { get; set; }

        [JsonProperty("onHold")]
        public bool OnHold { get; set; }

        [JsonProperty("savedElements")]
        public List<SavedElement> SavedElements { get; set; }
    }
}
