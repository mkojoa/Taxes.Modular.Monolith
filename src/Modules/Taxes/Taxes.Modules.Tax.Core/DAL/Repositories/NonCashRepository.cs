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
    internal class NonCashRepository : INonCashRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<NonCash> _nonCashs;
         
        public NonCashRepository(TaxesDbContext context)
        {
            _context = context;
            _nonCashs = _context.NonCash;
        }

        public async Task AddAsync(NonCash nonCash)
        {
            await _nonCashs.AddAsync(nonCash);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NonCash nonCash)
        {
            _nonCashs.Update(nonCash);
            await _context.SaveChangesAsync();
        }

        public Task<NonCash> GetAsync(string code)
            => _nonCashs.SingleOrDefaultAsync(x => x.Code == code);
        
    }
}
