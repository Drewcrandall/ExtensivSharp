using ExtensivSharp.Models.Auth;
using Newtonsoft.Json;
using System.Text;

namespace ExtensivSharp.Services
{
    public class AuthenticationService
    {
        public static async Task<ExtensivAuthResponse?> GetAuthenticationKey(ExtensivAuthRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://secure-wms.com/AuthServer/api/Token";

                // Configure headers
                client.DefaultRequestHeaders.Accept.Add(new("application/hal+json"));
                client.DefaultRequestHeaders.Authorization = new("Basic", request.Key);

                // Create request body
                var requestBody = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "user_login", request.UserId }
                };

                //create json content
                var content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                // Send request
                var response = await client.PostAsync(url, content);

                //check for null
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                //retrun a response
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<ExtensivAuthResponse>(responseJson);
                return responseObject;
            }
        }
    }
}
