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
        public string Name { get; set; }
        public int CalculationRuleId { get; set; }
        public CalculationRule CalculationRule { get; set; }
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


        public SavingsScheme()
        {}

        public SavingsScheme(
            Guid id, string code, Country country , string name , CalculationRule calculationRule ,
            int percentageBasis , decimal upperLimit , decimal lowerLimit ,
            decimal employee , decimal employer , int taxRebateEmpContrib , int taxDeductible ,
            int taxEmployerContrib , bool  transSegment , bool  employeeGLAcc , bool  employerGLAcc ,
            bool  employerPayable , bool status , DateTime createdAt, SavingsSchemeType savingsSchemeType, Guid userId
        )
        {
            Id   = id;
            Code   = code;
            Country   = country;
            Name   = name;
            CalculationRule   = calculationRule;
            PercentageBasis   = percentageBasis;
            UpperLimit   = upperLimit;
            LowerLimit   = lowerLimit;
            Employee   = employee;
            Employer   = employer;
            TaxRebateEmpContrib   = taxRebateEmpContrib;
            TaxDeductible   = taxDeductible;
            TaxEmployerContrib   = taxEmployerContrib;
            TransSegment   = transSegment;
            EmployeeGLAcc   = employeeGLAcc;
            EmployerGLAcc   = employerGLAcc;
            EmployerPayable   = employerPayable;
            Status   = status;
            CreatedAt   = createdAt;
            UserId   = userId;
            SavingsSchemeType   = savingsSchemeType;
        }

        internal static SavingsScheme CreateSavingsScheme (
                Guid id, string code, Country country , string name , CalculationRule calculationRule ,
                int percentageBasis , decimal upperLimit , decimal lowerLimit ,
                decimal employee , decimal employer , int taxRebateEmpContrib , int taxDeductible ,
                int taxEmployerContrib , bool  transSegment , bool  employeeGLAcc , bool  employerGLAcc ,
                bool  employerPayable , bool status , DateTime createdAt, SavingsSchemeType SavingsSchemeType, Guid userId
            ) 
        => new(
                id,  code,  country ,  name ,  calculationRule ,
                percentageBasis ,  upperLimit ,  lowerLimit ,
                employee ,  employer ,  taxRebateEmpContrib ,  taxDeductible ,
                taxEmployerContrib ,  transSegment ,   employeeGLAcc ,  employerGLAcc ,
                employerPayable , status , createdAt, SavingsSchemeType, userId
            );
    }
}
