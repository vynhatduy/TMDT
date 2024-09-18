using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace TMDT.Controllers
{
    public class GetObjController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public GetObjController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult GetImage(string imagePath)
        {
            var fullPath = Path.Combine(_env.WebRootPath, imagePath);
            if (System.IO.File.Exists(fullPath))
            {
                var fileExtension = Path.GetExtension(fullPath).ToLowerInvariant();
                var contentType = fileExtension switch
                {
                    ".png" => "image/png",
                    ".jpg" => "image/jpeg",
                    ".jpeg" => "image/jpeg",
                    ".gif" => "image/gif",
                    _ => "application/octet-stream",
                };

                return PhysicalFile(fullPath, contentType);
            }
            return NotFound();
        }
    }
}
