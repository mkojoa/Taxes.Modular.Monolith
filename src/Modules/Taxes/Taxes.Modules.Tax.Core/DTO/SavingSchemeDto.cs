using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Modules.Tax.Core.DTO
{
    internal class SavingSchemeDto
    {
        public Guid Id { get; set; } 
        public string Code { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public CalculationRuleDto CalculationRule { get; set; }
        public int PercentageBasis { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal Employee { get; set; }
        public decimal Employer { get; set; }
        public int TaxRebateEmpContrib { get; set; }
        public int TaxDeductible { get; set; }
        public int TaxEmployerContrib { get; set; }
        public bool  TransSegment { get; set; }
        public bool  EmployeeGLAcc { get; set; }
        public bool  EmployerGLAcc { get; set; }
        public bool  EmployerPayable { get; set; }
        public bool Status { get; set; }
        public SavingSchemeTypeDto SavingsSchemeType { get; set; }
    }
}
