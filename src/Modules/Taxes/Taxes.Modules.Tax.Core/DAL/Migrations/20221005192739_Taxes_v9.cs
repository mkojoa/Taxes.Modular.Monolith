using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRules_Countries_CountryId",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropForeignKey(
                name: "FK_NonCash_Countries_CountryId",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsSchemes_Countries_CountryId",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsSchemeTypes_Countries_CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialTaxes_Countries_CountryId",
                schema: "taxes",
                table: "SpecialTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxBandTables_Countries_CountryId",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxMasters_Countries_CountryId",
                schema: "taxes",
                table: "TaxMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxReliefs_Countries_CountryId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxTables_Countries_CountryId",
                schema: "taxes",
                table: "TaxTables");

            migrationBuilder.DropIndex(
                name: "IX_TaxTables_CountryId",
                schema: "taxes",
                table: "TaxTables");

            migrationBuilder.DropIndex(
                name: "IX_TaxReliefs_CountryId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropIndex(
                name: "IX_TaxMasters_CountryId",
                schema: "taxes",
                table: "TaxMasters");

            migrationBuilder.DropIndex(
                name: "IX_TaxBandTables_CountryId",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropIndex(
                name: "IX_SpecialTaxes_CountryId",
                schema: "taxes",
                table: "SpecialTaxes");

            migrationBuilder.DropIndex(
                name: "IX_SavingsSchemeTypes_CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes");

            migrationBuilder.DropIndex(
                name: "IX_SavingsSchemes_CountryId",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropIndex(
                name: "IX_NonCash_CountryId",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropIndex(
                name: "IX_LoanRules_CountryId",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "TaxTables");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "TaxMasters");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "SpecialTaxes");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CurrencySymbol",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxTables",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxReliefs",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxMasters",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxBandTables",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "SpecialTaxes",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "SavingsSchemes",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "NonCash",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                schema: "taxes",
                table: "LoanRules",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Demonym",
                schema: "taxes",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                schema: "taxes",
                table: "Countries",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTables_CountryCode1",
                schema: "taxes",
                table: "TaxTables",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReliefs_CountryCode1",
                schema: "taxes",
                table: "TaxReliefs",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_TaxMasters_CountryCode1",
                schema: "taxes",
                table: "TaxMasters",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBandTables_CountryCode1",
                schema: "taxes",
                table: "TaxBandTables",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTaxes_CountryCode1",
                schema: "taxes",
                table: "SpecialTaxes",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemeTypes_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemes_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CountryCode1");

            migrationBuilder.CreateIndex(
                name: "IX_NonCash_CountryCode1",
                schema: "taxes",
                table: "NonCash",
                column: "CountryCode1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NonCash_Countries_CountryCode1",
                schema: "taxes",
                table: "NonCash",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsSchemes_Countries_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsSchemeTypes_Countries_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialTaxes_Countries_CountryCode1",
                schema: "taxes",
                table: "SpecialTaxes",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxBandTables_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxBandTables",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxMasters_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxMasters",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxReliefs_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxReliefs",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxTables_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxTables",
                column: "CountryCode1",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRules_Countries_CountryCode1",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropForeignKey(
                name: "FK_NonCash_Countries_CountryCode1",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsSchemes_Countries_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingsSchemeTypes_Countries_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialTaxes_Countries_CountryCode1",
                schema: "taxes",
                table: "SpecialTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxBandTables_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxMasters_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxReliefs_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxTables_Countries_CountryCode1",
                schema: "taxes",
                table: "TaxTables");

            migrationBuilder.DropIndex(
                name: "IX_TaxTables_CountryCode1",
                schema: "taxes",
                table: "TaxTables");

            migrationBuilder.DropIndex(
                name: "IX_TaxReliefs_CountryCode1",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropIndex(
                name: "IX_TaxMasters_CountryCode1",
                schema: "taxes",
                table: "TaxMasters");

            migrationBuilder.DropIndex(
                name: "IX_TaxBandTables_CountryCode1",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropIndex(
                name: "IX_SpecialTaxes_CountryCode1",
                schema: "taxes",
                table: "SpecialTaxes");

            migrationBuilder.DropIndex(
                name: "IX_SavingsSchemeTypes_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemeTypes");

            migrationBuilder.DropIndex(
                name: "IX_SavingsSchemes_CountryCode1",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropIndex(
                name: "IX_NonCash_CountryCode1",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropIndex(
                name: "IX_LoanRules_CountryCode1",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxTables");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxReliefs");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxMasters");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "TaxBandTables");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "SpecialTaxes");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "SavingsSchemeTypes");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "SavingsSchemes");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "NonCash");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                schema: "taxes",
                table: "LoanRules");

            migrationBuilder.DropColumn(
                name: "Demonym",
                schema: "taxes",
                table: "Countries");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "TaxTables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "TaxReliefs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "TaxMasters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "TaxBandTables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "SpecialTaxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "SavingsSchemes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "NonCash",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "taxes",
                table: "LoanRules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "taxes",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "taxes",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                schema: "taxes",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencySymbol",
                schema: "taxes",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                schema: "taxes",
                table: "Countries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTables_CountryId",
                schema: "taxes",
                table: "TaxTables",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReliefs_CountryId",
                schema: "taxes",
                table: "TaxReliefs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxMasters_CountryId",
                schema: "taxes",
                table: "TaxMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBandTables_CountryId",
                schema: "taxes",
                table: "TaxBandTables",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTaxes_CountryId",
                schema: "taxes",
                table: "SpecialTaxes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemeTypes_CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemes_CountryId",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_NonCash_CountryId",
                schema: "taxes",
                table: "NonCash",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRules_CountryId",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRules_Countries_CountryId",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NonCash_Countries_CountryId",
                schema: "taxes",
                table: "NonCash",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsSchemes_Countries_CountryId",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsSchemeTypes_Countries_CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialTaxes_Countries_CountryId",
                schema: "taxes",
                table: "SpecialTaxes",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxBandTables_Countries_CountryId",
                schema: "taxes",
                table: "TaxBandTables",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxMasters_Countries_CountryId",
                schema: "taxes",
                table: "TaxMasters",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TaxTables_Countries_CountryId",
                schema: "taxes",
                table: "TaxTables",
                column: "CountryId",
                principalSchema: "taxes",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
