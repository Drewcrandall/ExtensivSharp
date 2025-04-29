using ExtensivSharp.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_Orders
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }
        public SpecifyDetailType Detail { get; set; } = SpecifyDetailType.None;
        public SpecifyItemDetailType ItemDetail { get; set; } = SpecifyItemDetailType.None;
        public int? MarkForListId { get; set; }
        public string? SkuList { get; set; }// comma-separated SKUs
        public string? SkuContains { get; set; }

        public string ToUrl()
        {
            var query = new List<string>();

            if (PageSize.HasValue)
                query.Add($"pgsiz={PageSize.Value}");

            if (PageNumber.HasValue)
                query.Add($"pgnum={PageNumber.Value}");

            if (!string.IsNullOrWhiteSpace(RqlFilter))
                query.Add($"rql={Uri.EscapeDataString(RqlFilter)}");

            if (!string.IsNullOrWhiteSpace(Sort))
                query.Add($"sort={Uri.EscapeDataString(Sort)}");

            if (Detail != SpecifyDetailType.None)
                query.Add($"detail={Detail}");

            if (ItemDetail != SpecifyItemDetailType.None)
                query.Add($"itemdetail={ItemDetail}");

            if (MarkForListId.HasValue)
                query.Add($"markforlistid={MarkForListId}");

            if (!string.IsNullOrWhiteSpace(SkuList))
                query.Add($"skulist={Uri.EscapeDataString(SkuList)}");

            if (!string.IsNullOrWhiteSpace(SkuContains))
                query.Add($"skucontains={Uri.EscapeDataString(SkuContains)}");

            return $"https://secure-wms.com/orders?{string.Join("&", query)}";
        }
    }
}
