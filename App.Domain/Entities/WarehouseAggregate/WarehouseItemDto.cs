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
        public int Id { get; init; }
        public int Quantity { get; init; }
        public int WarehouseId { get; init; }
        public int ProductId { get; init; }
        public ProductDto Product { get; init; }
    }
}
