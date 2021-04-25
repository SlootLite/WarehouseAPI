using App.Domain.Interfaces.Data;
using App.Domain.Interfaces.DomainServices;
using App.Domain.Services;
using App.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IWarehouseItemService, WarehouseItemService>();
            return services;
        }
    }
}
