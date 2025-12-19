using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class NameKey
    {
        [JsonProperty("facilityIdentifier")]
        public Identifier FacilityIdentifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
