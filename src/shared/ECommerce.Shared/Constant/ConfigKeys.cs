using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Constant
{
    public static class ConfigKeys
    {
        public static string LocationVersion = "LocationVersion";

        public static string SuggestTransferContents = "SuggestTransferContents";

        // Product key
        public const string DefaultNumberTopProducts = "6";
        public const string TopNewProduct = "TopNewProduct";
        public const string TopBestSellingProduct = "TopBestSellingProduct";
        public const string TopSuggestedProduct = "TopSuggestedProduct";
        public const string TopPurchaseProduct = "TopPurchaseProduct";

        // table product type
        public const string NewProductTableName = "new_products";
        public const string BestSellingProductTableName = "best_selling_products";
        public const string SuggestProductTableName = "suggest_products";
    }
}
