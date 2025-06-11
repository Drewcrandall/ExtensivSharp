using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using ExtensivSharp.Models.Receivers;
using ExtensivSharp.RQL;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    public class GET_Receivers
    {
        public string? AuthorizationToken { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string RqlFilter { get; set; } = string.Empty;
        public string? Sort { get; set; }
        public SpecifyItemDetailType Detail { get; set; } = SpecifyItemDetailType.None;
        public int? PurchaseOrderId { get; set; }
        public int? ReceiverType { get; set; }

        public string ToUrl()
        {
            var rql = new RqlQueryBuilder()
                .Where("serialNumber", "==", RqlFilter)
                .Build();

            return $"https://secure-wms.com/inventory/receivers/items?Detail={Detail}&rql={rql}";
        }
        public async Task<ExtensivApiResult<ReceiveItemResponse>> GetAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = new ExtensivApiResult<ReceiveItemResponse>()
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
                    result.Data = JsonConvert.DeserializeObject<ReceiveItemResponse>(responseContent)!;
                    result.Message = "ReceveItem retrieved successfully.";
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
