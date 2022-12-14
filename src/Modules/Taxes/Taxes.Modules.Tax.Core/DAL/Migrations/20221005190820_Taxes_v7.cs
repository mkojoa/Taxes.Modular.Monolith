using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "taxes",
                table: "SpecialTaxTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTaxTypes_Id_Name",
                schema: "taxes",
                table: "SpecialTaxTypes",
                columns: new[] { "Id", "Name" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpecialTaxTypes_Id_Name",
                schema: "taxes",
                table: "SpecialTaxTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "taxes",
                table: "SpecialTaxTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
