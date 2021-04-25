using App.Domain.Entities.WarehouseAggregate;
using App.Domain.Interfaces.Data;
using App.Domain.Interfaces.DomainServices;
using App.Domain.Specifications;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class WarehouseItemService : IWarehouseItemService
    {
        private readonly IRepository<WarehouseItem> _warehouseItemRepository;
        private readonly IMapper _mapper;
        public WarehouseItemService(IRepository<WarehouseItem> warehouseItemRepository,
            IMapper mapper)
        {
            _warehouseItemRepository = warehouseItemRepository;
            _mapper = mapper;
        }

        public async Task<WarehouseItemDto> GetWarehouseItem(int warehouseId, int productId, CancellationToken cancellationToken = default)
        {
            var spec = new WarehouseItemSpecification(warehouseId, productId);
            var warehouseItem = await _warehouseItemRepository.FirstOrDefaultAsync(spec, cancellationToken);

            return _mapper.Map<WarehouseItemDto>(warehouseItem);
        }
    }
}
