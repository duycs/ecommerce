using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.ResponseModels
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}
