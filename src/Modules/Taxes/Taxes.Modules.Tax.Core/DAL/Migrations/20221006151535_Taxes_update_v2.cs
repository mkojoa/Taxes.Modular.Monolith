using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_update_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculationRule",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "taxes",
                table: "NonCash",
                newName: "UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "taxes",
                table: "NonCash",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "taxes",
                table: "NonCash",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalculationRuleId",
                schema: "taxes",
                table: "NonCash",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NonCash_CalculationRuleId",
                schema: "taxes",
                table: "NonCash",
                column: "CalculationRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_NonCash_CalculationRules_CalculationRuleId",
                schema: "taxes",
                table: "NonCash",
                column: "CalculationRuleId",
                principalSchema: "taxes",
                principalTable: "CalculationRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonCash_CalculationRules_CalculationRuleId",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropIndex(
                name: "IX_NonCash_CalculationRuleId",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropColumn(
                name: "CalculationRuleId",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "taxes",
                table: "NonCash",
                newName: "UserID");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                schema: "taxes",
                table: "NonCash",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                schema: "taxes",
                table: "NonCash",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "CalculationRule",
                schema: "taxes",
                table: "NonCash",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                schema: "taxes",
                table: "NonCash",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
