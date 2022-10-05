using Taxes.Shared.Infrastructure.SqlServer;

namespace Taxes.Modules.Tax.Core.DAL;

internal class TaxesUnitOfWork : SqlServerUnitOfWork<TaxesDbContext>
{
    public TaxesUnitOfWork(TaxesDbContext dbContext) : base(dbContext)
    {
    }
}