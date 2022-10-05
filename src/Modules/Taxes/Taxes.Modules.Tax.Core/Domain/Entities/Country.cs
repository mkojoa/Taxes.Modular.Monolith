using Taxes.Shared.Abstractions.Kernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class Country
    {
        public Guid Id { get; set; }
        public Code Code { get; set; }
        public Name Name { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
