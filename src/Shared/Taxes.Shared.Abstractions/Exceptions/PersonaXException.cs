using System;

namespace Taxes.Shared.Abstractions.Exceptions;

public abstract class TaxesException : Exception
{
    protected TaxesException(string message) : base(message)
    {
    }
}