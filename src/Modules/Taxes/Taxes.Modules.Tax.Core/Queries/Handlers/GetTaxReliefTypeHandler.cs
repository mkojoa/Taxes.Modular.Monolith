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
    internal class GetTaxReliefTypeHandler : IQueryHandler<GetTaxReliefType, IEnumerable<TaxReliefTypeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetTaxReliefTypeHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<TaxReliefTypeDto>> HandleAsync(GetTaxReliefType query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.TaxReliefType
                .Where(x => x.CountryCode == query.CountryCode)
                .AsNoTracking()
                .Select(x => new TaxReliefTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryCode = x.CountryCode
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
