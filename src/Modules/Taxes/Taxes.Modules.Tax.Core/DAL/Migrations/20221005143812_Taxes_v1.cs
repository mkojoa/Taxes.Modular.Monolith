using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    public partial class Taxes_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "taxes");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inbox",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonCashTypes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonCashTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Outbox",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTaxTypes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanRules",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutoryRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GearingRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRules_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SavingsSchemeTypes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchemeCap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatutoryFund = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsSchemeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsSchemeTypes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaxMasters",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmtBased = table.Column<bool>(type: "bit", nullable: false),
                    PerBasedOnTable = table.Column<bool>(type: "bit", nullable: false),
                    Graduated = table.Column<bool>(type: "bit", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TaxTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxMasters_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NonCash",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculationRule = table.Column<long>(type: "bigint", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ceiling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NonCashTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonCash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonCash_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NonCash_NonCashTypes_NonCashTypeId",
                        column: x => x.NonCashTypeId,
                        principalSchema: "taxes",
                        principalTable: "NonCashTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTaxes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxTable = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationBasis = table.Column<int>(type: "int", nullable: false),
                    QualificationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialTaxTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxResidual = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialTaxes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialTaxes_SpecialTaxTypes_SpecialTaxTypeId",
                        column: x => x.SpecialTaxTypeId,
                        principalSchema: "taxes",
                        principalTable: "SpecialTaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxReliefs",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalcRule = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReliefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxReliefs_TaxTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "taxes",
                        principalTable: "TaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsSchemes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalcRule = table.Column<int>(type: "int", nullable: false),
                    PercentageBasis = table.Column<int>(type: "int", nullable: false),
                    UpperLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LowerLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Employee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Employer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRebateEmpContrib = table.Column<int>(type: "int", nullable: false),
                    TaxDeductible = table.Column<int>(type: "int", nullable: false),
                    TaxEmployerContrib = table.Column<int>(type: "int", nullable: false),
                    TransSegment = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeGLAcc = table.Column<bool>(type: "bit", nullable: false),
                    EmployerGLAcc = table.Column<bool>(type: "bit", nullable: false),
                    EmployerPayable = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SavingsSchemeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsSchemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsSchemes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavingsSchemes_SavingsSchemeTypes_SavingsSchemeTypeId",
                        column: x => x.SavingsSchemeTypeId,
                        principalSchema: "taxes",
                        principalTable: "SavingsSchemeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxTables",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxTables_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "taxes",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaxTables_TaxMasters_TaxMasterId",
                        column: x => x.TaxMasterId,
                        principalSchema: "taxes",
                        principalTable: "TaxMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxBandTables",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxBand = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBandTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxBandTables_TaxTables_TaxTableId",
                        column: x => x.TaxTableId,
                        principalSchema: "taxes",
                        principalTable: "TaxTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRules_CountryId",
                schema: "taxes",
                table: "LoanRules",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_NonCash_CountryId",
                schema: "taxes",
                table: "NonCash",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_NonCash_NonCashTypeId",
                schema: "taxes",
                table: "NonCash",
                column: "NonCashTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemes_CountryId",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemes_SavingsSchemeTypeId",
                schema: "taxes",
                table: "SavingsSchemes",
                column: "SavingsSchemeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsSchemeTypes_CountryId",
                schema: "taxes",
                table: "SavingsSchemeTypes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTaxes_CountryId",
                schema: "taxes",
                table: "SpecialTaxes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTaxes_SpecialTaxTypeId",
                schema: "taxes",
                table: "SpecialTaxes",
                column: "SpecialTaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBandTables_TaxTableId",
                schema: "taxes",
                table: "TaxBandTables",
                column: "TaxTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxMasters_CountryId",
                schema: "taxes",
                table: "TaxMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReliefs_TaxTypeId",
                schema: "taxes",
                table: "TaxReliefs",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTables_CountryId",
                schema: "taxes",
                table: "TaxTables",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTables_TaxMasterId",
                schema: "taxes",
                table: "TaxTables",
                column: "TaxMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inbox",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "LoanRules",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "NonCash",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "Outbox",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "SavingsSchemes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "SpecialTaxes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "TaxBandTables",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "TaxReliefs",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "NonCashTypes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "SavingsSchemeTypes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "SpecialTaxTypes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "TaxTables",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "TaxTypes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "TaxMasters",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "taxes");
        }
    }
}
