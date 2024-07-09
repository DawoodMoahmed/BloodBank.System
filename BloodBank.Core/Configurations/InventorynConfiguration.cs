using BloodBank.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Configurations
{
    class InventorynConfiguration : IEntityTypeConfiguration<Inventoryn>
    {
        public void Configure(EntityTypeBuilder<Inventoryn> builder)
        {
            builder.Property(e => e.BloodType).IsRequired();
            builder.Property(e => e.WithdrawalDate).IsRequired();
            builder.Property(e => e.ExpiryDate).IsRequired();

        }
    }
}
