using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class SavingSchemeAlreadyExistException : TaxesException
{
    public string Code { get; }

    public SavingSchemeAlreadyExistException(string code) 
    : base($"Saving Scheme with code: '{code}' was not found.")
    {
        Code = code;
    }

}