using App.Domain.Entities;
using App.Domain.Entities.WarehouseAggregate;
using App.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Entities.WarehouseTests
{
    public class WarehouseEditItem
    {
        private readonly int _testProductId = 1;
        private readonly Warehouse _warehouse;

        public WarehouseEditItem() 
        {
            _warehouse = new Warehouse("warehouse");
        }

        [Fact]
        public void EditItem()
        {
            _warehouse.AddItem(_testProductId);

            _warehouse.EditItem(_testProductId, 5);

            var warehouseItem = _warehouse.WarehouseItems.First();
            Assert.Equal(5, warehouseItem.Quantity);
        }

        [Fact]
        public void EditNotExistingItem()
        {
            Assert.Throws<ItemNotFoundException>(() => _warehouse.EditItem(_testProductId, 5));
        }
    }
}
