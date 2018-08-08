using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCatalog.Data;
using SimpleCatalog.Data.Dto;
using SimpleCatalog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCatalog.Services.Services
{
    /// <summary>
    /// Service for handling Product Categories entities
    /// </summary>
    /// <seealso cref="SimpleCatalog.Services.Interfaces.IProductCategoryService" />
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly SimpleCatalogDbContext _dbContext;

        public ProductCategoryService(
            SimpleCatalogDbContext dbContext,
            ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Gets all Product Catagories.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<ProductCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var itemsFromDb = await _dbContext.ProductCategories
                .Select(x => new ProductCategoryDto(x))
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
            return ConvertToTree(itemsFromDb);
        }

        /// <summary>
        /// Gets the Product Category by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ProductCategoryDto> GetAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var item = await _dbContext.ProductCategories.FindAsync(id);
            var res = new ProductCategoryDto(item);
            return res;
        }

        private List<ProductCategoryDto> ConvertToTree(List<ProductCategoryDto> dbElements)
        {
            dbElements.ForEach(x => x.Children = null);
            var result = new List<ProductCategoryDto>();

            // Creates new list with filled Children property for properly using on frontend
            foreach (var el in dbElements)
            {
                var parentEl = dbElements.FirstOrDefault(x => x.Id == el.ParentId);
                if (parentEl != null)
                {
                    if (parentEl.Children == null) parentEl.Children = new List<ProductCategoryDto>();
                    parentEl.Children.Add(el);
                }
                else
                {
                    result.Add(el);
                }
            }

            return result;
        }

        #region IDisposable Support

        private bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                        _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}