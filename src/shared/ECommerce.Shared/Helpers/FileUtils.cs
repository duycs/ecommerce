using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ECommerce.Shared.Helpers
{
    public static class FileUtils
    {
        private const string TempFolderName = "temp";

        public static List<T> ReadCsv<T>(string path, ILogger logger, string[] headers, Func<string[], string[], T> mapper) where T : class
        {
            if (!File.Exists(path))
            {
                logger.LogWarning("Data file not found at " + path);
                return new List<T>();
            }

            try
            {
                headers = ValidateHeaders(path, headers);
            }
            catch (Exception ex)
            {
                logger.LogWarning("Data file at " + path + " is not valid", ex);
            }

            return (from row in File.ReadAllLines(path).Skip(1)
                    select (from t in Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")
                            select t.Trim('"')).ToArray() into column
                    select mapper(column, headers) into x
                    where x != null
                    select x).ToList();
        }

        private static string[] ValidateHeaders(string csvFile, string[] requiredHeaders)
        {
            string[] array = File.ReadLines(csvFile).First().ToLowerInvariant()
                .Split(',');
            foreach (string text in requiredHeaders)
            {
                if (!array.Contains(text))
                {
                    throw new Exception("does not contain required header '" + text + "'");
                }
            }

            return array;
        }

        public static string GetFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public static string SearchForFile(string fileName, string folderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            FileInfo fileInfo = directoryInfo.GetFiles(fileName, SearchOption.AllDirectories).FirstOrDefault();
            if (fileInfo == null)
            {
                return null;
            }

            Uri uri = new Uri(directoryInfo.FullName);
            Uri uri2 = new Uri(fileInfo.FullName);
            return uri.MakeRelativeUri(uri2).OriginalString;
        }

        public static bool TryRead(string path, out string text)
        {
            text = string.Empty;
            if (!File.Exists(path))
            {
                return false;
            }

            text = File.ReadAllText(path);
            return true;
        }

        public static string GetTempFolderPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "temp");
        }

        public static string GetTempFilePath()
        {
            return Path.Combine(GetTempFolderPath(), Guid.NewGuid().ToString("N"));
        }
    }
}
