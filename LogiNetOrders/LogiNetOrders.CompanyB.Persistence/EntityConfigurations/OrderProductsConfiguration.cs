using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Persistence.EntityConfigurations;

public class OrderProductsConfiguration : IEntityTypeConfiguration<OrderProducts>
{
    public void Configure(EntityTypeBuilder<OrderProducts> builder)
    {
        builder.ToTable("OrderProducts");

        builder.Property(op => op.Amount).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(op => op.Order)
               .WithMany(o => o.OrderProducts)
               .HasForeignKey(op => op.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(op => op.Product)
               .WithMany()
               .HasForeignKey(op => op.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(op => op.ProductId).ValueGeneratedNever();
    }
}
