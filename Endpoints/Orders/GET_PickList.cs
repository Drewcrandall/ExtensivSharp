using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Pick;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ExtensivSharp.Endpoints.Orders
{
    /// <summary>
    /// Gets a pick job's consolidated pick list, across every order in the job. Consolidation is by
    /// Location + ItemTraits, so serialized inventory yields one line per serial at quantity 1, each
    /// tagged with the movable unit it sits on at
    /// <c>PickItem.ItemTraits.PalletIdentifier.NameKey.Name</c>.
    /// <para>
    /// The ETag returned here is the If-Match value for the first <see cref="POST_Pick"/> of a run;
    /// each pick response then supplies the ETag for the next.
    /// </para>
    /// </summary>
    public class GET_PickList
    {
        public string? AuthorizationToken { get; set; }
        public int PickJobId { get; set; }

        public string ToUrl()
        {
            return $"https://secure-wms.com/orders/pickjobs/{PickJobId}/picklist";
        }

        public async Task<ExtensivApiResult<ConsolidatedPickList>> GetAsync(IHttpClientFactory factory)
        {
            using HttpClient client = factory.CreateClient();

            var result = new ExtensivApiResult<ConsolidatedPickList>()
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
                result.Data = JsonConvert.DeserializeObject<ConsolidatedPickList>(responseContent)!;
                result.Message = "PickList retrieved successfully.";
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
