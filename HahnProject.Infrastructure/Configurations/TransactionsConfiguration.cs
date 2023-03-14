using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HahnProject.Infrastructure.PlainModels;

namespace HahnProject.Infrastructure.Configurations
{
    partial class TransactionsConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> entity)
        {
            entity.HasKey(e => e.id)
                .HasName("PK__transact__3213E83FE6287CED");

            entity.ToTable("transactions");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.person).HasColumnName("person");

            entity.Property(e => e.transaction_began)
                .HasColumnName("transaction_began");

            entity.Property(e => e.total)
            .HasColumnName("total");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Transactions> entity);
    }
}
