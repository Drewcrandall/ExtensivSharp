using System.Collections.Generic;

namespace ExtensivSharp.Models.Properties
{
    public class CarrierProperties
    {
        public List<BillingCode> DefaultBillingCodes { get; set; } = new();
        public List<ShipmentService> DefaultShipmentServices { get; set; } = new();
        public List<CarrierResource> ResourceList { get; set; } = new();
    }
}
