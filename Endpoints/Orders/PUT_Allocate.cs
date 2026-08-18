using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Allocates an open order.
    /// <para>
    /// Leave ProposedAllocations null to let Extensiv allocate automatically. Set it to allocate
    /// specific receive items manually - this is the bulk path, so every serial on a movable unit
    /// can be allocated in a single request, which is what makes MU-based allocation cheap even
    /// though picking is one call per line.
    /// </para>
    /// </summary>
    public class PUT_Allocate
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public string? IsMatch { get; set; }

        /// <summary>
        /// Manual allocations grouped by order item. Null means auto-allocate.
        /// </summary>
        public ProposedAllocationsForOrder? ProposedAllocations { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/allocator";
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

            string json = ProposedAllocations is null
                ? "{}"
                : JsonConvert.SerializeObject(ProposedAllocations, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = OrderId;
                result.Message = "Order allocated successfully.";
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
