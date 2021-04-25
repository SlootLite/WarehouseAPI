using App.Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.WarehouseAggregate
{
    public class WarehouseItem : BaseEntity
    {
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public int WarehouseId { get; private set; }
        public Warehouse Warehouse { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public WarehouseItem()
        {

        }

        public WarehouseItem(int warehouseId, int productId, int quantity = 1)
        {
            WarehouseId = warehouseId;
            ProductId = productId;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
