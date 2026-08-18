using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Order-centric pick information. Extensiv already filters out shipped and under-allocated
    /// orders, and optionally picked or loadable ones.
    /// <para>
    /// Two RQL recipes from Extensiv's documentation. To look up one order for picking:
    /// <c>OrderId==x</c>. To show the next order available to a given picker in a facility:
    /// <c>facilityidentifier.id==f;(pickjobid=hv=false,(pickjob.pickerid=hv=false,pickjob.pickerid==u))</c>
    /// with <c>Sort = "PickJob.Priority,PickJob.ReadOnly.CreationDate,OrderId"</c>, PageSize 1 and
    /// PageNumber stepped up each time the picker rejects the offered order.
    /// </para>
    /// </summary>
    public class GET_PickCandidates
    {
        public string? AuthorizationToken { get; set; }

        /// <summary>Must be positive; the API rejects anything above 100. Defaults to 10 when unset.</summary>
        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }
        public bool? LoadOut { get; set; }
        public bool? Picked { get; set; }

        /// <summary>Include candidates in a pick job that contains at least one order on hold.</summary>
        public bool? IncludePickJobsOnHold { get; set; }

        /// <summary>
        /// Omit the pick payload not needed for counts, locations, SKU summary, customer, reference,
        /// pick job id, order count, bin count and loadout/pick status.
        /// </summary>
        public bool? ReducePickInfo { get; set; }

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

            if (Picked.HasValue)
                query.Add($"picked={Picked.Value.ToString().ToLowerInvariant()}");

            if (IncludePickJobsOnHold.HasValue)
                query.Add($"includePickJobsOnHold={IncludePickJobsOnHold.Value.ToString().ToLowerInvariant()}");

            if (ReducePickInfo.HasValue)
                query.Add($"reducePickInfo={ReducePickInfo.Value.ToString().ToLowerInvariant()}");

            return $"https://secure-wms.com/orders/pickcandidates?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<PickCandidateList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PickCandidateList>()
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
                result.Data = JsonConvert.DeserializeObject<PickCandidateList>(responseContent)!;
                result.Message = "PickCandidates retrieved successfully.";
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
