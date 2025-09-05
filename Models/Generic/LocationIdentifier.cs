using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Generic
{
    public class LocationIdentifier
    {
        [JsonProperty("nameKey")]
        public NameKey NameKey { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
