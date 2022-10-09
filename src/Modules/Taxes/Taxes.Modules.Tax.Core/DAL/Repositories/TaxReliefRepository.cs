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
    internal class TaxReliefRepository : ITaxReliefRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<TaxRelief> _taxReliefs;
         
        public TaxReliefRepository(TaxesDbContext context)
        {
            _context = context;
            _taxReliefs = _context.TaxReliefs;
        }

        public async Task AddAsync(TaxRelief taxRelief)
        {
            await _taxReliefs.AddAsync(taxRelief);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaxRelief taxRelief)
        {
            _taxReliefs.Update(taxRelief);
            await _context.SaveChangesAsync();
        }

        public Task<TaxRelief> GetAsync(string code)
            => _taxReliefs.SingleOrDefaultAsync(x => x.Code == code);
        
    }
}
