using Newtonsoft.Json;

namespace ExtensivSharp.Models.Receivers
{
#pragma warning disable CS8618
    public class EmbeddedReceiveItems
    {
        [JsonProperty("http://api.3plCentral.com/rels/inventory/receiveritem")]
        public List<ReceiveItem> ReceiveItems { get; set; }
    }
}
