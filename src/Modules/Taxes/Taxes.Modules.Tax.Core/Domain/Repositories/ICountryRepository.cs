using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.Domain.Repositories
{
    internal interface ICountryRepository
    {
        Task<Country> GetAsync(Guid id);
        Task<Country> GetAsync(string code);
        Task AddAsync(Country country);
        Task UpdateAsync(Country country);
    }
}
