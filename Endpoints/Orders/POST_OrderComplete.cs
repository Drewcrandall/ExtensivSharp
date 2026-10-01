using ExtensivSharp.Models.Helper;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Completes an order, meaning the customer is done specifying order and order item information. Returns 204.</summary>
    public class POST_OrderComplete
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public string? IsMatch { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/completer";
        }

        public async Task<ExtensivApiResult<int>> PostAsync(IHttpClientFactory factory)
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

            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = OrderId;
                result.Message = "Order completed successfully.";
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
