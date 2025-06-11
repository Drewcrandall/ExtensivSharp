using Newtonsoft.Json;

namespace ExtensivSharp.Models.Auth
{
    public class ExtensivAuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string? RefreshToken { get; set; }
        [JsonProperty("scope")]
        public string? Scope { get; set; }

        public ExtensivAuthResponse(string accessToken, string tokenType, int expiresIn, string refreshToken, string scope)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            RefreshToken = refreshToken;
            Scope = scope;
        }
    }
}
