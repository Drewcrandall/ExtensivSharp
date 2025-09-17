using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class PUT_Order
    {
        public string? AuthorizationToken { get; set; }
        public OrderCreate Order { get; set; } = new();
        public int OrderId { get; set; }
        public string? IsMatch { get; set; }
        private static string ToUrl(int orderId)
        {
            return $"https://secure-wms.com/orders/{orderId}";
        }
        public async Task<ExtensivApiResult<Order>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();
            var result = new ExtensivApiResult<Order>()
            {
                Success = false
            };
            var url = ToUrl(OrderId);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch ?? string.Empty, true));
            string JsonContent = JsonConvert.SerializeObject(Order);
            var content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
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
                result.Success = false;
                result.Message = responseContent;
            }
            return result;
        }
    }
}
