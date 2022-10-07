using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_update_v5 : Migration
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

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "taxes",
                table: "LoanRules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "taxes",
                table: "LoanRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "taxes",
                table: "LoanRules",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                schema: "taxes",
                table: "LoanRules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                schema: "taxes",
                table: "LoanRules",
                type: "nvarchar(max)",
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
