﻿using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using ExtensivSharp.RQL;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

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
                HttpStatusCodeHelper.SetResponseMessage(response, result, responseContent);
            }
            return result;
            
        }
    }
}
