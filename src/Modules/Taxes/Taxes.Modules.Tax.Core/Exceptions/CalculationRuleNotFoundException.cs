using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class CalculationRuleNotFoundException : TaxesException
{
    public int Id { get; }

    public CalculationRuleNotFoundException(int id) 
    : base($"Calculation Rule with id: '{id}' was not found.")
    {
        Id = id;
    }

}