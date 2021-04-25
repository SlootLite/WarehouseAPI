using App.Domain.Entities.ProductAggregate;
using App.Domain.Entities.WarehouseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data
{
    public class WarehouseContextSeed
    {
        public static async Task SeedAsync(WarehouseContext context,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!await context.Products.AnyAsync())
                {
                    await context.Products.AddRangeAsync(
                        GetProducts());

                    await context.SaveChangesAsync();
                }

                if (!await context.WarehouseItems.AnyAsync())
                {
                    await context.WarehouseItems.AddRangeAsync(
                        GetWarehouseItems());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<WarehouseContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<Product> GetProducts()
        {
            return new List<Product>() 
            {
                new ("Бритва"),
                new ("Сок"),
                new ("Шторы"),
                new ("Наушники")
            };
        }

        static IEnumerable<WarehouseItem> GetWarehouseItems()
        {
            return new List<WarehouseItem>()
            {
                new (1, 1, 5),
                new (1, 4, 2),
                new (2, 2, 1),
                new (2, 3, 6),
                new (3, 1, 3),
                new (3, 2, 2)
            };
        }
    }
}
