using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class ReceiptAdviceSendInfo
    {
        [JsonProperty("markInfo")]
        public MarkInfo MarkInfo { get; set; }

        [JsonProperty("sentInfo")]
        public SentInfo SentInfo { get; set; }
    }
}
