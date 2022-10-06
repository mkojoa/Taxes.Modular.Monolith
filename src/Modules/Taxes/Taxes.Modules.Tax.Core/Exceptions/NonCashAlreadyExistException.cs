using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class NonCashAlreadyExistException : TaxesException
{
    public string Code { get; }

    public NonCashAlreadyExistException(string code) 
    : base($"NonCash with code: '{code}' was not found.")
    {
        Code = code;
    }

}