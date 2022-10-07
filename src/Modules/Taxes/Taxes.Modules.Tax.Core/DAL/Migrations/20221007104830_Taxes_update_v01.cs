using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_update_v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "taxes",
                table: "SavingsSchemes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CalcRule",
                schema: "taxes",
                table: "SavingsSchemes",
                newName: "CalculationRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemes_CalculationRuleId",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CalculationRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsSchemes_CalculationRules_CalculationRuleId",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CalculationRuleId",
                principalSchema: "taxes",
                principalTable: "CalculationRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsSchemes_CalculationRules_CalculationRuleId",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropIndex(
                name: "IX_SavingsSchemes_CalculationRuleId",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "taxes",
                table: "SavingsSchemes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CalculationRuleId",
                schema: "taxes",
                table: "SavingsSchemes",
                newName: "CalcRule");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "taxes",
                table: "SavingsSchemes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "taxes",
                table: "SavingsSchemes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
