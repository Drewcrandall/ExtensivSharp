﻿using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
#pragma warning disable CS8618
    public class Identifier
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
