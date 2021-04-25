using App.Domain.Entities;
using App.Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Entities.WarehouseTests
{
    public class WarehouseAddItem
    {
        private readonly int _testProductId = 1;
        private readonly int _testProductId2 = 2;
        private readonly Warehouse _warehouse;

        public WarehouseAddItem() 
        {
            _warehouse = new Warehouse("warehouse");
        }

        [Fact]
        public void AddItem()
        {
            _warehouse.AddItem(_testProductId);
            Assert.Equal(1, _warehouse.WarehouseItems.Count);
        }
        [Fact]
        public void AddItems()
        {
            _warehouse.AddItem(_testProductId);
            _warehouse.AddItem(_testProductId2);
            Assert.Equal(2, _warehouse.WarehouseItems.Count);
        }
        [Fact]
        public void IncrimentItem()
        {
            _warehouse.AddItem(_testProductId);
            _warehouse.AddItem(_testProductId);

            var firstItem = _warehouse.WarehouseItems.First();

            Assert.Equal(1, _warehouse.WarehouseItems.Count);
            Assert.Equal(2, firstItem.Quantity);
            Assert.Equal(_testProductId, firstItem.ProductId);
        }
    }
}
