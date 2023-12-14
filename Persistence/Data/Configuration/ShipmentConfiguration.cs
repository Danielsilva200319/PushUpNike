using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("shipment");

            builder.HasIndex(e => e.IdAddress, "idAddress");

            builder.HasIndex(e => e.IdStatus, "idStatus");

            builder.HasIndex(e => e.IdTypeShipment, "idTypeShipment");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdAddress).HasColumnName("idAddress");
            builder.Property(e => e.IdStatus).HasColumnName("idStatus");
            builder.Property(e => e.IdTypeShipment).HasColumnName("idTypeShipment");

            builder.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("shipment_ibfk_1");

            builder.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("shipment_ibfk_2");

            builder.HasOne(d => d.IdTypeShipmentNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdTypeShipment)
                .HasConstraintName("shipment_ibfk_3");
        }
    }
}