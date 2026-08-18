using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Inventory;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Inventory
{
    /// <summary>
    /// Creates a movable unit. Leave Pallet.Label blank to have Extensiv generate a license plate.
    /// Extensiv recommends alphanumeric labels; special characters are not supported.
    /// </summary>
    public class POST_Pallet
    {
        public string? AuthorizationToken { get; set; }
        public Pallet Pallet { get; set; } = new();

        public string ToUrl()
        {
            return "https://secure-wms.com/inventory/pallets";
        }

        public async Task<ExtensivApiResult<Pallet>> PostAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<Pallet>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            string json = JsonConvert.SerializeObject(Pallet, new JsonSerializerSettings
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
                result.Data = JsonConvert.DeserializeObject<Pallet>(responseContent)!;
                result.Message = "Pallet created successfully.";
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
