using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("payment");

            builder.HasIndex(e => e.IdClient, "idClient");

            builder.HasIndex(e => e.IdStatus, "idStatus");

            builder.HasIndex(e => e.IdTypePayment, "idTypePayment");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdClient).HasColumnName("idClient");
            builder.Property(e => e.IdStatus).HasColumnName("idStatus");
            builder.Property(e => e.IdTypePayment).HasColumnName("idTypePayment");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("payment_ibfk_1");

            builder.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("payment_ibfk_3");

            builder.HasOne(d => d.IdTypePaymentNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdTypePayment)
                .HasConstraintName("payment_ibfk_2");
        }
    }
}