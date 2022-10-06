
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Commands;

namespace Taxes.Modules.Tax.Core.Commands;

internal record CreateNonCash
    (
         string CountryCode,
         string Code ,
         string Name ,
         string Notes ,
         int CalculationRuleId,
         decimal Rate,
         decimal Ceiling,
         bool Status,
         DateTime StartDate,
         Guid UserId,
         int NonCashTypeId
    )
    : ICommand;
