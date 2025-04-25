using ExtensivSharp.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class PUT_OrderItem
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/items/{OrderItemId}";
        }
    }
}
