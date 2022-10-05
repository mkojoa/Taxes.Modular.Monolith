using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class TaxMaster 
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool AmtBased { get; set; }
        public bool PerBasedOnTable { get; set; }
        public bool Graduated { get; set; }
        public DateTime Startdate { get; set; }
        public string EndDate { get; set; }
        public bool Default { get; set; }
        public Guid UserId { get; set; }
        public bool Status { get; set; }
        public Guid TaxTableId { get; set; }
        public ICollection<TaxTable> TaxTable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
