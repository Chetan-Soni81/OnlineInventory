using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace OnlineInventory.Utility
{
    public class DbInitializerBase
    {

        public async Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string Directory)
        {
            var response = string.Empty;
            var upload = Path.Combine(env.WebRootPath, Directory);
            var fileExtensions = string.Empty;
            var filePath = string.Empty;
            var fileName = string.Empty;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    fileExtensions = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid().ToString() + fileExtensions;
                    filePath = Path.Combine(upload, fileName);
                    using (var ms = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(ms);
                    }

                    response = fileName;
                }

            }
                return response;
        }
    }
}