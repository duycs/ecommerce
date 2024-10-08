using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dotnet.Ultimate.Mvc.FormUpload
{
    public class TempFormFileModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            Type modelType = context.Metadata.ModelType;
            if (modelType != typeof(TempFormFile) && !typeof(IEnumerable<TempFormFile>).IsAssignableFrom(modelType))
            {
                return null;
            }

            return new TempFormFileModelBinder(context.Services.GetRequiredService<ILoggerFactory>());
        }
    }
    public class TempFormFile
    {
        public string Name { get; set; }

        public string FileName { get; set; }

        public string ContentDisposition { get; set; }

        public string ContentType { get; set; }

        public string TempPath { get; set; }

        public long Length { get; set; }

        public TempFormFile()
        {
        }

        public TempFormFile(ContentDispositionHeaderValue contentDisposition, string tempPath, long length)
        {
            Name = HeaderUtilities.RemoveQuotes(contentDisposition.Name).ToString();
            FileName = HeaderUtilities.RemoveQuotes(contentDisposition.FileNameStar.HasValue ? contentDisposition.FileNameStar : contentDisposition.FileName).ToString();
            TempPath = tempPath;
            Length = length;
            ContentDisposition = contentDisposition.ToString();
        }

        public Stream OpenReadStream()
        {
            return File.OpenRead(TempPath);
        }

        public IEnumerable<(string, StringValues)> GetValues()
        {
            yield return (Name + ".Name", Name);
            yield return (Name + ".FileName", FileName);
            yield return (Name + ".TempPath", TempPath);
            yield return (Name + ".Length", Length.ToString());
            yield return (Name + ".ContentDisposition", ContentDisposition);
            yield return (Name + ".ContentType", ContentType);
        }
    }
    public class TempFormFileModelBinder : IModelBinder
    {
        private readonly ILogger<TempFormFileModelBinder> _logger;

        public TempFormFileModelBinder(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<TempFormFileModelBinder>();
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }

            ICollection<TempFormFile> collection = await ReadFormFile(bindingContext);
            string modelName = bindingContext.ModelName;
            if (bindingContext.ModelType == typeof(TempFormFile))
            {
                if (collection.Count == 0)
                {
                    return;
                }

                TempFormFile tempFormFile = collection.First();
                bindingContext.ValidationState.Add(tempFormFile, new ValidationStateEntry
                {
                    Key = modelName
                });
                bindingContext.ModelState.SetModelValue(modelName, null, null);
                bindingContext.Result = ModelBindingResult.Success(tempFormFile);
            }

            if (typeof(IEnumerable<TempFormFile>).IsAssignableFrom(bindingContext.ModelType))
            {
                bindingContext.ValidationState.Add(collection, new ValidationStateEntry
                {
                    Key = modelName
                });
                bindingContext.ModelState.SetModelValue(modelName, null, null);
                bindingContext.Result = ModelBindingResult.Success(collection);
            }
        }

        private async Task<ICollection<TempFormFile>> ReadFormFile(ModelBindingContext bindingContext)
        {
            HttpContext httpContext = bindingContext.HttpContext;
            return (await LargeFileBinderExtensions.ParseFormAsync(logger: httpContext.RequestServices.GetService<ILogger<TempFormFileModelBinder>>(), request: httpContext.Request)).Item1;
        }
    }
    public static class LargeFileBinderExtensions
    {
        private static readonly FormOptions DefaultFormOptions = new FormOptions();

        public static async Task<(ICollection<TempFormFile>, KeyValueAccumulator)> ParseFormAsync(this HttpRequest request, ILogger logger)
        {
            if (!request.IsMultipartContentType())
            {
                throw new Exception("Expected a multipart request, but got " + request.ContentType);
            }

            KeyValueAccumulator formAccumulator = default(KeyValueAccumulator);
            List<TempFormFile> fileAccumulator = new List<TempFormFile>();
            string boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(request.ContentType), DefaultFormOptions.MultipartBoundaryLengthLimit);
            MultipartReader reader = new MultipartReader(boundary, request.Body);
            MultipartSection section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                if (ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition))
                {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        string targetFilePath = FileUtils.GetTempFilePath();
                        using (FileStream targetStream = File.Create(targetFilePath))
                        {
                            await section.Body.CopyToAsync(targetStream);
                            logger.LogInformation("Copied the uploaded file '" + targetFilePath + "'");
                        }

                        HeaderDictionary headerDictionary = new HeaderDictionary(section.Headers);
                        fileAccumulator.Add(new TempFormFile(contentDisposition, targetFilePath, section.Body.Length)
                        {
                            ContentType = headerDictionary["Content-Type"]
                        });
                    }
                    else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                    {
                        StringSegment key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
                        Encoding encoding = GetEncoding(section);
                        using StreamReader streamReader = new StreamReader(section.Body, encoding, detectEncodingFromByteOrderMarks: true, 1024, leaveOpen: true);
                        string text = await streamReader.ReadToEndAsync();
                        if (string.Equals(text, "undefined", StringComparison.OrdinalIgnoreCase))
                        {
                            text = string.Empty;
                        }

                        formAccumulator.Append(key.ToString(), text);
                        if (formAccumulator.ValueCount > DefaultFormOptions.ValueCountLimit)
                        {
                            throw new InvalidDataException($"Form key count limit {DefaultFormOptions.ValueCountLimit} exceeded.");
                        }
                    }
                }

                MultipartSection multipartSection = ((!request.Body.CanSeek || request.Body.Position != request.Body.Length) ? (await reader.ReadNextSectionAsync()) : null);
                section = multipartSection;
                contentDisposition = null;
            }

            logger.LogInformation($"Number of file upload: '{fileAccumulator.Count}'");
            return (fileAccumulator, formAccumulator);
        }

        private static Encoding GetEncoding(MultipartSection section)
        {
            if (!MediaTypeHeaderValue.TryParse(section.ContentType, out var parsedValue) || Encoding.UTF7.Equals(parsedValue.Encoding))
            {
                return Encoding.UTF8;
            }

            return parsedValue.Encoding;
        }
    }
}
