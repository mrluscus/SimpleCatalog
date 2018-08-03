using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SimpleCatalog.Data;
using System;
using System.IO;
using System.Reflection;
using SimpleCatalog.Services.Interfaces;
using SimpleCatalog.Services.Services;

namespace SimpleCatalog.Web
{
    public class Startup
    {
        private static ILogger<Startup> _logger = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(env))
                env = "Development";

            // Read configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile($"appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true);

            Configuration = builder.Build();

            // Connection string for using in DBContext
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services
                .AddDbContext<SimpleCatalogDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient)
                .AddTransient<IProductCategoryService, ProductCategoryService>()
                .AddTransient<IProductService, ProductService>()
                .AddSingleton(new LoggerFactory().AddNLog())
                .AddLogging()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            var provider = services.BuildServiceProvider();
            _logger = provider.GetService<ILogger<Startup>>();
            _logger.LogInformation("Start the project");

            try
            {
                //Apply database migrations. (It will create DB if not exist)
                using (var dbCntx = provider.GetService<SimpleCatalogDbContext>())
                {
                    dbCntx.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Migration error");
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}