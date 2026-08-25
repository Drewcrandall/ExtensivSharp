using ExtensivSharp.Models.Helper;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Generates an order's packages from its configured packaging setup. Returns 204.</summary>
    public class PUT_PackagesGenerate
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public bool? OverrideSummary { get; set; }
        public string? IsMatch { get; set; }

        public string ToUrl()
        {
            var url = $"https://secure-wms.com/orders/{OrderId}/packages/generator";

            if (OverrideSummary.HasValue)
                url += $"?overridesummary={OverrideSummary.Value.ToString().ToLowerInvariant()}";

            return url;
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
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));

            var content = new StringContent("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = OrderId;
                result.Message = "Packages generated successfully.";
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
