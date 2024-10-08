using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Configurations
{
    public class AuthenticationSettings
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string ApiName { get; set; }
        public string ApiSecret { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string[] Scopes { get; set; }
    }
}
