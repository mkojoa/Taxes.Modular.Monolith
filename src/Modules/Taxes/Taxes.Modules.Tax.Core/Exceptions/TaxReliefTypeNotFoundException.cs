using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class TaxReliefTypeNotFoundException : TaxesException
{
    public int Id { get; }

    public TaxReliefTypeNotFoundException(int id) 
    : base($"Tax Relief Type with id: '{id}' was not found.")
    {
        Id = id;
    }

}