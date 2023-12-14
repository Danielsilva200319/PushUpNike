using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("discount");

            builder.HasIndex(e => e.IdStatus, "idStatus");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Description).HasMaxLength(255);
            builder.Property(e => e.Discount1)
                .HasMaxLength(50)
                .HasColumnName("Discount");
            builder.Property(e => e.IdStatus).HasColumnName("idStatus");
            builder.Property(e => e.Percentage).HasColumnType("double(5,2)");

            builder.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("discount_ibfk_1");
        }
    }
}