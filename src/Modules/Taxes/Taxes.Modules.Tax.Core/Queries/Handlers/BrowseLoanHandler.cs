using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DAL;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Shared.Abstractions.Queries;
using Taxes.Shared.Infrastructure.SqlServer;

namespace Taxes.Modules.Tax.Core.Queries.Handlers
{
    internal class BrowseLoanHandler : IQueryHandler<BrowseLoan, Paged<LoanDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public BrowseLoanHandler(TaxesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

         public Task<Paged<LoanDto>> HandleAsync(BrowseLoan query, CancellationToken cancellationToken = default)
        {
            var repo = _dbContext.LoanRules
                .AsNoTracking();
                if (!string.IsNullOrWhiteSpace(query.Filter))
                {
                    repo = repo.Where(x => EF.Functions.Like(x.Name, $"%{query.Filter}%")).AsQueryable();
                }
                return repo.Select(x => new LoanDto
                {
                    Id = x.Id, 
                    Name = x.Name,
                    StatutoryRate = x.StatutoryRate,
                    GearingRatio= x.GearingRatio,
                    StartDate = x.StartDate,
                    Status = x.Status,
                    Country = new CountryDto {
                        Code = x.Country.Code,
                        Name = x.Country.Name
                    },
                }).PaginateAsync(query, cancellationToken);

        }
    }
}
