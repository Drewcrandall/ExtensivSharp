using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Requests a package's UCC-128 carton label as ZPL. Note this route is not nested under an
    /// order id - the package id alone identifies it.
    /// </summary>
    public class GET_PackageUcc128Label
    {
        public string? AuthorizationToken { get; set; }
        public int PackageId { get; set; }

        /// <summary>Which label template to render with.</summary>
        public int LabelTemplateId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/packages/{PackageId}/ucc128label?labelTemplateId={LabelTemplateId}";
        }

        public async Task<ExtensivApiResult<Ucc128Label>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<Ucc128Label>()
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
                result.Data = JsonConvert.DeserializeObject<Ucc128Label>(responseContent)!;
                result.Message = "UCC-128 label retrieved successfully.";
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
