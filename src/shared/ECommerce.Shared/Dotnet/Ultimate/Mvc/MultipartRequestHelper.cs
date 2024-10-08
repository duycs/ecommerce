using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;

namespace ECommerce.Shared.Dotnet.Ultimate.Mvc
{
    public static class MultipartRequestHelper
    {
        public static string GetBoundary(MediaTypeHeaderValue contentType, int lengthLimit)
        {
            string text = HeaderUtilities.RemoveQuotes(contentType.Boundary).ToString();
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new InvalidDataException("Missing content-type boundary.");
            }

            if (text.Length > lengthLimit)
            {
                throw new InvalidDataException($"Multipart boundary length limit {lengthLimit} exceeded.");
            }

            return text;
        }

        public static bool IsMultipartContentType(this HttpRequest request)
        {
            if (!string.IsNullOrEmpty(request.ContentType))
            {
                return request.ContentType.Contains("multipart/", StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        public static bool HasFormDataContentDisposition(ContentDispositionHeaderValue contentDisposition)
        {
            if (contentDisposition != null && contentDisposition.DispositionType.Equals("form-data") && string.IsNullOrEmpty(contentDisposition.FileName.ToString()))
            {
                return string.IsNullOrEmpty(contentDisposition.FileNameStar.ToString());
            }

            return false;
        }

        public static bool HasFileContentDisposition(ContentDispositionHeaderValue contentDisposition)
        {
            if (contentDisposition != null && contentDisposition.DispositionType.Equals("form-data"))
            {
                if (string.IsNullOrEmpty(contentDisposition.FileName.ToString()))
                {
                    return !string.IsNullOrEmpty(contentDisposition.FileNameStar.ToString());
                }

                return true;
            }

            return false;
        }
    }
}
