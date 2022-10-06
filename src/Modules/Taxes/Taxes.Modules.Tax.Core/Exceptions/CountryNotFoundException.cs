using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class CountryNotFoundException : TaxesException
{
    public string Code { get; }

    public CountryNotFoundException(string code) 
    : base($"Country with code: '{code}' was not found.")
    {
        Code = code;
    }

}