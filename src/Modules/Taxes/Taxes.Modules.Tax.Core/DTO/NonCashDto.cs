using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Modules.Tax.Core.DTO
{
    internal class NonCashDto
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public CalculationRuleDto CalculationRule { get; set; }
        public decimal Rate { get; set; }
        public decimal Ceiling { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public NonCashTypeDto NonCashType { get; set; } 
    }
}
