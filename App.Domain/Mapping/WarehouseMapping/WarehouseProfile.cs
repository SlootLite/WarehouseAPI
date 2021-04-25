using App.Domain.Entities.WarehouseAggregate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Mapping.WarehouseMapping
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<Warehouse, WarehouseWithItemsDto>();
            CreateMap<WarehouseItem, WarehouseItemDto>();
        }
    }
}
