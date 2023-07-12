using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyEFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppDbContext_MaxLengthIsFixedLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "products",
                table: "ProductTb",
                type: "nchar(100)", // Nchar daki "n" harfi unique olmasını sağlıyor.Farklı karakterde değerler tutabilir anlamına geliyor.
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)", // buradaki var ifadesi ise ilgili sütunun belli bir uzunlukta olup olmayacağına karar verir.
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "products",
                table: "ProductTb",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);
        }
    }
}
