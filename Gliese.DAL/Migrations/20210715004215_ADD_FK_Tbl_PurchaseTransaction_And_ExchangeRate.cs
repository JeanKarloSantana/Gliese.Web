using Microsoft.EntityFrameworkCore.Migrations;

namespace Gliese.DAL.Migrations
{
    public partial class ADD_FK_Tbl_PurchaseTransaction_And_ExchangeRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransaction_IdExchangeRate",
                table: "PurchaseTransaction",
                column: "IdExchangeRate");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseTransaction_ExchangeRate_IdExchangeRate",
                table: "PurchaseTransaction",
                column: "IdExchangeRate",
                principalTable: "ExchangeRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseTransaction_ExchangeRate_IdExchangeRate",
                table: "PurchaseTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseTransaction_IdExchangeRate",
                table: "PurchaseTransaction");
        }
    }
}
