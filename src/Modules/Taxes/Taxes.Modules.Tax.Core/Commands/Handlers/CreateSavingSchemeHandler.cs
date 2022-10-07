using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.Domain.Entities;
using Taxes.Modules.Tax.Core.Domain.Repositories;
using Taxes.Modules.Tax.Core.Exceptions;
using Taxes.Shared.Abstractions.Commands;
using Taxes.Shared.Abstractions.Time;

namespace Taxes.Modules.Tax.Core.Commands.Handlers
{
    internal class CreateSavingSchemeHandler : ICommandHandler<CreateSavingScheme>
    {
        private readonly ISavingSchemeRepository _savingSchemeRepository;
        private readonly ISavingSchemeTypeRepository _savingSchemeTypeRepository;
        private readonly ICountryRepository  _countryRepository;
        private readonly ICalculationRepository  _calculationRuleRepository ;
        private readonly IClock _clock;
        private readonly ILogger<CreateNonCashHandler> _logger;

        public CreateSavingSchemeHandler(
            ISavingSchemeRepository savingSchemeRepository ,
            ISavingSchemeTypeRepository savingSchemeTypeRepository,
            ICountryRepository  countryRepository,
            ICalculationRepository  calculationRuleRepository,
            IClock clock,
            ILogger<CreateNonCashHandler> logger
            )
        {
            _savingSchemeRepository = savingSchemeRepository;
            _savingSchemeTypeRepository = savingSchemeTypeRepository;
            _countryRepository = countryRepository;
            _calculationRuleRepository = calculationRuleRepository;
            _clock = clock;
            _logger = logger;
        }


        public async Task HandleAsync(CreateSavingScheme command, CancellationToken cancellationToken = default)
        {
            var savingsScheme = await _savingSchemeRepository.GetAsync(command.Code);
            if (savingsScheme is not null)
            {
                throw new SavingSchemeAlreadyExistException(command.Code);
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

            var savingsSchemeType = await _savingSchemeTypeRepository.GetAsync(command.SavingsSchemeTypeId);
            if (savingsSchemeType is null)
            {
                throw new SavingSchemeTypeNotFoundException(command.SavingsSchemeTypeId);
            }

            var create = SavingsScheme.CreateSavingsScheme(
                command.Id, command.Code,  country ,  command.Name ,  calculationRule ,
                command.PercentageBasis ,  command.UpperLimit ,  command.LowerLimit ,
                command.Employee ,  command.Employer ,  command.TaxRebateEmpContrib ,  command.TaxDeductible ,
                command.TaxEmployerContrib ,  command.TransSegment ,  command.EmployeeGLAcc , command.EmployerGLAcc ,
                command.EmployerPayable , command.Status , _clock.CurrentDate(), savingsSchemeType, command.UserId
            );

            await _savingSchemeRepository.AddAsync(create);
            _logger.LogInformation(message: $"Saving Scheme with ID: '{create.Id}' was created.");
        }
    }
}
