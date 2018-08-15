using Microsoft.Extensions.Logging;
using SimpleCatalog.Services.Interfaces;
using SimpleCatalog.Services.Models;
using System;
using System.IO;

namespace SimpleCatalog.Services.Services
{
    /// <summary>
    ///  files service
    /// </summary>
    /// <seealso cref="IImageService" />
    public class ImageService : IImageService
    {
        private readonly ImageConfig _imageConfig;
        private readonly ILogger<ImageService> _logger;

        public ImageService(ImageConfig imageConfig, ILogger<ImageService> logger)
        {
            _imageConfig = imageConfig;
            _logger = logger;
        }

        /// <summary>
        /// Gets or sets the WWW root path.
        /// </summary>
        /// <value>
        /// The WWW root path.
        /// </value>
        public string WwwRootPath { get; set; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public MemoryStream GetImage(string name)
        {
            try
            {
                string imageFolder = _imageConfig.PathToImages;
                string path = Path.Combine(WwwRootPath, imageFolder);
                string fileName = path + name + ".png";

                var memory = new MemoryStream();
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;

                return memory;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string GetImagePath(string name)
        {
            return Path.Combine(WwwRootPath, _imageConfig.PathToImages, name + ".png");
        }

        /// <summary>
        /// Saves the image to the folder.
        /// </summary>
        /// <param name="request">The request.</param>
        public bool SaveImageToFolder(ImageRequest request)
        {
            try
            {
                string imageFolder = _imageConfig.PathToImages;
                string path = Path.Combine(WwwRootPath, imageFolder);

                // Check for existing folder
                var newFolder = new DirectoryInfo(path);
                if (!newFolder.Exists)
                {
                    newFolder.Create();
                }

                // Compose file name
                var f = new FileInfo(request.FileName);
                var name = Path.GetFileNameWithoutExtension(request.IsTemp ? "temp" : f.Name);
                string fileName = path + name + ".png";

                // Save file
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(request.ImageData);
                        bw.Write(data);
                        bw.Close();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}