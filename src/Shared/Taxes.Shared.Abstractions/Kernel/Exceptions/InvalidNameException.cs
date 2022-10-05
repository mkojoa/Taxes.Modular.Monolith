using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidNameException : TaxesException
    {
        public string Name { get; }

        public InvalidNameException(string name) : base($" Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
