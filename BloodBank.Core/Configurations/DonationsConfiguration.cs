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
    public class DonationsConfiguration : IEntityTypeConfiguration<Donations>
    {
        public void Configure(EntityTypeBuilder<Donations> builder)
        {
            builder.Property(e => e.DonorID).IsRequired();
            builder.Property(e => e.BloodID).IsRequired();
            builder.Property(e => e.DonationDate).IsRequired();
            builder.Property(e => e.MedicalTechniciansID).IsRequired();
        }
    }
}
