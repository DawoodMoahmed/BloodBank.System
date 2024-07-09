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
    
    public class TestResultsConfiguration : IEntityTypeConfiguration<TestResults>
    {
        public void Configure(EntityTypeBuilder<TestResults> builder)
        {
            builder.Property(e => e.TestID).IsRequired(); 
        }
    }
}
