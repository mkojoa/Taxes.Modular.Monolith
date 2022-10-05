using Taxes.Shared.Abstractions.Exceptions;
using System;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions
{
    internal class UnsupportedLangException : TaxesException
    {
        public string Lang { get; }

        public UnsupportedLangException(string lang) : base($"Language: '{lang}' is unsupported.")
        {
            Lang = lang;
        }
    }
}