using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions;

public class UnsupportedCountryException : TaxesException
{
    public string Country { get; }

    public UnsupportedCountryException(string country) : base($"Country: '{country}' is unsupported.")
    {
        Country = country;
    }
}