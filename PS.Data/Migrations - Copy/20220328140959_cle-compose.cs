using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class clecompose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Client_ClientFK",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Products_ProductFK",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ClientFK",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ProductFK",
                table: "Invoices",
                newName: "IX_Invoices_ProductFK");

            migrationBuilder.AlterColumn<string>(
                name: "ClientFK",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                columns: new[] { "ClientFK", "ProductFK", "PurchaseDate" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Cin");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientFK",
                table: "Invoices",
                column: "ClientFK",
                principalTable: "Clients",
                principalColumn: "Cin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Products_ProductFK",
                table: "Invoices",
                column: "ProductFK",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientFK",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Products_ProductFK",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ProductFK",
                table: "Invoice",
                newName: "IX_Invoice_ProductFK");

            migrationBuilder.AlterColumn<string>(
                name: "ClientFK",
                table: "Invoice",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Cin");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ClientFK",
                table: "Invoice",
                column: "ClientFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Client_ClientFK",
                table: "Invoice",
                column: "ClientFK",
                principalTable: "Client",
                principalColumn: "Cin",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Products_ProductFK",
                table: "Invoice",
                column: "ProductFK",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
