using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Modules.Tax.Core.DTO
{
    internal class LoanDto
    {
        public Guid Id { get; set; }
        public CountryDto Country { get; set; } 
        public string Name { get; set; }
        public decimal StatutoryRate { get; set; }
        public decimal GearingRatio { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; } 
    }
}
