using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypeClientConfiguration : IEntityTypeConfiguration<Typeclient>
    {
        public void Configure(EntityTypeBuilder<Typeclient> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typeclient");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.TypeClient1)
                .HasMaxLength(20)
                .HasColumnName("TypeClient");
        }
    }
}