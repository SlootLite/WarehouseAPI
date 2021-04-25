using App.Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.WarehouseAggregate
{
    public record WarehouseItemDto
    {
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public int WarehouseId { get; private set; }
        public int ProductId { get; private set; }
        public ProductDto Product { get; private set; }
    }
}
