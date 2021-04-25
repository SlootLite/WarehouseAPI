using App.Domain.Entities.ProductAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiProductController
{
    public class GetProduct : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public GetProduct(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Product()
        {
            var response = await Client.GetAsync("/api/product/4");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ProductDto>(stringResponse);
            Assert.Equal(4, model.Id);
            Assert.Equal("Наушники", model.Name);
        }

        [Fact]
        public async Task ProductWrong()
        {
            var response = await Client.GetAsync("/api/product/50");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
