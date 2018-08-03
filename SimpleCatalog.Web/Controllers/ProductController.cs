using Microsoft.AspNetCore.Mvc;
using SimpleCatalog.Data.Dto;
using SimpleCatalog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCatalog.Web.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductDto>> Get()
            => await _productService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(Guid id)
            => await _productService.GetAsync(id);

        [HttpPost]
        public async Task Post([FromBody]ProductDto dto, CancellationToken cancellationToken)
            => await _productService.SaveAsync(dto, cancellationToken);

        [HttpPut, Route("{id}")]
        public async Task Put(Guid id, [FromBody]ProductDto dto, CancellationToken cancellationToken)
            => await _productService.SaveAsync(dto, cancellationToken);

        [HttpDelete, Route("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
            => await _productService.DeleteAsync(id, cancellationToken);
    }
}