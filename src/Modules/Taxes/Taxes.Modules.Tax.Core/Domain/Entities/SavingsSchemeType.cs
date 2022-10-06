using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class SavingsSchemeType
    {
        [Key]
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public Guid UserId { get; set; }
        public decimal SchemeCap { get; set; }
        public int StatutoryFund { get; set; }
    }
}
