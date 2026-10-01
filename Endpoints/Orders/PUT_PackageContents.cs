using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Replaces a package's content records in bulk.</summary>
    public class PUT_PackageContents
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public int PackageId { get; set; }
        public string? IsMatch { get; set; }
        public PackageContentList PackageContents { get; set; } = new();

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/{OrderId}/packages/{PackageId}/contents";
        }

        public async Task<ExtensivApiResult<PackageContentList>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PackageContentList>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));

            string json = JsonConvert.SerializeObject(PackageContents, new JsonSerializerSettings
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
                result.Data = JsonConvert.DeserializeObject<PackageContentList>(responseContent)!;
                result.Message = "Package contents updated successfully.";
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
