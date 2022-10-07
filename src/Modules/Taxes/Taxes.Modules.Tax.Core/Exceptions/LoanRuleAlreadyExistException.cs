using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class LoanRuleAlreadyExistException : TaxesException
{
    public string Code { get; }

    public LoanRuleAlreadyExistException(string code) 
    : base($"Loan Rule with code: '{code}' was not found.")
    {
        Code = code;
    }

}