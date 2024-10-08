using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Dotnet.Ultimate.Mvc.FormUpload
{
    public static class MvcConfigureExtension
    {
        public static void AllowUploadLargeFile(this MvcOptions mvcOptions)
        {
            mvcOptions.ModelBinderProviders.Insert(0, new TempFormFileModelBinderProvider());
        }
    }
}
