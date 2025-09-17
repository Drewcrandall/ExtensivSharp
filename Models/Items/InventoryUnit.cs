using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class InventoryUnit
    {
        [JsonProperty("unitIdentifier")]
        public Identifier UnitIdentifier { get; set; }

        [JsonProperty("minimumStock")]
        public decimal MinimumStock { get; set; }

        [JsonProperty("maximumStock")]
        public decimal MaximumStock { get; set; }

        [JsonProperty("reorderQuantity")]
        public decimal ReorderQuantity { get; set; }

        [JsonProperty("inventoryMethod")]
        public int InventoryMethod { get; set; }

        [JsonProperty("imperial")]
        public Measurements Imperial { get; set; }

        [JsonProperty("metric")]
        public Measurements Metric { get; set; }
    }
}
