using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Modules.Tax.Core.Domain.Repositories;

namespace Taxes.Modules.Tax.Core.DAL.Repositories
{
    internal class SavingSchemeTypeRepository : ISavingSchemeTypeRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<SavingsSchemeType>  _savingsSchemeTypes;
         
        public SavingSchemeTypeRepository(TaxesDbContext context)
        {
            _context = context;
            _savingsSchemeTypes = _context.SavingsSchemeTypes;
        }

        public async Task AddAsync(SavingsSchemeType savingsSchemeType)
        {
            await _savingsSchemeTypes.AddAsync(savingsSchemeType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SavingsSchemeType savingsSchemeType)
        {
            _savingsSchemeTypes.Update(savingsSchemeType);
            await _context.SaveChangesAsync();
        }

        public Task<SavingsSchemeType> GetAsync(Guid id)
            => _savingsSchemeTypes.SingleOrDefaultAsync(x => x.Id == id);
    }
}
