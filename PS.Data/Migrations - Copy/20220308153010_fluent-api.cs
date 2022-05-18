using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class fluentapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Products_ProductsProductId",
                table: "ProductProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersId",
                table: "ProductProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catgegories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProvider",
                table: "ProductProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catgegories",
                table: "Catgegories");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Catgegories");

            migrationBuilder.RenameTable(
                name: "ProductProvider",
                newName: "ProdProv");

            migrationBuilder.RenameTable(
                name: "Catgegories",
                newName: "MyCategories");

            migrationBuilder.RenameColumn(
                name: "address_StreetAddress",
                table: "Products",
                newName: "MyAddress");

            migrationBuilder.RenameColumn(
                name: "address_City",
                table: "Products",
                newName: "MyCity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProvider_ProvidersId",
                table: "ProdProv",
                newName: "IX_ProdProv_ProvidersId");

            migrationBuilder.AlterColumn<string>(
                name: "MyAddress",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MyCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdProv",
                table: "ProdProv",
                columns: new[] { "ProductsProductId", "ProvidersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyCategories",
                table: "MyCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdProv_Products_ProductsProductId",
                table: "ProdProv",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdProv_Providers_ProvidersId",
                table: "ProdProv",
                column: "ProvidersId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MyCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "MyCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdProv_Products_ProductsProductId",
                table: "ProdProv");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdProv_Providers_ProvidersId",
                table: "ProdProv");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MyCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdProv",
                table: "ProdProv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyCategories",
                table: "MyCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MyCategories");

            migrationBuilder.RenameTable(
                name: "ProdProv",
                newName: "ProductProvider");

            migrationBuilder.RenameTable(
                name: "MyCategories",
                newName: "Catgegories");

            migrationBuilder.RenameColumn(
                name: "MyCity",
                table: "Products",
                newName: "address_City");

            migrationBuilder.RenameColumn(
                name: "MyAddress",
                table: "Products",
                newName: "address_StreetAddress");

            migrationBuilder.RenameIndex(
                name: "IX_ProdProv_ProvidersId",
                table: "ProductProvider",
                newName: "IX_ProductProvider_ProvidersId");

            migrationBuilder.AlterColumn<string>(
                name: "address_StreetAddress",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Catgegories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProvider",
                table: "ProductProvider",
                columns: new[] { "ProductsProductId", "ProvidersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catgegories",
                table: "Catgegories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Products_ProductsProductId",
                table: "ProductProvider",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersId",
                table: "ProductProvider",
                column: "ProvidersId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catgegories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Catgegories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
