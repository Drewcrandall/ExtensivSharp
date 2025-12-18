using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ReceiverEmbedded
    {
        [JsonProperty("http://api.3plCentral.com/rels/inventory/receiver")]
        public List<Receiver> Receivers { get; set; }
    }
}
