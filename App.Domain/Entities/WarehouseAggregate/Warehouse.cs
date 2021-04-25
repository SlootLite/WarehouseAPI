using App.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.WarehouseAggregate
{
    public class Warehouse : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private List<WarehouseItem> _warehouseItems = new List<WarehouseItem>();
        public IReadOnlyCollection<WarehouseItem> WarehouseItems => _warehouseItems.AsReadOnly();
        
        public Warehouse()
        {

        }

        public Warehouse(string name)
        {
            Name = name;
        }

        public void AddItem(int productId, int quantity = 1)
        {
            if(!_warehouseItems.Any(s => s.ProductId == productId))
            {
                _warehouseItems.Add(new WarehouseItem(Id, productId, quantity));
                return;
            }
            var existingItem = _warehouseItems.FirstOrDefault(s => s.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }

        public void EditItem(int productId, int quantity)
        {
            var existingItem = _warehouseItems.FirstOrDefault(s => s.ProductId == productId);
            if(existingItem == null)
            {
                throw new ItemNotFoundException(nameof(WarehouseItem));
            }
            existingItem.SetQuantity(quantity);
        }

        public void RemoveItem(int productId)
        {
            var item = _warehouseItems.FirstOrDefault(s => s.ProductId == productId);
            if (item == null)
            {
                return;
            }
            _warehouseItems.Remove(item);
        }

        public void RemoveEmptyItems()
        {
            _warehouseItems.RemoveAll(s => s.Quantity <= 0);
        }
    }
}
