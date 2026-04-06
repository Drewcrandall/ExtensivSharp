using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Inventory
{
    public class PUT_Shaker
    {
        public string? AuthorizationToken { get; set; }
        public ReceiveItemPutRequest UpdateTrackBy { get; set; } = new();
        private static string ToUrl()
        {
            return $"https://secure-wms.com/inventory/shaker";
        }
        public async Task<ExtensivApiResult<ReceiveItemPutRequest>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();
            var result = new ExtensivApiResult<ReceiveItemPutRequest>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            string JsonContent = JsonConvert.SerializeObject(UpdateTrackBy, settings);
            var content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<ReceiveItemPutRequest>(responseContent)!;
                result.Message = "TrackBy Updated successfully.";
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
