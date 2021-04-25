using App.Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Entities.WarehouseTests
{
    public class WarehouseRemoveItem
    {
        private readonly int _testProductId = 1;
        private readonly int _testProductId2 = 2;
        private readonly Warehouse _warehouse;
        public WarehouseRemoveItem()
        {
            _warehouse = new Warehouse("warehouse");
            _warehouse.AddItem(_testProductId);
        }

        [Fact]
        public void RemoveItem()
        {
            _warehouse.RemoveItem(_testProductId);
            Assert.Equal(0, _warehouse.WarehouseItems.Count);
        }

        [Fact]
        public void RemoveNotExistingItem()
        {
            _warehouse.RemoveItem(_testProductId2);
            Assert.Equal(1, _warehouse.WarehouseItems.Count);
        }
    }
}
