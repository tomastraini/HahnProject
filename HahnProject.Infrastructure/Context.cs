using HahnProject.Infrastructure.Configurations;
using HahnProject.Infrastructure.PlainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        public DbSet<Person> person { get; set; }
        public DbSet<PersonType> persontype { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());

            modelBuilder.Entity<Person>()
                .HasOne(x => x.PersonType)
                .WithMany(x => x.people)
                .HasForeignKey(p => p.person_type);


            OnModelCreatingPartial(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer("Data Source=host.docker.internal;Initial Catalog=HahnWarehouse;User ID=sa;Password=123;TrustServerCertificate=true");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
