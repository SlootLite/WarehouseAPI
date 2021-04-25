using App.Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Entities.ProductTests
{
    public class ProductCreate
    {
        [Theory]
        [InlineData("Test")]
        [InlineData(" Test ")]
        public void CreateProduct(string name)
        {
            var product = new Product(name);
            Assert.Equal(name.Trim(), product.Name);
        }
    }
}
