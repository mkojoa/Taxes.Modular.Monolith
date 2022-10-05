using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class TaxBandTable
    {
        public Guid Id { get; set; }
        public Guid TaxTableId { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; } 
        public decimal TaxBand { get; set; }
        public decimal TaxableAmt { get; set; }
        public decimal Percentage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public Guid UserId { get; set; }
        public TaxTable TaxTable { get; set; }
    }
}
