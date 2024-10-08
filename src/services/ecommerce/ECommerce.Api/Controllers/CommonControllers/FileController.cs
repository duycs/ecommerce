using ECommerce.Shared.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers.CommonControllers
{
    public class FileController : CommonControllerBase
    {
        [HttpPost("upload")]
        [AllowAnonymous]
        [ValidateMultipartContent]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromForm] int id, [FromForm] IList<IFormFile> files)
        {
            var temporaryFolder = Path.Combine(Path.GetTempPath(), id.ToString());
            if (!Directory.Exists(temporaryFolder))
            {
                Directory.CreateDirectory(temporaryFolder);
            }
            foreach (var form in files)
            {
                var filePath = Path.Combine(temporaryFolder, form.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await form.CopyToAsync(fileStream);
                }
                else
                {
                    using var fileStream = new FileStream(filePath, FileMode.Open);
                    await form.CopyToAsync(fileStream);
                }

            }
            return Accepted();
        }

        [HttpPost("test")]
        [AllowAnonymous]
        [ValidateMultipartContent]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> TestUploadFile()
        {
            var content = string.Empty;
            var temporaryFolder = Path.Combine(Path.GetTempPath());
            var filePath = Path.Combine(temporaryFolder, "log.json");

            using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                content = await reader.ReadToEndAsync();
                if (!Directory.Exists(temporaryFolder))
                {
                    Directory.CreateDirectory(temporaryFolder);
                }
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.Create(filePath);
                }
            }
            await System.IO.File.WriteAllLinesAsync(filePath, new List<string>() { content });
            return Accepted();
        }
    }
}
