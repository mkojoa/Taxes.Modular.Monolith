using System;

namespace Taxes.Modules.Tax.Core.DTO
{
    public class TaxReliefDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public CountryDto Country { get; set; }
        public string Name { get; set; }
        public TaxReliefTypeDto TaxReliefType { get; set; } 
        public int TaxReliefTypeId { get; set; } 
        public decimal Amount { get; set; }
        public CalculationRuleDto CalculationRule {get; set;}
        public string Notes { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}