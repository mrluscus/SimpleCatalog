using SimpleCatalog.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SimpleCatalog.Data.Dto;

namespace SimpleCatalog.Services.Interfaces
{
    /// <summary>
    /// Service interface for handling Products entities
    /// </summary>
    public interface IProductService : IDisposable
    {
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the Product by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ProductDto> GetAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Products by category id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<List<ProductDto>> GetByCategoryIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Saves the Product.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Guid> SaveAsync(ProductDto item, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the Product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}