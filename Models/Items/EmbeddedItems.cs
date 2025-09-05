using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
        public class EmbeddedItems
        {
            [JsonProperty("http://api.3plCentral.com/rels/customers/item")]
            public List<Item> Items { get; set; }
        }

}
