using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using ExtensivSharp.RQL;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_OrderByReferenceNumber
    {
        public string? AuthorizationToken { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        /// <summary>
        /// When set, also requires <c>readOnly.customerIdentifier.id==&lt;id&gt;</c> so a reference number
        /// that collides across customers can only resolve to this customer's order.
        /// </summary>
        public int? CustomerIdentifierId { get; set; }
        public SpecifyDetailType Detail { get; set; }
        public SpecifyItemDetailType ItemDetail { get; set; }

        private string ToUrl()
        {
            var builder = new RqlQueryBuilder()
                .Where("referenceNum", "==", ReferenceNumber);

            if (CustomerIdentifierId.HasValue)
                builder.Where("readOnly.customerIdentifier.id", "==", CustomerIdentifierId.Value.ToString());

            var rql = builder.Build();

            return $"https://secure-wms.com/orders?detail={Detail}&itemdetail={ItemDetail}&rql={Uri.EscapeDataString(rql)}";
        }
        public async Task<ExtensivApiResult<Models.Order.Orders>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<Models.Order.Orders>()
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
                result.Data = JsonConvert.DeserializeObject<Models.Order.Orders>(responseContent)!;
                result.Message = "Order retrieved successfully.";
                result.Etag = response.Headers.ETag?.Tag ?? null;
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
