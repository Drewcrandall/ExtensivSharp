using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Properties;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Properties
{
    public class GET_Carriers
    {
        public string? AuthorizationToken { get; set; }

        public string ToUrl()
        {
            return "https://secure-wms.com/properties/carriers";
        }

        public async Task<ExtensivApiResult<CarrierProperties>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();
            var result = new ExtensivApiResult<CarrierProperties>()
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
                result.Data = JsonConvert.DeserializeObject<CarrierProperties>(responseContent)!;
                result.Message = "Carriers retrieved successfully.";
                result.Etag = response.Headers.ETag?.Tag ?? null;
            }
            else
            {
                HttpStatusCodeHelper.SetResponseMessage(response, result, responseContent);
            }
            return result;
        }
    }
}
