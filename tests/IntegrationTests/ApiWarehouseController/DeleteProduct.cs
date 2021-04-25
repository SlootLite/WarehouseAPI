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
    public class DeleteProduct : IClassFixture<ApiFixture>
    {
        public HttpClient Client { get; }

        public DeleteProduct(ApiFixture fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Delete()
        {
            var response = await Client.DeleteAsync("/api/warehouse/1/product/1");
            response.EnsureSuccessStatusCode();
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteWrong()
        {
            var response = await Client.DeleteAsync("/api/warehouse/1/product/50");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
