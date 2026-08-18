using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Records that what was physically picked differs from the pick line - a different location,
    /// lot, serial, expiration date or movable unit. Extensiv reconciles the allocation behind the
    /// scenes and errors if it cannot. Same ETag chaining rules as POST_Pick.
    /// </summary>
    public class POST_Mispick
    {
        public string? AuthorizationToken { get; set; }
        public int PickJobId { get; set; }
        public string? IsMatch { get; set; }
        public MispickInfo MispickInfo { get; set; } = new();

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/pickjobs/{PickJobId}/pickitems/mispicker";
        }

        public async Task<ExtensivApiResult<ConsolidatedPickList>> PostAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<ConsolidatedPickList>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));

            string json = JsonConvert.SerializeObject(MispickInfo, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<ConsolidatedPickList>(responseContent)!;
                result.Message = "Mispick recorded successfully.";
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
