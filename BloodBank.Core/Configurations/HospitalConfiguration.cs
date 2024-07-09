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
   public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.Property(e => e.HospitalName).IsRequired().HasMaxLength(225);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(225);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10); 
        }
    }
}
