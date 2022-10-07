
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Shared.Abstractions.Commands;

namespace Taxes.Modules.Tax.Core.Commands;

internal record CreateLoanRule
    (
            string CountryCode , string Code , string Name , decimal StatutoryRate ,
            decimal GearingRatio , DateTime StartDate , bool Status , 
            Guid UserId
    )
: ICommand;
