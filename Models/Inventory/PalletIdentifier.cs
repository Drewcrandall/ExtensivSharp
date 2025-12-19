using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class PalletIdentifier
    {
        [JsonProperty("nameKey")]
        public NameKey NameKey { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
