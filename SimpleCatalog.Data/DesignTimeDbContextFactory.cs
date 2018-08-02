using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SimpleCatalog.Data
{
  public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SimpleCatalogDbContext>
  {
    public SimpleCatalogDbContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
      var builder = new DbContextOptionsBuilder<SimpleCatalogDbContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");
      builder.UseSqlServer(connectionString);
      return new SimpleCatalogDbContext(builder.Options);
    }
  }
}