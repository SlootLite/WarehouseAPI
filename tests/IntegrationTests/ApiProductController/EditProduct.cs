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
    public class EditProduct : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }
        private readonly string _testName = "Большой мешок";

        public EditProduct(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task EditWrong()
        {
            var response = await Client.PutAsync("/api/product/1", GetItemJson(" "));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Edit()
        {
            var response = await Client.PutAsync("/api/product/2", GetItemJson(_testName));
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ProductDto>(stringResponse);

            Assert.Equal(_testName, model.Name);
        }

        private StringContent GetItemJson(string name)
        {
            var request = new EditProductRequest()
            {
                Name = name
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }
    }
}
