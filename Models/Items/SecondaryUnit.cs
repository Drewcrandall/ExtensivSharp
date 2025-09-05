using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class SecondaryUnit
    {
        [JsonProperty("inventoryAlso")]
        public bool InventoryAlso { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("imperial")]
        public Measurements Imperial { get; set; }

        [JsonProperty("metric")]
        public Measurements Metric { get; set; }

        [JsonProperty("unitIdentifier")]
        public Identifier UnitIdentifier { get; set; }

        [JsonProperty("inventoryUnitsPerUnit")]
        public decimal InventoryUnitsPerUnit { get; set; }
    }
}
