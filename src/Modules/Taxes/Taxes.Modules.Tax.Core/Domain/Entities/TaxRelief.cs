using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class TaxRelief
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public TaxReliefType TaxReliefType { get; set; } 
        public int TaxReliefTypeId { get; set; } 
        public decimal Amount { get; set; }
        public int CalculationRuleId { get; set; }
        public CalculationRule CalculationRule { get; set; }
        public string Notes { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }

        public TaxRelief()
        {}

        public TaxRelief(
            Guid id , string code , Country country , string name , TaxReliefType taxReliefType,
            decimal amount , CalculationRule calculationRule , string notes , bool status , 
            DateTime createdAt , Guid userId
        )
        {
                 Id = id;
                 Code = code;
                 Country = country;
                 Name = name;
                 TaxReliefType = taxReliefType;
                 Amount = amount;
                 CalculationRule = calculationRule;
                 Notes = notes;
                 Status = status;
                 CreatedAt = createdAt;
                 UserId = userId;
        }

        internal static TaxRelief CreateTaxRelief (
            Guid id , string code , Country country , string name , TaxReliefType taxReliefType,
            decimal amount , CalculationRule calculationRule , string notes , bool status , 
            DateTime createdAt , Guid userId
            ) 
        => new(
                 id ,  code ,  country ,  name ,  taxReliefType,
                 amount ,  calculationRule ,  notes ,  status , 
                 createdAt ,  userId
            );
    }
}
