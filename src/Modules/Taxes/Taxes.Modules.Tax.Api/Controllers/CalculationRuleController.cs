using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Modules.Tax.Core.Queries;
using Taxes.Shared.Abstractions.Dispatchers;

namespace Taxes.Modules.Tax.Api.Controllers
{
    internal class CalculationRuleController : BaseController
    {
        private const string Policy = "calculationrule";
        private readonly IDispatcher _dispatcher;

        public CalculationRuleController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;


        }

        [HttpGet]
        [SwaggerOperation("get calculation rule")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<CalculationRuleDto>>> GetAllAsync()
            => Ok(await _dispatcher.QueryAsync(new GetCalculationRules { }));


    }
}
