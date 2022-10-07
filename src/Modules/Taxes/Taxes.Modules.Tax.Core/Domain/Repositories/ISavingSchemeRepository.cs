using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;

namespace Taxes.Modules.Tax.Core.Domain.Repositories
{
    internal interface ISavingSchemeRepository
    {
        Task<SavingsScheme> GetAsync(string code);
        Task AddAsync(SavingsScheme savingScheme);
        Task UpdateAsync(SavingsScheme savingScheme);
    }
}
