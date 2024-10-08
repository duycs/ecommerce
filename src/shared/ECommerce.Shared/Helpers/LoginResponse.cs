using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Helpers
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}
