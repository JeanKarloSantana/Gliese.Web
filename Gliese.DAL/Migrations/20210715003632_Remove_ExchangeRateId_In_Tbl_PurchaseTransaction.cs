using Microsoft.EntityFrameworkCore.Migrations;

namespace Gliese.DAL.Migrations
{
    public partial class Remove_ExchangeRateId_In_Tbl_PurchaseTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseTransaction_ExchangeRate_ExchangeRateId",
                table: "PurchaseTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseTransaction_ExchangeRateId",
                table: "PurchaseTransaction");

            migrationBuilder.DropColumn(
                name: "ExchangeRateId",
                table: "PurchaseTransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExchangeRateId",
                table: "PurchaseTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransaction_ExchangeRateId",
                table: "PurchaseTransaction",
                column: "ExchangeRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseTransaction_ExchangeRate_ExchangeRateId",
                table: "PurchaseTransaction",
                column: "ExchangeRateId",
                principalTable: "ExchangeRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
