using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Commands;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Modules.Tax.Core.Domain.Repositories;
using Taxes.Modules.Tax.Core.Exceptions;
using Taxes.Shared.Abstractions.Commands;
using Taxes.Shared.Abstractions.Time;

namespace Taxes.Modules.Tax.Core.Commands.Handlers
{
    internal class CreateLoanRuleHandler : ICommandHandler<CreateLoanRule>
    {
        private readonly ILoanRuleRepository _loanRuleRepository;
        private readonly ICountryRepository  _countryRepository;
        private readonly IClock _clock;
        private readonly ILogger<CreateLoanRuleHandler> _logger;

        public CreateLoanRuleHandler(
            ILoanRuleRepository loanRuleRepository ,
            ICountryRepository  countryRepository,
            IClock clock,
            ILogger<CreateLoanRuleHandler> logger
            )
        {
            _loanRuleRepository = loanRuleRepository;
            _countryRepository = countryRepository;
            _clock = clock;
            _logger = logger;
        }



        public async Task HandleAsync(CreateLoanRule command, CancellationToken cancellationToken = default)
        {
            var nonCash = await _loanRuleRepository.GetAsync(command.Code);
            if (nonCash is not null)
            {
                throw new LoanRuleAlreadyExistException(command.Code);
            }

            var country = await _countryRepository.GetAsync(command.CountryCode);
            if (country is null)
            {
                throw new CountryNotFoundException(command.CountryCode);
            }

            var create = LoanRule.CreateLoanRule(
                Guid.NewGuid() , country , command.Code , command.Name , command.StatutoryRate ,
                command.GearingRatio , command.StartDate , command.Status , _clock.CurrentDate(),
                command.UserId
            );

            await _loanRuleRepository.AddAsync(create);
            _logger.LogInformation(message: $"Loan Rule with ID: '{create.Id}' was created.");
        }
    }
}
