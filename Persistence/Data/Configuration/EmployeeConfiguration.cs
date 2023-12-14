using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("employee");

            builder.HasIndex(e => e.IdAddress, "idAddress");

            builder.HasIndex(e => e.IdCity, "idCity");

            builder.HasIndex(e => e.IdPhone, "idPhone");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Department).HasMaxLength(50);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.IdAddress).HasColumnName("idAddress");
            builder.Property(e => e.IdCity).HasColumnName("idCity");
            builder.Property(e => e.IdPhone).HasColumnName("idPhone");
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Position).HasMaxLength(80);

            builder.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("employee_ibfk_1");

            builder.HasOne(d => d.IdCityNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("employee_ibfk_3");

            builder.HasOne(d => d.IdPhoneNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPhone)
                .HasConstraintName("employee_ibfk_2");
        }
    }
}