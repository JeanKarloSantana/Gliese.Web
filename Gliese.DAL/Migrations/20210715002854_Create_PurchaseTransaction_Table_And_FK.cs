using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gliese.DAL.Migrations
{
    public partial class Create_PurchaseTransaction_Table_And_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_Person_PersonId",
                table: "MainTransaction");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_PersonId",
                table: "MainTransaction");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "MainTransaction");

            migrationBuilder.CreateTable(
                name: "PurchaseTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdExchangeRate = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyRateLog = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellRateLog = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeRateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTransaction_ExchangeRate_ExchangeRateId",
                        column: x => x.ExchangeRateId,
                        principalTable: "ExchangeRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseTransaction_MainTransaction_Id",
                        column: x => x.Id,
                        principalTable: "MainTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_IdPerson",
                table: "MainTransaction",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransaction_ExchangeRateId",
                table: "PurchaseTransaction",
                column: "ExchangeRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_Person_IdPerson",
                table: "MainTransaction",
                column: "IdPerson",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_Person_IdPerson",
                table: "MainTransaction");

            migrationBuilder.DropTable(
                name: "PurchaseTransaction");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_IdPerson",
                table: "MainTransaction");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "MainTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_PersonId",
                table: "MainTransaction",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_Person_PersonId",
                table: "MainTransaction",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
