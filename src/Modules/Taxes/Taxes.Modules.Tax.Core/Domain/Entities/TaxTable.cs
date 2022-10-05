using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class TaxTable
    {
        public Guid Id { get; set; }
        public Guid TaxMasterId { get; set; }  
        public TaxMaster TaxMaster { get; set; }  
        public ICollection<TaxBandTable> TaxBandTable { get; set; }  
        public string CountryCode { get; set; }
        public Country Country { get; set; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
    }
}
