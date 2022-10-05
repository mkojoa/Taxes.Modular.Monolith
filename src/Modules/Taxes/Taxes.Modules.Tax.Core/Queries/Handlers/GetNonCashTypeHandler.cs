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
    internal class GetNonCashTypeHandler : IQueryHandler<GetNonCashType, IEnumerable<NonCashTypeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetNonCashTypeHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<NonCashTypeDto>> HandleAsync(GetNonCashType query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.NonCashTypes
                .Where(x => x.CountryCode == query.CountryCode)
                .AsNoTracking()

                .Select(x => new NonCashTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryCode = x.CountryCode
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
