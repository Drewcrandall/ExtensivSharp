using ExtensivSharp.Models.Orders;
using ExtensivSharp.RQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_OrderByReferenceNumber
    {
        public string ReferenceNumber { get; set; }
        public SpecifyDetailType Detail { get; set; }
        public SpecifyItemDetailType ItemDetail { get; set; }

        public string ToUrl()
        {
            var rql = new RqlQueryBuilder()
                .Where("referenceNum", "==", ReferenceNumber)
                .Build();

            return $"https://secure-wms.com/orders?detail={Detail}&itemdetail={ItemDetail}&rql={rql}";
        }
    }
}
