using App.Domain.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data.Config
{
    public class ProductConfiruration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
