using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("order");

            builder.HasIndex(e => e.IdClient, "idClient");

            builder.HasIndex(e => e.IdPayment, "idPayment");

            builder.HasIndex(e => e.IdProduct, "idProduct");

            builder.HasIndex(e => e.IdShipment, "idShipment");

            builder.HasIndex(e => e.IdStatus, "idStatus");

            builder.HasIndex(e => e.IdTypeOrder, "idTypeOrder");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdClient).HasColumnName("idClient");
            builder.Property(e => e.IdPayment).HasColumnName("idPayment");
            builder.Property(e => e.IdProduct).HasColumnName("idProduct");
            builder.Property(e => e.IdShipment).HasColumnName("idShipment");
            builder.Property(e => e.IdStatus).HasColumnName("idStatus");
            builder.Property(e => e.IdTypeOrder).HasColumnName("idTypeOrder");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("order_ibfk_1");

            builder.HasOne(d => d.IdPaymentNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPayment)
                .HasConstraintName("order_ibfk_4");

            builder.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("order_ibfk_6");

            builder.HasOne(d => d.IdShipmentNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdShipment)
                .HasConstraintName("order_ibfk_3");

            builder.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("order_ibfk_5");

            builder.HasOne(d => d.IdTypeOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdTypeOrder)
                .HasConstraintName("order_ibfk_2");
        }
    }
}