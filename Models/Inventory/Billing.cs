using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class Billing
    {
        [JsonProperty("billingCharges")]
        public List<BillingCharge> BillingCharges { get; set; }
    }
}
