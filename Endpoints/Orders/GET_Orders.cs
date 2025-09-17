using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_Orders
    {
        public string? AuthorizationToken { get; set; }
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
        public async Task<ExtensivApiResult<Models.Order.Orders>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<Models.Order.Orders>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            HttpResponseMessage response = await client.GetAsync(url);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<Models.Order.Orders>(responseContent)!;
                result.Message = "Order retrieved successfully.";
                result.Etag = response.Headers.ETag?.Tag ?? null;
            }
            else
            {
                HttpStatusCodeHelper.SetResponseMessage(response, result, responseContent);
            }
            return result;
        }
    }
}
