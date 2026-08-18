using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
    /// <summary>
    /// Records that what was physically picked differs from what the pick line specified - a
    /// different location, lot, serial, expiration date or movable unit. Extensiv reconciles the
    /// allocation behind the scenes and errors if it cannot.
    /// </summary>
    public class MispickInfo
    {
        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        /// <summary>The location actually picked from.</summary>
        [JsonProperty("locationIdentifier")]
        public LocationIdentifier? LocationIdentifier { get; set; }

        /// <summary>The track-by values actually picked.</summary>
        [JsonProperty("itemTrackBys")]
        public ItemTrackBys? ItemTrackBys { get; set; }

        [JsonProperty("pickItemId")]
        public string? PickItemId { get; set; }
    }
}
