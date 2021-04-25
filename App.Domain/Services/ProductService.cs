using App.Domain.Entities.ProductAggregate;
using App.Domain.Exceptions;
using App.Domain.Interfaces.Data;
using App.Domain.Interfaces.DomainServices;
using App.Domain.Specifications;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.GetListAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductAsync(int productId, CancellationToken cancellationToken = default)
        {
            var product = await GetProductByIdAsync(productId, cancellationToken);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(string name, CancellationToken cancellationToken = default)
        {
            var spec = new ProductSpecification(name);
            var product = await _productRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if(product != null)
            {
                throw new ItemAlreadyExistException(nameof(Product));
            }

            product = new Product(name);
            await _productRepository.AddAsync(product, cancellationToken);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> EditProductAsync(int productId, string name, CancellationToken cancellationToken = default)
        {
            var product = await GetProductByIdAsync(productId, cancellationToken);

            product.SetName(name);

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductDto>(product);
        }

        private async Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            var spec = new ProductSpecification(productId);
            var product = await _productRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (product == null)
            {
                throw new ItemNotFoundException(nameof(Product));
            }

            return product;
        }
    }
}
