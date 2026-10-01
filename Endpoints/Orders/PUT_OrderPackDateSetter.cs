using ExtensivSharp.Models.Helper;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Sets the order's pack-done date to now. No If-Match required. Returns 204.</summary>
    public class PUT_OrderPackDateSetter
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/packdatesetter";
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
                result.Message = "Pack date set successfully.";
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
