using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    /// <summary>Unlike the other property collections, this rel returns no totalResults.</summary>
    public class PalletTypeList
    {
        [JsonProperty("_embedded")]
        public EmbeddedPalletTypes Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded pallet types.</summary>
        [JsonIgnore]
        public List<PalletType> PalletTypes => Embedded?.PalletTypes ?? new();
    }
}
