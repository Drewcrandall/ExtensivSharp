using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Gets the open orders occupying a bin. No results means the bin is free to use; one result
    /// means it is in use; more than one means the bin-occupancy logic has been bypassed somewhere.
    /// </summary>
    public class GET_OrdersByBin
    {
        public string? AuthorizationToken { get; set; }
        public string Bin { get; set; } = string.Empty;
        public int FacilityId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/bins/{Uri.EscapeDataString(Bin)}?facilityId={FacilityId}";
        }

        public async Task<ExtensivApiResult<BinInfo>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<BinInfo>()
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
                result.Data = JsonConvert.DeserializeObject<BinInfo>(responseContent)!;
                result.Message = "Bin orders retrieved successfully.";
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
