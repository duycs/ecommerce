using ECommerce.Shared.Dotnet;
using ECommerce.Shared.Dotnet.Ultimate.Mvc.FormUpload;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ECommerce.Shared.Extensions
{
    public static class Extentions
    {
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddPortableObjectLocalization(delegate (LocalizationOptions o)
            {
                o.ResourcesPath = "Localization";
            });
            services.Configure(delegate (RequestLocalizationOptions options)
            {
                //List<CultureInfo> list = new List<CultureInfo>
                //{
                //    new CultureInfo("vi-VN"),
                //    new CultureInfo("en-US")
                //};
                //options.DefaultRequestCulture = new RequestCulture(CultureName.Default);
                //options.SupportedCultures = list;
                //options.SupportedUICultures = list;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });
            services.AddLocalization();
        }
        public static IDictionary<string, string[]> TranslateErrors(this IStringLocalizer localizer, ModelStateDictionary modelStateDictionary)
        {
            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>(StringComparer.Ordinal);
            foreach (KeyValuePair<string, ModelStateEntry> item in modelStateDictionary)
            {
                item.Deconstruct(out var key, out var value);
                string key2 = key;
                ModelErrorCollection errors = value.Errors;
                if (errors == null || errors.Count <= 0)
                {
                    continue;
                }

                if (errors.Count == 1)
                {
                    string text = GetErrorMessage(errors[0]);
                    dictionary.Add(key2, new string[1] { text });
                    continue;
                }

                string[] array = new string[errors.Count];
                for (int i = 0; i < errors.Count; i++)
                {
                    array[i] = GetErrorMessage(errors[i]);
                }

                dictionary.Add(key2, array);
            }

            return dictionary;
            string GetErrorMessage(ModelError error)
            {
                return string.IsNullOrEmpty(error.ErrorMessage) ? localizer["default error message"] : localizer[error.ErrorMessage];
            }
        }
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
