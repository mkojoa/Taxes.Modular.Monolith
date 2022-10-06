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
    internal class BrowseNonCashHandler : IQueryHandler<BrowseNonCash, Paged<NonCashDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public BrowseNonCashHandler(TaxesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

         public Task<Paged<NonCashDto>> HandleAsync(BrowseNonCash query, CancellationToken cancellationToken = default)
        {
            var nonCashes = _dbContext.NonCash
                .AsNoTracking();
                if (!string.IsNullOrWhiteSpace(query.Filter))
                {
                    nonCashes = nonCashes.Where(x => EF.Functions.Like(x.Code, $"%{query.Filter}%") || EF.Functions.Like(x.Name, $"%{query.Filter}%")).AsQueryable();
                }
                return nonCashes.Select(x => new NonCashDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CountryCode = x.CountryCode,
                    Notes = x.Notes,
                    CalculationRule = new CalculationRuleDto{
                        Id = x.CalculationRule.Id,
                        Name = x.CalculationRule.Name,
                        Code = x.CalculationRule.Code,
                        Type = x.CalculationRule.Type,
                        Status = x.CalculationRule.Status
                    },
                    Rate = x.Rate,
                    Ceiling = x.Ceiling,
                    Status = x.Status,
                    StartDate = x.StartDate,
                    NonCashType = new NonCashTypeDto{
                        Id = x.NonCashType.Id,
                        Name = x.NonCashType.Name,
                        CountryCode = x.NonCashType.CountryCode
                    }
                }).PaginateAsync(query, cancellationToken);

        }
    }
}
