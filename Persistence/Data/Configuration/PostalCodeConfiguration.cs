using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PostalCodeConfiguration : IEntityTypeConfiguration<Postalcode>
    {
        public void Configure(EntityTypeBuilder<Postalcode> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("postalcode");

            builder.HasIndex(e => e.IdCity, "idCity");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdCity).HasColumnName("idCity");
            builder.Property(e => e.PostalCode1)
                .HasMaxLength(20)
                .HasColumnName("PostalCode");

            builder.HasOne(d => d.IdCityNavigation).WithMany(p => p.Postalcodes)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("postalcode_ibfk_1");
        }
    }
}