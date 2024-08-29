using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Persistence.EntityConfigurations;

public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("Deliveries");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.DeliveryDate).IsRequired();

        builder.HasOne(d => d.DeliveryPerson)
               .WithMany()
               .HasForeignKey(d => d.DeliveryPersonId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Orders>()
       .WithMany() // Delivery'den Orders'a Many-to-One ilişki
       .HasForeignKey(d => d.OrderId)
       .OnDelete(DeleteBehavior.Restrict);
    }
}
