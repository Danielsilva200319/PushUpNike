using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("product");

            builder.HasIndex(e => e.IdCategory, "idCategory");

            builder.HasIndex(e => e.IdTypeProduct, "idTypeProduct");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Description).HasMaxLength(255);
            builder.Property(e => e.IdCategory).HasColumnName("idCategory");
            builder.Property(e => e.IdTypeProduct).HasColumnName("idTypeProduct");
            builder.Property(e => e.Name).HasMaxLength(255);

            builder.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("product_ibfk_2");

            builder.HasOne(d => d.IdTypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeProduct)
                .HasConstraintName("product_ibfk_1");
        }
    }
}