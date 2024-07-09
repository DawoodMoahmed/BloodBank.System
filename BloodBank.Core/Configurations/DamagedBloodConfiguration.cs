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
    public class DamagedBloodConfiguration  : IEntityTypeConfiguration<DamagedBlood> 
    {
        public void Configure(EntityTypeBuilder<DamagedBlood> builder)
        {
            builder.Property(e => e.BloodID).IsRequired();
            builder.Property(e => e.MedicalTechniciansID).IsRequired();
            builder.Property(e => e.TheReason).IsRequired();
            builder.Property(e => e.DateOfDestruction).IsRequired();
        }
    }
}
