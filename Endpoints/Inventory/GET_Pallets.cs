using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Inventory;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Inventory
{
    /// <summary>
    /// Lists movable units. Filter by label with <c>RqlFilter = "label==MU12345"</c>.
    /// <para>
    /// This returns unit metadata only - label, facility, type and dimensions. It never returns
    /// contents; for those use GET_StockDetails filtered on the unit's label.
    /// </para>
    /// </summary>
    public class GET_Pallets
    {
        public string? AuthorizationToken { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }

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

            return $"https://secure-wms.com/inventory/pallets?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<PalletList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PalletList>()
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
                result.Data = JsonConvert.DeserializeObject<PalletList>(responseContent)!;
                result.Message = "Pallets retrieved successfully.";
                result.Etag = response.Headers.ETag?.Tag;
            }
            else
            {
                result.Message = string.IsNullOrWhiteSpace(responseContent)
                    ? response.ReasonPhrase
                    : responseContent;
            }
            return result;
        }
    }
}
