using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("phone");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Phone1)
                .HasMaxLength(20)
                .HasColumnName("Phone");
            builder.Property(e => e.TypePhone).HasMaxLength(50);
        }
    }
}