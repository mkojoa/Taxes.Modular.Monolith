using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions;

public class InvalidAmountException : TaxesException
{
    public decimal Amount { get; }

    public InvalidAmountException(decimal amount) : base($"Amount: '{amount}' is invalid.")
    {
        Amount = amount;
    }
}