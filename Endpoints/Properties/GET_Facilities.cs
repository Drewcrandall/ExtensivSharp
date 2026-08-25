using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Properties;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Properties
{
    /// <summary>
    /// Lists facilities. Check Facility.CrossCustomerPickEnabled before building a pick job that
    /// spans customers.
    /// </summary>
    public class GET_Facilities
    {
        public string? AuthorizationToken { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }

        /// <summary>Limit results to facilities the given customer is authorized for.</summary>
        public int? CustomerId { get; set; }

        public bool? WithDeactivateLinks { get; set; }

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

            if (CustomerId.HasValue)
                query.Add($"customerId={CustomerId.Value}");

            if (WithDeactivateLinks.HasValue)
                query.Add($"withDeactivateLinks={WithDeactivateLinks.Value.ToString().ToLowerInvariant()}");

            return $"https://secure-wms.com/properties/facilities?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<FacilityList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<FacilityList>()
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
                result.Data = JsonConvert.DeserializeObject<FacilityList>(responseContent)!;
                result.Message = "Facilities retrieved successfully.";
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
