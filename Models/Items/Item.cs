using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Items
{
    public class Item
    {
        [JsonProperty("readOnly")]
        public ReadOnlyItemData ReadOnly { get; set; }

        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description2")]
        public string Description2 { get; set; }

        [JsonProperty("inventoryCategory")]
        public string InventoryCategory { get; set; }

        [JsonProperty("classificationIdentifier")]
        public Identifier ClassificationIdentifier { get; set; }

        [JsonProperty("nmfc")]
        public string Nmfc { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("temperature")]
        public decimal Temperature { get; set; }

        [JsonProperty("maxAllocateFromPickline")]
        public decimal MaxAllocateFromPickline { get; set; }

        [JsonProperty("picklineMin")]
        public decimal PicklineMin { get; set; }

        [JsonProperty("picklineMax")]
        public decimal PicklineMax { get; set; }

        [JsonProperty("accountRef")]
        public string AccountRef { get; set; }

        [JsonProperty("countryOfManufacture")]
        public string CountryOfManufacture { get; set; }

        [JsonProperty("harmonizedCode")]
        public string HarmonizedCode { get; set; }

        [JsonProperty("qualifierRenamers")]
        public List<QualifierRenamer> QualifierRenamers { get; set; }

        [JsonProperty("kit")]
        public Kit Kit { get; set; }

        [JsonProperty("options")]
        public ItemOptions Options { get; set; }

        [JsonProperty("replenishment")]
        public bool Replenishment { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedItem Embedded { get; set; }
    }
}
