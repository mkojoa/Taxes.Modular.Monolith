using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Modules.Tax.Core.Domain.Repositories;

namespace Taxes.Modules.Tax.Core.DAL.Repositories
{
    internal class SavingSchemeRepository : ISavingSchemeRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<SavingsScheme> _savingsSchemes;
         
        public SavingSchemeRepository(TaxesDbContext context)
        {
            _context = context;
            _savingsSchemes = _context.SavingsSchemes;
        }

        public async Task AddAsync(SavingsScheme savingsScheme)
        {
            await _savingsSchemes.AddAsync(savingsScheme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SavingsScheme savingsScheme)
        {
            _savingsSchemes.Update(savingsScheme);
            await _context.SaveChangesAsync();
        }

        public Task<SavingsScheme> GetAsync(string code)
            => _savingsSchemes.SingleOrDefaultAsync(x => x.Code == code);
        
    }
}
