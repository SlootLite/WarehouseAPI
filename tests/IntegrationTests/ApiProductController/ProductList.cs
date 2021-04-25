using App.Domain.Entities.ProductAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiProductController
{
    public class ProductList : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public ProductList(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetListProduct()
        {
            var response = await Client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(stringResponse);
            Assert.Equal(4, model.Count());
        }
    }
}
