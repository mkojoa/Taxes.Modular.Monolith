using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions;

public class InvalidCountryException : TaxesException
{
    public string Country { get; }

    public InvalidCountryException(string country) : base($"Country: '{country}' is invalid.")
    {
        Country = country;
    }
}