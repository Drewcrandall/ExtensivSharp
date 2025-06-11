using Newtonsoft.Json;

namespace ExtensivSharp.Models.Receivers
{
#pragma warning disable CS8618
    public class ReceiveItemResponse
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedReceiveItems Embedded { get; set; }
    }
}
