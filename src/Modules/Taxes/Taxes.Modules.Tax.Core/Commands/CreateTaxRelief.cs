using System;
using Taxes.Shared.Abstractions.Commands;

namespace Taxes.Modules.Tax.Core.Commands;

internal record CreateTaxRelief
    (
        string Code,
        string CountryCode,
        string Name,
        int TaxReliefTypeId, 
        decimal Amount,
        int CalculationRuleId,
        string Notes,
        bool Status,
        DateTime CreatedAt,
        Guid UserId
    ) : ICommand;