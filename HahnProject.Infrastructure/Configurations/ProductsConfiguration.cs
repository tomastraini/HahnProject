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
    partial class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> entity)
        {
            entity.HasKey(e => e.id)
                .HasName("PK__products__3213E83FB75CE54D");

            entity.ToTable("products");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.description).HasColumnName("description");

            entity.Property(e => e.price)
                .HasColumnName("price");

            entity.Property(e => e.stock)
            .HasColumnName("stock");

            entity.Property(e => e.supplier_id)
            .HasColumnName("supplier_id");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Products> entity);
    }
}
