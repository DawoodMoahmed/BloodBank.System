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
      public class TestConfiguration : IEntityTypeConfiguration<Test>   
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(e => e.TestName).IsRequired().HasMaxLength(225);
            builder.Property(e => e.ExaminationOfDate).IsRequired();
            builder.Property(e => e.Condition).IsRequired();
        }

     
    }
}
