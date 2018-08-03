using Microsoft.AspNetCore.Mvc;
using SimpleCatalog.Data.Dto;
using SimpleCatalog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCatalog.Web.Controllers
{
    [Route("api/productcategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<List<ProductCategoryDto>> Get() => await _productCategoryService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ProductCategoryDto> Get(Guid id) => await _productCategoryService.GetAsync(id);
    }
}