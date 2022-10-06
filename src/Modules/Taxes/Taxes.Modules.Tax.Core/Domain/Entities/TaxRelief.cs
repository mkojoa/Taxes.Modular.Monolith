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
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public TaxReliefType TaxReliefType { get; set; } 
        public int TaxReliefTypeId { get; set; } 
        public decimal Amount { get; set; }
        public int CalcRule { get; set; }
        public string Notes { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
