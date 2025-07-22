using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_OrderItem
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GET_OrderByReferenceNumber(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public SpecifyItemDetailType Detail { get; set; } = SpecifyItemDetailType.None;

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/items/{OrderItemId}?detail={Detail}";
        }
        public async Task<ExtensivApiResult<OrderItem>> GetAsync()
        {
            using HttpClient client = new();
            var result = new ExtensivApiResult<OrderItem>()
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
                result.Data = JsonConvert.DeserializeObject<OrderItem>(responseContent)!;
                result.Message = "OrderItem retrieved successfully.";
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
