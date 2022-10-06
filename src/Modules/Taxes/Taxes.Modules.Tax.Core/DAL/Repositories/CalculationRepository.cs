using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Modules.Tax.Core.Domain.Repositories;

namespace Taxes.Modules.Tax.Core.DAL.Repositories
{
    internal class CalculationRepository : ICalculationRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<CalculationRule> _calculationRules;
         
        public CalculationRepository(TaxesDbContext context)
        {
            _context = context;
            _calculationRules = _context.CalculationRules;
        }

        public async Task AddAsync(CalculationRule calculationRule)
        {
            await _calculationRules.AddAsync(calculationRule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CalculationRule calculationRule)
        {
            _calculationRules.Update(calculationRule);
            await _context.SaveChangesAsync();
        }

        public Task<CalculationRule> GetAsync(string code)
            => _calculationRules.SingleOrDefaultAsync(x => x.Code == code);

        public Task<CalculationRule> GetAsync(int id)
            => _calculationRules.SingleOrDefaultAsync(x => x.Id == id);
    }
}
