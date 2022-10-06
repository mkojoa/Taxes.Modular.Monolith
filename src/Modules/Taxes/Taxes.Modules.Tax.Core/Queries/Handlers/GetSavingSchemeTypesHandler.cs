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
    internal class GetSavingSchemeTypesHandler : IQueryHandler<GetSavingSchemeTypes, IEnumerable<SavingSchemeTypeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetSavingSchemeTypesHandler(TaxesDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SavingSchemeTypeDto>> HandleAsync(GetSavingSchemeTypes query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.SavingsSchemeTypes
                .AsNoTracking()
                .Select(x => new SavingSchemeTypeDto
                { 
                    Id = x.Id, 
                    Name = x.Name,
                    CountryCode = x.CountryCode,
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
