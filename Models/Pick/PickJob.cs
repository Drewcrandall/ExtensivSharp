using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;

namespace ExtensivSharp.Models.Pick
{
#pragma warning disable CS8618
    /// <summary>
    /// A pick job covering one or more orders. On create, supply <see cref="OrderIdentifiers"/> and
    /// optionally <see cref="Priority"/>, <see cref="PickInstructions"/> and
    /// <see cref="LoadOutLocation"/>; <see cref="ReadOnly"/> is populated by the server.
    /// All orders must share a facility, and must share a customer unless the facility has
    /// CrossCustomerPickEnabled set.
    /// </summary>
    public class PickJob
    {
        [JsonProperty("readOnly")]
        public PickJobReadOnly ReadOnly { get; set; }

        /// <summary>Uninterpreted by Extensiv; used solely for user-facing sorting.</summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("pickInstructions")]
        public string PickInstructions { get; set; }

        /// <summary>Honoured only in candidate searches; ignored for every other purpose.</summary>
        [JsonProperty("pickerId")]
        public int? PickerId { get; set; }

        [JsonProperty("picker")]
        public Identifier Picker { get; set; }

        [JsonProperty("orderIdentifiers")]
        public List<OrderIdentifier> OrderIdentifiers { get; set; }

        /// <summary>Location used to stage inventory for load out.</summary>
        [JsonProperty("loadOutLocation")]
        public LocationIdentifier LoadOutLocation { get; set; }
    }
}
