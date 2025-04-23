using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensivSharp.Models.Auth
{
    public class ExtensivAuthRequest
    {
        private string _clientId;
        private string _clientSecret;

        public ExtensivAuthRequest(string clientId, string clientSecret, string userId)
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
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
        }
    }
}
