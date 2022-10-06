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
    internal class NonCashTypeRepository : INonCashTypeRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<NonCashType> _nonCashTypes;
         
        public NonCashTypeRepository(TaxesDbContext context)
        {
            _context = context;
            _nonCashTypes = _context.NonCashTypes;
        }

        public async Task AddAsync(NonCashType nonCashType)
        {
            await _nonCashTypes.AddAsync(nonCashType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NonCashType nonCashType)
        {
            _nonCashTypes.Update(nonCashType);
            await _context.SaveChangesAsync();
        }

        public Task<NonCashType> GetAsync(int id)
            => _nonCashTypes.SingleOrDefaultAsync(x => x.Id == id);
    }
}
