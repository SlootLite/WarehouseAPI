using App.Domain.Entities;
using App.Domain.Entities.WarehouseAggregate;
using App.Domain.Exceptions;
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
    public class WarehouseService : IWarehouseService
    {
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly IMapper _mapper;
        public WarehouseService(IRepository<Warehouse> warehouseRepository,
            IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync(CancellationToken cancellationToken = default)
        {
            var warehouses = await _warehouseRepository.GetListAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
        }

        public async Task<WarehouseWithItemsDto> GetWarehouseAsync(int warehouseId, CancellationToken cancellationToken = default)
        {
            var spec = new WarehouseWithItemsProductSpecification(warehouseId);
            var warehouse = await _warehouseRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (warehouse == null)
            {
                throw new ItemNotFoundException(nameof(Warehouse));
            }

            return _mapper.Map<WarehouseWithItemsDto>(warehouse);
        }

        public async Task<WarehouseItemDto> AddProductToWarehouseAsync(int warehouseId, int productId, int quantity = 1, CancellationToken cancellationToken = default)
        {
            var warehouse = await GetWarehouseWithItemsAsync(warehouseId, cancellationToken);

            warehouse.AddItem(productId, quantity);
            warehouse.RemoveEmptyItems();

            _warehouseRepository.Update(warehouse);
            await _warehouseRepository.SaveChangesAsync(cancellationToken);

            var warehouseItem = warehouse.WarehouseItems.FirstOrDefault(s => s.ProductId == productId);
            return _mapper.Map<WarehouseItemDto>(warehouseItem);
        }

        public async Task<WarehouseItemDto> EditProductOfWarehouseAsync(int warehouseId, int productId, int quantity, CancellationToken cancellationToken = default)
        {
            var warehouse = await GetWarehouseWithItemsAsync(warehouseId, cancellationToken);

            warehouse.EditItem(productId, quantity);
            warehouse.RemoveEmptyItems();

            _warehouseRepository.Update(warehouse);
            await _warehouseRepository.SaveChangesAsync(cancellationToken);

            var warehouseItem = warehouse.WarehouseItems.FirstOrDefault(s => s.ProductId == productId);
            return _mapper.Map<WarehouseItemDto>(warehouseItem);
        }

        public async Task RemoveProductFromWarehouseAsync(int warehouseId, int productId, CancellationToken cancellationToken = default)
        {
            var warehouse = await GetWarehouseWithItemsAsync(warehouseId, cancellationToken);

            warehouse.RemoveItem(productId);

            _warehouseRepository.Update(warehouse);
            await _warehouseRepository.SaveChangesAsync(cancellationToken);
        }

        private async Task<Warehouse> GetWarehouseWithItemsAsync(int warehouseId, CancellationToken cancellationToken = default)
        {
            var spec = new WarehouseWithItemsSpecification(warehouseId);
            var warehouse = await _warehouseRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (warehouse == null)
            {
                throw new ItemNotFoundException(nameof(Warehouse));
            }

            return warehouse;
        }
    }
}
