using Microsoft.EntityFrameworkCore.Migrations;

namespace Gliese.DAL.Migrations
{
    public partial class ADD_ID_CURRENCY_TO_COUNTRY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Country_IdCountry",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_IdCountry",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "IdCountry",
                table: "Currency");

            migrationBuilder.AddColumn<int>(
                name: "IdCurrency",
                table: "Country",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdCurrency",
                table: "Country",
                column: "IdCurrency");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Currency_IdCurrency",
                table: "Country",
                column: "IdCurrency",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Currency_IdCurrency",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_IdCurrency",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "IdCurrency",
                table: "Country");

            migrationBuilder.AddColumn<int>(
                name: "IdCountry",
                table: "Currency",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_IdCountry",
                table: "Currency",
                column: "IdCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_Country_IdCountry",
                table: "Currency",
                column: "IdCountry",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
