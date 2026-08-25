using Newtonsoft.Json;

namespace ExtensivSharp.Models.Properties
{
#pragma warning disable CS8618
    /// <summary>
    /// A warehouse within the 3PL. The <c>contact</c> and <c>customerOptions</c> blocks the API also
    /// returns are deliberately not modelled here - nothing in this library needs them, and mapping
    /// the contact would add a sixth copy of the address shape.
    /// </summary>
    public class Facility
    {
        [JsonProperty("facilityId")]
        public int FacilityId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("deactivated")]
        public bool Deactivated { get; set; }

        [JsonProperty("usePredefinedLocations")]
        public bool? UsePredefinedLocations { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("upsAccount")]
        public string UpsAccount { get; set; }

        [JsonProperty("fedExAccount")]
        public string FedExAccount { get; set; }

        [JsonProperty("fuelSurcharge")]
        public decimal FuelSurcharge { get; set; }

        [JsonProperty("locationFieldCount")]
        public int LocationFieldCount { get; set; }

        /// <summary>0 = US Imperial, 1 = Metric.</summary>
        [JsonProperty("measurementSystemDefault")]
        public byte MeasurementSystemDefault { get; set; }

        [JsonProperty("lastCloseDate")]
        public DateTime? LastCloseDate { get; set; }

        [JsonProperty("freightRateLocationCode")]
        public string FreightRateLocationCode { get; set; }

        /// <summary>A Windows TimeZoneInfo.Id, for example "Central Standard Time".</summary>
        [JsonProperty("timeZoneName")]
        public string TimeZoneName { get; set; }

        [JsonProperty("shippingZip")]
        public string ShippingZip { get; set; }

        /// <summary>
        /// When batch manual-allocating selected orders, skip any order that cannot be fully allocated.
        /// </summary>
        [JsonProperty("preventPartialOrderManualAllocation")]
        public bool PreventPartialOrderManualAllocation { get; set; }

        [JsonProperty("replenishment")]
        public bool Replenishment { get; set; }

        [JsonProperty("replenishFewestLocations")]
        public bool ReplenishFewestLocations { get; set; }

        [JsonProperty("maxCycleCountsPerDay")]
        public int? MaxCycleCountsPerDay { get; set; }

        [JsonProperty("maxCycleCountsPerDayExceeded")]
        public bool MaxCycleCountsPerDayExceeded { get; set; }

        /// <summary>
        /// When false, every order in a pick job must belong to the same customer.
        /// </summary>
        [JsonProperty("crossCustomerPickEnabled")]
        public bool CrossCustomerPickEnabled { get; set; }
    }
}
