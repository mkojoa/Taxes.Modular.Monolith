using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_update_v5_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRules_Countries_CountryCode1",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropIndex(
                name: "IX_LoanRules_CountryCode1",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "LoanRules",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRules_CountryCode",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRules_Countries_CountryCode",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryCode",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRules_Countries_CountryCode",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropIndex(
                name: "IX_LoanRules_CountryCode",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "LoanRules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "LoanRules",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRules_CountryCode1",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRules_Countries_CountryCode1",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");
        }
    }
}
