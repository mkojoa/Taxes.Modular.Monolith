using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions;

public class UnsupportedCurrencyException : TaxesException
{
    public string Currency { get; }

    public UnsupportedCurrencyException(string currency) : base($"Usupported: '{currency}' is invalid.")
    {
        Currency = currency;
    }
}