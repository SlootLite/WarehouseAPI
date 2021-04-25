using App.Domain.Entities.ProductAggregate;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(int productId)
        {
            Query
                .Where(s => s.Id == productId);
        }
        public ProductSpecification(string name)
        {
            var trimmedName = name.Trim();
            Query
                .Where(s => s.Name == trimmedName);
        }
    }
}
