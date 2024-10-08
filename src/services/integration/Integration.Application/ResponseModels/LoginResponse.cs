using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.ResponseModels
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}
