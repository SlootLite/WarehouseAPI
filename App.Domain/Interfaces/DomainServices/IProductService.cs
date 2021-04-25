using App.Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.DomainServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken = default);
        Task<ProductDto> GetProductAsync(int productId, CancellationToken cancellationToken = default);
        Task<ProductDto> CreateProductAsync(string name, CancellationToken cancellationToken = default);
        Task<ProductDto> EditProductAsync(int productId, string name, CancellationToken cancellationToken = default);
    }
}
