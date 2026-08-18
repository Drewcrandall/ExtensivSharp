using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Inventory
{
#pragma warning disable CS8618
    /// <summary>
    /// A movable unit as a resource in its own right - the pallet, carton, cart or trailer, not its
    /// contents. Read the contents with stock details filtered by this unit's label.
    /// Distinct from <see cref="PalletInfo"/>, which is the pallet block carried on a receiver item.
    /// </summary>
    public class Pallet
    {
        /// <summary>A new unique label, or leave blank for Extensiv to generate a license plate.</summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("palletTypeIdentifier")]
        public Identifier PalletTypeIdentifier { get; set; }

        [JsonProperty("metric")]
        public Dimensions Metric { get; set; }

        [JsonProperty("imperial")]
        public Dimensions Imperial { get; set; }

        [JsonProperty("rowVersion")]
        public string RowVersion { get; set; }
    }
}
