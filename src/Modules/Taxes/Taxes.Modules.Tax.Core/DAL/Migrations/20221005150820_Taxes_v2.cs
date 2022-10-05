using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "TaxTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "TaxReliefs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "TaxReliefs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "TaxBandTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "TaxBandTables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "SpecialTaxTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "taxes",
                table: "NonCashTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxReliefs_CountryId",
                schema: "taxes",
                table: "TaxReliefs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBandTables_CountryId",
                schema: "taxes",
                table: "TaxBandTables",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxBandTables_Countries_CountryId",
                schema: "taxes",
                table: "TaxBandTables",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxReliefs_Countries_CountryId",
                schema: "taxes",
                table: "TaxReliefs",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxBandTables_Countries_CountryId",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxReliefs_Countries_CountryId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropIndex(
                name: "IX_TaxReliefs_CountryId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropIndex(
                name: "IX_TaxBandTables_CountryId",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "taxes",
                table: "TaxTypes");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "taxes",
                table: "SpecialTaxTypes");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "taxes",
                table: "NonCashTypes");
        }
    }
}
