using App.Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.DomainServices
{
    public interface IWarehouseItemService
    {
        Task<WarehouseItemDto> GetWarehouseItem(int warehouseId, int productId, CancellationToken cancellationToken = default);
    }
}
