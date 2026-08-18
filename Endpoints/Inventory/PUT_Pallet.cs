using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Inventory;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Inventory
{
    /// <summary>Updates a movable unit - its label, type or dimensions.</summary>
    public class PUT_Pallet
    {
        public string? AuthorizationToken { get; set; }
        public int PalletId { get; set; }
        public string? IsMatch { get; set; }
        public Pallet Pallet { get; set; } = new();

        public string ToUrl()
        {
            return $"https://secure-wms.com/inventory/pallets/{PalletId}";
        }

        public async Task<ExtensivApiResult<Pallet>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<Pallet>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));

            string json = JsonConvert.SerializeObject(Pallet, new JsonSerializerSettings
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
                result.Data = JsonConvert.DeserializeObject<Pallet>(responseContent)!;
                result.Message = "Pallet updated successfully.";
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
