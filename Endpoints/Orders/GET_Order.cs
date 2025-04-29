using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using ExtensivSharp.RQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_Order
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public SpecifyDetailType Detail { get; set; } = SpecifyDetailType.None;
        public SpecifyItemDetailType ItemDetail { get; set; } = SpecifyItemDetailType.None;
        private string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}?detail={Detail}&itemdetail={ItemDetail}";
        }
        public async Task<ExtensivApiResult<Order>> GetAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = new ExtensivApiResult<Order>()
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
                    result.Data = JsonConvert.DeserializeObject<Order>(responseContent);
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
}
