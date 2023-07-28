using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyEFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class NamePriceBarcode_IncludedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name")
                .Annotation("SqlServer:Include", new[] { "Price", "Stock", "Barcode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }
    }
}
