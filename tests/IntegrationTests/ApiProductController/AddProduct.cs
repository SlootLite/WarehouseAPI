using App.API.Requests.ProductRequests;
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
    public class AddProduct : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public AddProduct(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("Item")]
        [InlineData(" Item2 ")]
        public async Task Add(string name)
        {
            var response = await Client.PostAsync("/api/product", GetItemJson(name));
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ProductDto>(stringResponse);

            Assert.Equal(name.Trim(), model.Name);
        }

        [Fact]
        public async Task AddWrong()
        {
            var response = await Client.PostAsync("/api/product", GetItemJson(" "));
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private StringContent GetItemJson(string name)
        {
            var request = new AddProductRequest()
            {
                Name = name
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }
    }
}
