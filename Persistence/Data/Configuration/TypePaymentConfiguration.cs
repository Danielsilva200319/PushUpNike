using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypePaymentConfiguration : IEntityTypeConfiguration<Typepayment>
    {
        public void Configure(EntityTypeBuilder<Typepayment> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("typepayment");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.TypePayment1)
                .HasMaxLength(50)
                .HasColumnName("TypePayment");
        }
    }
}