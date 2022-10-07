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
    internal class GetLoanHandler : IQueryHandler<GetLoan, LoanDto>
    {
        private readonly TaxesDbContext _dbContext;

        public GetLoanHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<LoanDto> HandleAsync(GetLoan query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.LoanRules
                .Where(x => x.Id == query.Id)
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
                }).SingleOrDefaultAsync(cancellationToken);

            return repo;
        }
    }
}
