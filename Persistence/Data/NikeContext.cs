using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=campus2024;database=nike", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.IdCity, "idCity");

            entity.HasIndex(e => e.IdPostalCode, "idPostalCode");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .HasColumnName("Address");
            entity.Property(e => e.IdCity).HasColumnName("idCity");
            entity.Property(e => e.IdPostalCode).HasColumnName("idPostalCode");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("address_ibfk_2");

            entity.HasOne(d => d.IdPostalCodeNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdPostalCode)
                .HasConstraintName("address_ibfk_1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .HasColumnName("Category");
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.IdDepartment, "idDepartment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdDepartment).HasColumnName("idDepartment");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("city_ibfk_1");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.IdAddress, "idAddress");

            entity.HasIndex(e => e.IdCity, "idCity");

            entity.HasIndex(e => e.IdDiscount, "idDiscount");

            entity.HasIndex(e => e.IdPhone, "idPhone");

            entity.HasIndex(e => e.IdTypeClient, "idTypeClient");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.IdCity).HasColumnName("idCity");
            entity.Property(e => e.IdDiscount).HasColumnName("idDiscount");
            entity.Property(e => e.IdPhone).HasColumnName("idPhone");
            entity.Property(e => e.IdTypeClient).HasColumnName("idTypeClient");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("client_ibfk_2");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("client_ibfk_1");

            entity.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdDiscount)
                .HasConstraintName("client_ibfk_5");

            entity.HasOne(d => d.IdPhoneNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdPhone)
                .HasConstraintName("client_ibfk_3");

            entity.HasOne(d => d.IdTypeClientNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdTypeClient)
                .HasConstraintName("client_ibfk_4");
        });

        modelBuilder.Entity<County>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("county");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.IdCountry, "idCountry");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("department_ibfk_1");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("discount");

            entity.HasIndex(e => e.IdStatus, "idStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Discount1)
                .HasMaxLength(50)
                .HasColumnName("Discount");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.Percentage).HasColumnType("double(5,2)");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("discount_ibfk_1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdAddress, "idAddress");

            entity.HasIndex(e => e.IdCity, "idCity");

            entity.HasIndex(e => e.IdPhone, "idPhone");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.IdCity).HasColumnName("idCity");
            entity.Property(e => e.IdPhone).HasColumnName("idPhone");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(80);

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("employee_ibfk_1");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("employee_ibfk_3");

            entity.HasOne(d => d.IdPhoneNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPhone)
                .HasConstraintName("employee_ibfk_2");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.IdClient, "idClient");

            entity.HasIndex(e => e.IdPayment, "idPayment");

            entity.HasIndex(e => e.IdProduct, "idProduct");

            entity.HasIndex(e => e.IdShipment, "idShipment");

            entity.HasIndex(e => e.IdStatus, "idStatus");

            entity.HasIndex(e => e.IdTypeOrder, "idTypeOrder");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.IdPayment).HasColumnName("idPayment");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdShipment).HasColumnName("idShipment");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.IdTypeOrder).HasColumnName("idTypeOrder");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("order_ibfk_1");

            entity.HasOne(d => d.IdPaymentNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPayment)
                .HasConstraintName("order_ibfk_4");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("order_ibfk_6");

            entity.HasOne(d => d.IdShipmentNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdShipment)
                .HasConstraintName("order_ibfk_3");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("order_ibfk_5");

            entity.HasOne(d => d.IdTypeOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdTypeOrder)
                .HasConstraintName("order_ibfk_2");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.HasIndex(e => e.IdClient, "idClient");

            entity.HasIndex(e => e.IdStatus, "idStatus");

            entity.HasIndex(e => e.IdTypePayment, "idTypePayment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.IdTypePayment).HasColumnName("idTypePayment");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("payment_ibfk_1");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("payment_ibfk_3");

            entity.HasOne(d => d.IdTypePaymentNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdTypePayment)
                .HasConstraintName("payment_ibfk_2");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("phone");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Phone1)
                .HasMaxLength(20)
                .HasColumnName("Phone");
            entity.Property(e => e.TypePhone).HasMaxLength(50);
        });

        modelBuilder.Entity<Postalcode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("postalcode");

            entity.HasIndex(e => e.IdCity, "idCity");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCity).HasColumnName("idCity");
            entity.Property(e => e.PostalCode1)
                .HasMaxLength(20)
                .HasColumnName("PostalCode");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Postalcodes)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("postalcode_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdCategory, "idCategory");

            entity.HasIndex(e => e.IdTypeProduct, "idTypeProduct");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdTypeProduct).HasColumnName("idTypeProduct");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("product_ibfk_2");

            entity.HasOne(d => d.IdTypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeProduct)
                .HasConstraintName("product_ibfk_1");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shipment");

            entity.HasIndex(e => e.IdAddress, "idAddress");

            entity.HasIndex(e => e.IdStatus, "idStatus");

            entity.HasIndex(e => e.IdTypeShipment, "idTypeShipment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.IdTypeShipment).HasColumnName("idTypeShipment");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("shipment_ibfk_1");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("shipment_ibfk_2");

            entity.HasOne(d => d.IdTypeShipmentNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdTypeShipment)
                .HasConstraintName("shipment_ibfk_3");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EntityName).HasMaxLength(20);
            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<Typeclient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeclient");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeClient1)
                .HasMaxLength(20)
                .HasColumnName("TypeClient");
        });

        modelBuilder.Entity<Typeorder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeorder");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeOrder1)
                .HasMaxLength(50)
                .HasColumnName("TypeOrder");
        });

        modelBuilder.Entity<Typepayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typepayment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypePayment1)
                .HasMaxLength(50)
                .HasColumnName("TypePayment");
        });

        modelBuilder.Entity<Typeproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeproduct");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.TypeProduct1)
                .HasMaxLength(50)
                .HasColumnName("TypeProduct");
        });

        modelBuilder.Entity<Typeshipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeshipment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeShipment1)
                .HasMaxLength(50)
                .HasColumnName("TypeShipment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
