using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DAL;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Shared.Abstractions.Queries;

namespace Taxes.Modules.Tax.Core.Queries.Handlers
{
    internal class GetTaxReliefsHandler : IQueryHandler<GetTaxReliefs, IEnumerable<TaxReliefDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetTaxReliefsHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<TaxReliefDto>> HandleAsync(GetTaxReliefs query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.TaxReliefs
                .Where(x => x.Country.Code == query.CountryCode)
                .AsNoTracking()
                .Select(x => new TaxReliefDto
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
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
