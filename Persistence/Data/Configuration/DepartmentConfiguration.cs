using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("department");

            builder.HasIndex(e => e.IdCountry, "idCountry");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdCountry).HasColumnName("idCountry");
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("department_ibfk_1");
        }
    }
}