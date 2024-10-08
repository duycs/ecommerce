using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Models
{
    public class AccessTokenModel
    {
        public string AccessToken { get; private set; }
        public int ExpiresIn { get; private set; }
        public string TokenType { get; private set; }
        public string RefreshToken { get; private set; }
        public string Scope { get; private set; }

        public AccessTokenModel(string accessToken, int expiresIn, string tokenType, string refreshToken, string scope)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
            RefreshToken = refreshToken;
            Scope = scope;
        }
    }
}
