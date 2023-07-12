using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyEFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class ChangeId_ForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTB_API",
                schema: "products_api",
                table: "ProductTB_API");

            migrationBuilder.EnsureSchema(
                name: "products");

            migrationBuilder.RenameTable(
                name: "ProductTB_API",
                schema: "products_api",
                newName: "ProductTb",
                newSchema: "products");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "products",
                table: "ProductTb",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name2",
                schema: "products",
                table: "ProductTb",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "products",
                table: "ProductTb",
                newName: "Product_Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "products",
                table: "ProductTb",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "products",
                table: "ProductTb",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Product_Id",
                schema: "products",
                table: "ProductTb",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTb",
                schema: "products",
                table: "ProductTb",
                column: "Product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTb",
                schema: "products",
                table: "ProductTb");

            migrationBuilder.EnsureSchema(
                name: "products_api");

            migrationBuilder.RenameTable(
                name: "ProductTb",
                schema: "products",
                newName: "ProductTB_API",
                newSchema: "products_api");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "products_api",
                table: "ProductTB_API",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "products_api",
                table: "ProductTB_API",
                newName: "name2");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                schema: "products_api",
                table: "ProductTB_API",
                newName: "id");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                schema: "products_api",
                table: "ProductTB_API",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "name2",
                schema: "products_api",
                table: "ProductTB_API",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "products_api",
                table: "ProductTB_API",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTB_API",
                schema: "products_api",
                table: "ProductTB_API",
                column: "id");
        }
    }
}
