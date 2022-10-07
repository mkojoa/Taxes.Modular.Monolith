
using System;
using Taxes.Shared.Abstractions.Commands;

namespace Taxes.Modules.Tax.Core.Commands;

internal record CreateSavingScheme
    (
        Guid Id,
        string Code,
        string CountryCode,
        string Name,
        int CalculationRuleId ,
        int PercentageBasis,
        decimal UpperLimit,
        decimal LowerLimit,
        decimal Employee,
        decimal Employer,
        int TaxRebateEmpContrib,
        int TaxDeductible,
        int TaxEmployerContrib,
        bool  TransSegment,
        bool  EmployeeGLAcc,
        bool  EmployerGLAcc,
        bool  EmployerPayable,
        bool Status,
        Guid SavingsSchemeTypeId,
        Guid UserId
    ) : ICommand;
