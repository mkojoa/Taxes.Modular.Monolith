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
    internal class TaxReliefTypeRepository : ITaxReliefTypeRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<TaxReliefType> _taxReliefTypes;
         
        public TaxReliefTypeRepository(TaxesDbContext context)
        {
            _context = context;
            _taxReliefTypes = _context.TaxReliefType;
        }

        public async Task AddAsync(TaxReliefType taxReliefType)
        {
            await _taxReliefTypes.AddAsync(taxReliefType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaxReliefType taxReliefType)
        {
            _taxReliefTypes.Update(taxReliefType);
            await _context.SaveChangesAsync();
        }

        public Task<TaxReliefType> GetAsync(int id)
            => _taxReliefTypes.SingleOrDefaultAsync(x => x.Id == id);
    }
}
