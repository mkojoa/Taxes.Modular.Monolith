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
    internal class GetCalculationRulesHandler : IQueryHandler<GetCalculationRules, IEnumerable<CalculationRuleDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetCalculationRulesHandler(TaxesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CalculationRuleDto>> HandleAsync(GetCalculationRules query, CancellationToken cancellationToken = default)
        {
            var countries = await _dbContext.CalculationRules
                .AsNoTracking()
                .Select(x => new CalculationRuleDto { 
                    Id = x.Id, 
                    Code = x.Code, 
                    Name = x.Name,
                    Type = x.Type,
                    Status = x.Status,
                }).ToListAsync(cancellationToken);

            return countries;
        }
    }
}
