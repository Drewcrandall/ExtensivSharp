using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class LocationInfo
    {
        [JsonProperty("locationId")]
        public int LocationId { get; set; }

        [JsonProperty("display")]
        public string Display { get; set; }

        [JsonProperty("rawField1")]
        public string RawField1 { get; set; }

        [JsonProperty("rawField2")]
        public string RawField2 { get; set; }

        [JsonProperty("rawField3")]
        public string RawField3 { get; set; }

        [JsonProperty("rawField4")]
        public string RawField4 { get; set; }
    }

}
