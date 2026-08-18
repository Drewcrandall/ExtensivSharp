using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
#pragma warning disable CS8618
    /// <summary>
    /// Identifies a movable unit (pallet, carton, cart, trailer). The label the warehouse scans is
    /// <c>NameKey.Name</c>.
    /// </summary>
    public class PalletIdentifier
    {
        [JsonProperty("nameKey")]
        public NameKey NameKey { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
