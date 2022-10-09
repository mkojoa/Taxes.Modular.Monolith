using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Repositories
{
    internal interface ITaxReliefTypeRepository
    {
        Task<TaxReliefType> GetAsync(int id);
        Task AddAsync(TaxReliefType taxReliefType);
        Task UpdateAsync(TaxReliefType taxReliefType);
    }
}
