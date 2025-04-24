using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Orders
{
    class Orders
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddedOrders Embedded { get; set; }
    }
}
