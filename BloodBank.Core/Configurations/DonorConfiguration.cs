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
    public class DonorConfiguration :  IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(255);
            builder.Property(e => e.BloodType).IsRequired().HasMaxLength(4); 
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.Property(e => e.LastDonationDate).IsRequired(); 
        }
    }
}
