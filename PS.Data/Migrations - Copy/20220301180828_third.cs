using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Products",
                newName: "address_City");

            migrationBuilder.RenameColumn(
                name: "StreetAdresse",
                table: "Products",
                newName: "address_StreetAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address_City",
                table: "Products",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address_StreetAddress",
                table: "Products",
                newName: "StreetAdresse");
        }
    }
}
