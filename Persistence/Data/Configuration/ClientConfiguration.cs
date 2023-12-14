using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("client");

            builder.HasIndex(e => e.IdAddress, "idAddress");

            builder.HasIndex(e => e.IdCity, "idCity");

            builder.HasIndex(e => e.IdDiscount, "idDiscount");

            builder.HasIndex(e => e.IdPhone, "idPhone");

            builder.HasIndex(e => e.IdTypeClient, "idTypeClient");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Comment).HasMaxLength(255);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Gender).HasMaxLength(20);
            builder.Property(e => e.IdAddress).HasColumnName("idAddress");
            builder.Property(e => e.IdCity).HasColumnName("idCity");
            builder.Property(e => e.IdDiscount).HasColumnName("idDiscount");
            builder.Property(e => e.IdPhone).HasColumnName("idPhone");
            builder.Property(e => e.IdTypeClient).HasColumnName("idTypeClient");
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("client_ibfk_2");

            builder.HasOne(d => d.IdCityNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("client_ibfk_1");

            builder.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdDiscount)
                .HasConstraintName("client_ibfk_5");

            builder.HasOne(d => d.IdPhoneNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdPhone)
                .HasConstraintName("client_ibfk_3");

            builder.HasOne(d => d.IdTypeClientNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdTypeClient)
                .HasConstraintName("client_ibfk_4");
        }
    }
}