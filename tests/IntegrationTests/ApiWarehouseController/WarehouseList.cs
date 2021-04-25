using App.Domain.Entities.WarehouseAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.ApiWarehouseController
{
    public class WarehouseList : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public WarehouseList(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetListWarehouse()
        {
            var response = await Client.GetAsync("/api/warehouse");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<IEnumerable<WarehouseDto>>(stringResponse);
            var firstModel = model.First();
            
            Assert.Equal(10, model.Count());
            Assert.Equal("Склад 1", firstModel.Name);
        }
    }
}
