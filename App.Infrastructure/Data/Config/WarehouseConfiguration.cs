using App.Domain.Entities.WarehouseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data.Config
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.Property(s => s.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasData(
                new { Id = 1, Name = "Склад 1" },
                new { Id = 2, Name = "Склад 2" },
                new { Id = 3, Name = "Склад 3" },
                new { Id = 4, Name = "Склад 4" },
                new { Id = 5, Name = "Склад 5" },
                new { Id = 6, Name = "Склад 6" },
                new { Id = 7, Name = "Склад 7" },
                new { Id = 8, Name = "Склад 8" },
                new { Id = 9, Name = "Склад 9" },
                new { Id = 10, Name = "Склад 10" }
                );
        }
    }
}
