using SimpleCatalog.Services.Models;
using System.IO;

namespace SimpleCatalog.Services.Interfaces
{
    /// <summary>
    /// Saving files service
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Gets or sets the WWW root path.
        /// </summary>
        /// <value>
        /// The WWW root path.
        /// </value>
        string WwwRootPath { get; set; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        MemoryStream GetImage(string name);

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        string GetImagePath(string name);

        /// <summary>
        /// Saves the image to the folder.
        /// </summary>
        /// <param name="request">The request.</param>
        bool SaveImageToFolder(ImageRequest request);
    }
}