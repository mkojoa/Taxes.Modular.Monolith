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
    internal class GetSpecialTaxTypesHandler : IQueryHandler<GetSpecialTaxTypes, IEnumerable<SpecialTaxTypeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetSpecialTaxTypesHandler(TaxesDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SpecialTaxTypeDto>> HandleAsync(GetSpecialTaxTypes query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.SpecialTaxTypes
                .AsNoTracking()
                .Select(x => new SpecialTaxTypeDto
                { 
                    Id = x.Id, 
                    Name = x.Name,
                    CountryCode = x.CountryCode,
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
