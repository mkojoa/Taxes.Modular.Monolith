using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DAL;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Shared.Abstractions.Queries;

namespace Taxes.Modules.Tax.Core.Queries.Handlers
{
    internal class GetCountryHandler : IQueryHandler<GetCountry, CountryDto>
    {
        private readonly TaxesDbContext _dbContext;

        public GetCountryHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CountryDto> HandleAsync(GetCountry query, CancellationToken cancellationToken = default)
        {
            var countries = await _dbContext.Countries
                .Where(x => x.Code == query.Code)
                .AsNoTracking()

                .Select(x => new CountryDto
                {
                    Code = x.Code,
                    Name = x.Name
                }).SingleOrDefaultAsync(cancellationToken);

            return countries;
        }
    }
}
