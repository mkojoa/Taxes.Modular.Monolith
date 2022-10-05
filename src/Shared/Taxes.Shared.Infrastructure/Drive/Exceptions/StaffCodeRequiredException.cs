using Taxes.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Exceptions
{
    internal class StaffCodeRequiredException : TaxesException
    {
        public StaffCodeRequiredException()
            : base($"Staff Id is required to process file")
        { }
    }
}
