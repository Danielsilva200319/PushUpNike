using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;

namespace Persistence.Data;

public partial class NikeContext : DbContext
{
    public NikeContext()
    {
    }

    public NikeContext(DbContextOptions<NikeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<County> Counties { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Postalcode> Postalcodes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Typeclient> Typeclients { get; set; }

    public virtual DbSet<Typeorder> Typeorders { get; set; }

    public virtual DbSet<Typepayment> Typepayments { get; set; }

    public virtual DbSet<Typeproduct> Typeproducts { get; set; }

    public virtual DbSet<Typeshipment> Typeshipments { get; set; }
    public virtual DbSet<Rol> Rols { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<UserRol> UserRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=campus2024;database=nike", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
