using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Auth
{
    public class AuthRequest
    {
        private string _clientId;
        private string _clientSecret;

        public AuthRequest(string clientId, string clientSecret, string userId)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            UserId = userId;
            Key = GenerateKey();
        }

        public string ClientId
        {
            get => _clientId;
            set {
                _clientId = value;
                Key = GenerateKey();
            }
        }

        public string ClientSecret
        {
            get => _clientSecret;
            set
            {
                _clientSecret = value;
                Key = GenerateKey();
            }
        }

        public string UserId { get; set; }

        public string Key { get; private set; }

        private string GenerateKey()
        {
            return $"{_clientId}:{_clientSecret}";
        }
    }
}
