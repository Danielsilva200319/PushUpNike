using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypeProductConfiguration : IEntityTypeConfiguration<Typeproduct>
    {
        public void Configure(EntityTypeBuilder<Typeproduct> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typeproduct");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Description).HasMaxLength(255);
            builder.Property(e => e.TypeProduct1)
                .HasMaxLength(50)
                .HasColumnName("TypeProduct");
        }
    }
}