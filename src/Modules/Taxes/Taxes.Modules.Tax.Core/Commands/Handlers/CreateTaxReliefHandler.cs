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
    internal class CreateTaxReliefHandler : ICommandHandler<CreateNonCash>
    {
        private readonly ITaxReliefRepository _taxReliefRepository;
        private readonly ITaxReliefTypeRepository _taxReliefTypeRepository;
        private readonly ICountryRepository  _countryRepository;
        private readonly ICalculationRepository  _calculationRuleRepository ;
        private readonly IClock _clock;
        private readonly ILogger<CreateTaxReliefHandler> _logger;

        public CreateTaxReliefHandler(
            ITaxReliefRepository taxReliefRepository ,
            ITaxReliefTypeRepository taxReliefTypeRepository,
            ICountryRepository  countryRepository,
            ICalculationRepository  calculationRuleRepository,
            IClock clock,
            ILogger<CreateTaxReliefHandler> logger
            )
        {
            _taxReliefRepository = taxReliefRepository;
            _taxReliefTypeRepository = taxReliefTypeRepository;
            _countryRepository = countryRepository;
            _calculationRuleRepository = calculationRuleRepository;
            _clock = clock;
            _logger = logger;
        }



        public async Task HandleAsync(CreateNonCash command, CancellationToken cancellationToken = default)
        {
            var taxRelief = await _taxReliefRepository.GetAsync(command.Code);
            if (taxRelief is not null)
            {
                throw new TaxReliefAlreadyExistException(command.Code);
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

            var taxReliefType = await _taxReliefTypeRepository.GetAsync(command.NonCashTypeId);
            if (taxReliefType is null)
            {
                throw new TaxReliefTypeNotFoundException(command.NonCashTypeId);
            }

            var create = TaxRelief.CreateTaxRelief(
                // command.CountryCode ,country, command.Code ,
                // command.Name ,command.Notes ,calculationRule ,command.Rate ,
                // command.Ceiling ,command.Status ,command.StartDate ,_clock.CurrentDate(), 
                // command.UserId ,nonCashType
            );

            await _taxReliefRepository.AddAsync(create);
            _logger.LogInformation(message: $"Tax Relief with ID: '{create.Id}' was created.");
        }
    }
}
