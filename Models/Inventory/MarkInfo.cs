using ExtensivSharp.Models.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class MarkInfo
    {
        [JsonProperty("candidate")]
        public int Candidate { get; set; }

        [JsonProperty("channelIdentifier")]
        public Identifier ChannelIdentifier { get; set; }

        [JsonProperty("transformIds")]
        public string TransformIds { get; set; }
    }
}
