using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Gets a single pick job. Use <see cref="GET_PickList"/> for the items to be picked.
    /// </summary>
    public class GET_PickJob
    {
        public string? AuthorizationToken { get; set; }
        public int PickJobId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/pickjobs/{PickJobId}";
        }

        public async Task<ExtensivApiResult<PickJob>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PickJob>()
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
                result.Data = JsonConvert.DeserializeObject<PickJob>(responseContent)!;
                result.Message = "PickJob retrieved successfully.";
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
