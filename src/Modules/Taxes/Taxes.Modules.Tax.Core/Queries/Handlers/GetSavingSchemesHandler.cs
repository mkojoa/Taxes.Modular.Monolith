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
    internal class GetSavingSchemesHandler : IQueryHandler<GetSavingSchemes, IEnumerable<SavingSchemeDto>>
    {
        private readonly TaxesDbContext _dbContext;

        public GetSavingSchemesHandler(TaxesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<SavingSchemeDto>> HandleAsync(GetSavingSchemes query, CancellationToken cancellationToken = default)
        {
            var repo = await _dbContext.SavingsSchemes
                .Where(x => x.CountryCode == query.CountryCode)
                .AsNoTracking()

                .Select(x => new SavingSchemeDto
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
                }).ToListAsync(cancellationToken);

            return repo;
        }
    }
}
