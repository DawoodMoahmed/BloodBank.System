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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FristName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(225);
            builder.Property(e => e.PassWord).IsRequired().HasMaxLength(8);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);
        }
    }
  
}
