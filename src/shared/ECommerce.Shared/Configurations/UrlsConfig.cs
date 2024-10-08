using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Configurations
{
    public class UrlsConfig
    {
        public class SaasMethods
        {
            public static string Login() => "/api/sync/auth/login";
            public static string CreateOrder() => "/api/sync/ecommerce/order";
            public static string Liability(int customerId) => $"/api/sync/ecommerce/customer/{customerId}/liabilities";
            public static string CancelOrder(uint orderId) => $"/api/sync/ecommerce/order/{orderId}/cancel";
            public static string UpdateNot(uint orderId) => $"/api/sync/ecommerce/order/{orderId}/note";
        }
    }
}
