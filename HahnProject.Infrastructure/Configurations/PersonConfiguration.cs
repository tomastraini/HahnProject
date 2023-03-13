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
    partial class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.HasKey(e => e.id)
                .HasName("PK__person__3213E83FC6905740");

            entity.ToTable("person");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.business_name).HasColumnName("business_name");

            entity.Property(e => e.balance)
                .HasColumnName("balance");

            entity.Property(e => e.creation_date)
            .HasColumnName("creation_date");

            entity.Property(e => e.person_type)
            .HasColumnName("person_type");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Person> entity);
    }
}
