using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions
{
    internal class InvalidCodeException : TaxesException
    {
        public string Code { get; }

        public InvalidCodeException(string code) : base($"Code: '{code}' is invalid.")
        {
            Code = code;
        }
    }
}
