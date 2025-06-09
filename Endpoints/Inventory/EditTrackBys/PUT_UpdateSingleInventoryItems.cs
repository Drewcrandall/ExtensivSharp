using ExtensivSharp.Models.Helper;
using ExtensivSharp.Models.Order;
using ExtensivSharp.Models.Receivers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ExtensivSharp.Endpoints.Inventory.EditTrackBys
{
    class PUT_UpdateSingleInventoryItems
    {
        public string? AuthorizationToken { get; set; }
        public ReceiveItemPutRequest UpdateTrackBy { get; set; } = new();
        private static string ToUrl()
        {
            return $"https://secure-wms.com/orders";
        }
        public async Task<ExtensivApiResult<ReceiveItemPutRequest>> PostAsync()
        {
            using HttpClient client = new();
            var result = new ExtensivApiResult<ReceiveItemPutRequest>()
            {
                Success = false
            };
            var url = ToUrl();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            string JsonContent = JsonConvert.SerializeObject(UpdateTrackBy);
            var content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();

            result.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<ReceiveItemPutRequest>(responseContent)!;
                result.Message = "TrackBy Updated successfully.";
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
