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
    internal class CreateNonCashHandler : ICommandHandler<CreateNonCash>
    {
        private readonly INonCashRepository _nonCashRepository;
        private readonly INonCashTypeRepository _nonCashTypeRepository;
        private readonly ICountryRepository  _countryRepository;
        private readonly ICalculationRepository  _calculationRuleRepository ;
        private readonly IClock _clock;
        private readonly ILogger<CreateNonCashHandler> _logger;

        public CreateNonCashHandler(
            INonCashRepository nonCashRepository ,
            INonCashTypeRepository nonCashTypeRepository,
            ICountryRepository  countryRepository,
            ICalculationRepository  calculationRuleRepository,
            IClock clock,
            ILogger<CreateNonCashHandler> logger
            )
        {
            _nonCashRepository = nonCashRepository;
            _nonCashTypeRepository = nonCashTypeRepository;
            _countryRepository = countryRepository;
            _calculationRuleRepository = calculationRuleRepository;
            _clock = clock;
            _logger = logger;
        }



        public async Task HandleAsync(CreateNonCash command, CancellationToken cancellationToken = default)
        {
            var nonCash = await _nonCashRepository.GetAsync(command.Code);
            if (nonCash is not null)
            {
                throw new NonCashAlreadyExistException(command.Code);
            }

            var country = await _countryRepository.GetAsync(command.CountryCode);
            if (country is null)
            {
                throw new CountryNotFoundException(command.CountryCode);
            }


             var calculationRule = await _calculationRuleRepository.GetAsync(command.CalculationRuleId);
            if (calculationRule is null)
            {
                throw new CalculationRuleNotFoundException(command.CalculationRuleId);
            }

            var nonCashType = await _nonCashTypeRepository.GetAsync(command.NonCashTypeId);
            if (nonCashType is null)
            {
                throw new NonCashNotTypeFoundException(command.NonCashTypeId);
            }

            var create = NonCash.CreateNonCash(
                command.CountryCode ,country, command.Code ,
                command.Name ,command.Notes ,calculationRule ,command.Rate ,
                command.Ceiling ,command.Status ,command.StartDate ,_clock.CurrentDate(), 
                command.UserId ,nonCashType
            );

            await _nonCashRepository.AddAsync(create);
            _logger.LogInformation(message: $"NonCash with ID: '{create.Id}' was created.");
        }
    }
}
