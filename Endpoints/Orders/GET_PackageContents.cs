using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Gets every content record in a package.</summary>
    public class GET_PackageContents
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public int PackageId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/packages/{PackageId}/contents";
        }

        public async Task<ExtensivApiResult<PackageContentList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PackageContentList>()
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
                result.Data = JsonConvert.DeserializeObject<PackageContentList>(responseContent)!;
                result.Message = "Package contents retrieved successfully.";
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
