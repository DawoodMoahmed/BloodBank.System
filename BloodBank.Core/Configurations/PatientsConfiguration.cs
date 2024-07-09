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
   public class PatientsConfiguration : IEntityTypeConfiguration<Patient> 
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.BloodType).IsRequired();
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);
           

        } 
    }
}
