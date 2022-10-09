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
    internal class GetTaxReliefHandler : IQueryHandler<GetTaxRelief, TaxReliefDto>
    {
        private readonly TaxesDbContext _dbContext;

        public GetTaxReliefHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<TaxReliefDto> HandleAsync(GetTaxRelief query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.TaxReliefs
                .Where(x => x.Id == query.Id)
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
                }).SingleOrDefaultAsync(cancellationToken);

            return repo;
        }
    }
}
