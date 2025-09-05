using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class Kit
    {
        [JsonProperty("materialNotes")]
        public string MaterialNotes { get; set; }

        [JsonProperty("components")]
        public List<KitComponent> Components { get; set; }
    }
}
