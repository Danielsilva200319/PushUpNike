using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "county",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypePhone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    EntityName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typeclient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    TypeClient = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typeorder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    TypeOrder = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typepayment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    TypePayment = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typeproduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    TypeProduct = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typeshipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    TypeShipment = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCountry = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "department_ibfk_1",
                        column: x => x.idCountry,
                        principalTable: "county",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Percentage = table.Column<double>(type: "double(5,2)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    idStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "discount_ibfk_1",
                        column: x => x.idStatus,
                        principalTable: "status",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: true),
                    idTypeProduct = table.Column<int>(type: "int", nullable: true),
                    idCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "product_ibfk_1",
                        column: x => x.idTypeProduct,
                        principalTable: "typeproduct",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "product_ibfk_2",
                        column: x => x.idCategory,
                        principalTable: "category",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUserFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshToken_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userrol",
                columns: table => new
                {
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrol", x => new { x.IdUserFk, x.IdRolFk });
                    table.ForeignKey(
                        name: "FK_userrol_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userrol_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idDepartment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "city_ibfk_1",
                        column: x => x.idDepartment,
                        principalTable: "department",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "postalcode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "postalcode_ibfk_1",
                        column: x => x.idCity,
                        principalTable: "city",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idPostalCode = table.Column<int>(type: "int", nullable: true),
                    idCity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "address_ibfk_1",
                        column: x => x.idPostalCode,
                        principalTable: "postalcode",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "address_ibfk_2",
                        column: x => x.idCity,
                        principalTable: "city",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idAddress = table.Column<int>(type: "int", nullable: true),
                    idPhone = table.Column<int>(type: "int", nullable: true),
                    idCity = table.Column<int>(type: "int", nullable: true),
                    idDiscount = table.Column<int>(type: "int", nullable: true),
                    idTypeClient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "client_ibfk_1",
                        column: x => x.idCity,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "client_ibfk_2",
                        column: x => x.idAddress,
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "client_ibfk_3",
                        column: x => x.idPhone,
                        principalTable: "phone",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "client_ibfk_4",
                        column: x => x.idTypeClient,
                        principalTable: "typeclient",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "client_ibfk_5",
                        column: x => x.idDiscount,
                        principalTable: "discount",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Department = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idAddress = table.Column<int>(type: "int", nullable: true),
                    idPhone = table.Column<int>(type: "int", nullable: true),
                    idCity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "employee_ibfk_1",
                        column: x => x.idAddress,
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "employee_ibfk_2",
                        column: x => x.idPhone,
                        principalTable: "phone",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "employee_ibfk_3",
                        column: x => x.idCity,
                        principalTable: "city",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ShipmentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EstimatedArrival = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualArrival = table.Column<DateOnly>(type: "date", nullable: true),
                    idAddress = table.Column<int>(type: "int", nullable: true),
                    idStatus = table.Column<int>(type: "int", nullable: true),
                    idTypeShipment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "shipment_ibfk_1",
                        column: x => x.idAddress,
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "shipment_ibfk_2",
                        column: x => x.idStatus,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "shipment_ibfk_3",
                        column: x => x.idTypeShipment,
                        principalTable: "typeshipment",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    idClient = table.Column<int>(type: "int", nullable: true),
                    idTypePayment = table.Column<int>(type: "int", nullable: true),
                    idStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "payment_ibfk_1",
                        column: x => x.idClient,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "payment_ibfk_2",
                        column: x => x.idTypePayment,
                        principalTable: "typepayment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "payment_ibfk_3",
                        column: x => x.idStatus,
                        principalTable: "status",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: true),
                    idClient = table.Column<int>(type: "int", nullable: true),
                    idTypeOrder = table.Column<int>(type: "int", nullable: true),
                    idShipment = table.Column<int>(type: "int", nullable: true),
                    idPayment = table.Column<int>(type: "int", nullable: true),
                    idStatus = table.Column<int>(type: "int", nullable: true),
                    idProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "order_ibfk_1",
                        column: x => x.idClient,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_ibfk_2",
                        column: x => x.idTypeOrder,
                        principalTable: "typeorder",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_ibfk_3",
                        column: x => x.idShipment,
                        principalTable: "shipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_ibfk_4",
                        column: x => x.idPayment,
                        principalTable: "payment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_ibfk_5",
                        column: x => x.idStatus,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_ibfk_6",
                        column: x => x.idProduct,
                        principalTable: "product",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idCity",
                table: "address",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "idPostalCode",
                table: "address",
                column: "idPostalCode");

            migrationBuilder.CreateIndex(
                name: "idDepartment",
                table: "city",
                column: "idDepartment");

            migrationBuilder.CreateIndex(
                name: "idAddress",
                table: "client",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "idCity1",
                table: "client",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "idDiscount",
                table: "client",
                column: "idDiscount");

            migrationBuilder.CreateIndex(
                name: "idPhone",
                table: "client",
                column: "idPhone");

            migrationBuilder.CreateIndex(
                name: "idTypeClient",
                table: "client",
                column: "idTypeClient");

            migrationBuilder.CreateIndex(
                name: "idCountry",
                table: "department",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "idStatus",
                table: "discount",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "idAddress1",
                table: "employee",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "idCity2",
                table: "employee",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "idPhone1",
                table: "employee",
                column: "idPhone");

            migrationBuilder.CreateIndex(
                name: "idClient",
                table: "order",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "idPayment",
                table: "order",
                column: "idPayment");

            migrationBuilder.CreateIndex(
                name: "idProduct",
                table: "order",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "idShipment",
                table: "order",
                column: "idShipment");

            migrationBuilder.CreateIndex(
                name: "idStatus1",
                table: "order",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "idTypeOrder",
                table: "order",
                column: "idTypeOrder");

            migrationBuilder.CreateIndex(
                name: "idClient1",
                table: "payment",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "idStatus2",
                table: "payment",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "idTypePayment",
                table: "payment",
                column: "idTypePayment");

            migrationBuilder.CreateIndex(
                name: "idCity3",
                table: "postalcode",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "idCategory",
                table: "product",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "idTypeProduct",
                table: "product",
                column: "idTypeProduct");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_IdUserFk",
                table: "refreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "idAddress2",
                table: "shipment",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "idStatus3",
                table: "shipment",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "idTypeShipment",
                table: "shipment",
                column: "idTypeShipment");

            migrationBuilder.CreateIndex(
                name: "IX_userrol_IdRolFk",
                table: "userrol",
                column: "IdRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropTable(
                name: "userrol");

            migrationBuilder.DropTable(
                name: "typeorder");

            migrationBuilder.DropTable(
                name: "shipment");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "typeshipment");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "typepayment");

            migrationBuilder.DropTable(
                name: "typeproduct");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "phone");

            migrationBuilder.DropTable(
                name: "typeclient");

            migrationBuilder.DropTable(
                name: "discount");

            migrationBuilder.DropTable(
                name: "postalcode");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "county");
        }
    }
}
