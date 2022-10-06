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
    internal class GetCountriesHandler : IQueryHandler<GetCountries, IEnumerable<CountryDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetCountriesHandler(TaxesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CountryDto>> HandleAsync(GetCountries query, CancellationToken cancellationToken = default)
        {
            var countries = await _dbContext.Countries
                .AsNoTracking()
                .Select(x => new CountryDto { 
                    Code = x.Code, 
                    Name = x.Name,
                }).ToListAsync(cancellationToken);

            return countries;
        }
    }
}
