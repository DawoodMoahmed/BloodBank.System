using BloodBank.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
    public class MedicalTechniciansConfiguration : IEntityTypeConfiguration<MedicalTechnician>
    {
        public void Configure(EntityTypeBuilder<MedicalTechnician> builder)
        {
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(10);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(10);
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.Qualification).IsRequired().HasMaxLength(30);
            builder.Property(e => e.YearsOfExperience).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(30);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);


        }
    }
}
