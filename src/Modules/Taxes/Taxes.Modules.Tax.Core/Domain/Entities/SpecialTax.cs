using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class SpecialTax
    {
        public Guid Id { get; set; }
        public Guid TaxTable { get; set; }
        public int QualificationBasis { get; set; } 
        public decimal QualificationAmount { get; set; }
        public SpecialTaxType SpecialTaxType { get; set; }
        public int SpecialTaxTypeId { get; set; }
        public bool Status { get; set; } 
        public Country Country { get; set; } 
        public string CountryCode { get; set; }
        public bool TaxResidual { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
