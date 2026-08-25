using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class PackageReadOnly
    {
        [JsonProperty("oversize")]
        public bool? Oversize { get; set; }

        [JsonProperty("cod")]
        public bool? Cod { get; set; }

        /// <summary>
        /// Incremental package id used to build the UCC-128; increments on every package created.
        /// The full UCC-128 is held in <see cref="CartonId"/>.
        /// </summary>
        [JsonProperty("ucc128")]
        public int? Ucc128 { get; set; }

        /// <summary>The full UCC-128 value: the GS1 company prefix followed by <see cref="Ucc128"/>.</summary>
        [JsonProperty("cartonId")]
        public string CartonId { get; set; }

        [JsonProperty("label")]
        public byte[] Label { get; set; }
    }
}
