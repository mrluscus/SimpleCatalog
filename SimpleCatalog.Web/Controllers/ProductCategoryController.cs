using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCatalog.Data.Dto;
using SimpleCatalog.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCatalog.Web.Controllers
{
    [Route("api/productcategory")]
    [ApiController]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ILogger<ProductCategoryController> _logger;

        public ProductCategoryController(IProductCategoryService productCategoryService,
            ILogger<ProductCategoryController> logger)
        {
            _productCategoryService = productCategoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _productCategoryService.GetAllAsync();
                var res = Json(items);

                // Emulate delay of loading
                Thread.Sleep(2000);

                return res;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryDto> Get(Guid id) => await _productCategoryService.GetAsync(id);
    }
}