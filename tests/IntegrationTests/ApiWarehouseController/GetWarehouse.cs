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
    public class GetWarehouse : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public GetWarehouse(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Warehouse()
        {
            var response = await Client.GetAsync("/api/warehouse/4");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<WarehouseWithItemsDto>(stringResponse);
            Assert.Equal(4, model.Id);
            Assert.Equal("Склад 4", model.Name);
        }

        [Fact]
        public async Task WarehouseWrong()
        {
            var response = await Client.GetAsync("/api/warehouse/50");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task WarehouseWrong1()
        {
            var response = await Client.GetAsync("/api/warehouse/1");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<WarehouseWithItemsDto>(stringResponse);
            Assert.Equal(1, model.Id);
        }
    }
}
