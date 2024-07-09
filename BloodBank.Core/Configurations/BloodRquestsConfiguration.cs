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
    public class BloodRquestsConfiguration  : IEntityTypeConfiguration<BloodRquests>
    {
        public void Configure(EntityTypeBuilder<BloodRquests> builder)
        {
            builder.Property(e => e.PatientsId).IsRequired();
            builder.Property(e => e.ApplicationDate).IsRequired();
            builder.Property(e => e.BloodType).IsRequired().HasConversion<string>();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.HospitalId).IsRequired();
            builder.Property(e => e.IsReleased);


            builder.HasOne(i => i.Patients)
                .WithMany(i => i.BloodRquests)
                .HasForeignKey(i => i.PatientsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Hospital)
             .WithMany()
                .HasForeignKey(i => i.HospitalId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
