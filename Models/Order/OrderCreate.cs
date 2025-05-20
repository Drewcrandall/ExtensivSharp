using ExtensivSharp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class OrderCreate
    {
        public Identifier CustomerIdentifier { get; set; }
        public Identifier FacilityIdentifier { get; set; }
        public string ReferenceNum { get; set; }
        public string Notes { get; set; }
        public string ShippingNotes { get; set; }
        public string BillingCode { get; set; }
        public string AsnNumber { get; set; }
        public RoutingInfo RoutingInfo { get; set; }
        public ShipToCreate ShipTo { get; set; }
        public SoldToCreate SoldTo { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
