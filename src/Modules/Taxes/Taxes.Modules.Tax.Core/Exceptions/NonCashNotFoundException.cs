using System;
using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Modules.Tax.Core.Exceptions;


internal class NonCashNotFoundException : TaxesException
{
    public Guid Id { get; }

    public NonCashNotFoundException(Guid id) 
    : base($"Non Cash with id: '{id}' was not found.")
    {
        Id = id;
    }

}

internal class NonCashNotTypeFoundException : TaxesException
{
    public int Id { get; }

    public NonCashNotTypeFoundException(int id) 
    : base($"Non Cash with id: '{id}' was not found.")
    {
        Id = id;
    }

}