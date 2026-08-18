using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Job-centric, multi-order pick information. Use GET_PickCandidates for the order-centric view.
    /// </summary>
    public class GET_PickJobs
    {
        public string? AuthorizationToken { get; set; }

        /// <summary>Must be positive; the API rejects anything above 1000. Defaults to 100 when unset.</summary>
        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }
        public bool? LoadOut { get; set; }

        /// <summary>Include pick jobs containing at least one order on hold.</summary>
        public bool? IncludeOnHold { get; set; }

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

            if (LoadOut.HasValue)
                query.Add($"loadout={LoadOut.Value.ToString().ToLowerInvariant()}");

            if (IncludeOnHold.HasValue)
                query.Add($"includeOnHold={IncludeOnHold.Value.ToString().ToLowerInvariant()}");

            return $"https://secure-wms.com/orders/pickjobs?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<PickJobList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PickJobList>()
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
                result.Data = JsonConvert.DeserializeObject<PickJobList>(responseContent)!;
                result.Message = "PickJobs retrieved successfully.";
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
