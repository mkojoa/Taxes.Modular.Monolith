using Microsoft.EntityFrameworkCore;
using Taxes.Shared.Abstractions.Kernel.Entites;
using Taxes.Shared.Infrastructure.Messaging.Outbox;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.DAL;

internal class TaxesDbContext : DbContext
{
    public DbSet<InboxMessage> Inbox { get; set; }
    public DbSet<OutboxMessage> Outbox { get; set; }
    public DbSet<Country> Countries { get; set; } 
    public DbSet<LoanRule> LoanRules { get; set; } 
    public DbSet<NonCashType> NonCashTypes { get; set; } 
    public DbSet<NonCash> NonCash { get; set; } 
    public DbSet<SavingsSchemeType> SavingsSchemeTypes { get; set; } 
    public DbSet<SavingsScheme> SavingsSchemes { get; set; } 
    public DbSet<SpecialTaxType> SpecialTaxTypes { get; set; } 
    public DbSet<SpecialTax> SpecialTaxes { get; set; } 
    public DbSet<TaxBandTable> TaxBandTables { get; set; } 
    public DbSet<TaxMaster> TaxMasters { get; set; } 
    public DbSet<TaxRelief> TaxReliefs { get; set; } 
    public DbSet<TaxReliefType> TaxReliefType { get; set; }  
    public DbSet<TaxTable> TaxTables { get; set; }
    public DbSet<CalculationRule> CalculationRules { get; set; } 
     

    public TaxesDbContext(DbContextOptions<TaxesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("taxes");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}