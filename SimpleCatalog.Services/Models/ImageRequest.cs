namespace SimpleCatalog.Services.Models
{
    /// <summary>
    /// Saving image request model
    /// </summary>
    public class ImageRequest
    {
        /// <summary>
        /// The file name
        /// </summary>
        public string FileName;

        /// <summary>
        /// The image data
        /// </summary>
        public string ImageData;

        /// <summary>
        /// Is temporary image for new product
        /// </summary>
        public bool IsTemp;
    }
}