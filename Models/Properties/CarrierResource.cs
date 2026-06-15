using System.Collections.Generic;

namespace ExtensivSharp.Models.Properties
{
    public class CarrierResource
    {
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? CarrierCode { get; set; }
        public string? ScacCode { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public bool Deactivated { get; set; }
        public List<ShipmentService> ShipmentServices { get; set; } = new();
        public List<BillingCode> BillingCodes { get; set; } = new();
    }
}
