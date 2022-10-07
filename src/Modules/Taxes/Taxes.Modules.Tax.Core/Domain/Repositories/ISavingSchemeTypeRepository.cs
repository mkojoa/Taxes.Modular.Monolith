using System;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.Domain.Repositories
{
    internal interface ISavingSchemeTypeRepository
    {
        Task<SavingsSchemeType> GetAsync(Guid id);
        Task AddAsync(SavingsSchemeType savingSchemeType);
        Task UpdateAsync(SavingsSchemeType savingSchemeType);
    }
}
