using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleCatalog.Data.Model;
using System.IO;

namespace SimpleCatalog.Data
{
    public class SimpleCatalogDbContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public SimpleCatalogDbContext(DbContextOptions<SimpleCatalogDbContext> options) : base(options)
        {
        }
    }
}