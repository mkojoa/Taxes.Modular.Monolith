using Taxes.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Abstractions.Kernel.Exceptions
{
    internal class InvalidLangException : TaxesException
    {
        public string Lang { get; }

        public InvalidLangException(string lang) : base($"Language: '{lang}' is invalid.")
        {
            Lang = lang;
        }
    }
}
