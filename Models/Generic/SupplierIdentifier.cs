﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Generic
{
    public class SupplierIdentifier
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
