using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    /// <summary>A storage spot within a facility. Also used to name a pick job's load-out staging location.</summary>
    public class Location
    {
        [JsonProperty("allocationPriority")]
        public int AllocationPriority { get; set; }

        /// <summary>Required.</summary>
        [JsonProperty("field1")]
        public string Field1 { get; set; }

        [JsonProperty("field2")]
        public string Field2 { get; set; }

        [JsonProperty("field3")]
        public string Field3 { get; set; }

        [JsonProperty("field4")]
        public string Field4 { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("locationTypeIdentifier")]
        public Identifier LocationTypeIdentifier { get; set; }

        [JsonProperty("locationBillingTypeIdentifier")]
        public Identifier LocationBillingTypeIdentifier { get; set; }

        [JsonProperty("quarantinable")]
        public bool Quarantinable { get; set; }

        [JsonProperty("height")]
        public decimal? Height { get; set; }

        [JsonProperty("width")]
        public decimal? Width { get; set; }

        [JsonProperty("length")]
        public decimal? Length { get; set; }

        [JsonProperty("weightAllowed")]
        public decimal? WeightAllowed { get; set; }

        [JsonProperty("temperatureMinimum")]
        public decimal? TemperatureMinimum { get; set; }

        [JsonProperty("quantityMinimum")]
        public decimal? QuantityMinimum { get; set; }

        [JsonProperty("zones")]
        public string Zones { get; set; }

        [JsonProperty("percentFill")]
        public decimal? PercentFill { get; set; }

        [JsonProperty("storeOnlyPallets")]
        public bool StoreOnlyPallets { get; set; }

        [JsonProperty("numberPalletsAllowed")]
        public int? NumberPalletsAllowed { get; set; }

        /// <summary>Read-only; when this location was last counted in an inventory audit.</summary>
        [JsonProperty("lastCountedDate")]
        public DateTime? LastCountedDate { get; set; }

        [JsonProperty("quantityMax")]
        public decimal? QuantityMax { get; set; }

        [JsonProperty("rowVersion")]
        public string RowVersion { get; set; }

        [JsonProperty("nonPickable")]
        public bool NonPickable { get; set; }

        [JsonProperty("replenishLocation")]
        public bool ReplenishLocation { get; set; }

        [JsonProperty("replenishmentEnabled")]
        public bool ReplenishmentEnabled { get; set; }

        [JsonProperty("pickPath")]
        public int? PickPath { get; set; }

        [JsonProperty("locationId")]
        public int LocationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("deactivated")]
        public bool Deactivated { get; set; }

        [JsonProperty("hasInventory")]
        public bool HasInventory { get; set; }
    }
}
