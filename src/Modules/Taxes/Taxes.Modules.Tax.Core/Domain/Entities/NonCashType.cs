using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class NonCashType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
