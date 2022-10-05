using Taxes.Shared.Abstractions.Exceptions;


namespace Taxes.Shared.Abstractions.Kernel.Exceptions
{
    internal class InvalidCompanyReferenceException : TaxesException
    {
        public string Reference { get; }

        public InvalidCompanyReferenceException(string reference) : base($"Company Reference: '{reference}' is invalid.")
        {
            Reference = reference;
        }
    }
}