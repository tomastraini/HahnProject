using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HahnProject.Infrastructure.PlainModels;

namespace HahnProject.Infrastructure.Configurations
{
    partial class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> entity)
        {
            entity.HasKey(e => e.id)
                .HasName("PK__person_t__3213E83F45214A7E");

            entity.ToTable("person_type");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.type)
            .HasColumnName("type");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PersonType> entity);
    }
}
