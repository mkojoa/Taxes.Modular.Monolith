using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Shared.Abstractions.Queries;

namespace Taxes.Modules.Tax.Core.Queries
{
    internal class BrowseNonCash : PagedQuery<NonCashDto>
    {
        public string Filter { get; set; }
    }
}
