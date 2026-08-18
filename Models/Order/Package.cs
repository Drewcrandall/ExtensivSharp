using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    /// <summary>A labeling unit - a carton. Dimensions are in the measurement system of the order's facility.</summary>
    public class Package
    {
        [JsonProperty("packageId")]
        public int PackageId { get; set; }

        /// <summary>
        /// Largely ignored; defaults to 2 ("Package"). If supplied it must match a value in
        /// Extensiv's PackageType table.
        /// </summary>
        [JsonProperty("packageTypeId")]
        public int PackageTypeId { get; set; }

        /// <summary>
        /// Optional. When supplied, fills in length, width, height and weight for any of those not
        /// given explicitly.
        /// </summary>
        [JsonProperty("packageDefIdentifier")]
        public Identifier PackageDefIdentifier { get; set; }

        [JsonProperty("length")]
        public decimal? Length { get; set; }

        [JsonProperty("width")]
        public decimal? Width { get; set; }

        [JsonProperty("height")]
        public decimal? Height { get; set; }

        [JsonProperty("weight")]
        public decimal? Weight { get; set; }

        [JsonProperty("codAmount")]
        public decimal? CodAmount { get; set; }

        [JsonProperty("insuredAmount")]
        public decimal? InsuredAmount { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("readOnly")]
        public PackageReadOnly ReadOnly { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedPackageContents Embedded { get; set; }

        /// <summary>
        /// The package's contents. Extensiv carries these under "_embedded" on both requests and
        /// responses, so this projects onto <see cref="Embedded"/> rather than being a wire property
        /// in its own right.
        /// </summary>
        [JsonIgnore]
        public List<PackageContent> PackageContents
        {
            get => Embedded?.PackageContents ?? new();
            set => Embedded = new EmbeddedPackageContents { PackageContents = value };
        }
    }
}
