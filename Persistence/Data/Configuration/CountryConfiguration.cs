using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("county");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}