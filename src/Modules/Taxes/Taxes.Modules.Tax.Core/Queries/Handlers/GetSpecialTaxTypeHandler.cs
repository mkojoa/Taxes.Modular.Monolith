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
    internal class GetSpecialTaxTypeHandler : IQueryHandler<GetSpecialTaxType, IEnumerable<SpecialTaxTypeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetSpecialTaxTypeHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<SpecialTaxTypeDto>> HandleAsync(GetSpecialTaxType query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.SpecialTaxTypes
                .Where(x => x.CountryCode == query.CountryCode)
                .AsNoTracking()
                .Select(x => new SpecialTaxTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryCode = x.CountryCode
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
