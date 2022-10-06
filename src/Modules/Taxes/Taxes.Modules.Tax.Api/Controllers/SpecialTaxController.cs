using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taxes.Modules.Tax.Core.DTO;
using Taxes.Modules.Tax.Core.Queries;
using Taxes.Shared.Abstractions.Dispatchers;

namespace Taxes.Modules.Tax.Api.Controllers
{
    internal class SpecialTaxController : BaseController
    {
        private const string Policy = "specialtax";
        private readonly IDispatcher _dispatcher;

        public SpecialTaxController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;


        }

        [HttpGet("Type/{countryCode}")]
        [SwaggerOperation("Get special tax type by country code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<SpecialTaxTypeDto>>> GetAsync(string countryCode)
            => OkOrNotFound(await _dispatcher.QueryAsync(new GetSpecialTaxType { CountryCode = countryCode }));

        [HttpGet("Type")]
        [SwaggerOperation("get special tax type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<SpecialTaxTypeDto>>> GetAllAsync()
            => Ok(await _dispatcher.QueryAsync(new GetSpecialTaxTypes { }));


    }
}
