using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class SavingsScheme
    {
        public Guid Id { get; set; } 
        public string Code { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }
        public int CalcRule { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UserId { get; set; }
        public Guid SavingsSchemeTypeId { get; set; } 
        public SavingsSchemeType SavingsSchemeType { get; set; }
        public DateTime EndDate { get; set; } 
        public DateTime StartDate { get; set; }
    }
}
