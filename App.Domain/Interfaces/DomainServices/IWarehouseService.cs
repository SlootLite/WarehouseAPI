using App.Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.DomainServices
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync(CancellationToken cancellationToken = default);
        Task<WarehouseWithItemsDto> GetWarehouseAsync(int warehouseId, CancellationToken cancellationToken = default);
        Task<WarehouseItemDto> AddProductToWarehouseAsync(int warehouseId, int productId, int quantity = 1, CancellationToken cancellationToken = default);
        Task<WarehouseItemDto> EditProductOfWarehouseAsync(int warehouseId, int productId, int quantity, CancellationToken cancellationToken = default);
        Task RemoveProductFromWarehouseAsync(int warehouseId, int productId, CancellationToken cancellationToken = default);
    }
}
