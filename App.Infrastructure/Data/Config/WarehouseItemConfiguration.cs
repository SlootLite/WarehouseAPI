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
    public class WarehouseItemConfiguration : IEntityTypeConfiguration<WarehouseItem>
    {
        public void Configure(EntityTypeBuilder<WarehouseItem> builder)
        {
            builder.Property(s => s.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(s => s.Quantity)
                .IsRequired();
        }
    }
}
