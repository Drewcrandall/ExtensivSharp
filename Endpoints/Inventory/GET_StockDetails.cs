using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Inventory;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Inventory
{
    /// <summary>
    /// Detailed inventory including track-by information, one row per receive item.
    /// <para>
    /// This is how the contents of a movable unit are read. Filter by MU label with
    /// <c>RqlFilter = "palletidentifier.namekey.name==MU12345"</c> and every row returns a serial
    /// plus the ReceiveItemId needed to allocate it.
    /// </para>
    /// </summary>
    public class GET_StockDetails
    {
        public string? AuthorizationToken { get; set; }

        /// <summary>Required by the API.</summary>
        public int CustomerId { get; set; }

        /// <summary>Required by the API.</summary>
        public int FacilityId { get; set; }

        /// <summary>Must be positive; the API rejects anything above 500. Defaults to 100 when unset.</summary>
        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }

        /// <summary>
        /// When editing allocations, supply the order item id to have inventory already allocated to
        /// that order item counted as available.
        /// </summary>
        public int? OrderItemId { get; set; }

        public string? SavedElementNameOrValueContains { get; set; }

        public string ToUrl()
        {
            var query = new List<string>
            {
                $"customerid={CustomerId}",
                $"facilityid={FacilityId}"
            };

            if (PageSize.HasValue)
                query.Add($"pgsiz={PageSize.Value}");

            if (PageNumber.HasValue)
                query.Add($"pgnum={PageNumber.Value}");

            if (!string.IsNullOrWhiteSpace(RqlFilter))
                query.Add($"rql={Uri.EscapeDataString(RqlFilter)}");

            if (!string.IsNullOrWhiteSpace(Sort))
                query.Add($"sort={Uri.EscapeDataString(Sort)}");

            if (OrderItemId.HasValue)
                query.Add($"orderitemid={OrderItemId.Value}");

            if (!string.IsNullOrWhiteSpace(SavedElementNameOrValueContains))
                query.Add($"senameorvaluecontains={Uri.EscapeDataString(SavedElementNameOrValueContains)}");

            return $"https://secure-wms.com/inventory/stockdetails?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<StockDetailList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<StockDetailList>()
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
                result.Data = JsonConvert.DeserializeObject<StockDetailList>(responseContent)!;
                result.Message = "StockDetails retrieved successfully.";
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
