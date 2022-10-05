using Taxes.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Exceptions
{
    internal class UnsupportedExtensionException : TaxesException
    {         
        public UnsupportedExtensionException() 
            : base($"Base64 string extension is unsupported.")
        {}
    }
}
