using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineStore.MultiTenant.Api.Migrations
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    WeightInKg = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "OrderItemId", "OrderId", "Price", "ProductId", "Quantity", "WeightInKg" },
                values: new object[,]
                {
                    { new Guid("29253941-e6c1-41ce-8d96-cd487f7f174c"), null, 80.0m, new Guid("396be858-4b5b-4ccd-9bbd-8f7328b9390c"), 1, 1.0m },
                    { new Guid("3adad5f7-fdc6-402b-8f5e-d417420aebb4"), null, 120.0m, new Guid("a7be5fd1-0bef-4d62-886d-29dfab419d83"), 1, 3.5m },
                    { new Guid("62090a64-1b6b-4502-8fa2-25a822ff23cb"), null, 45.0m, new Guid("0c5ecb09-5da9-443a-b155-be0465c8202a"), 2, 0.5m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreationDate", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("01edb615-6d07-4a24-9016-12412271dd04"), new DateTime(2024, 3, 20, 0, 10, 49, 722, DateTimeKind.Local).AddTicks(4984), new Guid("c52ae0d7-e8ab-4ff8-a0e7-6634895001e1") },
                    { new Guid("96cc899a-519e-4eaa-ac95-2eb6f8b2949c"), new DateTime(2024, 3, 20, 0, 10, 49, 722, DateTimeKind.Local).AddTicks(4936), new Guid("019fc834-c3d7-4a57-ba91-97f7b63363c5") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5d302965-7a19-454a-97cc-6671faed4891"), "A stylish wooden desk lamp for your workspace.", "Wooden Desk Lamp", 80.0m },
                    { new Guid("adec8f41-95c3-4edf-af79-ebe2db93157e"), "A vintage typewriter for the nostalgic writer.", "Vintage Typewriter", 120.0m },
                    { new Guid("f1294e07-26be-44e1-8198-80713150e390"), "A handcrafted leather notebook for your thoughts.", "Leather Notebook", 45.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
