using App.Domain.Entities.WarehouseAggregate;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Specifications
{
    public class WarehouseItemSpecification : Specification<WarehouseItem>
    {
        public WarehouseItemSpecification(int warehouseId, int productId)
        {
            Query
                .Where(s => s.WarehouseId == warehouseId && s.ProductId == productId)
                .Include(s => s.Product);
        }
    }
}
