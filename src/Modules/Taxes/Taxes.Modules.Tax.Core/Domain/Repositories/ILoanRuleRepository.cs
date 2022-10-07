using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Repositories
{
    internal interface ILoanRuleRepository
    {
        Task<LoanRule> GetAsync(string code);
        Task AddAsync(LoanRule loanRule);
        Task UpdateAsync(LoanRule loanRule);
    }
}
