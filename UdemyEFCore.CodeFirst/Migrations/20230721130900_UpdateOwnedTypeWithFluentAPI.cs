using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyEFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOwnedTypeWithFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person_LastName",
                table: "Managers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Person_FirstName",
                table: "Managers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Person_Age",
                table: "Managers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Person_LastName",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Person_FirstName",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Person_Age",
                table: "Employees",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Managers",
                newName: "Person_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Managers",
                newName: "Person_FirstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Managers",
                newName: "Person_Age");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "Person_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employees",
                newName: "Person_FirstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Employees",
                newName: "Person_Age");
        }
    }
}
