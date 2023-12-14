using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("address");

            builder.HasIndex(e => e.IdCity, "idCity");

            builder.HasIndex(e => e.IdPostalCode, "idPostalCode");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Address1)
                .HasMaxLength(255)
                .HasColumnName("Address");
            builder.Property(e => e.IdCity).HasColumnName("idCity");
            builder.Property(e => e.IdPostalCode).HasColumnName("idPostalCode");

            builder.HasOne(d => d.IdCityNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("address_ibfk_2");

            builder.HasOne(d => d.IdPostalCodeNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdPostalCode)
                .HasConstraintName("address_ibfk_1");
        }
    }
}