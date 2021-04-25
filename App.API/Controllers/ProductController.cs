using App.API.Requests.ProductRequests;
using App.Domain.Entities.ProductAggregate;
using App.Domain.Interfaces.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _productService.GetAllProductsAsync(cancellationToken);
        }

        [HttpGet("{productId}")]
        public async Task<ProductDto> Get(int productId, CancellationToken cancellationToken = default)
        {
            return await _productService.GetProductAsync(productId, cancellationToken);
        }

        [HttpPost]
        public async Task<ProductDto> AddProduct([FromBody] AddProductRequest request, CancellationToken cancellationToken = default)
        {
            return await _productService.CreateProductAsync(request.Name, cancellationToken);
        }

        [HttpPut("{productId}")]
        public async Task<ProductDto> EditProduct(int productId, [FromBody] EditProductRequest request, CancellationToken cancellationToken = default)
        {
            return await _productService.EditProductAsync(productId, request.Name, cancellationToken);
        }
    }
}
