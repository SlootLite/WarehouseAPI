using App.Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Entities.WarehouseTests
{
    public class WarehouseRemoveEmptyItems
    {
        private readonly int _testProductId = 1;
        private readonly int _testProductId2 = 2;
        private readonly Warehouse _warehouse;
        public WarehouseRemoveEmptyItems()
        {
            _warehouse = new Warehouse("warehouse");
            _warehouse.AddItem(_testProductId, 0);
            _warehouse.AddItem(_testProductId2, -1);
        }
        [Fact]
        public void RemoveEmptyItems()
        {
            _warehouse.RemoveEmptyItems();
            Assert.Equal(0, _warehouse.WarehouseItems.Count);
        }
    }
}
