using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    /// <summary>This rel returns no totalResults - only the embedded collection.</summary>
    public class PackageList
    {
        [JsonProperty("_embedded")]
        public EmbeddedPackages Embedded { get; set; }

        /// <summary>Convenience accessor for the embedded packages.</summary>
        [JsonIgnore]
        public List<Package> Packages => Embedded?.Packages ?? new();
    }
}
