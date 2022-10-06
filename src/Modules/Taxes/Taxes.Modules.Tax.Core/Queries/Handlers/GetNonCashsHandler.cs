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
    internal class GetNonCashsHandler : IQueryHandler<GetNonCashs, IEnumerable<NonCashDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetNonCashsHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<NonCashDto>> HandleAsync(GetNonCashs query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.NonCash
                .Where(x => x.CountryCode == query.CountryCode)
                .AsNoTracking()
                .Select(x => new NonCashDto
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
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
