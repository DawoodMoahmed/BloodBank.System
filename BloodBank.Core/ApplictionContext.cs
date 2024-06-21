using BloodBank.Core.Configurations;
using BloodBank.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core
{
    public class ApplictionContext : DbContext
    {
        public ApplictionContext()
        {

        }
        public ApplictionContext(DbContextOptions options): base(options)
        {

        }

        const string DefaultConnection = "Server=.; Database=BloodBank; User=sa; Trusted_Connection=false; ConnectRetryCount=0;MultipleActiveResultSets=true ;Password=1111; Integrated security=false;";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DonorConfiguration());
          


        }

        public DbSet<Donor> Donors { get; set; }
    }
}
