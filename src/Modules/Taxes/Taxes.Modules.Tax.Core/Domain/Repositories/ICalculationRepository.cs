using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Repositories
{
    internal interface ICalculationRepository
    {
        Task<CalculationRule> GetAsync(string code);
        Task<CalculationRule> GetAsync(int id); 
        Task AddAsync(CalculationRule calculationRule);
        Task UpdateAsync(CalculationRule calculationRule);
    }
}
