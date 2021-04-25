using App.Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Entities.ProductTests
{
    public class ProductSetName
    {
        [Theory]
        [InlineData("Test")]
        [InlineData(" Test ")]
        public void SetName(string name)
        {
            var product = new Product("123");
            product.SetName(name);
            Assert.Equal(name.Trim(), product.Name);
        }
    }
}
