using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Properties;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Properties
{
    /// <summary>
    /// Lists the locations in a facility. Use this to pick the staging location for a pick job's
    /// LoadOutLocation.
    /// </summary>
    public class GET_LocationsByFacility
    {
        public string? AuthorizationToken { get; set; }
        public int FacilityId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }

        /// <summary>
        /// Filter out locations in an active audit. Setting this makes the response non-cacheable.
        /// </summary>
        public bool? ExcludeAuditing { get; set; }

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

            if (ExcludeAuditing.HasValue)
                query.Add($"excludeAuditing={ExcludeAuditing.Value.ToString().ToLowerInvariant()}");

            return $"https://secure-wms.com/properties/facilities/{FacilityId}/locations?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<LocationList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<LocationList>()
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
                result.Data = JsonConvert.DeserializeObject<LocationList>(responseContent)!;
                result.Message = "Locations retrieved successfully.";
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
