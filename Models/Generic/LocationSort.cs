using Newtonsoft.Json;

namespace ExtensivSharp.Models.Generic
{
#pragma warning disable CS8618
    /// <summary>
    /// The location's sortable field components, used to order a pick list into walking sequence.
    /// </summary>
    public class LocationSort
    {
        [JsonProperty("field1")]
        public string Field1 { get; set; }

        [JsonProperty("field2")]
        public string Field2 { get; set; }

        [JsonProperty("field3")]
        public string Field3 { get; set; }

        [JsonProperty("field4")]
        public string Field4 { get; set; }
    }
}
