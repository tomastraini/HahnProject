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
    partial class SubTransactionsConfiguration : IEntityTypeConfiguration<SubTransactions>
    {
        public void Configure(EntityTypeBuilder<SubTransactions> entity)
        {
            entity.HasKey(e => e.id)
                .HasName("PK__sub_tran__3213E83FFABD8F9F");

            entity.ToTable("sub_transactions");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.transaction_id).HasColumnName("transaction_id");

            entity.Property(e => e.product_id)
                .HasColumnName("product_id");

            entity.Property(e => e.amount)
            .HasColumnName("amount");

            entity.Property(e => e.total)
            .HasColumnName("total");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<SubTransactions> entity);
    }
}
