using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCatalog.Data;
using SimpleCatalog.Data.Dto;
using SimpleCatalog.Data.Model;
using SimpleCatalog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCatalog.Services.Services
{
    /// <summary>
    /// Service for handling Products entities
    /// </summary>
    /// <seealso cref="SimpleCatalog.Services.Interfaces.IProductService" />
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly SimpleCatalogDbContext _dbContext;

        public ProductService(
            SimpleCatalogDbContext dbContext,
            ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await _dbContext.Products
                .Select(x => new ProductDto(x))
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the Product by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ProductDto> GetAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var item = await _dbContext.Products.FindAsync(id);
            var res = new ProductDto(item);
            return res;
        }

        /// <summary>
        /// Gets Products by category identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<List<ProductDto>> GetByCategoryIdAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _dbContext.Products
                .Where(x => x.ProductCategoryId == id)
                .Select(x => new ProductDto(x))
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Saves the Product.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<Guid> SaveAsync(ProductDto item, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var dbSet = _dbContext.Products;
                var itemFromDb = dbSet.Find(item.Id);
                if (itemFromDb != null)
                {
                    itemFromDb.ProductCategoryId = item.ProductCategoryId;
                    itemFromDb.Name = item.Name;
                    itemFromDb.Price = item.Price;
                    itemFromDb.Quantity = item.Quantity;
                    dbSet.Update(itemFromDb);
                }
                else
                {
                    itemFromDb = new Product
                    {
                        Id = Guid.NewGuid(),
                        ProductCategoryId = item.ProductCategoryId,
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity
                    };

                    dbSet.Add(itemFromDb);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                return item.Id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Deletes the Product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var dbSet = _dbContext.Products;
                var entity = dbSet.Find(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }

            return false;
        }

        /// <summary>
        /// Deletes the List of Products.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(List<Guid> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            var dbSet = _dbContext.Products;
            foreach (var id in ids)
            {
                var entity = dbSet.Find(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                }
            }

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
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