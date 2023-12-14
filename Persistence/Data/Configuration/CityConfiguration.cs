using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("city");

            builder.HasIndex(e => e.IdDepartment, "idDepartment");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdDepartment).HasColumnName("idDepartment");
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("city_ibfk_1");
        }
    }
}