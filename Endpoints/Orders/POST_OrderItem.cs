using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Creates a new line item on an existing order.
    /// See https://3w.extensiv.com/rels/orders/items - If-Match is required and the ETag comes from
    /// the parent ORDER (not from an order item). Success status is 201 and the response body is an
    /// OrderItemList, because an alias SKU can expand into more than one order item.
    /// </summary>
    public class POST_OrderItem
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public string? IsMatch { get; set; }
        public OrderItem OrderItem { get; set; }

        /// <summary>
        /// Optional. When set, the API validates the new line against available inventory.
        /// </summary>
        public bool? ValidateOverallocation { get; set; }

        public string ToUrl()
        {
            var url = $"https://secure-wms.com/orders/{OrderId}/items";
            if (ValidateOverallocation.HasValue)
            {
                url = $"{url}?validateOveralloc={ValidateOverallocation.Value.ToString().ToLowerInvariant()}";
            }
            return url;
        }

        public async Task<ExtensivApiResult<OrderItemList>> PostAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<OrderItemList>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));
            string json = JsonConvert.SerializeObject(OrderItem, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = ParseCreatedItems(responseContent);
                result.Message = "OrderItem created successfully.";
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

        /// <summary>
        /// The documented response is an OrderItemList envelope, but a 201 can also come back as a
        /// bare array or a single item depending on how the resource is rendered. Handle all three
        /// rather than returning null data on a call that actually succeeded.
        /// </summary>
        private static OrderItemList ParseCreatedItems(string responseContent)
        {
            var list = new OrderItemList();

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return list;
            }

            try
            {
                var token = JToken.Parse(responseContent);

                if (token is JArray array)
                {
                    list.Embedded = new OrderEmbedded { OrderItems = array.ToObject<List<OrderItem>>() ?? new List<OrderItem>() };
                    return list;
                }

                var parsed = token.ToObject<OrderItemList>();
                if (parsed?.Embedded?.OrderItems != null)
                {
                    return parsed;
                }

                // Not an envelope - try it as a single created item.
                var single = token.ToObject<OrderItem>();
                if (single != null)
                {
                    list.Embedded = new OrderEmbedded { OrderItems = new List<OrderItem> { single } };
                }
            }
            catch (JsonException)
            {
                // Leave the list empty. The call succeeded; the caller can still treat a missing
                // orderItemId as "created but id unknown" and reconcile on the next pass.
            }

            return list;
        }
    }
}
