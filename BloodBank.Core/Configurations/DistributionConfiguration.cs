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
   public class DistributionConfiguration : IEntityTypeConfiguration<Distribution>
    {
        public void Configure(EntityTypeBuilder<Distribution> builder)
        {
            builder.Property(e => e.BloodID).IsRequired();
            builder.Property(e => e.MedicalTechniciansID).IsRequired();
            builder.Property(e => e.HospitalID).IsRequired();
            builder.Property(e => e.DistributionDate).IsRequired();
            builder.Property(e => e.Condition).IsRequired().HasMaxLength(225);
        }
    }

}
