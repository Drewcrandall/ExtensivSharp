using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    /// <summary>This rel returns no totalResults - only the embedded collection.</summary>
    public class PackageContentList
    {
        [JsonProperty("_embedded")]
        public EmbeddedPackageContents Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded package contents.</summary>
        [JsonIgnore]
        public List<PackageContent> PackageContents => Embedded?.PackageContents ?? new();
    }
}
