using ExtensivSharp.Models.Orders;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_Order
    {
        public int OrderId { get; set; }
        public SpecifyDetailType Detail { get; set; } = SpecifyDetailType.None;
        public SpecifyItemDetailType ItemDetail { get; set; } = SpecifyItemDetailType.None;
        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}?detail={Detail}&itemdetail={ItemDetail}";
        }
    }
}
