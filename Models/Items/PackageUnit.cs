using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class PackageUnit
    {
        [JsonProperty("imperial")]
        public Measurements Imperial { get; set; }

        [JsonProperty("metric")]
        public Measurements Metric { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("isPrepackaged")]
        public bool IsPrepackaged { get; set; }

        [JsonProperty("unitIdentifier")]
        public Identifier UnitIdentifier { get; set; }

        [JsonProperty("inventoryUnitsPerUnit")]
        public decimal InventoryUnitsPerUnit { get; set; }
    }
}
