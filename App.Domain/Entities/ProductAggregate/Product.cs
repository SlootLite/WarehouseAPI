using App.Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private List<WarehouseItem> _warehouseItems = new List<WarehouseItem>();
        public IReadOnlyCollection<WarehouseItem> WarehouseItems => _warehouseItems.AsReadOnly();

        public Product()
        {

        }

        public Product(string name)
        {
            Name = name.Trim();
        }

        public void SetName(string name)
        {
            Name = name.Trim();
        }
    }
}
