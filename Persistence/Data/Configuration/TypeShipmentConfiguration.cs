using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypeShipmentConfiguration : IEntityTypeConfiguration<Typeshipment>
    {
        public void Configure(EntityTypeBuilder<Typeshipment> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typeshipment");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.TypeShipment1)
                .HasMaxLength(50)
                .HasColumnName("TypeShipment");
        }
    }
}