using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class BillingCharge
    {
        [JsonProperty("chargeType")]
        public int ChargeType { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("details")]
        public List<ChargeDetail> Details { get; set; }
    }
}
