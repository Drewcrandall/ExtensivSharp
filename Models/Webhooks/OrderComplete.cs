using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Webhooks
{
    public class OrderComplete
    {
        public int TplId { get; set; }
        public int WmsEventId { get; set; }
        public DateTime DateTime { get; set; }
        public string EventType { get; set; }
        public Resource Resource { get; set; }
        public string Links { get; set; }
        public string Data { get; set; }
        public string Tags { get; set; }
    }
}
