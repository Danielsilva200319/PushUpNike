using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypeOrderConfiguration : IEntityTypeConfiguration<Typeorder>
    {
        public void Configure(EntityTypeBuilder<Typeorder> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typeorder");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.TypeOrder1)
                .HasMaxLength(50)
                .HasColumnName("TypeOrder");
        }
    }
}