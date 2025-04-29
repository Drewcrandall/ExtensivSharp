using ExtensivSharp.Models.Helper;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class DELETE_OrderItem
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public string? IsMatch { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/items/{OrderItemId}";
        }
        public async Task<ExtensivApiResult<int>> DeleteAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = new ExtensivApiResult<int>()
                {
                    Success = false
                };
                var url = ToUrl();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch ?? string.Empty, true));
                var content = new StringContent("{}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.DeleteAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = OrderItemId;
                    result.Message = "OrderItem Deleted successfully.";
                }
                else
                {
                    HttpStatusCodeHelper.SetResponseMessage(response, result, responseContent);
                }
                return result;
            }
        }
    }
}
