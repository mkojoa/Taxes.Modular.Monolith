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
    internal class BrowseTaxReliefHandler : IQueryHandler<BrowseTaxRelief, Paged<TaxReliefDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public BrowseTaxReliefHandler(TaxesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

         public Task<Paged<TaxReliefDto>> HandleAsync(BrowseTaxRelief query, CancellationToken cancellationToken = default)
        {
            var repos = _dbContext.TaxReliefs
                .AsNoTracking();
                if (!string.IsNullOrWhiteSpace(query.Filter))
                {
                    repos = repos.Where(x => EF.Functions.Like(x.Code, $"%{query.Filter}%") || EF.Functions.Like(x.Name, $"%{query.Filter}%")).AsQueryable();
                }
                return repos.Select(x => new TaxReliefDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Notes = x.Notes,
                    Amount = x.Amount,
                     Country = new CountryDto{
                        Code = x.Country.Code,
                        Name = x.Country.Name
                    },
                    CalculationRule = new CalculationRuleDto{
                        Id = x.CalculationRule.Id,
                        Name = x.CalculationRule.Name,
                        Code = x.CalculationRule.Code,
                        Type = x.CalculationRule.Type,
                        Status = x.CalculationRule.Status
                    },
                    Status = x.Status,
                    TaxReliefType = new TaxReliefTypeDto{
                        Id = x.TaxReliefType.Id,
                        Name = x.TaxReliefType.Name,
                        CountryCode = x.TaxReliefType.CountryCode
                    }
                }).PaginateAsync(query, cancellationToken);

        }
    }
}
