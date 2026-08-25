using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>Records a load-out of one pick line onto the trailer.</summary>
    public class LoadInfo
    {
        [JsonProperty("pickItemId")]
        public string? PickItemId { get; set; }
    }
}
