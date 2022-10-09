using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class TaxReliefAlreadyExistException : TaxesException
{
    public string Code { get; }

    public TaxReliefAlreadyExistException(string code) 
    : base($"Tax relief with code: '{code}' was not found.")
    {
        Code = code;
    }

}