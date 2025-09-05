using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Items
{
    public class ItemQualifier
    {
        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }
    }
}
