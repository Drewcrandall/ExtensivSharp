using ExtensivSharp.Models.Helper;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Consolidates an order's packages into one. No If-Match required. Returns 204.</summary>
    public class PUT_PackagesConsolidate
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public int? PackageDefId { get; set; }
        public bool? OverrideSummary { get; set; }

        public string ToUrl()
        {
            var query = new List<string>();

            if (PackageDefId.HasValue)
                query.Add($"packageDefId={PackageDefId.Value}");

            if (OverrideSummary.HasValue)
                query.Add($"overridesummary={OverrideSummary.Value.ToString().ToLowerInvariant()}");

            var url = $"https://secure-wms.com/orders/{OrderId}/packages/consolidator";

            return query.Count == 0 ? url : $"{url}?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<int>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<int>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            var content = new StringContent("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = OrderId;
                result.Message = "Packages consolidated successfully.";
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
