using ExtensivSharp.Entities;
using ExtensivSharp.Models.Orders;
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
        public async Task<ExtensivApiResult<Order>> GetAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = new ExtensivApiResult<Order>()
                {
                    Success = false
                };
                var url = $"https://secure-wms.com/orders/{OrderId}?detail={Detail}&itemdetail={ItemDetail}";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

                HttpResponseMessage response = await client.GetAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();

                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode) 
                {
                    result.Success = true;
                    result.Data = JsonConvert.DeserializeObject<Order>(responseContent);
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            result.Message = "Authentication failed. Please check your credentials.";
                            break;
                        case HttpStatusCode.Forbidden:
                            result.Message = "You don't have permission to access this resource.";
                            break;
                        case HttpStatusCode.NotFound:
                            result.Message = "The requested resource was not found.";
                            break;
                        default:
                            result.Message = $"API error: {response.StatusCode} - {responseContent}";
                            break;
                    }
                }
                return result;
            }
        }
    }
}
