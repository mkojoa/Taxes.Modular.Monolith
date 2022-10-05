using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Repositories;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.DAL.Repositories
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly TaxesDbContext _context;
        private readonly DbSet<Country> _countries;
         
        public CountryRepository(TaxesDbContext context)
        {
            _context = context;
            _countries = _context.Countries;
        }

        public async Task AddAsync(Country country)
        {
            await _countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Country country)
        {
            _countries.Update(country);
            await _context.SaveChangesAsync();
        }

        public Task<Country> GetAsync(string code)
            => _countries.SingleOrDefaultAsync(x => x.Code == code);
    }
}
