using Taxes.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Exceptions
{
    internal class InvalidFolderStructureException : TaxesException
    {
        public InvalidFolderStructureException()
            : base($"Folder should have a parent with atleast one child")
        { } 
    }
}
