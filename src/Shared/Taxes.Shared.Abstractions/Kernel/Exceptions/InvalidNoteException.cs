using Taxes.Shared.Abstractions.Exceptions;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions
{
    internal class InvalidNoteException : TaxesException
    {
        public string Note { get; }

        public InvalidNoteException(string note) : base($"Note: '{note}' is invalid.")
        {
            Note = note;
        }
    }
}
