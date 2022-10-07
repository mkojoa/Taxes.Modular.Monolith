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
using Taxes.Shared.Infrastructure.SqlServer;

namespace Taxes.Modules.Tax.Core.Queries.Handlers
{
    internal class BrowseSavingSchemeHandler : IQueryHandler<BrowseSavingScheme, Paged<SavingSchemeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public BrowseSavingSchemeHandler(TaxesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

         public Task<Paged<SavingSchemeDto>> HandleAsync(BrowseSavingScheme query, CancellationToken cancellationToken = default)
        {
            var repo = _dbContext.SavingsSchemes
                .AsNoTracking();
                if (!string.IsNullOrWhiteSpace(query.Filter))
                {
                    repo = repo.Where(x => EF.Functions.Like(x.Code, $"%{query.Filter}%") || EF.Functions.Like(x.Name, $"%{query.Filter}%")).AsQueryable();
                }
                return repo.Select(x => new SavingSchemeDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CalculationRule = new CalculationRuleDto{
                        Id = x.CalculationRule.Id,
                        Type = x.CalculationRule.Type,
                        Code = x.CalculationRule.Code,
                        Name = x.CalculationRule.Name
                    },
                    Country = new CountryDto {
                        Code = x.Country.Code,
                        Name = x.Country.Name, 
                    },
                    PercentageBasis = x.PercentageBasis,
                    UpperLimit = x.UpperLimit,
                    LowerLimit = x.LowerLimit,
                    Employee = x.Employee,
                    Employer = x.Employer,
                    TaxRebateEmpContrib = x.TaxRebateEmpContrib,
                    TaxDeductible = x.TaxDeductible,
                    TaxEmployerContrib = x.TaxEmployerContrib,
                    TransSegment = x.TransSegment,
                    EmployeeGLAcc = x.EmployeeGLAcc,
                    EmployerGLAcc = x.EmployerGLAcc,
                    EmployerPayable = x.EmployerPayable,
                    Status = x.Status,
                    SavingsSchemeType = new SavingSchemeTypeDto{
                        Id = x.SavingsSchemeType.Id,
                        Name = x.SavingsSchemeType.Name,
                        CountryCode = x.SavingsSchemeType.CountryCode,
                        SchemeCap = x.SavingsSchemeType.SchemeCap,
                        StatutoryFund = x.SavingsSchemeType.StatutoryFund
                    }
                }).PaginateAsync(query, cancellationToken);

        }
    }
}
