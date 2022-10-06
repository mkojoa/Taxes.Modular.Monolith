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
        public long? CalculationRule { get; set; }
        public decimal Rate { get; set; }
        public decimal Ceiling { get; set; }
        public bool Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public Guid? UserID { get; set; }
        public int NonCashTypeId { get; set; }
        public NonCashType NonCashType { get; set; } 

    }
}
