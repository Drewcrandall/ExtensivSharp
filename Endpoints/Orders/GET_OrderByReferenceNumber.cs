using ExtensivSharp.Entities;
using ExtensivSharp.Models.Orders;
using ExtensivSharp.RQL;
using ExtensivSharp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_OrderByReferenceNumber
    {
        public string? AuthorizationToken { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public SpecifyDetailType Detail { get; set; }
        public SpecifyItemDetailType ItemDetail { get; set; }

        private string ToUrl()
        {
            var rql = new RqlQueryBuilder()
                .Where("referenceNum", "==", ReferenceNumber)
                .Build();

            return $"https://secure-wms.com/orders?detail={Detail}&itemdetail={ItemDetail}&rql={rql}";
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
                }
                else
                {
                    HttpStatusCodeService.SetResponseMessage(response, result, responseContent);
                }
                return result;
            }
        }
    }
}
