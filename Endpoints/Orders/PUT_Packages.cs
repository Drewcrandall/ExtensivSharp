using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Replaces an order's packages in bulk.</summary>
    public class PUT_Packages
    {
        public string? AuthorizationToken { get; set; }
        public int OrderId { get; set; }
        public string? IsMatch { get; set; }
        public bool? CalculateWeight { get; set; }
        public bool? CalculateDims { get; set; }
        public bool? DeleteAllContents { get; set; }
        public PackageList Packages { get; set; } = new();

        public string ToUrl()
        {
            var query = new List<string>();

            if (CalculateWeight.HasValue)
                query.Add($"calculateWeight={CalculateWeight.Value.ToString().ToLowerInvariant()}");

            if (CalculateDims.HasValue)
                query.Add($"calculateDims={CalculateDims.Value.ToString().ToLowerInvariant()}");

            if (DeleteAllContents.HasValue)
                query.Add($"deleteAllContents={DeleteAllContents.Value.ToString().ToLowerInvariant()}");

            var url = $"https://secure-wms.com/orders/{OrderId}/packages";

            return query.Count == 0 ? url : $"{url}?{string.Join("&", query)}";
        }

        public async Task<ExtensivApiResult<PackageList>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<PackageList>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            if (!string.IsNullOrWhiteSpace(IsMatch))
                client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue(IsMatch, true));

            string json = JsonConvert.SerializeObject(Packages, new JsonSerializerSettings
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
                result.Data = JsonConvert.DeserializeObject<PackageList>(responseContent)!;
                result.Message = "Packages updated successfully.";
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
