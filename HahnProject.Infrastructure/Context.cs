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
        public DbSet<Products> products { get; set; }
        public DbSet<Transactions> transactions { get; set; }
        public DbSet<SubTransactions> subtransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionsConfiguration());
            modelBuilder.ApplyConfiguration(new SubTransactionsConfiguration());


            modelBuilder.Entity<Person>()
                .HasOne(x => x.PersonType)
                .WithMany(x => x.people)
                .HasForeignKey(p => p.person_type);

            modelBuilder.Entity<Products>()
                .HasOne(x => x.supplier)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.supplier_id);

            modelBuilder.Entity<SubTransactions>()
                .HasOne(x => x.Transactions)
                .WithMany(x => x.SubTransactions)
                .HasForeignKey(x => x.transaction_id);

            modelBuilder.Entity<SubTransactions>(entry =>
            {
                entry.ToTable("sub_transactions", tb => tb.HasTrigger("updatetotal"));
            });

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
