using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Completes a pick job and sets its done date. Supply ReasonForIncomplete to force completion
    /// while items remain to be picked; the job then comes back with DoneIncomplete true.
    /// </summary>
    public class PUT_PickJobComplete
    {
        public string? AuthorizationToken { get; set; }
        public int PickJobId { get; set; }
        public string? IsMatch { get; set; }

        /// <summary>Required only when forcing completion with items still outstanding.</summary>
        public string? ReasonForIncomplete { get; set; }

        public string ToUrl()
        {
            var url = $"https://secure-wms.com/orders/pickjobs/{PickJobId}/completer";

            if (!string.IsNullOrWhiteSpace(ReasonForIncomplete))
                url += $"?reasonForIncomplete={Uri.EscapeDataString(ReasonForIncomplete)}";

            return url;
        }

        public async Task<ExtensivApiResult<PickJob>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PickJob>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));

            var content = new StringContent("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<PickJob>(responseContent)!;
                result.Message = "PickJob completed successfully.";
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
