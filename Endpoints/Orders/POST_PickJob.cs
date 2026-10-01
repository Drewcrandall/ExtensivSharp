using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Creates a pick job over one or more orders.
    /// <para>
    /// Every order must belong to the same facility, and to the same customer unless the facility
    /// has CrossCustomerPickEnabled set. Every order must also be in an eventually-pickable state.
    /// Populate <c>PickJob.OrderIdentifiers</c>; the ReadOnly block is filled in by Extensiv.
    /// </para>
    /// </summary>
    public class POST_PickJob
    {
        public string? AuthorizationToken { get; set; }
        public PickJob PickJob { get; set; } = new();

        public string ToUrl()
        {
            return "https://secure-wms.com/orders/pickjobs";
        }

        public async Task<ExtensivApiResult<PickJob>> PostAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PickJob>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            string json = JsonConvert.SerializeObject(PickJob, new JsonSerializerSettings
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
                result.Data = JsonConvert.DeserializeObject<PickJob>(responseContent)!;
                result.Message = "PickJob created successfully.";
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
