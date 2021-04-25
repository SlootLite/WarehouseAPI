using App.API.Requests.WarehouseRequests;
using App.Domain.Entities.WarehouseAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiWarehouseController
{
    public class AddProduct : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public AddProduct(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Add()
        {
            var response = await Client.PostAsync("/api/warehouse/1/product/2", GetItemJson(5));
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<WarehouseItemDto>(stringResponse);

            Assert.Equal(5, model.Quantity);
            Assert.Equal(2, model.ProductId);
            Assert.Equal(1, model.WarehouseId);
            Assert.Equal(2, model.Product.Id);
        }

        [Fact]
        public async Task AddWrongProduct()
        {
            var response = await Client.PostAsync("/api/warehouse/1/product/50", GetItemJson(1));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task AddToWrongWarehouse()
        {
            var response = await Client.PostAsync("/api/warehouse/50/product/1", GetItemJson(1));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private StringContent GetItemJson(int quantity)
        {
            var request = new ModifyWarehouseItemRequest()
            {
                Quantity = quantity
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }
    }
}
