using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Webhooks
{
    public class Resource
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public Order.Order Body { get; set; }
    }
}
