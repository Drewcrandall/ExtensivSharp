using ExtensivSharp.Models.Helper;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>Assigns every pick job in a batch to one user. Returns 204.</summary>
    public class PUT_BatchAssigner
    {
        public string? AuthorizationToken { get; set; }

        /// <summary>The batch id, which is the PickJobId of the first pick job in the batch.</summary>
        public int BatchId { get; set; }

        /// <summary>The user having the pick jobs assigned to them.</summary>
        public int UserId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/pickjobs/{BatchId}/batchassigner?uid={UserId}";
        }

        public async Task<ExtensivApiResult<int>> PutAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<int>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);

            var content = new StringContent("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = BatchId;
                result.Message = "Batch assigned successfully.";
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
