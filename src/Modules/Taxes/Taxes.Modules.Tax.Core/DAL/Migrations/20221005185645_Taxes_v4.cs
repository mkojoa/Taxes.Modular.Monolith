using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxReliefs_TaxTypes_TaxTypeId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropTable(
                name: "TaxTypes",
                schema: "taxes");

            migrationBuilder.RenameColumn(
                name: "TaxTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                newName: "TaxReliefTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaxReliefs_TaxTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                newName: "IX_TaxReliefs_TaxReliefTypeId");

            migrationBuilder.CreateTable(
                name: "TaxReliefType",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReliefType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TaxReliefs_TaxReliefType_TaxReliefTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                column: "TaxReliefTypeId",
                principalSchema: "taxes",
                principalTable: "TaxReliefType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxReliefs_TaxReliefType_TaxReliefTypeId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropTable(
                name: "TaxReliefType",
                schema: "taxes");

            migrationBuilder.RenameColumn(
                name: "TaxReliefTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                newName: "TaxTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaxReliefs_TaxReliefTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                newName: "IX_TaxReliefs_TaxTypeId");

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TaxReliefs_TaxTypes_TaxTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                column: "TaxTypeId",
                principalSchema: "taxes",
                principalTable: "TaxTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
