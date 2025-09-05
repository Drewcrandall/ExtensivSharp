using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class EmbeddedItem
    {
        [JsonProperty("item")]
        public List<ItemQualifier> Items { get; set; }
    }
}
