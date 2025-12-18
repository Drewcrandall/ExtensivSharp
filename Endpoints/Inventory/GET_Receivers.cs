using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Inventory;
using ExtensivSharp.Models.Order;
using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Inventory
{
    public class GET_Receivers
    {
        public string? AuthorizationToken { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? RqlFilter { get; set; }
        public string? Sort { get; set; }
        public ReceiverChildren Detail { get; set; } = ReceiverChildren.None;
        public ReceiveItemChildren ItemDetail { get; set; } = ReceiveItemChildren.None;
        public int? PurchaseOrderId { get; set; }
        public ReceiverType ReceiverType { get; set; } = ReceiverType.Normal;
        public bool? DeactivatedCustomers { get; set; }
        public string ToUrl()
        {
            var query = new List<string>();

            if (PageSize.HasValue)
                query.Add($"pgsiz={PageSize.Value}");

            if (PageNumber.HasValue)
                query.Add($"pgnum={PageNumber.Value}");

            if (!string.IsNullOrWhiteSpace(RqlFilter))
                query.Add($"rql={Uri.EscapeDataString(RqlFilter)}");

            if (!string.IsNullOrWhiteSpace(Sort))
                query.Add($"sort={Uri.EscapeDataString(Sort)}");

            if (Detail != ReceiverChildren.None)
                query.Add($"detail={Detail}");

            if (ItemDetail != ReceiveItemChildren.None)
                query.Add($"itemdetail={ItemDetail}");

            if (PurchaseOrderId.HasValue)
                query.Add($"purchaseorderid={PurchaseOrderId.Value}");

            if (ReceiverType != ReceiverType.Normal)
                query.Add($"receivertype={ReceiverType}");

            if (DeactivatedCustomers.HasValue)
                query.Add($"deactivatedcustomers={DeactivatedCustomers.Value}");

            return $"https://secure-wms.com/inventory/receivers?{string.Join("&", query)}";
        }
        public async Task<ExtensivApiResult<ReceiverList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();
            var result = new ExtensivApiResult<ReceiverList>()
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
                result.Data = JsonConvert.DeserializeObject<ReceiverList>(responseContent)!;
                result.Message = "ReceiverItems retrieved successfully.";
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
