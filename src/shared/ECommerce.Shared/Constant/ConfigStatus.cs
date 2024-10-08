using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Constant
{
    public class ConfigStatus
    {
        public class ProductQuantityStatus
        {
            /// <summary>
            /// Tat ca
            /// </summary>
            public const uint All = 0;
            /// <summary>
            /// Trạngt hái còn hàng
            /// </summary>
            public const uint Stocking = 1;
            /// <summary>
            /// Trạng thái hết hàng
            /// </summary>
            public const uint OutStock = 2;
        }
    }
}
