using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EMobile.DB.MinioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly IMinioProvider _minioClient;

        public HelperController(IMinioProvider minioProvider)
        {
            _minioClient = minioProvider;
        }

        [HttpGet]
        [Route("GetImage")]
        public async Task<IActionResult> GetImageAsync(string imageName)
        {
            var streamX = new MemoryStream();
            try
            {
                await _minioClient._minioClient
                   .GetObjectAsync("uploads", imageName, (stream) =>{
                        stream.CopyTo(streamX);
                    });
            }
            catch (Exception e)
            {
               return UnprocessableEntity(e.Message);
            }

            byte[] byteArray = streamX.ToArray();
            return File(byteArray, "image/jpeg");
        }
    }
}