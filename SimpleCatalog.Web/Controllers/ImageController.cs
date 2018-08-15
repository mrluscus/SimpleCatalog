using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCatalog.Services.Interfaces;
using SimpleCatalog.Services.Models;
using System;

namespace SimpleCatalog.Web.Controllers
{
    [Route("api/image")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly ILogger<ImageController> _logger;

        public ImageController(
            IImageService imageService,
            ILogger<ImageController> logger,
            IHostingEnvironment env)
        {
            _imageService = imageService;
            _imageService.WwwRootPath = env.WebRootPath;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [Produces("image/png")]
        public IActionResult Get(string id)
        {
            try
            {
                var filePath = _imageService.GetImagePath(id);

                if (System.IO.File.Exists(filePath))
                    return PhysicalFile(filePath, "image/png");

                return BadRequest("File not found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("check/{id}")]
        public IActionResult Check(string id)
        {
            var filePath = _imageService.GetImagePath(id);
            if (System.IO.File.Exists(filePath))
                return Ok();

            return NoContent();
        }

        /// <summary>
        /// Posts the saving request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost, Route("upload")]
        public IActionResult Post([FromBody]ImageRequest request)
        {
            try
            {
                _imageService.SaveImageToFolder(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}