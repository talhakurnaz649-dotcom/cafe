using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProductsAndNullableAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerAddress",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 8, "Kahve", "Espresso ile ince dokulu kadifemsi sıcak sütün mükemmel buluşması.", "https://images.unsplash.com/photo-1577968897966-3d4325b36b61?q=80&w=300", true, "Flat White", 95.00m },
                    { 9, "Kahve", "Zengin espresso, çikolata sosu, sıcak süt ve krema şöleni.", "https://images.unsplash.com/photo-1534778101976-62847782c213?q=80&w=300", true, "Caffe Mocha", 105.00m },
                    { 10, "Kahve", "18 saat boyunca soğuk suda demlenmiş, yumuşak içimli soğuk filtre kahve.", "https://images.unsplash.com/photo-1517701604599-bb29b565090c?q=80&w=300", true, "Cold Brew", 90.00m },
                    { 11, "Tatlı", "İçi ıslak, bol çikolatalı ve ceviz parçacıklı leziz brownie dilimi.", "https://images.unsplash.com/photo-1564355808539-22fda35bed7e?q=80&w=300", true, "Çikolatalı Brownie", 95.00m },
                    { 12, "Tatlı", "Ceviz, havuç ve tarçın eşliğinde ev yapımı kıvamında leziz kek dilimi.", "https://images.unsplash.com/photo-1607958996333-41aef7caefaa?q=80&w=300", true, "Havuçlu Tarçınlı Kek", 85.00m },
                    { 13, "Tatlı", "Karamelize elma dolgusu ve tereyağlı çıtır hamuruyla servis edilen dilim tart.", "https://images.unsplash.com/photo-1508737027454-e6454ef45afd?q=80&w=300", true, "Elmalı Tart", 90.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerAddress",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
