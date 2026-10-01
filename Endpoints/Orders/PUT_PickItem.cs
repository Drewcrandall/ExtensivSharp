using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Associates a picker with one pick line. No If-Match required.</summary>
    public class PUT_PickItem
    {
        public string? AuthorizationToken { get; set; }
        public int PickJobId { get; set; }
        public PickLineInfo PickLineInfo { get; set; } = new();

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/pickjobs/{PickJobId}/pickitems";
        }

        public async Task<ExtensivApiResult<PickLineInfo>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PickLineInfo>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            string json = JsonConvert.SerializeObject(PickLineInfo, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<PickLineInfo>(responseContent)!;
                result.Message = "PickItem updated successfully.";
                result.Etag = response.Headers.ETag?.Tag;
            }
            else
            {
                result.Message = string.IsNullOrWhiteSpace(responseContent)
                    ? response.ReasonPhrase
                    : responseContent;
            }
            return result;
        }
    }
}
