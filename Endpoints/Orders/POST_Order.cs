using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class POST_Order
    {
        public string? AuthorizationToken { get; set; }
        public OrderCreate Order { get; set; } = new();
        private static string ToUrl()
        {
            return $"https://secure-wms.com/orders";
        }
        public async Task<ExtensivApiResult<Order>> PostAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();
            var result = new ExtensivApiResult<Order>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            string JsonContent = JsonConvert.SerializeObject(Order);
            var content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<Order>(responseContent)!;
                result.Message = "Order retrieved successfully.";
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
