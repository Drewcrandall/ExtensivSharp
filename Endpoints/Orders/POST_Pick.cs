using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Records a pick against one pick line.
    /// <para>
    /// Extensiv accepts exactly one PickItemId per call and has no bulk form, so picking a whole
    /// movable unit means issuing one of these per serial. Each call requires If-Match and returns
    /// the entire updated pick list with a fresh ETag, so the calls cannot be parallelised. Feed the
    /// Etag off each result into the next request's IsMatch.
    /// </para>
    /// <para>
    /// A 412 means the ETag went stale because something else touched the job. Re-read the pick list
    /// with GET_PickList and resume from the lines where PickedQty is still below Qty.
    /// </para>
    /// </summary>
    public class POST_Pick
    {
        public string? AuthorizationToken { get; set; }
        public int PickJobId { get; set; }
        public string? IsMatch { get; set; }
        public PickInfo PickInfo { get; set; } = new();

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/pickjobs/{PickJobId}/pickitems/picker";
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

            string json = JsonConvert.SerializeObject(PickInfo, new JsonSerializerSettings
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
                result.Message = "Pick recorded successfully.";
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
