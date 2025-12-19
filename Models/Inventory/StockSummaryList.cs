using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Inventory
{
    public class StockSummaryList
    {
        public int TotalResults { get; set;  }
        public List<StockSummary> Summaries { get; set; }
    }
}
