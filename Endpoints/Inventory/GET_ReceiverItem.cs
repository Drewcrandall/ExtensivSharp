using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Inventory
{
<<<<<<<< HEAD:Endpoints/Inventory/GET_ReceiverItems.cs
    /// <summary>
    /// Returns all line items,includes item details, of a specific Receiver.
    /// </summary>
    public class GET_ReceiverItems
========
    public class GET_ReceiverItem
>>>>>>>> f307ae6b5180f98145aae8aa7b8b71d77ca8fef3:Endpoints/Inventory/GET_ReceiverItem.cs
    {
        public string? AuthorizationToken { get; set; }
        public int ReceiverId { get; set; }
        public ReceiveItemDetail Detail { get; set; } = ReceiveItemDetail.None;

        public string ToUrl()
        {
            return $"https://secure-wms.com/inventory/receivers/{ReceiverId}/items?detail={Detail}";
        }
        public async Task<ExtensivApiResult<List<ReceiveItem>>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();
            var result = new ExtensivApiResult<List<ReceiveItem>>()
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
                result.Data = JsonConvert.DeserializeObject<List<ReceiveItem>>(responseContent)!;
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
