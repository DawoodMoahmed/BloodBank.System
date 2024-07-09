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
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions options): base(options)
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
        public DbSet<User> Users { get; set; } 
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalTechnician> MedicalTechnicians { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Donations> Donations { get; set; }

    }
}
