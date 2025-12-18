using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ReceiverItemEmbedded
    {
        [JsonProperty("http://api.3plCentral.com/rels/inventory/receiveritem")]
        public List<ReceiverItem> ReceiverItems { get; set; }
    }
}
