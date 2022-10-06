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
    internal class GetSavingSchemeTypeHandler : IQueryHandler<GetSavingSchemeType, IEnumerable<SavingSchemeTypeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetSavingSchemeTypeHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<SavingSchemeTypeDto>> HandleAsync(GetSavingSchemeType query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.SavingsSchemeTypes
                .Where(x => x.CountryCode == query.CountryCode)
                .AsNoTracking()

                .Select(x => new SavingSchemeTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryCode = x.CountryCode
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
