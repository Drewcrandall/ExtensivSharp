using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// The open orders currently occupying a bin. No results means the bin is free; one result means
    /// it is in use; more than one indicates the bin-occupancy logic has been bypassed somewhere.
    /// </summary>
    public class BinInfo
    {
        [JsonProperty("orderIds")]
        public List<int> OrderIds { get; set; }
    }
}
