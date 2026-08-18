using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Properties;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Properties
{
    /// <summary>Lists movable unit types - pallet, carton, skid, cart, trailer and so on.</summary>
    public class GET_PalletTypes
    {
        public string? AuthorizationToken { get; set; }

        public string ToUrl()
        {
            return "https://secure-wms.com/properties/pallettypes";
        }

        public async Task<ExtensivApiResult<PalletTypeList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PalletTypeList>()
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
                result.Data = JsonConvert.DeserializeObject<PalletTypeList>(responseContent)!;
                result.Message = "PalletTypes retrieved successfully.";
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
