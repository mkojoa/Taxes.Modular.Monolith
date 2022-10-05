﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taxes.Modules.Tax.Core.DAL;

#nullable disable

namespace Taxes.Modules.Tax.Core.DAL.Migrations
{
    [DbContext(typeof(TaxesDbContext))]
    [Migration("20221005192739_Taxes_v9")]
    partial class Taxes_v9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("taxes")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.LoanRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GearingRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("StatutoryRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.ToTable("LoanRules", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.NonCash", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("CalculationRule")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Ceiling")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NonCashTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("NonCashTypeId");

                    b.ToTable("NonCash", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.NonCashType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NonCashTypes", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SavingsScheme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalcRule")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Employee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("EmployeeGLAcc")
                        .HasColumnType("bit");

                    b.Property<decimal>("Employer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("EmployerGLAcc")
                        .HasColumnType("bit");

                    b.Property<bool>("EmployerPayable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LowerLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PercentageBasis")
                        .HasColumnType("int");

                    b.Property<Guid>("SavingsSchemeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TaxDeductible")
                        .HasColumnType("int");

                    b.Property<int>("TaxEmployerContrib")
                        .HasColumnType("int");

                    b.Property<int>("TaxRebateEmpContrib")
                        .HasColumnType("int");

                    b.Property<bool>("TransSegment")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("UpperLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("SavingsSchemeTypeId");

                    b.ToTable("SavingsSchemes", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SavingsSchemeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SchemeCap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StatutoryFund")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.ToTable("SavingsSchemeTypes", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SpecialTax", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("QualificationAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QualificationBasis")
                        .HasColumnType("int");

                    b.Property<int>("SpecialTaxTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TaxResidual")
                        .HasColumnType("bit");

                    b.Property<Guid>("TaxTable")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("SpecialTaxTypeId");

                    b.ToTable("SpecialTaxes", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SpecialTaxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SpecialTaxTypes", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxBandTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxBand")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("TaxTableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TaxableAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("TaxTableId");

                    b.ToTable("TaxBandTables", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AmtBased")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Default")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Graduated")
                        .HasColumnType("bit");

                    b.Property<bool>("PerBasedOnTable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("TaxTableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.ToTable("TaxMasters", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxRelief", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CalcRule")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TaxReliefTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("TaxReliefTypeId");

                    b.ToTable("TaxReliefs", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxReliefType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxReliefType", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaxMasterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("TaxMasterId");

                    b.ToTable("TaxTables", "taxes");
                });

            modelBuilder.Entity("Taxes.Shared.Abstractions.Kernel.Entites.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Demonym")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Code");

                    b.ToTable("Countries", "taxes");
                });

            modelBuilder.Entity("Taxes.Shared.Infrastructure.Messaging.Outbox.InboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Inbox", "taxes");
                });

            modelBuilder.Entity("Taxes.Shared.Infrastructure.Messaging.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SentAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TraceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Outbox", "taxes");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.LoanRule", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.NonCash", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("Taxes.Modules.Tax.Core.Domain.Entities.NonCashType", "NonCashType")
                        .WithMany()
                        .HasForeignKey("NonCashTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("NonCashType");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SavingsScheme", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("Taxes.Modules.Tax.Core.Domain.Entities.SavingsSchemeType", "SavingsSchemeType")
                        .WithMany()
                        .HasForeignKey("SavingsSchemeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("SavingsSchemeType");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SavingsSchemeType", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.SpecialTax", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("Taxes.Modules.Tax.Core.Domain.Entities.SpecialTaxType", "SpecialTaxType")
                        .WithMany()
                        .HasForeignKey("SpecialTaxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("SpecialTaxType");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxBandTable", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("Taxes.Modules.Tax.Core.Domain.Entities.TaxTable", "TaxTable")
                        .WithMany("TaxBandTable")
                        .HasForeignKey("TaxTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("TaxTable");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxMaster", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxRelief", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("Taxes.Modules.Tax.Core.Domain.Entities.TaxReliefType", "TaxReliefType")
                        .WithMany()
                        .HasForeignKey("TaxReliefTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("TaxReliefType");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxTable", b =>
                {
                    b.HasOne("Taxes.Shared.Abstractions.Kernel.Entites.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("Taxes.Modules.Tax.Core.Domain.Entities.TaxMaster", "TaxMaster")
                        .WithMany("TaxTable")
                        .HasForeignKey("TaxMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("TaxMaster");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxMaster", b =>
                {
                    b.Navigation("TaxTable");
                });

            modelBuilder.Entity("Taxes.Modules.Tax.Core.Domain.Entities.TaxTable", b =>
                {
                    b.Navigation("TaxBandTable");
                });
#pragma warning restore 612, 618
        }
    }
}
