using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    /// <summary>A rendered UCC-128 carton label, as ZPL.</summary>
    public class Ucc128Label
    {
        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("packageId")]
        public int PackageId { get; set; }

        [JsonProperty("zpl")]
        public string Zpl { get; set; }
    }
}
