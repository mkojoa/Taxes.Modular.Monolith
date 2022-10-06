using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class NonCash
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int CalculationRuleId { get; set; }
        public CalculationRule CalculationRule { get; set; }
        public decimal Rate { get; set; }
        public decimal Ceiling { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public int NonCashTypeId { get; set; }
        public NonCashType NonCashType { get; set; } 


        public NonCash()
        {}

        public NonCash(
            string countryCode , Country country ,  string code ,
            string name , string notes , CalculationRule calculationRule ,
            decimal rate , decimal ceiling , bool status , DateTime startDate ,
            DateTime createdAt , Guid userId , NonCashType nonCashType
        )
        {
             CountryCode = countryCode;
             Country = country; 
             Code = code;
             Name = name;
             Notes = notes;
             CalculationRule = calculationRule;
             Rate = rate;
             Ceiling = ceiling;
             Status = status;
             StartDate = startDate;
             CreatedAt  = createdAt;
             UserId = userId;
             NonCashType = nonCashType;
        }

        internal static NonCash CreateNonCash (
            string countryCode ,Country country , string code ,
            string name ,string notes ,CalculationRule calculationRule ,decimal rate ,
            decimal ceiling ,bool status ,DateTime startDate ,DateTime createdAt , 
            Guid userId ,NonCashType nonCashType
            ) 
        => new(
                countryCode , country , code ,name ,
                notes ,calculationRule ,rate ,ceiling ,
                status ,startDate ,createdAt , userId ,nonCashType
            );
    }
}
