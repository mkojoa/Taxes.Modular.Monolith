

using Taxes.Modules.Tax.Core.DTO;
using Taxes.Shared.Abstractions.Queries;

namespace Taxes.Modules.Tax.Core.Queries
{
    internal class BrowseLoan : PagedQuery<LoanDto>
    {
        public string Filter { get; set; }
    }
}
