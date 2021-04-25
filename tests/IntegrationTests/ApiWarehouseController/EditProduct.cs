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
    public class EditProduct : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public EditProduct(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Edit()
        {
            var response = await Client.PutAsync("/api/warehouse/1/product/1", GetItemJson(10));
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<WarehouseItemDto>(stringResponse);

            Assert.Equal(10, model.Quantity);
            Assert.Equal(1, model.ProductId);
            Assert.Equal(1, model.WarehouseId);
            Assert.Equal(1, model.Product.Id);
        }
        [Fact]
        public async Task EditNotExistWarehouseItem()
        {
            var response = await Client.PutAsync("/api/warehouse/1/product/2", GetItemJson(1));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task EditWrongProduct()
        {
            var response = await Client.PutAsync("/api/warehouse/1/product/50", GetItemJson(1));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task EditToWrongWarehouse()
        {
            var response = await Client.PutAsync("/api/warehouse/50/product/1", GetItemJson(1));

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
