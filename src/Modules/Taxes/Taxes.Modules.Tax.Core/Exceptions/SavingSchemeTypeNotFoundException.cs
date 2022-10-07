using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class SavingSchemeTypeNotFoundException : TaxesException
{
    public Guid Id { get; }

    public SavingSchemeTypeNotFoundException(Guid id) 
    : base($"Saving Scheme with id: '{id}' was not found.")
    {
        Id = id;
    }

}