using HahnProject.Infrastructure.Configurations;
using HahnProject.Infrastructure.PlainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HahnProject.Infrastructure
{
    public partial class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public IConfigurationRoot Configuration { get; }
        public Context()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
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
            options.UseSqlServer(Configuration.GetConnectionString("local"));
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
