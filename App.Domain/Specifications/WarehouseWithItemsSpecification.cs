using App.Domain.Entities;
using App.Domain.Entities.WarehouseAggregate;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Specifications
{
    public class WarehouseWithItemsSpecification : Specification<Warehouse>
    {
        public WarehouseWithItemsSpecification(int warehouseId)
        {
            Query
                .Where(s => s.Id == warehouseId)
                .Include(s => s.WarehouseItems);
        }
    }
}
