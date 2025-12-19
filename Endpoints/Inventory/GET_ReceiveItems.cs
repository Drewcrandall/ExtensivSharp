using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Inventory;
using ExtensivSharp.Models.Order;
using ExtensivSharp.Models.Receivers;
using ExtensivSharp.RQL;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Inventory
{
    /// <summary>
    /// the collection of receive items independent of any receiver. RQL is set to search by serial number so I dont need a receipt number or item id or anything
    /// </summary>
    public class GET_ReceiveItems
    {
        public string? AuthorizationToken { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string RqlFilter { get; set; } = string.Empty;
        public string? Sort { get; set; }
        public ReceiveItemChildren Detail { get; set; } = ReceiveItemChildren.None;
        public bool? IncludeInventoryLevels { get; set; }

        public string ToUrl()
        {
            var query = new List<string>();

            if (PageSize.HasValue)
                query.Add($"pgsiz={PageSize.Value}");

            if (PageNumber.HasValue)
                query.Add($"pgnum={PageNumber.Value}");

            if (!string.IsNullOrWhiteSpace(RqlFilter))
                query.Add($"rql={Uri.EscapeDataString(new RqlQueryBuilder()
                                                        .Where("serialNumber", "==", RqlFilter)
                                                        .Build())}");

            if (!string.IsNullOrWhiteSpace(Sort))
                query.Add($"sort={Uri.EscapeDataString(Sort)}");

            if (Detail != ReceiveItemChildren.None)
                query.Add($"detail={Detail}");

            if (IncludeInventoryLevels.HasValue)
                query.Add($"includInventoryLevels={IncludeInventoryLevels.Value}");

            return $"https://secure-wms.com/inventory/receivers/items?{string.Join("&", query)}";
        }
        public async Task<ExtensivApiResult<ReceiveItemResponse>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<ReceiveItemResponse>()
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
                result.Data = JsonConvert.DeserializeObject<ReceiveItemResponse>(responseContent)!;
                result.Message = "ReceveItem retrieved successfully.";
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
