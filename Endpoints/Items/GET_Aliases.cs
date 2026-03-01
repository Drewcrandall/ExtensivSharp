using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Items;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Items
{
    public class GET_Aliases
    {
        public string? AuthorizationToken { get; set; }
        public int? CustomerId { get; set; }
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

            return $"https://secure-wms.com/customers/{CustomerId}/itemaliases?{string.Join("&", query)}";
        }
        public async Task<ExtensivApiResult<Models.Items.Aliases>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<Models.Items.Aliases>()
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
                result.Data = JsonConvert.DeserializeObject<Models.Items.Aliases>(responseContent)!;
                result.Message = "Aliases retrieved successfully.";
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
