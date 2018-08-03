using SimpleCatalog.Data.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCatalog.Services.Interfaces
{
    /// <summary>
    /// Service interface for handling ProductCategory entities
    /// </summary>
    public interface IProductCategoryService : IDisposable
    {
        /// <summary>
        /// Gets all Product Catagories.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<List<ProductCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the Product Category by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ProductCategoryDto> GetAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}