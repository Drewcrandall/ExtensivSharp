using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class SentInfo
    {
        [JsonProperty("sent")]
        public bool Sent { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
