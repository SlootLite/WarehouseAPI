using App.API.Requests.WarehouseRequests;
using App.Domain.Entities.WarehouseAggregate;
using App.Domain.Interfaces.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IEnumerable<WarehouseDto>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _warehouseService.GetAllWarehousesAsync(cancellationToken);
        }

        [HttpGet("{warehouseId}")]
        public async Task<WarehouseWithItemsDto> Get(int warehouseId, CancellationToken cancellationToken = default)
        {
            return await _warehouseService.GetWarehouseAsync(warehouseId, cancellationToken);
        }

        [HttpPost("{warehouseId}/product/{productId}")]
        public async Task<WarehouseItemDto> AddProduct(int warehouseId, int productId, [FromBody] ModifyWarehouseItemRequest request, CancellationToken cancellationToken = default)
        {
            return await _warehouseService.AddProductToWarehouseAsync(warehouseId, productId, request.Quantity, cancellationToken);
        }

        [HttpPut("{warehouseId}/product/{productId}")]
        public async Task<WarehouseItemDto> EditProduct(int warehouseId, int productId, [FromBody] ModifyWarehouseItemRequest request, CancellationToken cancellationToken = default)
        {
            return await _warehouseService.EditProductOfWarehouseAsync(warehouseId, productId, request.Quantity, cancellationToken);
        }

        [HttpDelete("{warehouseId}/product/{productId}")]
        public async Task Delete(int warehouseId, int productId, CancellationToken cancellationToken = default)
        {
            await _warehouseService.RemoveProductFromWarehouseAsync(warehouseId, productId, cancellationToken);
        }
    }
}
