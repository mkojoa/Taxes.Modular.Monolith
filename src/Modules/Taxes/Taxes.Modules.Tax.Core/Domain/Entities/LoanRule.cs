using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class LoanRule
    { 
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; } 
        public string Name { get; set; }
        public decimal StatutoryRate { get; set; }
        public decimal GearingRatio { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; } 
        public bool Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UserId { get; set; } 
    }
}
