using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Modules.Tax.Core.Domain.Repositories;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.DAL.Repositories
{
    internal class LoanRuleRepository : ILoanRuleRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<LoanRule> _loanRules;
         
        public LoanRuleRepository(TaxesDbContext context)
        {
            _context = context;
            _loanRules = _context.LoanRules;
        }

        public async Task AddAsync(LoanRule loanRule)
        {
            await _loanRules.AddAsync(loanRule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanRule loanRule)
        {
            _loanRules.Update(loanRule);
            await _context.SaveChangesAsync();
        }

        public Task<LoanRule> GetAsync(string code)
            => _loanRules.SingleOrDefaultAsync(x => x.Code == code);
        
    }
}
