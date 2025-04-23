using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Auth
{
    public class AuthResponse
    {
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public int ExpiresIn { get; set; }
            public string RefreshToken { get; set; }
            public string Scope { get; set; }

        public AuthResponse(string accessToken, string tokenType, int expiresIn, string refreshToken, string scope)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            RefreshToken = refreshToken;
            Scope = scope;
        }
    }
}
