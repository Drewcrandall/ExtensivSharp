﻿using Newtonsoft.Json;

namespace ExtensivSharp.Models.Order
{
#pragma warning disable CS8618
    public class ItemIdentifier
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

}
