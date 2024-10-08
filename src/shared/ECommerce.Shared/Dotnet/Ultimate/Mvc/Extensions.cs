using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using ECommerce.Shared.Dotnet.Ultimate.Mvc.FormUpload;

namespace ECommerce.Shared.Dotnet.Ultimate.Mvc
{
    public static class Extensions
    {
        public static IMvcBuilder AddUltimateMvc(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddMvc(delegate (MvcOptions options)
            {
                options.AllowUploadLargeFile();
            }).AddNewtonsoftJson(delegate (MvcNewtonsoftJsonOptions options)
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}
