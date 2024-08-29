using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Persistence.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
           
            builder.HasOne(o => o.Consignee)
                   .WithMany()
                   .HasForeignKey(o => o.PersonId)
                   .OnDelete(DeleteBehavior.Restrict);

          
        }
    }
}
