using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Kahve", "Yoğun kıvamlı ve zengin aromalı klasik İtalyan espressosu.", "https://images.unsplash.com/photo-1510972527921-ce03766a1cf1?q=80&w=300", true, "Espresso", 70.00m },
                    { 2, "Kahve", "Espresso, buharla ısıtılmış süt ve üzerinde hafif süt köpüğü.", "https://images.unsplash.com/photo-1570968915860-54d5c301fc9f?q=80&w=300", true, "Caffe Latte", 90.00m },
                    { 3, "Kahve", "Sıcak su ile yumuşatılmış zengin Espresso lezzeti.", "https://images.unsplash.com/photo-1551046713-bc755f487116?q=80&w=300", true, "Americano", 80.00m },
                    { 4, "Kahve", "Geleneksel yöntemlerle cezvede pişirilmiş, bol köpüklü klasik Türk kahvesi.", "https://images.unsplash.com/photo-1514432324607-a09d9b4aefdd?q=80&w=300", true, "Türk Kahvesi", 65.00m },
                    { 5, "Tatlı", "İçi yumuşacık ve akışkan, üzeri karamelize yanık İspanyol cheesecake'i.", "https://images.unsplash.com/photo-1524351199679-46cddf530c04?q=80&w=300", true, "San Sebastian Cheesecake", 140.00m },
                    { 6, "Tatlı", "Sıcak servis edilen, içi akışkan çikolatalı nefis sufle.", "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?q=80&w=300", true, "Çikolatalı Sufle", 110.00m },
                    { 7, "Tatlı", "Espresso ile ıslatılmış savoyer bisküvileri ve mascarpone kremasıyla hazırlanan orijinal İtalyan tiramisusu.", "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?q=80&w=300", true, "Tiramisu", 120.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
