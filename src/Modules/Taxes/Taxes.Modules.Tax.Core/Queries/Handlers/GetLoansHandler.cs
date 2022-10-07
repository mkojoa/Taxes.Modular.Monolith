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

namespace Taxes.Modules.Tax.Core.Queries.Handlers
{
    internal class GetLoansHandler : IQueryHandler<GetLoans, IEnumerable<LoanDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetLoansHandler(TaxesDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoanDto>> HandleAsync(GetLoans query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.LoanRules
                .AsNoTracking()
                .Select(x => new LoanDto
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
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
